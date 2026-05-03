using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class CompositeKeysQueryDuckDBTest : CompositeKeysQueryRelationalTestBase<CompositeKeysQueryDuckDBFixture>
{
    public CompositeKeysQueryDuckDBTest(CompositeKeysQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}
