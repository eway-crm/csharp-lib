using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.CreateNewCompany
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


            // Create the company		
            wcfConnection.CallMethod("SaveCompany", JObject.FromObject(new
            {
                transmitObject = new
                {
                    FileAs = "Company",
                    CompanyName = "Company",
                    Purchaser = "1",
                    Phone = "111 222 333",
                    Email = "Email@company.com"
                }
            }));
        }
    }
}
