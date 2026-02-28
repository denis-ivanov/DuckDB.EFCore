using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingBulkUpdateDuckDBTest: ComplexTableSplittingBulkUpdateRelationalTestBase<ComplexTableSplittingDuckDBFixture>
{
    public ComplexTableSplittingBulkUpdateDuckDBTest(ComplexTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_inside_primitive_collection()
    {
        return base.Update_inside_primitive_collection();
    }
}