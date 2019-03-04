# Delete Company

![example output](Images/sample_output_before.PNG)
This sample shows deletion of company. It is done by using function `wcfConnection.CallMethod()` with name of the method as first parameter and jObject  with GUID of the Company to be deleted as second..
```c#

// List all companies
wcfConnection.CallMethod("DeleteCompany", JObject.FromObject(new {
        itemGuid = "E840934C-D505-4B35-B8D6-354CA0977E2B"
}));

```


We can now check that if we look for the company now, eWay-CRM will not find any results. The company was successfully deleted.

![example output](Images/sample_output_after.PNG)
## Sample code

To see the whole sample code click  [here](sample_code.php)