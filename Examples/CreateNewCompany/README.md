# Saving new Company
Here you can see the process of saving new company. It is done by using method ```wcfConnection.CallMethod()``` with name of API function as first parameter and json object with Company specifications as second parameter.
```c#

// Create the company		
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

```

### Output
Result of this code should be visible in eWay-CRM as a new company. If you wanted to see raw data of what the service returns, add output to console around the function and follow it up with its  `.ToString()`  . The output should look something like this:
```console

{
  "Description": null,
  "ReturnCode": "rcSuccess",
  "Guid": "f5c0659e-bef4-4401-8714-7b6022139a18",
  "IsUserMessageOptionalError": null,
  "UserMessage": null
}

 ```
As you can see, the service returns among other things a GUID of created item. You can use it for  [editing](https://github.com/rstefko/eway-crm-csharp-lib/tree/master/Examples/EditExistingCompany)  or creating relations to this item.

## Sample code
To see the whole sample code click  [here](Program.cs)