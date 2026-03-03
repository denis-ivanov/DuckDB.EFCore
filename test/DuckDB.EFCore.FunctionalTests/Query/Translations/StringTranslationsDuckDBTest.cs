using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class StringTranslationsDuckDBTest : StringTranslationsRelationalTestBase<BasicTypesQueryDuckDBFixture>
{
    public StringTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Like_with_non_string_column_using_ToString()
    {
        return base.Like_with_non_string_column_using_ToString();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FirstOrDefault()
    {
        return base.FirstOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IndexOf_after_ToString()
    {
        return base.IndexOf_after_ToString();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IndexOf_over_ToString()
    {
        return base.IndexOf_over_ToString();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IndexOf_with_constant_starting_position_char()
    {
        return base.IndexOf_with_constant_starting_position_char();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IndexOf_with_parameter_starting_position_char()
    {
        return base.IndexOf_with_parameter_starting_position_char();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Join_non_aggregate()
    {
        return base.Join_non_aggregate();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task LastOrDefault()
    {
        return base.LastOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Replace_using_property_arguments()
    {
        return base.Replace_using_property_arguments();
    }
}
