using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.LinkExistingItem
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

            // Save Relation
            wcfConnection.CallMethod("SaveRelation", JObject.FromObject(new
            {
                transmitObject = new
                {
                    ItemGUID1 = "129641b8-3677-11e7-9e49-080027cbca76",
                    ItemGUID2 = "0db3650f-bb87-4acc-96d6-9e6993cc6e61",
                    FolderName1 = "Projects",
                    FolderName2 = "Contacts",
                    RelationType = "GENERAL"
                }
            }));
        }
    }
}