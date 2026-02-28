using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class BuiltInDataTypesDuckDBTest : BuiltInDataTypesTestBase<BuiltInDataTypesDuckDBTest.BuiltInDataTypesDuckDBFixture>
{
    public BuiltInDataTypesDuckDBTest(BuiltInDataTypesDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_insert_and_read_back_all_non_nullable_data_types()
    {
        return base.Can_insert_and_read_back_all_non_nullable_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null()
    {
        return base.Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_insert_and_read_back_non_nullable_backed_data_types()
    {
        return base.Can_insert_and_read_back_non_nullable_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_insert_and_read_back_nullable_backed_data_types()
    {
        return base.Can_insert_and_read_back_nullable_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_insert_and_read_back_object_backed_data_types()
    {
        return base.Can_insert_and_read_back_object_backed_data_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_read_back_bool_mapped_as_int_through_navigation()
    {
        return base.Can_read_back_bool_mapped_as_int_through_navigation();
    }

    public class BuiltInDataTypesDuckDBFixture : BuiltInDataTypesFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

        public override bool StrictEquality { get; }

        public override bool SupportsAnsi => false;

        public override bool SupportsUnicodeToAnsiConversion => false;

        public override bool SupportsLargeStringComparisons { get; }

        public override bool SupportsBinaryKeys { get; }

        public override bool SupportsDecimalComparisons { get; }

        public override DateTime DefaultDateTime => DateTime.Parse("1754-08-30T22:43:41.1286549");

        public override bool PreservesDateTimeKind { get; }

        public TestSqlLoggerFactory TestSqlLoggerFactory { get; }
    }
}
