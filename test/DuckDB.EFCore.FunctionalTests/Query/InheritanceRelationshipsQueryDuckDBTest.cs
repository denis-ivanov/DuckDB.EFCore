using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class InheritanceRelationshipsQueryDuckDBTest : InheritanceRelationshipsQueryRelationalTestBase<InheritanceRelationshipsQueryDuckDBTest.InheritanceRelationshipsQueryDuckDBFixture>
{
    public InheritanceRelationshipsQueryDuckDBTest(InheritanceRelationshipsQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class InheritanceRelationshipsQueryDuckDBFixture : InheritanceRelationshipsQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
