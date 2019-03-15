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

            // Search Companies
            JObject response = wcfConnection.CallMethod("SearchCompanies", JObject.FromObject(new
            {
                transmitObject = new
                {
                    FileAs = "01"
                }
            }));

            Console.WriteLine("| {0,-35} | {1,-35} | {2,-35} |", "Name", "Address", "Phone");
            foreach (var item in ((JArray)response.GetValue("Data")))
            {
                Console.WriteLine("| {0,-35} | {1,-35} | {2,-35} |", item.Value<string>("FileAs"), item.Value<string>("Address1City")+" "+item.Value<string>("Address1Street") + " "+ item.Value<string>("Address1PostalCode"), item.Value<string>("Phone"));
            }
        }
    }
}
