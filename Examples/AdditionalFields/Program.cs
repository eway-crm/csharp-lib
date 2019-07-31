using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

using eWayCRM.API;


namespace ExamplesTesting.CreateDocument
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

            // Prepare values for multiple select
            JObject enumValues = LoadEnumValues("AF_29", wcfConnection);

            // Fill the additional fields
            JObject additionalFields = new JObject();
            additionalFields.Add("af_25", "7");
            additionalFields.Add("af_26", "1970-01-01");
            additionalFields.Add("af_27", PickEnum("Option 1", LoadEnumValues("AF_27", wcfConnection)));
            additionalFields.Add("af_28", "10992e33-c0d6-4a2e-b565-5babc646fd48");
            additionalFields.Add("af_29", new JArray {PickEnum("Option 1", enumValues), PickEnum("Option 2", enumValues), PickEnum("Option 3", enumValues)});

            // Create Company
            wcfConnection.CallMethod("SaveCompany", JObject.FromObject(new
            {
                transmitObject = new
                {
                    FileAs = "Company a.s.",
                    CompanyName = "Company a.s.",
                    Purchaser = "1",
                    Phone = "121 252 733",
                    Email = "Email@company.com",
                    AdditionalFields = additionalFields
                }
            }));
        }

        static string PickEnum(string name, JObject values)
        {
            foreach (JObject value in (JArray)values["Data"])
            {
                if (value.Value<string>("FileAs") == name)
                {
                    return value.Value<string>("ItemGUID");
                }
            }
            return null;
        }

        static JObject LoadEnumValues(string fieldNumber, Connection connection)
        {
            return connection.CallMethod("SearchEnumValues", JObject.FromObject(new
            {
                transmitObject = new
                {
                    EnumTypeName = fieldNumber
                }
            }));
        }
    }
}