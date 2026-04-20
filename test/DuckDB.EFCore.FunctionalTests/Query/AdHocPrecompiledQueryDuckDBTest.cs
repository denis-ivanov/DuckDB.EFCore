using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocPrecompiledQueryDuckDBTest: AdHocPrecompiledQueryRelationalTestBase
{
    public AdHocPrecompiledQueryDuckDBTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Index_no_evaluatability()
    {
        return base.Index_no_evaluatability();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Index_with_captured_variable()
    {
        return base.Index_with_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task JsonScalar()
    {
        return base.JsonScalar();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Materialize_non_public()
    {
        return base.Materialize_non_public();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_entity_with_property_requiring_converter_with_closure_works()
    {
        return base.Projecting_entity_with_property_requiring_converter_with_closure_works();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_expression_requiring_converter_without_closure_works()
    {
        return base.Projecting_expression_requiring_converter_without_closure_works();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_property_requiring_converter_with_closure_is_not_supported()
    {
        return base.Projecting_property_requiring_converter_with_closure_is_not_supported();
    }

    protected override bool AlwaysPrintGeneratedSources
        => false;

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
        => DuckDBPrecompiledQueryTestHelpers.Instance;
}