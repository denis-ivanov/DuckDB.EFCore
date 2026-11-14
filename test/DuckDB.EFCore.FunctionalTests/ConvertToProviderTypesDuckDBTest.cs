using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class ConvertToProviderTypesDuckDBTest : ConvertToProviderTypesTestBase<ConvertToProviderTypesDuckDBTest.ConvertToProviderTypesDuckDBFixture>
{
    public ConvertToProviderTypesDuckDBTest(ConvertToProviderTypesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = "DateTimeOffset with non-zero offset, https://github.com/dotnet/efcore/issues/26068")]
    public override async Task Can_insert_and_read_back_object_backed_data_types()
    {
        await base.Can_insert_and_read_back_object_backed_data_types();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_and_read_back_with_string_key()
    {
        await base.Can_insert_and_read_back_with_string_key();
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
    }
}
