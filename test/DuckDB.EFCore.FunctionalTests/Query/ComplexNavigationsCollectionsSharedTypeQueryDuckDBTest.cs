using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class ComplexNavigationsCollectionsSharedTypeQueryDuckDBTest : ComplexNavigationsCollectionsSharedTypeQueryRelationalTestBase<ComplexNavigationsSharedTypeQueryDuckDBFixture>
{
    public ComplexNavigationsCollectionsSharedTypeQueryDuckDBTest(ComplexNavigationsSharedTypeQueryDuckDBFixture fixture)
        : base(fixture)
    {
    }
}
