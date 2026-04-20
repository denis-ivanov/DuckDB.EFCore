using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocQuerySplittingQueryDuckDBTest: AdHocQuerySplittingQueryTestBase
{
    public AdHocQuerySplittingQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override DbContextOptionsBuilder SetQuerySplittingBehavior(DbContextOptionsBuilder optionsBuilder, QuerySplittingBehavior splittingBehavior)
    {
        new DuckDBDbContextOptionsBuilder(optionsBuilder).UseQuerySplittingBehavior(splittingBehavior);

        return optionsBuilder;
    }

    protected override DbContextOptionsBuilder ClearQuerySplittingBehavior(DbContextOptionsBuilder optionsBuilder)
    {
        throw new NotImplementedException();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_configure_SingleQuery_at_context_level()
    {
        return base.Can_configure_SingleQuery_at_context_level();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_configure_SplitQuery_at_context_level()
    {
        return base.Can_configure_SplitQuery_at_context_level();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_async()
    {
        return base.Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_sync()
    {
        return base.Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_sync();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NoTracking_split_query_creates_only_required_instances(bool async)
    {
        return base.NoTracking_split_query_creates_only_required_instances(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SplitQuery_disposes_inner_data_readers()
    {
        return base.SplitQuery_disposes_inner_data_readers();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Unconfigured_query_splitting_behavior_throws_a_warning()
    {
        return base.Unconfigured_query_splitting_behavior_throws_a_warning();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Using_AsSingleQuery_without_context_configuration_does_not_throw_warning()
    {
        return base.Using_AsSingleQuery_without_context_configuration_does_not_throw_warning();
    }
}