# List all Companies
This sample shows how to list all existing companies. It is done by using function `wcfConnection.CallMethod()` with name of the method as first parameter and empty jObject  as second. .
```c#

// List all companies
Console.WriteLine(wcfConnection.CallMethod("GetCompanies", new JObject()).ToString());

```

### Output
This is what you should see in console as output:
```console
{
  "Description": null,
  "ReturnCode": "rcSuccess",
  "Data": [
    {
      "ItemGUID": "92832c76-dc36-4782-9210-eacc579c14a0",
      "ItemVersion": 3,
      "AdditionalFields": {},
      "CreatedByGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "FileAs": "Chanay's Computers Inc",
      "IsPrivate": false,
      "ItemChanged": "2019-01-28 10:10:51Z",
      "ItemCreated": "2019-01-28 10:10:51Z",
      "ModifiedByGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "OwnerGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "Relations": null,
      "AccountNumber": "",
      "AdditionalDiscount": 0.0,
      "Address1City": "Brighton",
      "Address1CountryEn": "52ec58a3-1cf2-453c-a94d-93769ae99b9a",
      "Address1POBox": "",
      "Address1PostalCode": "48116",
      "Address1State": "MI",
      "Address1Street": "4 B Blue Ridge Blvd",
      "Address2City": null,
      "Address2CountryEn": null,
      "Address2POBox": "",
      "Address2PostalCode": null,
      "Address2State": null,
      "Address2Street": null,
      "Address3City": "",
      "Address3CountryEn": null,
      "Address3POBox": "",
      "Address3PostalCode": "",
      "Address3State": "",
      "Address3Street": "",
      "CompanyName": "Chanay's Computers Inc",
      "Competitor": null,
      "Department": "",
      "Email": null,
      "EmailOptOut": false,
      "EmployeesCount": 25,
      "Fax": "",
      "FirstContactEn": null,
      "ICQ": "",
      "ID": 2,
      "IdentificationNumber": null,
      "ImportanceEn": "b105584b-d460-4275-965d-65e9e13b1346",
      "LastActivity": "2019-01-27 00:00:00Z",
      "LineOfBusiness": null,
      "MSN": "",
      "MailingListOther": false,
      "Mobile": null,
      "MobileNormalized": null,
      "NextStep": null,
      "Note": "",
      "NotificationBy": "",
      "NotificationByEmail": true,
      "Phone": "810-292-9388",
      "PhoneNormalized": "8102929388",
      "Purchaser": false,
      "Reversal": 0.0,
      "SalePriceGuid": null,
      "Skype": "",
      "Suppliers": false,
      "VATNumber": null,
      "WebPage": ""
    }
  ]
}
>_
```

## Sample code

To see the whole sample code click  [here](https://github.com/rstefko/eway-crm-csharp-lib/blob/master/Examples/ListAllCompanies/sample_code.php)