using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Newtonsoft.Json.Linq;

namespace eWayCRM.API
{
    /// <summary>
    /// eWay-CRM API Connector class.
    /// This class helps to manage the connection to the eWay-CRM API.
    /// </summary>
    public class Connection
    {
        private readonly string serviceUri;
        private readonly string username;
        private readonly string passwordHash;
        private readonly string appIdentifier;

        private Guid? sessionId;

        public Connection(string apiServiceUri, string username, string passwordHash, string appIdentifier = "eWayCRM.API.CSharpConnector10")
        {
            if (string.IsNullOrEmpty(apiServiceUri))
                throw new ArgumentNullException("eWay-CRM API service uri was not supplied.", nameof(apiServiceUri));

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("eWay-CRM username was not supplied.", nameof(username));

            if (string.IsNullOrEmpty(passwordHash))
                throw new ArgumentNullException("eWay-CRM password hash was not supplied.", nameof(passwordHash));

            if (string.IsNullOrEmpty(appIdentifier))
                throw new ArgumentNullException("The client app identifier was not supplied.", nameof(appIdentifier));

            if (apiServiceUri.EndsWith(".asmx", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("The *.asmx file is not the right service endpoint. This connection is meant to be used against the eWay-CRM WCF API.", nameof(apiServiceUri));

            if (!apiServiceUri.EndsWith(".svc", StringComparison.OrdinalIgnoreCase))
            {
                apiServiceUri = (new Uri(new Uri(apiServiceUri), "WcfService/Service.svc")).ToString();
            }

            this.serviceUri = apiServiceUri;
            this.username = username;
            this.passwordHash = passwordHash;
            this.appIdentifier = appIdentifier;
        }

        public JObject CallMethod(string methodName, JObject data)
        {
            return this.CallMethod(methodName, data, true);
        }

        private JObject CallMethod(string methodName, JObject data, bool repeatSession)
        {
            JObject d = new JObject(data);
            this.EnsureLogin();
            d.Add("sessionId", this.sessionId);
            JObject response = this.Call(methodName, d);
            if (response.GetValue("ReturnCode").ToString() == "rcBadSession" && repeatSession)
            {
                this.LogIn();
                return this.CallMethod(methodName, data, false);
            }
            if (response.GetValue("ReturnCode").ToString() != "rcSuccess")
                throw new InvalidOperationException($"Unable to call wcf method '{methodName}'. Return code is '{response.GetValue("ReturnCode").ToString()}' with message: {response.GetValue("Description").ToString()}");
            return response;
        }

        private void EnsureLogin()
        {
            if (this.sessionId == null)
            {
                this.LogIn();
            }
        }

        private void LogIn()
        {
            JObject response = this.Call("LogIn", JObject.FromObject(new
            {
                userName = this.username,
                passwordHash = this.passwordHash,
                appVersion = this.appIdentifier
            }));
            if (response.GetValue("ReturnCode").ToString() != "rcSuccess")
                throw new InvalidOperationException($"Unable to connect to the wcf {this.serviceUri}. Login returned '{response.GetValue("ReturnCode").ToString()}' with message: {response.GetValue("Description").ToString()}");
            this.sessionId = new Guid(response.Value<string>("SessionId"));
        }

        private JObject Call(string methodName, JObject data)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException(nameof(methodName));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(this.GetMethodUri(methodName));
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.ContentType = "application/json";
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(data.ToString());
                webRequest.ContentLength = postBytes.Length;
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(postBytes, 0, postBytes.Length);
                }
            }

            string responseJson = null;
            using (HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            responseJson = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(responseJson))
            {
                throw new InvalidOperationException("Wcf returned nothing. That's strange.");
            }
            JObject result = JObject.Parse(responseJson);

            return result;
        }

        private string GetMethodUri(string methodName)
        {
            return this.serviceUri + "/" + methodName;
        }
    }
}
