# Car Mechanic Workshop Client-Server App


## Table of contents

### **Coding**
- [ **General info** ](#general-info)
- [ **Technologies** ](#technologies)
- [ **Install** ](#install)
- [ **Using** ](#using)
- [ **Unit Tesing** ](#unit-testing)
### **Documentation**
- [ **Server** ](#server)
- [ **Office Client** ](#office-client)
- [ **Repair Client** ](#repair-client)


## General info

### **Description**
This project is simple Client-Server Application. Created for a customer office and car mechanic workshop. You can record, store and select a car repair order.


### **Authors**
- [ **Deák Ruben** ](https://github.com/RubiMaistro)
- [ **Csirák Dávid** ](https://github.com/davidcsirak)


## Technologies

### **Project is created with:**
* C# 
* .NET 5.0 
* .NET WPF 
* Blazor Web Framework 
* .NET WEB API 
* Entity Framework 
* Async 
* MSTest 


## Install

```
$ git clone "repository_name"
```
- **Install with NuGet in Visual Studio:**
  - Microsoft.EntityFrameworkCore 5.0.13
  - Microsoft.EntityFrameworkCore.SqlServer 5.0.13
  - Microsoft.EntityFrameworkCore.Tools 5.0.13
  - Microsoft.AspNetCore.Components.WebAssembly 5.0.13
  - Microsoft.AspNetCore.Components.WebAssembly.DevServer 5.0.13
  - System.Net.Http.Json 5.0.0
  - Fody 6.6.0
  - PropertyChanged.Fody 3.4.0
  - coverlet.collector 3.0.2
  - Newtonsoft.Json 13.0.1
  - MSTest.TestAdapter 2.2.3
  - MSTest.TestFramework 2.2.3

## Using
- In Visual Studio or VSC
- First of all you should execute for the database in package manager
```
Update-Database
```

## Unit testing

- Unit testing with MSTest
- Testing database Model validation


## Server

- This is a simple WEB API with CRUD operations
- Data stored in local MSSQL


## Office Client

### **Description**
This client application deployed in a Car Repair Ordering Office. An ordering clerk can record and store car repair order for incoming customers

### **Technologie**
- **NET WPF** and **Blazor** frontend

### **Functions:**
- Listing the stored repair orders
- Adding new repair order
- Editing a repair order


## Repair Client

### **Description**
This client application deployed in Car Repair Workshop. A mechanic can change the status of car repair order 

### **Technologie**
- **.NET WPF** and **Blazor** frontend

### **Functions:**
- Listing the stored repair orders
- Changing status of repair order
- 
