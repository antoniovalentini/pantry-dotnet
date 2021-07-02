# pantry-dotnet
![example workflow](https://github.com/antoniovalentini/pantry-dotnet/actions/workflows/dotnet.yml/badge.svg)

This Pantry Client Library allows .NET developers to easily work with Pantry JSON storage APIs. It is built on top of .NET 5.

# How to use it
TBC

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
