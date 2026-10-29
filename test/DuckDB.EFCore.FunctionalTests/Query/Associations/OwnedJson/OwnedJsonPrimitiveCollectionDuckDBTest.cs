using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;

public class OwnedJsonPrimitiveCollectionDuckDBTest : OwnedJsonPrimitiveCollectionRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonPrimitiveCollectionDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
