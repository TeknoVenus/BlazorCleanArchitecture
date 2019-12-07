# Blazor Clean Architecture 
This is a simple test project to experiement build a Blazor (server-side) application using the principles of Clean Architecture. It also uses the DevExpress Blazor libraries for data visualisation.

The idea of this project is a simple class information page, where users can search for and view information about students. 

**Note - this is a pretty quick test project to get used to Blazor and misses out a lot of steps you would take in production such as validation! Don't use this as a reference design**

## Structure
### Core
This is the centre of the project, and all other dependencies point towards this project. It has very few external dependencies. The business logic is implemented here, such as any important algorithms, data processing and manipulation, and domain specific knowledge.

### Infrastructure
Any dependencies on external resources such as databases, 3rd party APIs, SOAP requests, file reading/writing etc are handled in this layer. It is only responsible with the data reading/writing, any manipulation and pre-processing should take place in the Core.

Classes here should be implementations of interfaces defined in Core. 

### Web
This is the presentation layer in this project - a Blazor based ASP.NET Core 3.0 app. This layer should be "dumb" and not contain any business logic - instead only performing tasks relevant to formatting and presenting the data to the user. This way, it is easy to switch out this layer for a new one if required (such as a WebAPI project or Xamarin app)

This project uses server-side Blazor, where the client communicates with the server over a websocket. Client side Blazor downloads a WASM version of the .NET Core runtime instead.

## Building and Running
### Requirements
* .NET Core 3.1 Runtime
* Visual Studio 2019 16.4.0
* DevExpress Blazor Components (https://www.devexpress.com/blazor/)
* Wonde School Data Sync Account (https://wonde.com/developers)

You will need to configure your Wonde token. In your Wonde account, get a multi-school API token. Then create a user secret as per the instructions here: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.0&tabs=windows

In addition, you must configure your NuGet feed to include the DevExpress Blazor libraries - you can get your details by signing in here: https://nuget.devexpress.com/
