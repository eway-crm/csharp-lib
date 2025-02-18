using eWay.Core.Extensions;
using eWay.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Policy;
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
        public static string MakeRequest(string url, string query, string method = WebRequestMethods.Http.Post, string contentType = "application/x-www-form-urlencoded", Encoding encoding = null, string authorization = null,
            string userAgent = null)
        {
            byte[] contentData = !string.IsNullOrEmpty(query) ? (encoding ?? Encoding.UTF8).GetBytes(query) : null;

            using (WebResponse response = MakeRequestInternal(url, method, contentData, contentType, authorization, userAgent))
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
        /// Makes request to a specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="contentData">The content data.</param>
        /// <param name="method">The request method.</param>
        /// <param name="contentType">The content type.</param>
        /// <param name="authorization">The authorization header.</param>
        /// <param name="userAgent">User Agent.</param>
        /// <returns></returns>
        public static Stream MakeRequest(string url, byte[] contentData = null, string method = WebRequestMethods.Http.Post, string contentType = "application/x-www-form-urlencoded",
            string authorization = null, string userAgent = null)
        {
            MemoryStream stream = new MemoryStream();
            using (WebResponse response = MakeRequestInternal(url, method, contentData, contentType, authorization, userAgent))
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Use default buffer size from Stream.CopyTo method
                    byte[] array = new byte[81920];
                    int count;
                    while ((count = responseStream.Read(array, 0, array.Length)) != 0)
                    {
                        stream.Write(array, 0, count);
                    }
                }
            }
            return stream;
        }

        private static WebResponse MakeRequestInternal(string url, string method, byte[] contentData, string contentType, string authorization = null, string userAgent = null)
        {
            WebRequest request = WebRequestHelper.Create(url, userAgent: userAgent);
            request.Method = method;

            if (!string.IsNullOrEmpty(authorization))
            {
                request.Headers.Add("Authorization", authorization);
            }

            if (!contentData.IsEmpty())
            {
                request.ContentType = contentType;
                request.ContentLength = contentData.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(contentData, 0, contentData.Length);
                }
            }

            return request.GetResponse();
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
