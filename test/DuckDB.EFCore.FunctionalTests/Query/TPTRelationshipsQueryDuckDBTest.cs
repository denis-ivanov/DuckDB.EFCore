using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTRelationshipsQueryDuckDBTest : TPTRelationshipsQueryTestBase<TPTRelationshipsQueryDuckDBTest.TPTRelationshipsQueryDuckDBFixture>
{
    public TPTRelationshipsQueryDuckDBTest(TPTRelationshipsQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    public class TPTRelationshipsQueryDuckDBFixture : TPTRelationshipsQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
