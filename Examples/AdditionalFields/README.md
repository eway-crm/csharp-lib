# Manipulating with additional fields
This example should provide some insight into manipulation with additional fields, namely fields of numeric, date, enum, relation and multi dropdown type. (This example is assuming that you know names of additional fields and in case of selections,  names of the options you want to choose. These can be found in eWay-CRM administration application.)

## Create company with additional fields
Here we prepare array with all the additional fields. Number and date takes values as usual. Enum field will be filled with option we choose.Next is the relation with GUID of the journal that we created as value.And last is DropDown with array of Dropdown options of our choice as value. Now we have everything prepared, we create array with specifications of company. Here we can use our additional fields array as value for "AditionalFields". Then we save the company by  `wcfConnection.CallMethod()`. (Getting values for enum and dropdown fields can get a little bit tricky, so we have prepared two functions to ease the access. Only thing left up to you is to fill the name of additional field and option that you want to put in it.)
```c#
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
```

## Output
As a result, you should see the newly created company with filled additional fields in your outlook.
![example output](Images/sample_output.PNG)

## Sample code
To see the whole sample code click [here](sample_code.php).

## Folder name
To ease understanding folder names, look [here](../../FolderNames.md).