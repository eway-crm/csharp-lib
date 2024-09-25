using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWay.Core.Extensions
{
    /// <summary>
    /// Class with extension methods.
    /// </summary>
    public static class ApiExtensions
    {
        /// <summary>
        /// DateTimeOffset RFC 3339 format string.
        /// </summary>
        public const string RFC_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'sszzz";

        /// <summary>
        /// Formats DateTime for JSON communication with API.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="printInLegacyFormat">True to use legacy format.</param>
        /// <returns></returns>
        public static string ToStringForApi(this DateTime dateTime, bool printInLegacyFormat = false)
        {
            if (printInLegacyFormat)
                return dateTime.ToString("u");

            return dateTime.ToString(RFC_FORMAT);
        }
    }
}
