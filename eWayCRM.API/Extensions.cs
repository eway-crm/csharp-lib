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
    }
}
