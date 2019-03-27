using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.ListAllCompanies
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
            JObject response = wcfConnection.CallMethod("GetCompanies");

            // Output table
            Console.WriteLine("| {0,-35} | {1,-35} | {2,-35} |", "Name", "Address", "Phone");
            foreach (var item in ((JArray)response.GetValue("Data")))
            {
                Console.WriteLine("| {0,-35} | {1,-35} | {2,-35} |", item.Value<string>("FileAs"), item.Value<string>("Address1City") + " " + item.Value<string>("Address1Street") + " " + item.Value<string>("Address1PostalCode"), item.Value<string>("Phone"));
            }
        }
    }
}
