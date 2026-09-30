using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations.Temporal;

public class DateOnlyTranslationsDuckDBTest : DateOnlyTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateOnlyTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
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
                .Where(o => EF.Functions.Strftime(o.DateOnly, "%d/%m/%Y") == "2020/01/01"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(o => o.DateOnly.ToString("dd/MM/yyyy") == "2020/01/01"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE strftime(b."DateOnly", '%d/%m/%Y') = '2020/01/01'
            """);
    }

    [ConditionalFact]
    public async Task DayName()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => EF.Functions.DayName(e.DateOnly) == "Wednesday"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.DateOnly.DayOfWeek.ToString() == "Wednesday"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE dayname(b."DateOnly") = 'Wednesday'
            """);
    }

    [ConditionalFact]
    public async Task DaysInMonth()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => EF.Functions.DaysInMonth(e.DateOnly) == 31),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => DateTime.DaysInMonth(e.DateOnly.Year, e.DateOnly.Month) == 31),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE days_in_month(b."DateOnly") = 31
            """);
    }

    public override async Task DayNumber_subtraction()
    {
        await base.DayNumber_subtraction();

        AssertSql(
            """
            DayNumber='726775'

            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE (date_diff('day', '0001-01-01', b."DateOnly") - $DayNumber) = 5
            """);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property()
    {
        return base.FromDateTime_compared_to_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDateTime_constant_DateTime_with_property_TimeOnly()
    {
        return base.ToDateTime_constant_DateTime_with_property_TimeOnly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_constant_TimeOnly()
    {
        return base.ToDateTime_property_with_constant_TimeOnly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_property_TimeOnly()
    {
        return base.ToDateTime_property_with_property_TimeOnly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_DateTime()
    {
        return base.ToDateTime_with_complex_DateTime();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_TimeOnly()
    {
        return base.ToDateTime_with_complex_TimeOnly();
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
