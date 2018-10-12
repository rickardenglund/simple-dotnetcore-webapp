# simple-dotnetcore-webapp 

This webapplication simply outputs a background color and a text from the configuration file *appsettings.json*, and also the value of custom environment variables *ENVIRONMENT* and *APP_NAME*

To be used in docker exercises

# Requirements
```
.NET Core v2.2.0-preview1
```

# Running the application with dotnet CLI
```bash
Clone repository
cd simple-dotnetcore-webapp/WebAppForDocker
dotnet run
```

# Health Check
Available on endpoint */health*
