using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class MaterializationInterceptionDuckDBTest : MaterializationInterceptionTestBase<MaterializationInterceptionDuckDBTest.DuckDBLibraryContext>
{
    public MaterializationInterceptionDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Binding_interceptors_are_used_by_queries(bool inject, bool usePooling)
    {
        await base.Binding_interceptors_are_used_by_queries(inject, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Binding_interceptors_are_used_when_creating_instances(bool inject, bool usePooling)
    {
        await base.Binding_interceptors_are_used_when_creating_instances(inject, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Intercept_query_materialization_for_empty_constructor(bool inject, bool usePooling)
    {
        await base.Intercept_query_materialization_for_empty_constructor(inject, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Intercept_query_materialization_for_full_constructor(bool inject, bool usePooling)
    {
        await base.Intercept_query_materialization_for_full_constructor(inject, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Intercept_query_materialization_with_owned_types(bool async, bool usePooling)
    {
        await base.Intercept_query_materialization_with_owned_types(async, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Intercept_query_materialization_with_owned_types_projecting_collection(bool async, bool usePooling)
    {
        await base.Intercept_query_materialization_with_owned_types_projecting_collection(async, usePooling);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [ClassData(typeof(DataGenerator<bool,bool>))]
    public override async Task Multiple_materialization_interceptors_can_be_used(bool inject, bool usePooling)
    {
        await base.Multiple_materialization_interceptors_can_be_used(inject, usePooling);
    }

    public class DuckDBLibraryContext(DbContextOptions options) : LibraryContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestEntity30244>().OwnsMany(e => e.Settings, b => b.ToJson());
        }
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory 
        => DuckDBTestStoreFactory.Instance;
}
