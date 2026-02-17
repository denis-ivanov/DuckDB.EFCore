using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class MiscellaneousTranslationsDuckDBTest : MiscellaneousTranslationsRelationalTestBase<BasicTypesQueryDuckDBFixture>
{
    public MiscellaneousTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToBoolean()
    {
        return base.Convert_ToBoolean();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToByte()
    {
        return base.Convert_ToByte();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToDecimal()
    {
        return base.Convert_ToDecimal();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToDouble()
    {
        return base.Convert_ToDouble();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToInt16()
    {
        return base.Convert_ToInt16();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToInt32()
    {
        return base.Convert_ToInt32();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToInt64()
    {
        return base.Convert_ToInt64();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Convert_ToString()
    {
        return base.Convert_ToString();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Random_on_EF_Functions()
    {
        return base.Random_on_EF_Functions();
    }
}
