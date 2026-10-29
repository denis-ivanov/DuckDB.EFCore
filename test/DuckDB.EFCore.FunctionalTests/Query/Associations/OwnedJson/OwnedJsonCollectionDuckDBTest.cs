using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;

public class OwnedJsonCollectionDuckDBTest: OwnedJsonCollectionRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonCollectionDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
