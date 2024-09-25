using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.Extensions
{
    /// <summary>
    /// Class with extension methods.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Gets date time from the JToken. This method can handle old format with space instead of T.
        /// </summary>
        /// <param name="token">The JToken.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static DateTime? GetDateTime(this Newtonsoft.Json.Linq.JToken token, string key)
        {
            Newtonsoft.Json.Linq.JValue value = token[key] as Newtonsoft.Json.Linq.JValue;
            if (value == null || value.Value == null)
                return null;

            switch (value.Value)
            {
                case DateTime dateTime:
                    return dateTime;

                case string stringValue:
                    return DateTime.Parse(stringValue);

                default:
                    throw new InvalidOperationException($"Unsupported type '{value.GetType()}'");
            }
        }
    }
}
