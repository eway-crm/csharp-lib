using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API
{
    public static class Extensions
    {
        /// <summary>
        /// Formats DateTime for JSON communication with API.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToStringForApi(this DateTime dateTime)
        {
            return dateTime.ToString("u");
        }

        /// <summary>
        /// Gets date time from the JToken. This method can handle old format with space instead of T.
        /// </summary>
        /// <param name="token">The JToken.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static DateTime? GetDateTime(this JToken token, string key)
        {
            JValue value = token[key] as JValue;
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
