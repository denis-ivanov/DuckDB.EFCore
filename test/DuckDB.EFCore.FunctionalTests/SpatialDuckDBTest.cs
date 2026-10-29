using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microsoft.EntityFrameworkCore;

public class SpatialDuckDBTest : SpatialTestBase<SpatialDuckDBFixture>
{
    public SpatialDuckDBTest(SpatialDuckDBFixture fixture) : base(fixture)
    {
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}