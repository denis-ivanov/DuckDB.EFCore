using System.Text;
using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class StringTranslationsDuckDBTest : StringTranslationsRelationalTestBase<BasicTypesQueryDuckDBFixture>
{
    public StringTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact]
    public async Task DamerauLevenshtein()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => EF.Functions.DamerauLevenshtein(e.String, "Seattle") == 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE damerau_levenshtein(b."String", 'Seattle') = 0
            """);
    }

    [ConditionalFact]
    public async Task Hamming()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Hamming(e.String, "Seattle") == 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND hamming(b."String", 'Seattle') = 0
            """);
    }

    [ConditionalFact]
    public async Task Jaccard()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Jaccard(e.String, "Seattle") == 1.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND jaccard(b."String", 'Seattle') = 1.0
            """);
    }

    [ConditionalFact]
    public async Task Left()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Left(e.String, 3) == "Sea"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND left(b."String", 3) = 'Sea'
            """);
    }

    [ConditionalFact]
    public async Task LeftGrapheme()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.LeftGrapheme(e.String, 3) == "Sea"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND left_grapheme(b."String", 3) = 'Sea'
            """);
    }

    [ConditionalFact]
    public async Task LengthGrapheme()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.LengthGrapheme(e.String) == 7),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND length_grapheme(b."String") = 7
            """);
    }

    [ConditionalFact]
    public async Task Levenshtein()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => EF.Functions.Levenshtein(e.String, "Seattle") == 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE levenshtein(b."String", 'Seattle') = 0
            """);
    }

    [ConditionalFact]
    public async Task Md5Number()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Md5Number(e.String) != 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND md5_number(b."String") <> 0
            """);
    }

    [ConditionalFact]
    public async Task Md5NumberLower()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Md5NumberLower(e.String) != 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND md5_number_lower(b."String") <> 0
            """);
    }

    [ConditionalFact]
    public async Task Md5NumberUpper()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Md5NumberUpper(e.String) != 0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND md5_number_upper(b."String") <> 0
            """);
    }

    [ConditionalFact]
    public async Task NotILikeEscape()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.NotILikeEscape(e.String, "s%e", "!") == false),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND NOT (not_ilike_escape(b."String", 's%e', '!'))
            """);
    }

    [ConditionalFact]
    public async Task NotLikeEscape()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.NotLikeEscape(e.String, "S%e", "!") == false),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND NOT (not_like_escape(b."String", 'S%e', '!'))
            """);
    }

    [ConditionalFact]
    public async Task ILike()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.ILike(e.String, "s%e")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" ILIKE 's%e'
            """);
    }

    [ConditionalFact]
    public async Task ILike_with_escape()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.ILike(e.String, "s!%e", "!")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => false),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" ILIKE 's!%e' ESCAPE '!'
            """);
    }

    [ConditionalFact]
    public async Task ILike_with_escape_matching()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.ILike(e.String, "s!%eattle", "!") == false),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" NOT ILIKE 's!%eattle' ESCAPE '!'
            """);
    }

    [ConditionalFact]
    public async Task LikeEscape()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.LikeEscape(e.String, "S%e", "!") == true),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND like_escape(b."String", 'S%e', '!')
            """);
    }

    [ConditionalFact]
    public async Task SimilarTo()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.SimilarTo(e.String, "(S|P).*")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" SIMILAR TO '(S|P).*'
            """);
    }

    [ConditionalFact]
    public async Task SimilarTo_negated()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.SimilarTo(e.String, "(B|P).*") == false),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" NOT SIMILAR TO '(B|P).*'
            """);
    }

    [ConditionalFact]
    public async Task Glob()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Glob(e.String, "S*e")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND b."String" GLOB 'S*e'
            """);
    }

    [ConditionalFact]
    public async Task Glob_negated()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.Glob(e.String, "B*") == false),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND NOT (b."String" GLOB 'B*')
            """);
    }

    [ConditionalFact]
    public async Task RegexExtract()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtract(e.String, @"[a-z]+") == "eattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract(b."String", '[a-z]+') = 'eattle'
            """);
    }

    [ConditionalFact]
    public async Task RegexExtract_group()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtract(e.String, @"S(\w+)", 1) == "eattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract(b."String", 'S(\w+)', 1) = 'eattle'
            """);
    }

    [ConditionalFact]
    public async Task RegexExtract_group_and_options()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtract(e.String, @"s(\w+)", 1, "i") == "eattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract(b."String", 's(\w+)', 1, 'i') = 'eattle'
            """);
    }

    [ConditionalFact]
    public async Task RegexExtractAll()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtractAll(e.String, @"[a-z]") == new[] { "e", "a", "t", "t", "l", "e" }),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract_all(b."String", '[a-z]') = ['e', 'a', 't', 't', 'l', 'e']::VARCHAR[]
            """);
    }

    [ConditionalFact]
    public async Task RegexExtractAll_group()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtractAll(e.String, @"([a-z])", 1) == new[] { "e", "a", "t", "t", "l", "e" }),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract_all(b."String", '([a-z])', 1) = ['e', 'a', 't', 't', 'l', 'e']::VARCHAR[]
            """);
    }

    [ConditionalFact]
    public async Task RegexExtractAll_group_and_options()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexExtractAll(e.String, @"([a-z])", 1, "i") == new[] { "S", "e", "a", "t", "t", "l", "e" }),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_extract_all(b."String", '([a-z])', 1, 'i') = ['S', 'e', 'a', 't', 't', 'l', 'e']::VARCHAR[]
            """);
    }

    [ConditionalFact]
    public async Task RegexFullMatch()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexFullMatch(e.String, @"[A-Za-z]+")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_full_match(b."String", '[A-Za-z]+')
            """);
    }

    [ConditionalFact]
    public async Task RegexFullMatch_options()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle" && EF.Functions.RegexFullMatch(e.String, @"[a-z]+", "i")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."String" = 'Seattle' AND regexp_full_match(b."String", '[a-z]+', 'i')
            """);
    }

    [ConditionalFact]
    public async Task Normalize()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.Normalize() == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.Normalize() == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE nfc_normalize(b."String") = 'Seattle'
            """);
    }

    [ConditionalFact]
    public async Task Normalize_FormC()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.Normalize(NormalizationForm.FormC) == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.Normalize(NormalizationForm.FormC) == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE nfc_normalize(b."String") = 'Seattle'
            """);
    }

    [ConditionalFact]
    public async Task PadLeft()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.PadLeft(10, 'a') == "aaaSeattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.PadLeft(10, 'a') == "aaaSeattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE lpad(b."String", 10, 'a') = 'aaaSeattle'
            """);
    }

    [ConditionalFact]
    public async Task PadRight()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.PadRight(10, 'a') == "Seattleaaa"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.String.PadRight(10, 'a') == "Seattleaaa"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE rpad(b."String", 10, 'a') = 'Seattleaaa'
            """);
    }

    [ConditionalFact]
    public async Task Path_GetFileName()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Path.GetFileName(e.String) == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Path.GetFileName(e.String) == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE parse_filename(b."String", false) = 'Seattle'
            """);
    }

    [ConditionalFact]
    public async Task Path_GetFileNameWithoutExtension()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Path.GetFileNameWithoutExtension(e.String) == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Path.GetFileNameWithoutExtension(e.String) == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE parse_filename(b."String", true) = 'Seattle'
            """);
    }

    [ConditionalFact]
    public async Task Uri_EscapeDataString()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Uri.EscapeDataString(e.String) == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Uri.EscapeDataString(e.String) == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE url_encode(b."String") = 'Seattle'
            """);
    }

    [ConditionalFact]
    public async Task Uri_UnescapeDataString()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Uri.UnescapeDataString(e.String) == "Seattle"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => Uri.UnescapeDataString(e.String) == "Seattle"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE url_decode(b."String") = 'Seattle'
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
