using eWay.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace eWayCRM.API.UnitTests.Extensions
{
    [TestClass]
    public class ApiExtensionsTests
    {
        private const string DATE = "2024-03-05";
        private const string DATE_TIME = "2024-03-05T13:45:56";

        private static readonly DateTime Unspecified = new DateTime(2024, 3, 5, 13, 45, 56, DateTimeKind.Unspecified);
        private static readonly DateTime Local = new DateTime(2024, 3, 5, 13, 45, 56, DateTimeKind.Local);
        private static readonly DateTime Utc = new DateTime(2024, 3, 5, 13, 45, 56, DateTimeKind.Utc);

        [TestMethod]
        public void FormatConstantsTest()
        {
            // The RFC format is a public constant, its value must not change.
            Assert.AreEqual("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz", ApiExtensions.RFC_FORMAT);

            // The shorter formats are prefixes of the longer ones, that is what allows the API to parse all of them.
            StringAssert.StartsWith(ApiExtensions.DATE_TIME_FORMAT, ApiExtensions.DATE_FORMAT);
            StringAssert.StartsWith(ApiExtensions.RFC_FORMAT, ApiExtensions.DATE_TIME_FORMAT);
        }

        [TestMethod]
        public void ToStringForApiTest()
        {
            Assert.AreEqual(DATE_TIME + FormatLocalOffset(Unspecified), Unspecified.ToStringForApi());
            Assert.AreEqual(DATE_TIME + FormatLocalOffset(Local), Local.ToStringForApi());

            Assert.AreEqual("2024-03-05 13:45:56Z", Unspecified.ToStringForApi(printInLegacyFormat: true));
        }

        [TestMethod]
        public void ToDateStringForApiTest()
        {
            // The kind of the value must not leak into the result.
            Assert.AreEqual(DATE, Unspecified.ToDateStringForApi());
            Assert.AreEqual(DATE, Local.ToDateStringForApi());
            Assert.AreEqual(DATE, Utc.ToDateStringForApi());
        }

        [TestMethod]
        public void ToDateTimeStringForApiTest()
        {
            // The wall clock value is kept as it is and no offset is appended, no matter what the kind is.
            Assert.AreEqual(DATE_TIME, Unspecified.ToDateTimeStringForApi());
            Assert.AreEqual(DATE_TIME, Local.ToDateTimeStringForApi());
            Assert.AreEqual(DATE_TIME, Utc.ToDateTimeStringForApi());
        }

        [TestMethod]
        public void ToDateTimeOffsetStringForApiTest()
        {
            Assert.AreEqual(DATE_TIME + "+00:00", Utc.ToDateTimeOffsetStringForApi());
            Assert.AreEqual(DATE_TIME + FormatLocalOffset(Unspecified), Unspecified.ToDateTimeOffsetStringForApi());
            Assert.AreEqual(DATE_TIME + FormatLocalOffset(Local), Local.ToDateTimeOffsetStringForApi());

            Assert.AreEqual(DATE_TIME + "-05:00", new DateTimeOffset(2024, 3, 5, 13, 45, 56, TimeSpan.FromHours(-5)).ToDateTimeOffsetStringForApi());
            Assert.AreEqual(DATE_TIME + "+02:00", new DateTimeOffset(2024, 3, 5, 13, 45, 56, TimeSpan.FromHours(2)).ToDateTimeOffsetStringForApi());
        }

        [TestMethod]
        public void NullableOverloadsTest()
        {
            DateTime? empty = null;
            DateTime? filled = Unspecified;
            DateTimeOffset? emptyOffset = null;
            DateTimeOffset? filledOffset = new DateTimeOffset(2024, 3, 5, 13, 45, 56, TimeSpan.FromHours(2));

            Assert.IsNull(empty.ToStringForApi());
            Assert.IsNull(empty.ToStringForApi(printInLegacyFormat: true));
            Assert.IsNull(empty.ToDateStringForApi());
            Assert.IsNull(empty.ToDateTimeStringForApi());
            Assert.IsNull(empty.ToDateTimeOffsetStringForApi());
            Assert.IsNull(emptyOffset.ToDateTimeOffsetStringForApi());

            Assert.AreEqual(Unspecified.ToStringForApi(), filled.ToStringForApi());
            Assert.AreEqual(Unspecified.ToStringForApi(printInLegacyFormat: true), filled.ToStringForApi(printInLegacyFormat: true));
            Assert.AreEqual(Unspecified.ToDateStringForApi(), filled.ToDateStringForApi());
            Assert.AreEqual(Unspecified.ToDateTimeStringForApi(), filled.ToDateTimeStringForApi());
            Assert.AreEqual(Unspecified.ToDateTimeOffsetStringForApi(), filled.ToDateTimeOffsetStringForApi());
            Assert.AreEqual(filledOffset.Value.ToDateTimeOffsetStringForApi(), filledOffset.ToDateTimeOffsetStringForApi());
        }

        [TestMethod]
        public void EdgeValuesDoNotThrowTest()
        {
            Assert.AreEqual("0001-01-01", DateTime.MinValue.ToDateStringForApi());
            Assert.AreEqual("0001-01-01T00:00:00", DateTime.MinValue.ToDateTimeStringForApi());
            Assert.AreEqual("9999-12-31T23:59:59", DateTime.MaxValue.ToDateTimeStringForApi());

            Assert.AreEqual("0001-01-01T00:00:00" + FormatLocalOffset(DateTime.MinValue), DateTime.MinValue.ToDateTimeOffsetStringForApi());
        }

        private static string FormatLocalOffset(DateTime dateTime)
        {
            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(dateTime);

            return (offset < TimeSpan.Zero ? "-" : "+") + offset.Duration().ToString("hh':'mm", CultureInfo.InvariantCulture);
        }
    }
}
