using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;

namespace DuckDB.EFCore.FunctionalTests.TestModels.Northwind;

public class NorthwindDuckDBContext(DbContextOptions options) : NorthwindRelationalContext(options);
