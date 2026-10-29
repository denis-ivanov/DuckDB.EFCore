using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class QueryFilterFuncletizationDuckDBTest : QueryFilterFuncletizationTestBase<QueryFilterFuncletizationDuckDBTest.QueryFilterFuncletizationDuckDBFixture>
{
    public QueryFilterFuncletizationDuckDBTest(QueryFilterFuncletizationDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class QueryFilterFuncletizationDuckDBFixture : QueryFilterFuncletizationRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
