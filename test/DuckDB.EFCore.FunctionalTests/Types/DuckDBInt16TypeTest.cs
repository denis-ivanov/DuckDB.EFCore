using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBInt16TypeTest : RelationalTypeTestBase<short, DuckDBInt16TypeTest.ShortTypeFixture>
{
    public DuckDBInt16TypeTest(ShortTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class ShortTypeFixture : RelationalTypeFixtureBase<short>
    {
        public override short Value { get; } = short.MinValue;
        public override short OtherValue { get; } = short.MaxValue;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
