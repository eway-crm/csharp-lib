using eWayCRM.API.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWayCRM.API.UnitTests.Net
{
    [TestClass]
    public class UrlBuilderTests
    {
        [TestMethod]
        public void CombineTest()
        {
            const string url = Tests.API_URL + "/auth/connect/introspect";
            Assert.AreEqual(url, UrlBuilder.Combine(Tests.API_URL, "auth/connect/introspect"));
            Assert.AreEqual(url, UrlBuilder.Combine(Tests.API_URL + "/", "auth/connect/introspect"));
            Assert.AreEqual(url, UrlBuilder.Combine(Tests.API_URL, "/auth/connect/introspect"));
            Assert.AreEqual(url, UrlBuilder.Combine(Tests.API_URL + "/", "/auth/connect/introspect"));
        }
    }
}
