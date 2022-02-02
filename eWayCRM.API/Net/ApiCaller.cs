using eWay.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace eWay.Core.Net
{
    /// <summary>
    /// Class which helps with API calls.
    /// </summary>
    public static class ApiCaller
    {
        /// <summary>
        /// Makes request to a specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="query">The query parameters.</param>
        /// <param name="method">The request method.</param>
        /// <param name="contentType">The content type.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="authorization">The authorization header.</param>
        /// <param name="userAgent">User Agent.</param>
        /// <returns></returns>
        public static string MakeRequest(string url, string query, string method = "POST", string contentType = "application/x-www-form-urlencoded", Encoding encoding = null, string authorization = null,
            string userAgent = null)
        {
            WebRequest request = WebRequestHelper.Create(url, userAgent: userAgent);
            request.Method = method;

            if (!string.IsNullOrEmpty(authorization))
            {
                request.Headers.Add("Authorization", authorization);
            }

            if (!string.IsNullOrEmpty(query))
            {
                var data = (encoding ?? Encoding.UTF8).GetBytes(query);

                request.ContentType = contentType;
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server.
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Creates basic authorization header.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string CreateBasicAuthorizationHeader(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return string.Concat("Basic ", Base64Encoder.Encode($"{userName}:{password}"));
        }
    }
}
