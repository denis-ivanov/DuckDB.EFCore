using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class CompositeKeyEndToEndDuckDBTest : CompositeKeyEndToEndTestBase<CompositeKeyEndToEndDuckDBTest.CompositeKeyEndToEndDuckDBFixture>
{
    public CompositeKeyEndToEndDuckDBTest(CompositeKeyEndToEndDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_use_generated_values_in_composite_key_end_to_end()
    {
        await base.Can_use_generated_values_in_composite_key_end_to_end();
    }

    public class CompositeKeyEndToEndDuckDBFixture : CompositeKeyEndToEndFixtureBase
    {
        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder.ConfigureWarnings(b =>
            {
                // b.Ignore(DuckDBEventId.CompositeKeyWithValueGeneration)
            }));

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
