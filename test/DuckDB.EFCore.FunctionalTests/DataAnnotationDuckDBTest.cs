using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class DataAnnotationDuckDBTest : DataAnnotationRelationalTestBase<DataAnnotationDuckDBTest.DataAnnotationDuckDBFixture>
{
    public DataAnnotationDuckDBTest(DataAnnotationDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MaxLengthAttribute_throws_while_inserting_value_longer_than_max_length()
    {
        return base.MaxLengthAttribute_throws_while_inserting_value_longer_than_max_length();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task StringLengthAttribute_throws_while_inserting_value_longer_than_max_length()
    {
        return base.StringLengthAttribute_throws_while_inserting_value_longer_than_max_length();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task TimestampAttribute_throws_if_value_in_database_changed()
    {
        return base.TimestampAttribute_throws_if_value_in_database_changed();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    protected override TestHelpers TestHelpers
        => DuckDBTestHelpers.Instance;

    public class DataAnnotationDuckDBFixture : DataAnnotationRelationalFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;
    }
}
