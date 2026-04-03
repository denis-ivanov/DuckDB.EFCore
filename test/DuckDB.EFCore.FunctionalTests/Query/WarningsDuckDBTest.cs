using Microsoft.EntityFrameworkCore.Query;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class WarningsDuckDBTest: WarningsTestBase<QueryNoClientEvalDuckDBFixture>
{
    public WarningsDuckDBTest(QueryNoClientEvalDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}