using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBUInt128TypeTest : RelationalTypeTestBase<UInt128, DuckDBUInt128TypeTest.UInt128TypeFixture>
{
    public DuckDBUInt128TypeTest(UInt128TypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class UInt128TypeFixture : RelationalTypeFixtureBase<UInt128>
    {
        public override UInt128 Value { get; } = UInt128.MinValue;
        public override UInt128 OtherValue { get; } = UInt128.MaxValue;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
