using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations.Temporal;

public class DateOnlyTranslationsDuckDBTest : DateOnlyTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public DateOnlyTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddDays()
    {
        return base.AddDays();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DayNumber_subtraction()
    {
        return base.DayNumber_subtraction();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime()
    {
        return base.FromDateTime();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant_and_parameter()
    {
        return base.FromDateTime_compared_to_constant_and_parameter();
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
