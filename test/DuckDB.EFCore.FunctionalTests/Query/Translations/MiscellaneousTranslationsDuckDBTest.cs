using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class MiscellaneousTranslationsDuckDBTest : MiscellaneousTranslationsRelationalTestBase<BasicTypesQueryDuckDBFixture>
{
    public MiscellaneousTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
