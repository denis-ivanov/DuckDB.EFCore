using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations.Temporal;

public class DateTimeTranslationsDuckDBTest : DateTimeTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateTimeTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact]
    public async Task Strftime()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(o => EF.Functions.Strftime(o.DateTime, "%d/%m/%Y") == "2020/01/01"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(o => o.DateTime.ToString("dd/MM/yyyy") == "2020/01/01"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE strftime(b."DateTime", '%d/%m/%Y') = '2020/01/01'
            """);
    }

    public override async Task DayOfYear()
    {
        await base.DayOfYear();

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE dayofyear(b."DateTime") = 124
            """);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Millisecond()
    {
        return base.Millisecond();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task subtract_and_TotalDays()
    {
        return base.subtract_and_TotalDays();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task TimeOfDay()
    {
        return base.TimeOfDay();
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
