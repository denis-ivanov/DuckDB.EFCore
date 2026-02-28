using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class GearsOfWarFromSqlQueryDuckDBTest : GearsOfWarFromSqlQueryTestBase<GearsOfWarQueryDuckDBFixture>
{
    public GearsOfWarFromSqlQueryDuckDBTest(GearsOfWarQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}