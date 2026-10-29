using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;

public class OwnedJsonStructuralEqualityDuckDBTest: OwnedJsonStructuralEqualityRelationalTestBase<OwnedJsonDuckDBFixture>
{
    public OwnedJsonStructuralEqualityDuckDBTest(OwnedJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
