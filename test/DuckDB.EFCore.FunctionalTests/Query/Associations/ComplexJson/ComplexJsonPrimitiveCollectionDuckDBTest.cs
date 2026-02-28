using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonPrimitiveCollectionDuckDBTest: ComplexJsonPrimitiveCollectionRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonPrimitiveCollectionDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
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

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Index()
    {
        return base.Index();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
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