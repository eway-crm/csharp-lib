using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json.Linq;

using eWayCRM.API;

namespace HoganReportProcessor
{
    class Program
    {
		//Connection to API
		Connection wcfConnection = new Connection(
                Program.Config.eWayCRMConnection.Url,
                Program.Config.eWayCRMConnection.UserName,
                Program.Config.eWayCRMConnection.Password,
                Program.Config.eWayCRMConnection.AppIdentifier
                );
		
		//Create the company		
		wcfConnection.CallMethod("SaveCompany", JObject.FromObject(new
                        {
                            transmitObject = new
                            {
                                'FileAs' => 'Company', 
								'CompanyName' => 'Company',
								'Purchaser' => '1',
								'Phone' => '111 222 333',
								'Email' => 'Email@company.com'
                            }
                        }));
	}
}