using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Translations.Temporal;

public class TimeOnlyTranslationsDuckDBTest : TimeOnlyTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public TimeOnlyTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_TimeSpan()
    {
        return base.Add_TimeSpan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddHours()
    {
        return base.AddHours();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AddMinutes()
    {
        return base.AddMinutes();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property()
    {
        return base.FromDateTime_compared_to_property();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant()
    {
        return base.FromDateTime_compared_to_constant();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_parameter()
    {
        return base.FromDateTime_compared_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_parameter()
    {
        return base.FromTimeSpan_compared_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_property()
    {
        return base.FromTimeSpan_compared_to_property();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsBetween()
    {
        return base.IsBetween();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Millisecond()
    {
        return base.Millisecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Microsecond()
    {
        return base.Microsecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nanosecond()
    {
        return base.Nanosecond();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Order_by_FromTimeSpan()
    {
        return base.Order_by_FromTimeSpan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subtract()
    {
        return base.Subtract();
    }
}
