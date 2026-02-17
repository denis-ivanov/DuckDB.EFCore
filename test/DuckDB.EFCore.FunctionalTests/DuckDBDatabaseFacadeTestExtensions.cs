using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.FunctionalTests;

public static class DuckDBDatabaseFacadeTestExtensions
{
    public static void EnsureClean(this DatabaseFacade databaseFacade)
        => new DuckDBDatabaseCleaner().Clean(databaseFacade);
}
