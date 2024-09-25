# eWay-CRM API
API used for communication with [eWay-CRM](http://www.eway-crm.com/) web service. It is a wrapper over HTTP/S communication and sessions. See our [documentation](https://kb.eway-crm.com/documentation/6-add-ins/6-7-api-1) for more information. 

## Installation
The simpliest way to start using this library is to get the  [NuGet Package](https://www.nuget.org/packages/eWayCRM.API). To do that, just run this command in your Package Manager Console (Visual Studio: Tools -> NuGet Package Manager -> Package Manager Console):

```
PM> Install-Package eWayCRM.API
```

## Usage

This library wraps the communication with JSON API. To provide the most variability, it lets you to input JSON data and fetch JSON data. For JSON representation, we have chosen the  [NewtonSoft.Json/Json.NET](https://www.newtonsoft.com/json)  library. As a consequence, be sure to have  `using Newtonsoft.Json.Linq;`  everywhere you need to work with our library.

The actual usage is then the same as it would be for example with  [PHP](https://github.com/rstefko/eway-crm-php-lib). See the [documentation](https://kb.eway-crm.com/documentation/6-add-ins/6-7-api-1)  for more.

## Establishing connection
To communicate with eWay-CRM web service, we first have to establish connection. This must be done prior to every action we want to accomplish with use of the web service. To do that, we have to  create new instance of ```Connection``` with four parameters: service url address (same as the one you use in outlook), username, password and application identifier. Identifier is bound to application and its version. It must contain number at its end.
```C#

Connection wcfConnection = new Connection(
	"https://trial.eway-crm.com/31994",
	"api",
	Connection.HashPassword("ApiTrial@eWay-CRM"),
	"ExampleApplication100"
	);

```

⚠️ If you log into eWay-CRM with your Microsoft account [Microsoft Account Authentication](https://kb.eway-crm.com/documentation/2-installation/2-3-installation-the-server-part/adjust-eway-crm-web-service-for-azure-login-office-365?set_language=en), the connector will not work with the legacy auth used in the examples. You will have to implement OAuth 2.0 authorization flow to get access and refresh token. You can see how to implement it in [TimeClock app code](https://github.com/rstefko/TimeClock/commit/5e86941c159e964c273ca3eaed9c2c59f2ced6ed). A ClientID / ClientSecret for you App will have to be created ([click here](https://kb.eway-crm.com/en/documentation/6-add-ins/integration-with-wordpress-1/integration-with-wordpress) for more details).

## Actions at the service

You can check actions available on your service on  `[service adress]/WcfService/Service.svc/help`  . We have put together a list of examples for some basic actions you can use the service for, so don't be shy an try it out.

### [Create new company](Examples/CreateNewCompany/README.md)
Example showcasing creation of new Company. \
Sample code [here](Examples/CreateNewCompany/Program.cs).

### [Edit existing company](Examples/EditExistingCompany/README.md)
Example showcasing editing existing Company. \
Sample code [here](Examples/EditExistingCompany/Program.cs).

### [List all companies](Examples/ListAllCompanies/README.md)
Example showcasing listing of all existing Companies. \
Sample code [here](Examples/ListAllCompanies/Program.cs).

### [Search for company](Examples/SearchForCompany/README.md)
Example showcasing serching for Company by parameters. \
Sample code [here](Examples/SearchForCompany/Program.cs).

### [Delete company](Examples/DeleteCompany/README.md)
Example showcasing deletion of Company. \
Sample code [here](Examples/DeleteCompany/Program.cs).

### [Link existing item](Examples/LinkExistingItem/README.md)
Example showcasing creation of simple relation. \
Sample code [here](Examples/LinkExistingItem/Program.cs).

### [Create document](Examples/CreateDocument/README.md)
Example showcasing creation of document. \
Sample code [here](Examples/CreateDocument/Program.cs).

### [Additional fields](Examples/AdditionalFields/README.md)
Example showcasing manipulation with additional fields. \
Sample code [here](Examples/AdditionalFields/Program.cs).

## Folder name
To ease understanding folder names, look [here](FolderNames.md).