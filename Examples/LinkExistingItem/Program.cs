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
                "https://trial.eway-crm.com/31994",
                "api",
                "470AE7216203E23E1983EF1851E72947",
                "TestingConnector01"
                );

            // Save Relation
            wcfConnection.CallMethod("SaveRelation", JObject.FromObject(new
            {
                transmitObject = new
                {
                    ItemGUID1     = "129641b8-3677-11e7-9e49-080027cbca76",
                    ItemGUID2     = "d9705ddc-9161-44e3-82cd-0bd0063b66f5",
                    FolderName1   = "Projects",
                    FolderName2   = "Contacts",
                    RelationType  = "GENERAL"
                }
            }));
        }
    }
}