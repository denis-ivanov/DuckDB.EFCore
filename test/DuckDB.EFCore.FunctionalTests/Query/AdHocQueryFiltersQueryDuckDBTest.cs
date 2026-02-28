using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class AdHocQueryFiltersQueryDuckDBTest : AdHocQueryFiltersQueryRelationalTestBase
{
    public AdHocQueryFiltersQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Invoke_inside_query_filter_gets_correctly_evaluated_during_translation()
    {
        return base.Invoke_inside_query_filter_gets_correctly_evaluated_during_translation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MultiContext_query_filter_test()
    {
        return base.MultiContext_query_filter_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters()
    {
        return base.Named_query_filters();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_anonymous()
    {
        return base.Named_query_filters_anonymous();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_anonymous_ignore()
    {
        return base.Named_query_filters_anonymous_ignore();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_caching()
    {
        return base.Named_query_filters_caching();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_ignore_all()
    {
        return base.Named_query_filters_ignore_all();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_ignore_some()
    {
        return base.Named_query_filters_ignore_some();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_overwriting()
    {
        return base.Named_query_filters_overwriting();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Named_query_filters_removing()
    {
        return base.Named_query_filters_removing();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Query_filter_with_contains_evaluates_correctly()
    {
        return base.Query_filter_with_contains_evaluates_correctly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Query_filter_with_pk_fk_optimization()
    {
        return base.Query_filter_with_pk_fk_optimization();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Self_reference_in_query_filter_works()
    {
        return base.Self_reference_in_query_filter_works();
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}