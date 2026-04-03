using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations.Temporal;

public class DateTimeTranslationsDuckDBTest : DateTimeTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateTimeTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DayOfYear()
    {
        return base.DayOfYear();
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

    public override Task UtcNow()
    {
        return base.UtcNow();
    }
}
