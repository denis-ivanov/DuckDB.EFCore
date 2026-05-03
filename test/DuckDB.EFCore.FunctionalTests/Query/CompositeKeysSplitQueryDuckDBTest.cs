using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class CompositeKeysSplitQueryDuckDBTest : CompositeKeysSplitQueryRelationalTestBase<CompositeKeysQueryDuckDBFixture>
{
    public CompositeKeysSplitQueryDuckDBTest(CompositeKeysQueryDuckDBFixture fixture) : base(fixture)
    {
    }
}