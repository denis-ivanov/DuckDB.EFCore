using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class WarningsDuckDBTest: WarningsTestBase<QueryNoClientEvalDuckDBFixture>
{
    public WarningsDuckDBTest(QueryNoClientEvalDuckDBFixture fixture) : base(fixture)
    {
    }
}