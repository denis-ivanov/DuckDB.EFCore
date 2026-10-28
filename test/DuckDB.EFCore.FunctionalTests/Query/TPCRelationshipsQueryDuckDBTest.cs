using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPCRelationshipsQueryDuckDBTest : TPCRelationshipsQueryTestBase<TPCRelationshipsQueryDuckDBTest.TPCRelationshipsQueryDuckDBFixture>
{
    public TPCRelationshipsQueryDuckDBTest(TPCRelationshipsQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class TPCRelationshipsQueryDuckDBFixture : TPCRelationshipsQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
