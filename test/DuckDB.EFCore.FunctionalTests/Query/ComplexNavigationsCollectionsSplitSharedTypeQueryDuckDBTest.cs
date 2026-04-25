using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class ComplexNavigationsCollectionsSplitSharedTypeQueryDuckDBTest : ComplexNavigationsCollectionsSplitSharedTypeQueryRelationalTestBase<ComplexNavigationsSharedTypeQueryDuckDBFixture>
{
    public ComplexNavigationsCollectionsSplitSharedTypeQueryDuckDBTest(ComplexNavigationsSharedTypeQueryDuckDBFixture fixture)
        : base(fixture)
    {
    }
}
