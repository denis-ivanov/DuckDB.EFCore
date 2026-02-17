using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations.Operators;

public class MiscellaneousOperatorTranslationsDuckDBTest : MiscellaneousOperatorTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public MiscellaneousOperatorTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Coalesce()
    {
        return base.Coalesce();
    }
}
