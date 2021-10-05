using eWay.Core.Net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWay.Core.Helpers
{
    public class OAuthHelper
    {
        private readonly string webServiceUrl;

        public OAuthHelper(string webServiceUrl)
        {
            if (string.IsNullOrEmpty(webServiceUrl))
                throw new ArgumentNullException(nameof(webServiceUrl));

            this.webServiceUrl = webServiceUrl;
        }

        /// <summary>
        /// Access token introspection.
        /// </summary>
        /// <returns></returns>
        public JToken Introspect(string accessToken, string authorization)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            string result = ApiCaller.MakeRequest(UrlBuilder.Combine(this.webServiceUrl, "auth/connect/introspect"), $"token={accessToken}", authorization: authorization);
            if (string.IsNullOrEmpty(result))
                throw new InvalidOperationException("API token response cannot be empty");

            return JObject.Parse(result);
        }

        /// <summary>
        /// Request a new access token.
        /// </summary>
        /// <param name="clientId">Client ID.</param>
        /// <param name="clientSecret">Client secret.</param>
        /// <param name="refreshToken">Refresh token.</param>
        /// <returns></returns>
        public JToken RequestAccessToken(string clientId, string clientSecret, string refreshToken)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentNullException(nameof(clientId));

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret));
            
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken));

            string data = $"client_id={clientId}&client_secret={clientSecret}&refresh_token={refreshToken}&grant_type=refresh_token";
            string result = ApiCaller.MakeRequest(UrlBuilder.Combine(this.webServiceUrl, "auth/connect/token"), data);
            if (string.IsNullOrEmpty(result))
                throw new InvalidOperationException("API token response cannot be empty");

            return JObject.Parse(result);
        }
    }
}
