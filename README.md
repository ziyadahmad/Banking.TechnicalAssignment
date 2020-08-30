# Banking Assignment

### Packages or technologies used

*  .Net Core 3.1
*  Swashbuckle ( Swagger )
*  RestSharp
*  LiteDb
*  AutoMapper
*  XUnit
*  FluentAssertions
*  Moq

### Setup
Download the code in newly created folder by cloning this repo.

```
git clone https://github.com/ziyadahmad/Banking.TechnicalAssignment.git
```

#### Run Banking Assignment Api

  Change directory into Banking.Assignment.Api
  
  ```
  cd Banking.TechnicalAssignment.Api
  ```
  
  Build Banking.Assignment.Api
  
  ```
  dotnet build Banking.TechnicalAssignment.Api.csproj
  ```
  
  Run Banking.Assignment.Api
  
  ```
  dotnet run Banking.TechnicalAssignment.Api.csproj  
  ```
  
  API listens on port 3000. Swagger is available at the endpoint address
  
#### Run Banking Assignment Web
  
  
  Change directory into Banking.Assignment.Web
  
  ```
  cd Banking.TechnicalAssignment.Web
  ```
  
  Build Banking.Assignment.Web
  
  ```
  dotnet build Banking.TechnicalAssignment.Web.csproj
  ```
  
  Run Banking.Assignment.Web
  
  ```
  dotnet run Banking.TechnicalAssignment.Web.csproj  
  ```
  
  Website opens on port 4000
  
### CI/CD

[![Build Status](https://dev.azure.com/ziyadahmad747/Banking.TechnicalAssignment/_apis/build/status/ziyadahmad.Banking.TechnicalAssignment?branchName=develop)](https://dev.azure.com/ziyadahmad747/Banking.TechnicalAssignment/_build/latest?definitionId=1&branchName=develop)

Multi Stage pipeline script for Azure Devops is configured to Build and Test API and Web projects