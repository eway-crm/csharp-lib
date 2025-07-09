using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.EitExistingCompany
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

            // Edit the company		
            wcfConnection.CallMethod("SaveCompany", JObject.FromObject(new
            {
                transmitObject = new
                {
                    ItemGUID = "bb32631e-8f81-4da5-a95d-52b49591c661",
                    FileAs = "Company",
                    CompanyName = "Company",
                    Purchaser = "1",
                    Phone = "202202202",
                    Email = "randomCompanyEmail@company.com"
                }
            }));
        }
    }
}