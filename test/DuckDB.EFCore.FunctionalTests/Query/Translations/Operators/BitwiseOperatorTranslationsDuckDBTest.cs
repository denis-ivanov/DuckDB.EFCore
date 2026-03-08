using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Xunit;
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

    public override Task Xor()
    {
        return base.Xor();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Xor_over_boolean()
    {
        return base.Xor_over_boolean();
    }
}
