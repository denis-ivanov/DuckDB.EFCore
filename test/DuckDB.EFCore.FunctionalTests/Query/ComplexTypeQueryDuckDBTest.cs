using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class ComplexTypeQueryDuckDBTest : ComplexTypeQueryRelationalTestBase<ComplexTypeQueryDuckDBTest.ComplexTypeQueryDuckDBFixture>
{
    public ComplexTypeQueryDuckDBTest(ComplexTypeQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    public class ComplexTypeQueryDuckDBFixture : ComplexTypeQueryRelationalFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
