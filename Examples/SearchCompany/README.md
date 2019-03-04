# Search Company

This example should show you how to search for company based on one or more parameters.. It is done by using function `wcfConnection.CallMethod()` with name of the method as first parameter and jObject with parameters of the search as second..
```c#

// List all companies
Console.WriteLine(wcfConnection.CallMethod("SearchCompanies", JObject.FromObject(new
{
    transmitObject = new
    {
        FileAs = "Dorl & Son Inc"
    }
})).ToString());

```

### Output
This is what you should see in console as output:
```console

{
  "Description": null,
  "ReturnCode": "rcSuccess",
  "Data": [
    {
      "ItemGUID": "8fa1d358-6090-4271-b8ad-96c083a98ba7",
      "ItemVersion": 3,
      "AdditionalFields": {},
      "CreatedByGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "FileAs": "Dorl & Son Inc",
      "IsPrivate": false,
      "ItemChanged": "2019-01-28 10:10:51Z",
      "ItemCreated": "2019-01-28 10:10:51Z",
      "ModifiedByGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "OwnerGUID": "dcd4897d-1ec5-4c8a-9aca-7ae19487151c",
      "Relations": null,
      "AccountNumber": "",
      "AdditionalDiscount": 0.0,
      "Address1City": "Kulpsville",
      "Address1CountryEn": "52ec58a3-1cf2-453c-a94d-93769ae99b9a",
      "Address1POBox": "",
      "Address1PostalCode": "19443",
      "Address1State": "PA",
      "Address1Street": "2371 Jerrold Ave",
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
      "CompanyName": "Dorl & Son Inc",
      "Competitor": null,
      "Department": "",
      "Email": null,
      "EmailOptOut": false,
      "EmployeesCount": 500,
      "Fax": "",
      "FirstContactEn": null,
      "ICQ": "",
      "ID": 4,
      "IdentificationNumber": null,
      "ImportanceEn": "53cf7016-ebe0-4e1e-b12f-de1a0f203c73",
      "LastActivity": "2019-01-28 00:00:00Z",
      "LineOfBusiness": null,
      "MSN": "",
      "MailingListOther": false,
      "Mobile": null,
      "MobileNormalized": null,
      "NextStep": null,
      "Note": "",
      "NotificationBy": "",
      "NotificationByEmail": true,
      "Phone": "215-874-1229",
      "PhoneNormalized": "2158741229",
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

To see the whole sample code click  [here](Program.cs)