using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class OwnedQueryDuckDBTest : OwnedQueryRelationalTestBase<OwnedQueryDuckDBTest.OwnedQueryDuckDBFixture>
{
    public OwnedQueryDuckDBTest(OwnedQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    public class OwnedQueryDuckDBFixture : RelationalOwnedQueryFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
