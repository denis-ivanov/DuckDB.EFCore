using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBFloatTypeTest : RelationalTypeTestBase<float, DuckDBFloatTypeTest.FloatTypeFixture>
{
    public DuckDBFloatTypeTest(FloatTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class FloatTypeFixture : RelationalTypeFixtureBase<float>
    {
        public override float Value { get; } = 30.5f;
        public override float OtherValue { get; } = 30f;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
