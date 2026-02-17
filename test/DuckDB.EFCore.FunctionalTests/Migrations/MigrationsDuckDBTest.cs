using DuckDB.EFCore.FunctionalTests.TestUtilities;
using DuckDB.EFCore.Scaffolding.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Migrations;

public class MigrationsDuckDBTest : MigrationsTestBase<MigrationsDuckDBTest.MigrationsDuckDBFixture>
{
    public MigrationsDuckDBTest(MigrationsDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_required_primitive_collection_with_custom_default_value_sql_to_existing_table()
    {
        throw new NotImplementedException();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_required_primitve_collection_with_custom_default_value_sql_to_existing_table()
    {
        throw new NotImplementedException();
    }

    public override async Task Add_check_constraint_with_name()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_check_constraint_with_name());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_column_computed_with_collation(bool stored)
    {
        return base.Add_column_computed_with_collation(stored);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_column_with_ansi()
    {
        return base.Add_column_with_ansi();
    }

    public override async Task Add_column_with_check_constraint()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_column_with_check_constraint());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_column_with_comment()
    {
        return base.Add_column_with_comment();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_column_with_computedSql(bool? stored)
    {
        return base.Add_column_with_computedSql(stored);
    }

    public override async Task Add_column_with_defaultValue_datetime()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_column_with_defaultValue_datetime());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_column_with_defaultValue_string()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_column_with_defaultValue_string());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_column_with_defaultValueSql()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_column_with_defaultValueSql());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }
    
    public override async Task Add_column_with_required()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_column_with_required());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_foreign_key()
    {
        return base.Add_foreign_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_foreign_key_with_name()
    {
        return base.Add_foreign_key_with_name();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_json_columns_to_existing_table()
    {
        return base.Add_json_columns_to_existing_table();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_primary_key_composite_with_name()
    {
        return base.Add_primary_key_composite_with_name();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_primary_key_int()
    {
        return base.Add_primary_key_int();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_primary_key_string()
    {
        return base.Add_primary_key_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_primary_key_with_name()
    {
        return base.Add_primary_key_with_name();
    }

    public override async Task Add_required_primitive_collection_to_existing_table()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitive_collection_to_existing_table());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_required_primitive_collection_with_custom_converter_and_custom_default_value_to_existing_table()
    {
         var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitive_collection_with_custom_converter_and_custom_default_value_to_existing_table());
         Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_required_primitive_collection_with_custom_default_value_to_existing_table()
    {
         var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitive_collection_with_custom_default_value_to_existing_table());
         Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_required_primitive_collection_with_custom_converter_to_existing_table()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitive_collection_with_custom_converter_to_existing_table());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }
    
    public override async Task Add_required_primitve_collection_to_existing_table()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitve_collection_to_existing_table());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_required_primitve_collection_with_custom_converter_and_custom_default_value_to_existing_table()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitve_collection_with_custom_converter_and_custom_default_value_to_existing_table());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    protected override async Task Add_required_primitive_collection_with_custom_default_value_sql_to_existing_table_core(string defaultValueSql)
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitive_collection_with_custom_default_value_sql_to_existing_table_core(defaultValueSql));
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_required_primitve_collection_with_custom_default_value_to_existing_table()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_required_primitve_collection_with_custom_default_value_to_existing_table());
        Assert.Equal("Parser Error: Adding columns with constraints not yet supported", exception.Message);
    }

    public override async Task Add_unique_constraint()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_unique_constraint());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    public override async Task Add_unique_constraint_composite_with_name()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Add_unique_constraint_composite_with_name());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    public override async Task Alter_check_constraint()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Alter_check_constraint());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);   
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_add_comment()
    {
        return base.Alter_column_add_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_change_comment()
    {
        return base.Alter_column_change_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_change_computed()
    {
        return base.Alter_column_change_computed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_change_computed_recreates_indexes()
    {
        return base.Alter_column_change_computed_recreates_indexes();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_change_computed_type()
    {
        return base.Alter_column_change_computed_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_change_type()
    {
        return base.Alter_column_change_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_computed(bool? stored)
    {
        return base.Alter_column_make_computed(stored);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_non_computed()
    {
        return base.Alter_column_make_non_computed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_required()
    {
        return base.Alter_column_make_required();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_required_with_composite_index()
    {
        return base.Alter_column_make_required_with_composite_index();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_required_with_index()
    {
        return base.Alter_column_make_required_with_index();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_make_required_with_null_data()
    {
        return base.Alter_column_make_required_with_null_data();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_column_remove_comment()
    {
        return base.Alter_column_remove_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_computed_column_add_comment()
    {
        return base.Alter_computed_column_add_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_index_change_sort_order()
    {
        return base.Alter_index_change_sort_order();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_index_make_unique()
    {
        return base.Alter_index_make_unique();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Alter_sequence_all_settings()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Alter_sequence_all_settings());
        Assert.Equal("Parser Error: Expected an integer argument for option as", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_sequence_restart_with()
    {
        return base.Alter_sequence_restart_with();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_sequence_increment_by()
    {
        return base.Alter_sequence_increment_by();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_table_add_comment()
    {
        return base.Alter_table_add_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_table_add_comment_non_default_schema()
    {
        return base.Alter_table_add_comment_non_default_schema();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_table_change_comment()
    {
        return base.Alter_table_change_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Alter_table_remove_comment()
    {
        return base.Alter_table_remove_comment();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_json_entities_to_regular_owned()
    {
        return base.Convert_json_entities_to_regular_owned();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_regular_owned_entities_to_json()
    {
        return base.Convert_regular_owned_entities_to_json();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_string_column_to_a_json_column_containing_collection()
    {
        return base.Convert_string_column_to_a_json_column_containing_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_string_column_to_a_json_column_containing_reference()
    {
        return base.Convert_string_column_to_a_json_column_containing_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_string_column_to_a_json_column_containing_required_reference()
    {
        return base.Convert_string_column_to_a_json_column_containing_required_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_index_descending()
    {
        return base.Create_index_descending();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_index_descending_mixed()
    {
        return base.Create_index_descending_mixed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_index_unique()
    {
        return base.Create_index_unique();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_index_with_filter()
    {
        return base.Create_index_with_filter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_schema()
    {
        return base.Create_schema();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_sequence()
    {
        return base.Create_sequence();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_sequence_all_settings()
    {
        return base.Create_sequence_all_settings();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_sequence_long()
    {
        return base.Create_sequence_long();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_sequence_short()
    {
        return base.Create_sequence_short();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_all_settings()
    {
        return base.Create_table_all_settings();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_comments()
    {
        return base.Create_table_with_comments();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_complex_properties_mapped_to_json()
    {
        return base.Create_table_with_complex_properties_mapped_to_json();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_complex_properties_with_nested_collection_mapped_to_json()
    {
        return base.Create_table_with_complex_properties_with_nested_collection_mapped_to_json();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_complex_type_with_required_properties_on_derived_entity_in_TPH()
    {
        return base.Create_table_with_complex_type_with_required_properties_on_derived_entity_in_TPH();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_computed_column(bool? stored)
    {
        return base.Create_table_with_computed_column(stored);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_json_column()
    {
        return base.Create_table_with_json_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_json_column_explicit_json_column_names()
    {
        return base.Create_table_with_json_column_explicit_json_column_names();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_multiline_comments()
    {
        return base.Create_table_with_multiline_comments();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_table_with_optional_complex_type_with_required_properties()
    {
        return base.Create_table_with_optional_complex_type_with_required_properties();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Create_unique_index_with_filter()
    {
        return base.Create_unique_index_with_filter();
    }

    public override async Task Drop_check_constraint()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Drop_check_constraint());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Drop_column_computed_and_non_computed_with_dependency()
    {
        return base.Drop_column_computed_and_non_computed_with_dependency();
    }

    public override async Task Drop_column_primary_key()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Drop_column_primary_key());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Drop_index()
    {
        return base.Drop_index();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Drop_json_columns_from_existing_table()
    {
        return base.Drop_json_columns_from_existing_table();
    }

    public override async Task Drop_primary_key_int()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Drop_primary_key_int());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    public override async Task Drop_primary_key_string()
    {
        var exception = await Assert.ThrowsAsync<DuckDBException>(async () => await base.Drop_primary_key_string());
        Assert.Equal("Not implemented Error: No support for that ALTER TABLE option yet!", exception.Message);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Drop_sequence()
    {
        return base.Drop_sequence();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Drop_unique_constraint()
    {
        return base.Drop_unique_constraint();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Move_sequence()
    {
        return base.Move_sequence();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Move_table()
    {
        return base.Move_table();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multiop_rename_table_and_create_new_table_with_the_old_name()
    {
        return base.Multiop_rename_table_and_create_new_table_with_the_old_name();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multiop_rename_table_and_drop()
    {
        return base.Multiop_rename_table_and_drop();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_column()
    {
        return base.Rename_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_index()
    {
        return base.Rename_index();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_json_column()
    {
        return base.Rename_json_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_sequence()
    {
        return base.Rename_sequence();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_table()
    {
        return base.Rename_table();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_table_with_json_column()
    {
        return base.Rename_table_with_json_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Rename_table_with_primary_key()
    {
        return base.Rename_table_with_primary_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SqlOperation()
    {
        return base.SqlOperation();
    }

    protected override string NonDefaultCollation { get; }

    public class MigrationsDuckDBFixture : MigrationsFixtureBase
    {
        protected override string StoreName
            => nameof(MigrationsDuckDBTest);

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public override RelationalTestHelpers TestHelpers
            => DuckDBTestHelpers.Instance;

        protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
            => base.AddServices(serviceCollection)
                .AddScoped<IDatabaseModelFactory, DuckDBDatabaseModelFactory>();
    }
}
