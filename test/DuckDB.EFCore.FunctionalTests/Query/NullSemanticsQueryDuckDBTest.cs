using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.NullSemanticsModel;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NullSemanticsQueryDuckDBTest : NullSemanticsQueryTestBase<NullSemanticsQueryDuckDBFixture>
{
    public NullSemanticsQueryDuckDBTest(NullSemanticsQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_string_FirstOrDefault_compared_to_nullable_string_LastOrDefault(bool async)
    {
        return base.Nullable_string_FirstOrDefault_compared_to_nullable_string_LastOrDefault(async);
    }

    protected override NullSemanticsContext CreateContext(bool useRelationalNulls = false)
    {
        var options = new DbContextOptionsBuilder(Fixture.CreateOptions());

        if (useRelationalNulls)
        {
            new DuckDBDbContextOptionsBuilder(options).UseRelationalNulls();
        }

        var context = new NullSemanticsContext(options.Options);

        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return context;
    }
}
