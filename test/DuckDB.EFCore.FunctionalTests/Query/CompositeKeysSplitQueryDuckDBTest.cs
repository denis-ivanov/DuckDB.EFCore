using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class CompositeKeysSplitQueryDuckDBTest : CompositeKeysSplitQueryRelationalTestBase<CompositeKeysQueryDuckDBFixture>
{
    public CompositeKeysSplitQueryDuckDBTest(CompositeKeysQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}