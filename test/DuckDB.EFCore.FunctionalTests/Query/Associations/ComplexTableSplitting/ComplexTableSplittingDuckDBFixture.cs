using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingDuckDBFixture : ComplexTableSplittingRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}