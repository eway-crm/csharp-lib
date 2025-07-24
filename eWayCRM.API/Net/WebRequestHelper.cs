using System.Net;

namespace eWay.Core.Net
{
    public static class WebRequestHelper
    {
#if (CORE)
        /// <summary>
        /// Static constructor.
        /// </summary>
        static WebRequestHelper()
        {
            CertificateErrorResolver.Initialize();
        }
#endif

        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="userAgent">User Agent.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        public static HttpWebRequest Create(string url, int? timeout = null, string userAgent = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new System.ArgumentNullException(nameof(url));

            var request = (HttpWebRequest)WebRequest.Create(url);

#if (CORE)
            request.Timeout = timeout ?? ApplicationSettings.ResponseTimeout;
#else
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
#endif

#if (CORE)
            // The following code it taken from http://stackoverflow.com/questions/490177/how-do-i-determine-elegantly-if-proxy-authentication-is-required-in-c-winforms
            // This code needs to be tested

            //HACK: add proxy
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            request.Proxy = proxy;
            request.PreAuthenticate = true;
            //HACK: end add proxy
#endif

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }

            request.AllowAutoRedirect = true;
            request.MaximumAutomaticRedirections = 3;
            request.KeepAlive = true;

            return request;
        }
    }
}