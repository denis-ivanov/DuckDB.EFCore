using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBInt128TypeTest : RelationalTypeTestBase<Int128, DuckDBInt128TypeTest.Int128TypeFixture>
{
    public DuckDBInt128TypeTest(Int128TypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class Int128TypeFixture : RelationalTypeFixtureBase<Int128>
    {
        public override Int128 Value { get; } = Int128.MinValue;
        public override Int128 OtherValue { get; } = Int128.MaxValue;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
