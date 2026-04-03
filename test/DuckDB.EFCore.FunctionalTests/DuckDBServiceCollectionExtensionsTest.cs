using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;

namespace DuckDB.EFCore.FunctionalTests;

public class DuckDBServiceCollectionExtensionsTest : RelationalServiceCollectionExtensionsTestBase
{
    public DuckDBServiceCollectionExtensionsTest()
        : base(DuckDBTestHelpers.Instance)
    {
    }
}