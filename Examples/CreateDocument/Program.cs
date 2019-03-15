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
                "470AE7216203E23E1983EF1851E72947",
                "TestingConnector01"
                );

            // Create Document
            wcfConnection.UploadFile(@"C:\Users\user\Documents\File.txt", out Guid guid);
            wcfConnection.CallMethod("SaveDocument", JObject.FromObject(new
            {
                transmitObject = new
                {
                    ItemGUID = guid,
                    FileAs = "File.txt",
                    DocName = "File",
                    Extension = "txt",
                    DocSize = 0
                }
            }));
        }
    }
}