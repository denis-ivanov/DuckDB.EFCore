using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations.Operators;

public class LogicalOperatorTranslationsDuckDBTest : LogicalOperatorTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public LogicalOperatorTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
