using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;

public class OwnedJsonProjectionDuckDBTest: OwnedJsonProjectionRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonProjectionDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
