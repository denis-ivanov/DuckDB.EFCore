using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class EnumTranslationsDuckDBTest : EnumTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public EnumTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bitwise_and_enum_constant()
    {
        return base.Bitwise_and_enum_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Equality_nullable_enum_to_constant()
    {
        return base.Equality_nullable_enum_to_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Equality_nullable_enum_to_null_constant()
    {
        return base.Equality_nullable_enum_to_null_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bitwise_and_integral_constant()
    {
        return base.Bitwise_and_integral_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Equality_nullable_enum_to_null_parameter()
    {
        return base.Equality_nullable_enum_to_null_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bitwise_and_nullable_enum_with_constant()
    {
        return base.Bitwise_and_nullable_enum_with_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Equality_nullable_enum_to_nullable_parameter()
    {
        return base.Equality_nullable_enum_to_nullable_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Equality_nullable_enum_to_parameter()
    {
        return base.Equality_nullable_enum_to_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_bitwise_and_nullable_enum_with_non_nullable_parameter()
    {
        return base.Where_bitwise_and_nullable_enum_with_non_nullable_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_bitwise_and_nullable_enum_with_nullable_parameter()
    {
        return base.Where_bitwise_and_nullable_enum_with_nullable_parameter();
    }
}