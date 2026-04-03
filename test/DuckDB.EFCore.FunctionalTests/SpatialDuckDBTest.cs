using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests;

[SpatialiteRequired]
public class SpatialDuckDBTest : SpatialTestBase<SpatialDuckDBFixture>
{
    public SpatialDuckDBTest(SpatialDuckDBFixture fixture) : base(fixture)
    {
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}