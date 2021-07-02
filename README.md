# pantry-dotnet
![example workflow](https://github.com/antoniovalentini/pantry-dotnet/actions/workflows/dotnet.yml/badge.svg)

.NET client library for Pantry JSON storage api.

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
