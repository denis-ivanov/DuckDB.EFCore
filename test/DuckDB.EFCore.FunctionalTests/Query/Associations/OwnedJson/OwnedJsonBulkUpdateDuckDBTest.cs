using Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.OwnedJson;

public class OwnedJsonBulkUpdateDuckDBTest: OwnedJsonBulkUpdateRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonBulkUpdateDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}