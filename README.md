# DuckDB.EFCore

DuckDB provider for Entity Framework Core.

[![NuGet](https://img.shields.io/nuget/v/DuckDB.EFCore.svg)](https://www.nuget.org/packages/DuckDB.EFCore)

## Installation

Install the [DuckDB.EFCore](https://www.nuget.org/packages/DuckDB.EFCore) NuGet package:

### .NET CLI
```bash
dotnet add package DuckDB.EFCore
```

### Package Manager
```powershell
Install-Package DuckDB.EFCore
```

## Usage

To use DuckDB in your Entity Framework Core application, call `UseDuckDB` in your `OnConfiguring` method or when configuring your `DbContext` in `AddDbContext`.

### Example

```csharp
public class MyDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseDuckDB("Data Source=my_database.db");
    }
}

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
```

### Dependency Injection

```csharp
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseDuckDB("Data Source=my_database.db"));
```

## Supported Features

- Basic CRUD operations
- LINQ queries
- Migrations
- Transactions
- Raw SQL queries

## Acknowledgments

This provider is built on top of the [DuckDB.NET](https://github.com/Giorgi/DuckDB.NET) ADO.NET provider.
