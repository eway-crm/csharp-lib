![eWay-CRM Logo](https://www.eway-crm.com/wp-content/themes/eway/img/email/logo_grey.png)
# eWay-CRM API
API used for communication with [eWay-CRM](http://www.eway-crm.com/) web service. It is a wrapper over HTTP/S communication and sessions. See our [documentation](https://kb.eway-crm.com/documentation/6-add-ins/6-7-api-1) for more information. 

## Installation
The simpliest way to start using this library is to get the  [NuGet Package](https://www.nuget.org/packages/eWayCRM.API). To do that, just run this command in your Package Manager Console (Visual Studio: Tools -> NuGet Package Manager -> Package Manager Console):

```
PM> Install-Package eWayCRM.API
```

## Usage

This library wraps the communication with JSON API. To provide the most variability, it lets you to input JSON data and fetch JSON data. For JSON representation, we have chosen the  [NewtonSoft.Json/Json.NET](https://www.newtonsoft.com/json)  library. As a consequence, be sure to have  `using Newtonsoft.Json.Linq;`  everywhere you need to work with our library.

The actual usage is then the same as it would be for example with  [PHP](https://github.com/rstefko/eway-crm-php-lib). See the  [documentation](https://kb.eway-crm.com/documentation/6-add-ins/6-7-api-1)  for more.

## Establishing connection
To communicate eWay-CRM web service, we first have to establish connection. This must be done prior to every action we want to accomplish with use of the web service. To do that, we have to  create new instance of ```eWayConnector()``` with four parameters: service url address (same as the one you use in outlook), username, password and application identifier.
```C#

Connection wcfConnection = new Connection(
	"https://trial.eway-crm.com/31994",
	"api",
	"ApiTrial@eWay-CRM",
	"ExampleApplication100"
	);

```

## Actions at the service

You can check actions available on your service on  `[service adress]/WcfService/Service.svc/help`  . We have put together a list of examples for some basic actions you can use the service for, so don't be shy an try it out.

### [Create new company](Examples/CreateNewCompany/README.md)<br />
Example showcasing creation of new Company.<br />
Sample code [here](Examples/CreateNewCompany/Program.cs).

### [Edit existing company](Examples/EditExistingCompany/README.md)<br />
Example showcasing editing existing Company.<br />
Sample code [here](Examples/EditExistingCompany/Program.cs).

### [List all companies](Examples/ListAllCompanies/README.md)<br />
Example showcasing listing of all existing Companies.<br />
Sample code [here](Examples/ListAllCompanies/Program.cs).

### [Search for company](Examples/SearchCompany/README.md)<br />
Example showcasing serching for Company by parameters.<br />
Sample code [here](Examples/SearchCompany/Program.cs).

### [Delete company](Examples/DeleteCompany/README.md)<br />
Example showcasing deletion Company.<br />
Sample code [here](Examples/DeleteCompany/Program.cs).

### [Link existing item](Examples/LinkExistingItem/README.md)<br />
Example showcasing creation of simple relation.<br />
Sample code [here](Examples/LinkExistingItem/Program.cs).

### [Create document](Examples/CreateDocument/README.md)<br />
Example showcasing creation of document.<br />
Sample code [here](Examples/CreateDocument/Program.cs).

## Folder name
To ease understanding folder names, look [here](FolderNames.md).