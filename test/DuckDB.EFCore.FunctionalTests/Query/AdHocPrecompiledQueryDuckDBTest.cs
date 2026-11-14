using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocPrecompiledQueryDuckDBTest : AdHocPrecompiledQueryRelationalTestBase
{
    public AdHocPrecompiledQueryDuckDBTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_entity_with_property_requiring_converter_with_closure_works()
    {
        return base.Projecting_entity_with_property_requiring_converter_with_closure_works();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_expression_requiring_converter_without_closure_works()
    {
        return base.Projecting_expression_requiring_converter_without_closure_works();
    }

    protected override bool AlwaysPrintGeneratedSources
        => false;

    protected override ITestStoreFactory NonSharedTestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
        => DuckDBPrecompiledQueryTestHelpers.Instance;
}
