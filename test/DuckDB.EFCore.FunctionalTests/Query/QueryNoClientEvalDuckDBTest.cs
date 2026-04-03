using Microsoft.EntityFrameworkCore.Query;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class QueryNoClientEvalDuckDBTest : QueryNoClientEvalTestBase<QueryNoClientEvalDuckDBFixture>
{
    public QueryNoClientEvalDuckDBTest(QueryNoClientEvalDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
