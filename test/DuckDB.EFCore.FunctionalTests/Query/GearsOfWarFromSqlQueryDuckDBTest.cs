using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class GearsOfWarFromSqlQueryDuckDBTest : GearsOfWarFromSqlQueryTestBase<GearsOfWarQueryDuckDBFixture>
{
    public GearsOfWarFromSqlQueryDuckDBTest(GearsOfWarQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}
