using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class MathTranslationsDuckDBTest : MathTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public MathTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
