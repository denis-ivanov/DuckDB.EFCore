using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests;

public class ConcurrencyDetectorDisabledDuckDBTest : ConcurrencyDetectorDisabledRelationalTestBase<
    ConcurrencyDetectorDisabledDuckDBTest.ConcurrencyDetectorSqlServerFixture>
{
    public ConcurrencyDetectorDisabledDuckDBTest(ConcurrencyDetectorSqlServerFixture fixture) : base(fixture)
    {
    }

    public class ConcurrencyDetectorSqlServerFixture : ConcurrencyDetectorFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => builder.EnableThreadSafetyChecks(enableChecks: false);
    }
}
