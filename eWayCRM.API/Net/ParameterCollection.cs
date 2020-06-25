using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace eWayCRM.API.Net
{
    /// <summary>
    /// Class which creates collection from query parameters.
    /// </summary>
    public class ParameterCollection : NameValueCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterCollection"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public ParameterCollection(string query)
        {
            this.ParseQueryParameters(query);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (this.Count == 0)
                return null;

            var stringBuilder = new StringBuilder();
            int i = 0;
            foreach (string name in this)
            {
                if (i != 0)
                    stringBuilder.Append("&");

                stringBuilder.AppendFormat("{0}={1}", name, this[name]);
                i++;
            }

            return stringBuilder.ToString();
        }

        private void ParseQueryParameters(string query)
        {
            if (string.IsNullOrEmpty(query))
                return;

            string[] querySegments = query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');
                if (parts.Length > 0)
                {
                    string key = parts[0].Trim(new char[] { '?', ' ' });
                    string val = parts[1].Trim();

                    this.Add(key, val);
                }
            }
        }
    }
}
