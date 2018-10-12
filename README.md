# simple-dotnetcore-webapp 

This webapplication simply outputs a background color and a text from the configuration file *appsettings.json*, and also the value of custom environment variables *ENVIRONMENT* and *APP_NAME*

To be used in docker exercises

# Requirements
```
.NET Core v2.2.0-preview2
```

# dotnet CLI commands
```dotnet restore ```
Downloads package dependencies referenced in *.csproj* file

```dotnet publish -c Release -o out ```
Packages the application and its dependencies with Release configuration and outputs to "/out" directory

# Health Check
Available on endpoint */health*
