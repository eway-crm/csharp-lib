using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.SearchForCompany
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

            // List all companies
            Console.WriteLine(wcfConnection.CallMethod("SearchCompanies", JObject.FromObject(new
            {
                transmitObject = new
                {
                    FileAs = "Dorl & Son Inc"
                }
            })).ToString());
        }
    }
}
