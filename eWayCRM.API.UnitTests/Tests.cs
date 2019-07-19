using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWayCRM.API.UnitTests
{
    [TestClass]
    public class Tests
    {
        private const string API_URL = "https://trial.eway-crm.com/31994";
        private const string DEV_API_URL = "http://eway-dev/eWayWSMemos_Dev";
        private const string API_USER = "api";
        private const string API_USER_PASSWORD = "ApiTrial@eWay-CRM";

        [TestMethod]
        public void LoginTest()
        {
            var connection = new Connection(API_URL, API_USER, Connection.HashPassword(API_USER_PASSWORD));
            connection.EnsureLogin();

            Assert.AreEqual(new Guid("BA3FF5DF-2920-11E9-910F-00224D483D5B"), connection.UserGuid);
            Assert.IsTrue(connection.Version > new Version(5, 3));
        }

        [TestMethod]
        public void InsecureLoginTest()
        {
            var connection = new Connection(DEV_API_URL, API_USER, Connection.HashPassword(API_USER_PASSWORD));
            connection.EnsureLogin();

            Assert.AreEqual(new Guid("1ccf3ac2-aa23-11e9-8091-08606ef204e5"), connection.UserGuid);
            Assert.IsTrue(connection.Version > new Version(5, 3));
        }
    }
}
