using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class QueryNoClientEvalDuckDBTest : QueryNoClientEvalTestBase<QueryNoClientEvalDuckDBFixture>
{
    public QueryNoClientEvalDuckDBTest(QueryNoClientEvalDuckDBFixture fixture) : base(fixture)
    {
    }
}