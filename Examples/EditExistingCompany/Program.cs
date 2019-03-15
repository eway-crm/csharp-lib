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
                    "https://trial.eway-crm.com/31994",
                    "api",
                    "470AE7216203E23E1983EF1851E72947",
                    "TestingConnector01"
                    );

            // Edit the company		
            wcfConnection.CallMethod("SaveCompany", JObject.FromObject(new
            {
                transmitObject = new
                {
                    ItemGUID = "ebdd18f3-92e9-412d-afec-e1aaf6139b09",
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