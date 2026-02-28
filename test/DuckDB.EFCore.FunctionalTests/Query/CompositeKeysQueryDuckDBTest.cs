using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class CompositeKeysQueryDuckDBTest : CompositeKeysQueryRelationalTestBase<CompositeKeysQueryDuckDBFixture>
{
    public CompositeKeysQueryDuckDBTest(CompositeKeysQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}