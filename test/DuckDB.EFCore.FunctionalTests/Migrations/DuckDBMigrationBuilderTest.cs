using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Migrations;

public class DuckDBMigrationBuilderTest
{
    [ConditionalFact]
    public void IsDuckDB_when_using_DuckDB()
    {
        var migrationBuilder = new MigrationBuilder("DuckDB.EFCore");
        Assert.True(migrationBuilder.IsDuckDB());
    }

    [ConditionalFact]
    public void Not_IsDuckDB_when_using_different_provider()
    {
        var migrationBuilder = new MigrationBuilder("Microsoft.EntityFrameworkCore.InMemory");
        Assert.False(migrationBuilder.IsDuckDB());
    }
}
