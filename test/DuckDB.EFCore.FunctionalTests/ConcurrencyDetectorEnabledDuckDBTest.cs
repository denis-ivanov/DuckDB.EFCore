using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests;

public class ConcurrencyDetectorEnabledDuckDBTest : ConcurrencyDetectorEnabledRelationalTestBase<
    ConcurrencyDetectorEnabledDuckDBTest.ConcurrencyDetectorDuckDBFixture>
{
    public ConcurrencyDetectorEnabledDuckDBTest(ConcurrencyDetectorDuckDBFixture fixture) : base(fixture)
    {
    }

    public class ConcurrencyDetectorDuckDBFixture : ConcurrencyDetectorFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;
    }
}
