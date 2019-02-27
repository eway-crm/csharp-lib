# Saving new Company
Here you can see the process of saving new company. It is done by using method ```wcfConnection.CallMethod()``` with name of API function as first parameter and json object with Company specifications as second parameter
```c#

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

```

### Output
Result of this code should be visible in eWay-CRM as a new company. If you wanted to see raw data of what the service returns, add output to console around the function and follow it up with its  `.ToString()`  . The output should look something like this :
```c#

object(stdClass)[2]
 public 'Description' => null
 public 'ReturnCode' => string 'rcSuccess' (length=9)
 public 'Guid' => string 'ebdd18f3-92e9-412d-afec-e1aaf6139b09' (length=36)
 public 'IsUserMessageOptionalError' => null
 public 'UserMessage' => null
 
 ```
As you can see, the service returns among other things a GUID of created item. You can use it for  [editing](https://github.com/rstefko/eway-crm-csharp-lib/tree/master/Examples/EditExistingCompany)  or creating relations to this item.

## Sample code
To see the whole sample code click  [here](https://github.com/rstefko/eway-crm-csharp-lib/blob/master/Examples/CreateNewCompany/Program.cs)