using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using eWayCRM.API.Exceptions;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection" /> class.
        /// </summary>
        /// <param name="apiServiceUri">The API service URI.</param>
        /// <param name="username">The eWay-CRM username. Ex. 'jsmith'.</param>
        /// <param name="passwordHash">Password hash. Use the hash made with "SecurityApp" or HashPassword.exe. MD5 hashes are accepted as well (unless AD HTTP Authentication between WS and WCF is activated).</param>
        /// <param name="appIdentifier">The application identifier. Must contain at least on alphabetic character on the beginning and at least one numeric character at the end.</param>
        /// <exception cref="ArgumentNullException">eWay-CRM API service uri was not supplied. - apiServiceUri
        /// or
        /// eWay-CRM username was not supplied. - username
        /// or
        /// eWay-CRM password hash was not supplied. - passwordHash
        /// or
        /// The client app identifier was not supplied. - appIdentifier</exception>
        /// <exception cref="ArgumentException">The *.asmx file is not the right service endpoint. This connection is meant to be used against the eWay-CRM WCF API. - apiServiceUri</exception>
        public Connection(string apiServiceUri, string username, string passwordHash, string appIdentifier = "eWayCRM.API.CSharpConnector10")
        {
            if (string.IsNullOrEmpty(apiServiceUri))
                throw new ArgumentNullException(nameof(apiServiceUri), "eWay-CRM API service uri was not supplied.");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), "eWay-CRM username was not supplied.");

            if (string.IsNullOrEmpty(passwordHash))
                throw new ArgumentNullException(nameof(passwordHash), "eWay-CRM password hash was not supplied.");

            if (string.IsNullOrEmpty(appIdentifier))
                throw new ArgumentNullException(nameof(appIdentifier), "The client app identifier was not supplied.");

            if (apiServiceUri.EndsWith(".asmx", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("The *.asmx file is not the right service endpoint. This connection is meant to be used against the eWay-CRM WCF API.", nameof(apiServiceUri));

            if (!Regex.IsMatch(appIdentifier, "^\\w.*\\d$"))
                throw new ArgumentException("The client app identifier must contain at least one alphabetic character on the beginning and at least one numeric character at the end.", nameof(appIdentifier));

            if (!apiServiceUri.EndsWith(".svc", StringComparison.OrdinalIgnoreCase))
            {
                apiServiceUri = (new Uri(new Uri(apiServiceUri), "WcfService/Service.svc")).ToString();
            }

            this.serviceUri = apiServiceUri;
            this.username = username;
            this.passwordHash = passwordHash;
            this.appIdentifier = appIdentifier;
        }

        /// <summary>
        /// Calls the given method against the eWay-CRM API.
        /// </summary>
        /// <param name="methodName">Name of the method. Ex. 'SaveCompany'</param>
        /// <param name="data">The JSON parameters posted to the method. Posting sessionId is not necessary. Ex.:
        /// {
        ///     transmitObject: {
        ///         FileAs: "My New Company"
        ///     }
        /// }</param>
        /// <returns>
        /// JSON data returned by the API service.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The method name was not supplied. - methodName
        /// or
        /// data - The parameter JSON data were not supplied. Supply at least an empty JSON object.
        /// </exception>
        /// <exception cref="LoginException">
        /// Logging into eWay-CRM was unsuccessful.
        /// </exception>
        /// <exception cref="ResponseException">
        /// Method calling ended up badly.
        /// </exception>
        public JObject CallMethod(string methodName, JObject data)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException("The method name was not supplied.", nameof(methodName));

            if (data == null)
                throw new ArgumentNullException(nameof(data), "The parameter JSON data were not supplied. Supply at least an empty JSON object.");

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
                throw new ResponseException(methodName, response.GetValue("ReturnCode").ToString(), response.GetValue("Description").ToString());
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
                throw new LoginException(response.GetValue("ReturnCode").ToString(), response.GetValue("Description").ToString());
            this.sessionId = new Guid(response.Value<string>("SessionId"));
        }

        private JObject Call(string methodName, JObject data)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            if (data == null)
                throw new ArgumentNullException(nameof(data));

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
                throw new InvalidOperationException("Wcf returned nothing. That's strange.");

            JObject result = JObject.Parse(responseJson);

            return result;
        }

        private string GetMethodUri(string methodName)
        {
            return this.serviceUri + "/" + methodName;
        }
    }
}
