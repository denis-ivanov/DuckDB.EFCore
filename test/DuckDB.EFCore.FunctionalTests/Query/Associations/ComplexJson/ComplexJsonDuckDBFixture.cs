using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonDuckDBFixture : ComplexJsonRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}
