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
            //Connection to API
            Connection wcfConnection = new Connection(
                    "https://trial.eway-crm.com/31994",
                    "api",
                    "470AE7216203E23E1983EF1851E72947",
                    "TestingConnector01"
                    );


            //Create the company		
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
