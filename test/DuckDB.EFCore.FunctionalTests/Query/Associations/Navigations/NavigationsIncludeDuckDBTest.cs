using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsIncludeDuckDBTest: NavigationsIncludeRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsIncludeDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}