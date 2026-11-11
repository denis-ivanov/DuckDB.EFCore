using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore;

public class SerializationDuckDBTest : SerializationTestBase<F1DuckDBFixture>
{
    public SerializationDuckDBTest(F1DuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory]
    public override void Can_round_trip_through_JSON(bool useNewtonsoft, bool ignoreLoops, bool writeIndented)
    {
        base.Can_round_trip_through_JSON(useNewtonsoft, ignoreLoops, writeIndented);
    }
}
