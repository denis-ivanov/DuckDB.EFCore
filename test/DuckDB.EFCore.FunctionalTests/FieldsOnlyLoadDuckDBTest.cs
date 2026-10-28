using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore;

public class FieldsOnlyLoadDuckDBTest : FieldsOnlyLoadTestBase<FieldsOnlyLoadDuckDBTest.FieldsOnlyLoadDuckDBFixture>
{
    public FieldsOnlyLoadDuckDBTest(FieldsOnlyLoadDuckDBFixture fixture) : base(fixture)
    {
    }

    public class FieldsOnlyLoadDuckDBFixture : FieldsOnlyLoadFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
