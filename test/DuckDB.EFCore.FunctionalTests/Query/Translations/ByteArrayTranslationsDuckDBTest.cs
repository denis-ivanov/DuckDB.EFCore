using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class ByteArrayTranslationsDuckDBTest : ByteArrayTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public ByteArrayTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = "https://github.com/duckdb/duckdb/discussions/7071")]
    public override Task Contains_with_column()
    {
        return base.Contains_with_column();
    }

    [ConditionalFact(Skip = "https://github.com/duckdb/duckdb/discussions/7071")]
    public override Task Contains_with_constant()
    {
        return base.Contains_with_constant();
    }

    [ConditionalFact(Skip = "https://github.com/duckdb/duckdb/discussions/7071")]
    public override Task Contains_with_parameter()
    {
        return base.Contains_with_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task First()
    {
        return base.First();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Index()
    {
        return base.Index();
    }

    [ConditionalFact]
    public async Task Convert_ToBase64String()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Select(b => Convert.ToBase64String(b.ByteArray)));

        AssertSql(
            """
            SELECT to_base64(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
