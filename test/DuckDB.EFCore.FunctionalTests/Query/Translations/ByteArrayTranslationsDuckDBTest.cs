using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using System.Security.Cryptography;
using System.Text;
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
            SELECT hex(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_FromHexString()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.FromHexString(Convert.ToHexString(b.ByteArray))),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT unhex(hex(b."ByteArray"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task MD5_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => MD5.HashData(b.ByteArray)),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT unhex(md5(b."ByteArray"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_MD5_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.ToHexString(MD5.HashData(b.ByteArray))),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equal(e, a, ignoreCase: true));

        AssertSql(
            """
            SELECT md5(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_MD5_HashData_in_where()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Where(b => Convert.ToHexString(MD5.HashData(b.ByteArray)) == "0000"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE md5(b."ByteArray") = '0000'
            """);
    }

    [ConditionalFact]
    public async Task SHA1_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => SHA1.HashData(b.ByteArray)),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT unhex(sha1(b."ByteArray"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_SHA1_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.ToHexString(SHA1.HashData(b.ByteArray))),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equal(e, a, ignoreCase: true));

        AssertSql(
            """
            SELECT sha1(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_SHA1_HashData_in_where()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Where(b => Convert.ToHexString(SHA1.HashData(b.ByteArray)) == "0000"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE sha1(b."ByteArray") = '0000'
            """);
    }

    [ConditionalFact]
    public async Task SHA256_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => SHA256.HashData(b.ByteArray)),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT unhex(sha256(b."ByteArray"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_SHA256_HashData()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Convert.ToHexString(SHA256.HashData(b.ByteArray))),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equal(e, a, ignoreCase: true));

        AssertSql(
            """
            SELECT sha256(b."ByteArray")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToHexString_SHA256_HashData_in_where()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Where(b => Convert.ToHexString(SHA256.HashData(b.ByteArray)) == "0000"),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE sha256(b."ByteArray") = '0000'
            """);
    }

    [ConditionalFact]
    public async Task Encoding_UTF8_GetBytes()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Encoding.UTF8.GetBytes(b.String)),
            assertOrder: true,
            elementAsserter: (e, a) => Assert.Equivalent(e, a));

        AssertSql(
            """
            SELECT encode(b."String")
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Encoding_UTF8_GetBytes_in_where()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Where(b => Encoding.UTF8.GetBytes(b.String).Length == 7));

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE octet_length(encode(b."String")) = 7
            """);
    }

    [ConditionalFact]
    public async Task Encoding_UTF8_GetString()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().OrderBy(b => b.Id).Select(b => Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(b.String))),
            assertOrder: true);

        AssertSql(
            """
            SELECT decode(encode(b."String"))
            FROM "BasicTypesEntities" AS b
            ORDER BY b."Id" NULLS FIRST
            """);
    }

    [ConditionalFact]
    public async Task Encoding_UTF8_GetString_in_where()
    {
        await AssertQuery(
            ss => ss.Set<BasicTypesEntity>().Where(b => Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(b.String)) == "Seattle"));

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE decode(encode(b."String")) = 'Seattle'
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
