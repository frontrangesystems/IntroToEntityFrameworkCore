# Intro to Entity Framework Core

An introduction to Entity Framework Core using SQL Server.

## Project Creation

The project was created using the .Net CLI. The following command will create the project:

```
dotnet new console
```

## Nuget Packages

There are several packages that are used in this project. The following packages are installed:

* ConsoleTables
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.EntityFrameworkCore.Tools.DotNet
* Microsoft.EntityFrameworkCore.SqlServer

To add the `ConsoleTables` package, use the following command in the `Terminal`:

```
dotnet add package ConsoleTables
```

Repeat for the remaining packages.

## Scaffolding

In this project we used code first with an empty database. If you are using an existing database, customize one of the commands below.

### VS Code

In the terminal enter the following command:

```shell
dotnet ef dbcontext scaffold "Server=.;Database=Movies;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entity
```

>**Note:** The `-o` flag is the output directory.

### Visual Studio

Open the `Package Manager Console` and enter the following command:

```shell
Scaffold-DbContext "Server=.;Database=Movies;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity
```

## Migrations

Migrations are an integral part of `Entity Framework Core`. In order to perform a migration, use the following steps:

1. Make changes to entities
2. If adding an entity, add the collection to the context.
    
    For example, use the following code to add a collection of `Person` entities to the context:
    
    ```csharp
    public virtual DbSet<Person> People { get; set; }
    ```

3. To create a migration named `Initial`, use the following command:

    ```
    dotnet ef migrations add Initial
    ```

4. To script the changes, use the `script` parameter:

    ```
    dotnet ef migrations script
    ```

5. If you want to apply the migration to the database, use the following command:

    ```
    dotnet ef database update
    ```

## Resources

Below are resources for further learning.

* [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/#pivot=efcore)
* [nuget](https://www.nuget.org/)
* [edX Course - Data Access in C# and .NET Core](https://www.edx.org/course/data-access-c-net-core-microsoft-dev258x)