# pantry-dotnet
![example workflow](https://github.com/antoniovalentini/pantry-dotnet/actions/workflows/dotnet.yml/badge.svg)

This Pantry Client Library allows .NET developers to easily work with Pantry JSON storage APIs. It is built on top of .NET 5.
Pantry is a free, API based JSON storage service for personal projects. 

# Disclaimer

This is a fan-made project only and it's not supported by pantry developers. It may be subject to change without notice and it's highly recommended to not store any sensible or secret data. For any further info or to know how your data will be managed, please refer to the [pantry website](https://getpantry.cloud/).

The software is provided “as is”, without warranty of any kind, express or implied. In no event shall the author be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.

# How to use it
Use the extension method provided by the `Pantry.Extensions.Microsoft` project to inject all the Pantry services:
```C#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddPantryLibrary(Configuration);
        // ...
    }
}
```
and ask the services collection for an `IPantryClient` to get access to `Pantries` and `Baskets` resource endpoints:
```C#
public class MyClass
{
    private readonly IPantryClient _pantryClient;

    public MyClass(IPantryClient pantryClient)
    {
        _pantryClient = pantryClient;
    }

    public async Task MyMethod()
    {
        // Get a specific pantry
        var pantryResponse = await _pantryClient.Pantries.GetPantry("pantry-id");
        
        // Get the content stored inside a basket
        var content = await _pantryClient.Baskets.Get<SampleContent>(
            "pantry-id", 
            "basked-name", 
            CancellationToken.None);
    }
}
```

# Running tests
To run the E2E tests, create an `appsettings.test.json` inside the E2E tests project like the following:
```JSON
{
    "Pantry": {
        "Id": "<your-pantry-key>",
        "Name": "<your-pantry-name>",
        "Description": "<your-pantry-description>"
    }
}
```
or set the following environment variables:
- `PANTRY__ID`
- `PANTRY__NAME`
- `PANTRY__DESCRIPTION`

# Resources
- [Pantry website](https://getpantry.cloud/)
- [Pantry documentation](https://documenter.getpostman.com/view/3281832/SzmZeMLC)
