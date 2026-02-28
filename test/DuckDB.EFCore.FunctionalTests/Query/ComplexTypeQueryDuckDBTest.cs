using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class ComplexTypeQueryDuckDBTest: ComplexTypeQueryRelationalTestBase<ComplexTypeQueryDuckDBTest.ComplexTypeQueryDuckDBFixture>
{
    public class ComplexTypeQueryDuckDBFixture : ComplexTypeQueryRelationalFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }

    public ComplexTypeQueryDuckDBTest(ComplexTypeQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Same_entity_with_complex_type_projected_twice_with_pushdown_as_part_of_another_projection(bool async)
    {
        return base.Same_entity_with_complex_type_projected_twice_with_pushdown_as_part_of_another_projection(async);
    }
}
