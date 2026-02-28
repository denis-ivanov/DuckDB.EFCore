using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class QueryNoClientEvalDuckDBFixture : NorthwindQueryDuckDBFixture<NoopModelCustomizer>
{
    
}