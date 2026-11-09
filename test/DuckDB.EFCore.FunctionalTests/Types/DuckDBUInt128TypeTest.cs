using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBUInt128TypeTest : RelationalTypeTestBase<UInt128, DuckDBUInt128TypeTest.UInt128TypeFixture>
{
    public DuckDBUInt128TypeTest(UInt128TypeFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExecuteUpdate_within_json_to_another_json_property()
    {
        return base.ExecuteUpdate_within_json_to_another_json_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExecuteUpdate_within_json_to_constant()
    {
        return base.ExecuteUpdate_within_json_to_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExecuteUpdate_within_json_to_nonjson_column()
    {
        return base.ExecuteUpdate_within_json_to_nonjson_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExecuteUpdate_within_json_to_parameter()
    {
        return base.ExecuteUpdate_within_json_to_parameter();
    }

    public class UInt128TypeFixture : RelationalTypeFixtureBase<UInt128>
    {
        public override UInt128 Value { get; } = UInt128.MinValue;
        public override UInt128 OtherValue { get; } = UInt128.MaxValue;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
