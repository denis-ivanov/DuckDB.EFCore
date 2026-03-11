using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations.Operators;

public class BitwiseOperatorTranslationsDuckDBTest : BitwiseOperatorTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public BitwiseOperatorTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
