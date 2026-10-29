using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;

public class OwnedJsonMiscellaneousDuckDBTest: OwnedJsonMiscellaneousRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonMiscellaneousDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
