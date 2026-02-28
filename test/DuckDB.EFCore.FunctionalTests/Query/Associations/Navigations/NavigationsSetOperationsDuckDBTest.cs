using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsSetOperationsDuckDBTest : NavigationsSetOperationsRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsSetOperationsDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}