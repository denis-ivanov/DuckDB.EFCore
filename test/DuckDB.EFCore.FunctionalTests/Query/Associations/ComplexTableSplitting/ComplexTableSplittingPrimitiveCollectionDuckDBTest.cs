using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingPrimitiveCollectionDuckDBTest: ComplexTableSplittingPrimitiveCollectionRelationalTestBase<ComplexTableSplittingDuckDBFixture>
{
    public ComplexTableSplittingPrimitiveCollectionDuckDBTest(ComplexTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
