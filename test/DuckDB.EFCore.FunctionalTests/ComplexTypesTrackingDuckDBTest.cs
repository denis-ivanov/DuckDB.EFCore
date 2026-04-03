using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests;

public class ComplexTypesTrackingDuckDBTest : ComplexTypesTrackingRelationalTestBase<ComplexTypesTrackingDuckDBTest.DuckDBFixture>
{
    public ComplexTypesTrackingDuckDBTest(DuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_save_default_values_in_optional_complex_property_with_multiple_properties(bool async)
    {
        await base.Can_save_default_values_in_optional_complex_property_with_multiple_properties(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_save_null_second_level_complex_property_with_required_properties(bool async)
    {
        await base.Can_save_null_second_level_complex_property_with_required_properties(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_save_null_third_level_complex_property_with_all_optional_properties(bool async)
    {
        await base.Can_save_null_third_level_complex_property_with_all_optional_properties(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_field_collections(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_field_collections(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_objects(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_objects(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_objects_with_fields(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_objects_with_fields(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_property_bag_collections(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_property_bag_collections(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_readonly_structs(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_readonly_structs(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_record_collections(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_record_collections(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_record_collections_with_fields(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_record_collections_with_fields(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_record_objects(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_record_objects(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_record_objects_with_fields(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_record_objects_with_fields(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_structs(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_structs(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_structs_with_fields(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_structs_with_fields(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_track_entity_with_complex_type_collections(EntityState state, bool async)
    {
        await base.Can_track_entity_with_complex_type_collections(state, async);
    }

    public class DuckDBFixture : RelationalFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
