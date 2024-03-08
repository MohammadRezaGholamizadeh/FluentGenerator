# Fluent Generator
This Package Is For Auto Generating The Fixture And Infrastructure That We Need To Config And Use In TDD - BDD And All Test That We Need To Run On Sql-Server And Sql-Lite and Other Database. This Package Make All Sut And Data Infrastructure And DbContext For You In Test Drivern Design Flow. Enjoy It
![Logo](https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/src/FluentGenerator/Logo.ico)

## Authors
- [@Mohammadreza Gholamizadeh [Phoenix]](https://github.com/MohammadRezaGholamizadeh)
## 🚀 About Me
I MohammadReza Gholamizadeh. I`m Dotnet Software Developer That Always Try To Make All things Easy for Developing. Please Star the Project And Package to Cover And Enjoy When Using It.

## 🔗 Links
[![Source Code](https://img.shields.io/badge/Source_Code-000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/MohammadRezaGholamizadeh/FluentGenerator/tree/main)
[![MohammadReza Gholamizadeh GitHub](https://img.shields.io/badge/MohammadReza_Gholamizadeh_GitHub-000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/MohammadRezaGholamizadeh)
[![Nuget](https://img.shields.io/badge/Nuget-4974a5?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/profiles/MohammadrezaGholamizadeh_Phoenix)

## Licenses
* [Apache-2.0 license](https://github.com/MohammadRezaGholamizadeh/FluentGenerator/blob/main/LICENSE)

## Base Requirement To Use
You Must Add FluentGenerator Package To Your Project That You Wrote All Your Service Test In It By These Command :

## Commands
Package Manager
```bash
NuGet\Install-Package FluentGenerator -Version 2024.1.0
```

## Get Start To Use It
### Step 1 : 
    Create A Generic Class And Inherit From AutoServiceConfiguration Abstract Class
### Step 2 : 
    Implement The Abstract Methods With Empty Body. These Methods Are : 
    * void ServicesConfiguration(ContainerBuilder container, Dictionary<Type, object> mockedServiceParameters, DbContext context)
    * DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)
    * DbContext SqlServerConfiguration()
### Step 3 :
    In [ServicesConfiguration] Method You Must Register All Your Service And Repository And ThirdPartyService That You Use In Your App.All Class That You Referenced In Each Class Must Be Registered Here.
### Step 4 : 
    In [SqlLiteConfiguration] Method You Must Config Your SqlLite DbContext To Inject To All Repository And Services That You Want To Test With Unit Tetsting Process.
### Step 5 :
    In [SqlServerConfiguration] Method You Must Config Your SqlServer DbContext To Inject To All Repository And Services That You Want To Test With Integration Or Spec Flow Tetsting Process And You Want Run On SqlServer DataBase.
### Step 6 : 
    Create A Generic Class And Inherit From Genericc Class That You Created In Step 1. Then Implement Sut And DataContext That You Want To Use In Generic Format Like Prictures, You Must Do It Like Pictures


# Class And Method Implementation
## Type : AutoServiceConfiguration
### AutoServiceConfiguration Methods : 

* ServicesConfiguration(container, mockedServiceParameters, context)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `container` | `ContainerBuilder` | ** **Required.**                      |
| `mockedServiceParameters` | `Dictionary<Type, Object>` | ** **Required.**                      |
| `context` | `DbContext` | ** **Required.**                      |

* SqlLiteConfiguration(sqliteConnection)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `sqliteConnection` | `SqliteConnection` | ** **Required.**                      |

* SqlServerConfiguration()


* GetContext()


* CreateService(dataBase)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `dataBase` | `DataBaseType` | ** **Required.**                      |

* GetConnectionString(jsonFileName, connectionStringName)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `jsonFileName` | `String` | ** **Required.**                      |
| `connectionStringName` | `String` | ** **Required.**                      |

* Dispose()



## Type : AutoServiceTools
### AutoServiceTools Methods : 

* WithConstructorParameters(registration, parameters)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `registration` | `IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>` | ** **Required.**                      |
| `parameters` | `Dictionary<Type, Object>` | ** **Required.**                      |

* WithDbContext(registration, context)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `registration` | `IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle>` | ** **Required.**                      |
| `context` | `TDbContext` | ** **Required.**                      |

* AddMockedParameter(parameter, parameterType, parameterValue)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `parameter` | `Dictionary<Type, Object>` | ** **Required.**                      |
| `parameterType` | `Type` | ** **Required.**                      |
| `parameterValue` | `Object` | ** **Required.**                      |

* MockObjectListCreator()


* SaveChangesOn(context, entity)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `context` | `DbContext` | ** **Required.**                      |
| `entity` | `Object` | ** **Required.**                      |


## Type : InMemoryDataBase
### This Type Has 1 Custom Constructor : 
* Constructor Number 1 : [ Void ] 
### InMemoryDataBase Methods : 

* CreateInMemoryDataContext(sqliteConnection, dbContextConstructorParameterDetails, entities)

| Parameter | Type     | Description                |
| -------- | ------- | ------------------------- |
| `sqliteConnection` | `SqliteConnection` | ** **Required.**                      |
| `dbContextConstructorParameterDetails` | `Dictionary<Type, Object>` | ** **Not Required.**                       |
| `entities` | `Object[]` | ** **Required.**                      |


