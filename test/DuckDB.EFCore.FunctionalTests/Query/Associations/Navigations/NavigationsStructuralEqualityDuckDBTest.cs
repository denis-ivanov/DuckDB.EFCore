using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsStructuralEqualityDuckDBTest : NavigationsStructuralEqualityRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsStructuralEqualityDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}