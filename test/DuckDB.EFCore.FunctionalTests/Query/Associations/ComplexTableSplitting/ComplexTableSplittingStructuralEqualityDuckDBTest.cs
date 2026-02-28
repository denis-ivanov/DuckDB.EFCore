using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingStructuralEqualityDuckDBTest: ComplexTableSplittingStructuralEqualityRelationalTestBase<ComplexTableSplittingDuckDBFixture>
{
    public ComplexTableSplittingStructuralEqualityDuckDBTest(ComplexTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}