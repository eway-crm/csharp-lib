using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// Date format string. Carries no time and no time zone information.
        /// </summary>
        public const string DATE_FORMAT = "yyyy'-'MM'-'dd";

        /// <summary>
        /// Date and time format string. Carries no time zone information, the value is sent as a plain wall clock time.
        /// </summary>
        public const string DATE_TIME_FORMAT = DATE_FORMAT + "'T'HH':'mm':'ss";

        /// <summary>
        /// DateTimeOffset RFC 3339 format string. Carries the UTC offset on top of the wall clock time.
        /// </summary>
        public const string RFC_FORMAT = DATE_TIME_FORMAT + "zzz";

        /// <summary>
        /// Formats DateTime for JSON communication with API.
        /// </summary>
        /// <remarks>
        /// The RFC format appends the offset of the machine time zone no matter what the <see cref="DateTime.Kind"/> of the value is.
        /// Use <see cref="ToDateStringForApi(DateTime)"/> or <see cref="ToDateTimeStringForApi(DateTime)"/> when the value carries no
        /// zone of its own, otherwise the value gets tagged with an offset it never had.
        /// </remarks>
        /// <param name="dateTime">The date time.</param>
        /// <param name="printInLegacyFormat">True to use legacy format.</param>
        /// <returns></returns>
        public static string ToStringForApi(this DateTime dateTime, bool printInLegacyFormat = false)
        {
            if (printInLegacyFormat)
                return dateTime.ToString("u");

            return dateTime.ToString(RFC_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats DateTime for JSON communication with API.
        /// </summary>
        /// <param name="dateTime">The date time. Null is formatted as null.</param>
        /// <param name="printInLegacyFormat">True to use legacy format.</param>
        /// <returns></returns>
        public static string ToStringForApi(this DateTime? dateTime, bool printInLegacyFormat = false)
        {
            if (!dateTime.HasValue)
                return null;

            return dateTime.Value.ToStringForApi(printInLegacyFormat);
        }

        /// <summary>
        /// Formats the date part of DateTime for JSON communication with API.
        /// Time and time zone information is left out, use it for values that mean a day rather than a moment.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToDateStringForApi(this DateTime dateTime)
        {
            return dateTime.ToString(DATE_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats the date part of DateTime for JSON communication with API.
        /// Time and time zone information is left out, use it for values that mean a day rather than a moment.
        /// </summary>
        /// <param name="dateTime">The date time. Null is formatted as null.</param>
        /// <returns></returns>
        public static string ToDateStringForApi(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

            return dateTime.Value.ToDateStringForApi();
        }

        /// <summary>
        /// Formats DateTime for JSON communication with API without any time zone information.
        /// The wall clock value is sent as it is, no matter what the <see cref="DateTime.Kind"/> of the value is.
        /// </summary>
        /// <remarks>
        /// Use this overload for values whose zone is unknown or irrelevant. Unlike <see cref="ToStringForApi(DateTime, bool)"/>
        /// it never tags the value with the offset of the machine time zone and it never triggers the DateTimeInvalidLocalFormat
        /// managed debugging assistant for values with <see cref="DateTimeKind.Utc"/>.
        /// </remarks>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToDateTimeStringForApi(this DateTime dateTime)
        {
            return dateTime.ToString(DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats DateTime for JSON communication with API without any time zone information.
        /// The wall clock value is sent as it is, no matter what the <see cref="DateTime.Kind"/> of the value is.
        /// </summary>
        /// <param name="dateTime">The date time. Null is formatted as null.</param>
        /// <returns></returns>
        public static string ToDateTimeStringForApi(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

            return dateTime.Value.ToDateTimeStringForApi();
        }

        /// <summary>
        /// Formats DateTime for JSON communication with API including the UTC offset.
        /// The offset is taken from the machine time zone for <see cref="DateTimeKind.Local"/> and <see cref="DateTimeKind.Unspecified"/>
        /// values and it is zero for <see cref="DateTimeKind.Utc"/> values.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToDateTimeOffsetStringForApi(this DateTime dateTime)
        {
            // The zzz specifier always prints the offset of the machine time zone, so it cannot be used for UTC values.
            if (dateTime.Kind == DateTimeKind.Utc)
                return dateTime.ToString(DATE_TIME_FORMAT, CultureInfo.InvariantCulture) + "+00:00";

            return dateTime.ToString(RFC_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats DateTime for JSON communication with API including the UTC offset.
        /// The offset is taken from the machine time zone for <see cref="DateTimeKind.Local"/> and <see cref="DateTimeKind.Unspecified"/>
        /// values and it is zero for <see cref="DateTimeKind.Utc"/> values.
        /// </summary>
        /// <param name="dateTime">The date time. Null is formatted as null.</param>
        /// <returns></returns>
        public static string ToDateTimeOffsetStringForApi(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

            return dateTime.Value.ToDateTimeOffsetStringForApi();
        }

        /// <summary>
        /// Formats DateTimeOffset for JSON communication with API including the UTC offset it carries.
        /// </summary>
        /// <param name="dateTimeOffset">The date time offset.</param>
        /// <returns></returns>
        public static string ToDateTimeOffsetStringForApi(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString(RFC_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats DateTimeOffset for JSON communication with API including the UTC offset it carries.
        /// </summary>
        /// <param name="dateTimeOffset">The date time offset. Null is formatted as null.</param>
        /// <returns></returns>
        public static string ToDateTimeOffsetStringForApi(this DateTimeOffset? dateTimeOffset)
        {
            if (!dateTimeOffset.HasValue)
                return null;

            return dateTimeOffset.Value.ToDateTimeOffsetStringForApi();
        }
    }
}
