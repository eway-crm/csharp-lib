using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.DeleteCompany
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Connection to API
            Connection wcfConnection = new Connection(
                "https://free.eway-crm.com/31994",
                "api",
                Connection.HashPassword("ApiTrial@eWay-CRM"),
                "TestingConnector01"
                );

            // List all companies
            wcfConnection.CallMethod("DeleteCompany", JObject.FromObject(new {
                    itemGuid = "3135277c-e8b9-4279-95d2-4fe5d333df5a"
            }));
        }
    }
}
