using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Translations.Temporal;

public class DateTimeOffsetTranslationsDuckDBTest : DateTimeOffsetTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateTimeOffsetTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
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

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddDays()
    {
        return base.AddDays();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddHours()
    {
        return base.AddHours();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMilliseconds()
    {
        return base.AddMilliseconds();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMinutes()
    {
        return base.AddMinutes();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMonths()
    {
        return base.AddMonths();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddSeconds()
    {
        return base.AddSeconds();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddYears()
    {
        return base.AddYears();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Date()
    {
        return base.Date();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DayOfYear()
    {
        return base.DayOfYear();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Hour()
    {
        return base.Hour();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Day()
    {
        return base.Day();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Microsecond()
    {
        return base.Microsecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Millisecond()
    {
        return base.Millisecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nanosecond()
    {
        return base.Nanosecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Now()
    {
        return base.Now();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task TimeOfDay()
    {
        return base.TimeOfDay();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToUnixTimeMilliseconds()
    {
        return base.ToUnixTimeMilliseconds();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Minute()
    {
        return base.Minute();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToUnixTimeSecond()
    {
        return base.ToUnixTimeSecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task UtcNow()
    {
        return base.UtcNow();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Ctor_DateTime()
    {
        await base.Ctor_DateTime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Ctor_DateTime_TimeSpan()
    {
        await base.Ctor_DateTime_TimeSpan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task DateTime()
    {
        await base.DateTime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task LocalDateTime()
    {
        await base.LocalDateTime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task ToOffset()
    {
        await base.ToOffset();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task UtcDateTime()
    {
        await base.UtcDateTime();
    }
}
