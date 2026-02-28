using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingMiscellaneousDuckDBTest: ComplexTableSplittingMiscellaneousRelationalTestBase<ComplexTableSplittingDuckDBFixture>
{
    public ComplexTableSplittingMiscellaneousDuckDBTest(ComplexTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}