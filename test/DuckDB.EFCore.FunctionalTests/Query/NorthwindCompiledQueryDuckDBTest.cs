using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindCompiledQueryDuckDBTest : NorthwindCompiledQueryTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindCompiledQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Keyless_query()
    {
        base.Keyless_query();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Keyless_query_async()
    {
        return base.Keyless_query_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Keyless_query_first()
    {
        base.Keyless_query_first();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Keyless_query_first_async()
    {
        return base.Keyless_query_first_async();
    }
}