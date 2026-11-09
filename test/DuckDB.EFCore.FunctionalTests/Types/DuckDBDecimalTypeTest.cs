using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBDecimalTypeTest : RelationalTypeTestBase<decimal, DuckDBDecimalTypeTest.DecimalTypeFixture>
{
    public DuckDBDecimalTypeTest(DecimalTypeFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task ExecuteUpdate_within_json_to_parameter()
    {
        await base.ExecuteUpdate_within_json_to_parameter();
    }

    public class DecimalTypeFixture : RelationalTypeFixtureBase<decimal>
    {
        public override decimal Value { get; } = 30.5m;
        public override decimal OtherValue { get; } = 30m;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
