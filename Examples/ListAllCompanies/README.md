# List all Companies
This sample shows how to list all existing companies. It is done by using function `wcfConnection.CallMethod()` with name of the method as parameter.
```c#

// List all companies
JObject response = wcfConnection.CallMethod("GetCompanies");

```

### Output
This is what you should see in console as output:
```console
| Name                                | Address                             | Phone                               |
| Chanay's Computers Inc              | Brighton 4 B Blue Ridge Blvd 48116  | 810-292-9388                        |
| Chemel & Peterson LLC               | Bridgeport 8 W Cerritos Ave #54 8014| 856-636-8749                        |
>_
```

## Sample code

To see the whole sample code click  [here](https://github.com/rstefko/eway-crm-csharp-lib/blob/master/Examples/ListAllCompanies/Program.cs)