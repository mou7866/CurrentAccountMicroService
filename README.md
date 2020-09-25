 # Current Account Micro Service 

<br/>

This is a simple microservice to manage Current Accounts. Only 3 endpoints have been developed so far
 - GetCurrentAccountTransactionHistory ![Paged]
 - Login
 - Register

## Technologies

* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* Blazor Serverside
* MediatR
* AutoMapper
* FluentValidation

### Database Configuration

This solution uses an in memory database and seeds the data on startup of the API. The databases are the following:
 - Identity -> All users
 - Application -> All application specific data

If you would like to use SQL Server, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

## Overview

### Solution Design

For this project, I have used the best practice design for SOLID, CQRS and inward dependencies. 
All user authentication has been developed on the API but not implemented on the UI. A simple diagram is on draw.io: https://drive.google.com/file/d/1rVOUa7RDnhRuGRTtckdUKVHI-aApMElv/view?usp=sharing


### Domain

This project all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing databases

### WebUI

This layer has 2 projects that are the entry points of the application. 
- WebAPI 
- UI -> Blazor

## Support

If you are having problems, please let me know on mou7866@gmail.com
