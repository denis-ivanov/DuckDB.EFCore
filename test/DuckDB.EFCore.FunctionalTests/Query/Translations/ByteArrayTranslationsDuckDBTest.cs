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

    public override async Task Length()
    {
        await base.Length();

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE octet_length(b."ByteArray") = 4
            """);
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

    [ConditionalFact]
    public async Task Convert_FromBase64String()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.FromBase64String(Convert.ToBase64String(b.ByteArray))),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT from_base64(to_base64(b."ByteArray"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.ToHexString(b.ByteArray)),
            assertOrder: true);

        AssertSql(
            """
            SELECT to_hex(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
