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
Available on endpoint */healthz*


# Create cluster

```bash
az login

# cd terraform/aks/
terraform init

# outputs the following variables used later in the setup: 
# resource_group, cluster_name, registry_login_server, registry_admin_username and registry_admin_password
terraform apply

az aks browse --resource-group {resource_group} --name {cluster_name}

-----

az aks install-cli

az aks get-credentials --resource-group {resource_group} --name {cluster_name}

kubectl get nodes

------

docker build -t {registry_login_server}/webapp:v1 .

docker login {registry_login_server} -u {registry_admin_username} -p {registry_admin_password}

docker push {registry_login_server}/webapp:v1

```
