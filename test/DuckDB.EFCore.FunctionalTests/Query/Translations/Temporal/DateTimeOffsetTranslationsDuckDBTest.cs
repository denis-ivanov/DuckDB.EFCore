using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations.Temporal;

public class DateTimeOffsetTranslationsDuckDBTest : DateTimeOffsetTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateTimeOffsetTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
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
                .Where(o => EF.Functions.Strftime(o.DateTimeOffset, "%d/%m/%Y") == "1985/05/03"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(o => o.DateTimeOffset.ToString("dd/MM/yyyy") == "1985/05/03"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE strftime(b."DateTimeOffset", '%d/%m/%Y') = '1985/05/03'
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddDays()
    {
        return base.AddDays();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddHours()
    {
        return base.AddHours();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMilliseconds()
    {
        return base.AddMilliseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMinutes()
    {
        return base.AddMinutes();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMonths()
    {
        return base.AddMonths();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddSeconds()
    {
        return base.AddSeconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddYears()
    {
        return base.AddYears();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Date()
    {
        return base.Date();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DayOfYear()
    {
        return base.DayOfYear();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Hour()
    {
        return base.Hour();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Day()
    {
        return base.Day();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Microsecond()
    {
        return base.Microsecond();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Millisecond()
    {
        return base.Millisecond();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nanosecond()
    {
        return base.Nanosecond();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Now()
    {
        return base.Now();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task TimeOfDay()
    {
        return base.TimeOfDay();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToUnixTimeMilliseconds()
    {
        return base.ToUnixTimeMilliseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Minute()
    {
        return base.Minute();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToUnixTimeSecond()
    {
        return base.ToUnixTimeSecond();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task UtcNow()
    {
        return base.UtcNow();
    }
}
