using DuckDB.EFCore.FunctionalTests;
using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class FunkyDataQueryDuckDBTest : FunkyDataQueryTestBase<FunkyDataQueryDuckDBTest.FunkyDataQueryDuckDBFixture>
{
    public FunkyDataQueryDuckDBTest(FunkyDataQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_FirstOrDefault_and_LastOrDefault(bool async)
    {
        return base.String_FirstOrDefault_and_LastOrDefault(async);
    }

    public class FunkyDataQueryDuckDBFixture : FunkyDataQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
