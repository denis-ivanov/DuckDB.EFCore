using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBDoubleTypeTest : RelationalTypeTestBase<double, DuckDBDoubleTypeTest.DoubleTypeFixture>
{
    public DuckDBDoubleTypeTest(DoubleTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class DoubleTypeFixture : RelationalTypeFixtureBase<double>
    {
        public override double Value { get; } = 30.5d;
        public override double OtherValue { get; } = 30d;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
