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

| Name                                | Address                             | Phone                               |
| Dorl & Son Inc                      | Kulpsville 2371 Jerrold Ave 19443   | 215-874-1229                        |
>_

```

## Sample code

To see the whole sample code click  [here](Program.cs)