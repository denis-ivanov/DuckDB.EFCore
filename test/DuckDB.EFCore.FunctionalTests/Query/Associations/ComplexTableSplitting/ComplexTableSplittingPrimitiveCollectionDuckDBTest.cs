using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingPrimitiveCollectionDuckDBTest: ComplexTableSplittingPrimitiveCollectionRelationalTestBase<ComplexTableSplittingDuckDBFixture>
{
    public ComplexTableSplittingPrimitiveCollectionDuckDBTest(ComplexTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Any_predicate()
    {
        return base.Any_predicate();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Contains()
    {
        return base.Contains();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Count()
    {
        return base.Count();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Index()
    {
        return base.Index();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nested_Count()
    {
        return base.Nested_Count();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_Sum()
    {
        return base.Select_Sum();
    }
}