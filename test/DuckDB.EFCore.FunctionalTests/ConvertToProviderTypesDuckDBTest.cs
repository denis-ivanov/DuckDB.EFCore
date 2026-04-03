using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests;

public class ConvertToProviderTypesDuckDBTest : ConvertToProviderTypesTestBase<ConvertToProviderTypesDuckDBTest.ConvertToProviderTypesDuckDBFixture>
{
    public ConvertToProviderTypesDuckDBTest(ConvertToProviderTypesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_compare_enum_to_constant()
    {
        await base.Can_compare_enum_to_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_compare_enum_to_parameter()
    {
        await base.Can_compare_enum_to_parameter();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_filter_projection_with_captured_enum_variable(bool async)
    {
        await base.Can_filter_projection_with_captured_enum_variable(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_filter_projection_with_inline_enum_variable(bool async)
    {
        await base.Can_filter_projection_with_inline_enum_variable(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_all_non_nullable_data_types()
    {
        await base.Can_insert_and_read_back_all_non_nullable_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null()
    {
        await base.Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_null()
    {
        await base.Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_non_nullable_backed_data_types()
    {
        await base.Can_insert_and_read_back_non_nullable_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_nullable_backed_data_types()
    {
        await base.Can_insert_and_read_back_nullable_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_object_backed_data_types()
    {
        await base.Can_insert_and_read_back_object_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_with_binary_key()
    {
        await base.Can_insert_and_read_back_with_binary_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_with_null_binary_foreign_key()
    {
        await base.Can_insert_and_read_back_with_null_binary_foreign_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_with_null_string_foreign_key()
    {
        await base.Can_insert_and_read_back_with_null_string_foreign_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_with_string_key()
    {
        await base.Can_insert_and_read_back_with_string_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_with_max_length_set()
    {
        await base.Can_insert_and_read_with_max_length_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_query_multiline_string()
    {
        await base.Can_insert_query_multiline_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_perform_query_with_ansi_strings_test()
    {
        await base.Can_perform_query_with_ansi_strings_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_perform_query_with_max_length()
    {
        await base.Can_perform_query_with_max_length();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_using_any_data_type()
    {
        await base.Can_query_using_any_data_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_using_any_data_type_nullable_shadow()
    {
        await base.Can_query_using_any_data_type_nullable_shadow();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_using_any_data_type_shadow()
    {
        await base.Can_query_using_any_data_type_shadow();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_using_any_nullable_data_type()
    {
        await base.Can_query_using_any_nullable_data_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_using_any_nullable_data_type_as_literal()
    {
        await base.Can_query_using_any_nullable_data_type_as_literal();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_query_with_null_parameters_using_any_nullable_data_type()
    {
        await base.Can_query_with_null_parameters_using_any_nullable_data_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_back_bool_mapped_as_int_through_navigation()
    {
        await base.Can_read_back_bool_mapped_as_int_through_navigation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_back_mapped_enum_from_collection_first_or_default()
    {
        await base.Can_read_back_mapped_enum_from_collection_first_or_default();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_datetime_reading_null_from_database()
    {
        await base.Optional_datetime_reading_null_from_database();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Equals_method_over_enum_works()
    {
        base.Equals_method_over_enum_works();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Object_equals_method_over_enum_works()
    {
        base.Object_equals_method_over_enum_works();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Object_to_string_conversion()
    {
        await base.Object_to_string_conversion();
    }

    public class ConvertToProviderTypesDuckDBFixture : ConvertToProviderTypesFixtureBase, ITestSqlLoggerFactory
    {
        public override bool StrictEquality
            => false;

        public override bool SupportsAnsi
            => false;

        public override bool SupportsUnicodeToAnsiConversion
            => true;

        public override bool SupportsLargeStringComparisons
            => true;

        public override bool SupportsDecimalComparisons
            => false;

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        public override bool SupportsBinaryKeys
            => true;

        public override DateTime DefaultDateTime
            => new();

        public override bool PreservesDateTimeKind
            => true;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            // TODO
        }
    }
}