using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace eWayCRM.API.Net
{
    /// <summary>
    /// Class used to build URL.
    /// </summary>
    public class UrlBuilder : UriBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public UrlBuilder(string url)
            : base(url) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        public UrlBuilder()
            : base() { }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        public string Url
        {
            get { return this.Uri.AbsoluteUri; }
        }

        /// <summary>
        /// Gets or sets the specified parameter.
        /// </summary>
        public string this[string parameter]
        {
            get
            {
                var parameters = new ParameterCollection(this.Query);

                return parameters[parameter];
            }

            set
            {
                var parameters = new ParameterCollection(this.Query);

                parameters[parameter] = value;

                this.Query = parameters.ToString();
            }
        }

        /// <summary>
        /// Combines base URL with other relative part.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="relativeUrl">The relative part.</param>
        /// <returns></returns>
        public static string Combine(string baseUrl, string relativeUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            if (string.IsNullOrEmpty(relativeUrl))
                throw new ArgumentNullException(nameof(relativeUrl));

            return $"{baseUrl.TrimEnd('/')}/{relativeUrl.TrimStart('/')}";
        }
    }
}
