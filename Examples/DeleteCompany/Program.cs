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
                "https://trial.eway-crm.com/31994",
                "api",
                Connection.HashPassword("ApiTrial@eWay-CRM"),
                "TestingConnector01"
                );

            // List all companies
            wcfConnection.CallMethod("DeleteCompany", JObject.FromObject(new {
                    itemGuid = "E840934C-D505-4B35-B8D6-354CA0977E2B"
            }));
        }
    }
}
