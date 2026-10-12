using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class MiscellaneousTranslationsDuckDBTest : MiscellaneousTranslationsRelationalTestBase<BasicTypesQueryDuckDBFixture>
{
    public MiscellaneousTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact]
    public async Task Convert_ToChar()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToChar(e.Int) == 'A'),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToChar(e.Int) == 'A'),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Int" > 0 AND chr(b."Int") = 'A'
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToInt32_char()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToInt32(Convert.ToChar(e.Int)) == 65),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToInt32(Convert.ToChar(e.Int)) == 65),
            assertEmpty: true);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Int" > 0 AND unicode(chr(b."Int")) = 65
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToString_Byte_with_base()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Byte > 0 && Convert.ToString(e.Byte, 2) == "1000"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Byte > 0 && Convert.ToString(e.Byte, 2) == "1000"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Byte" > 0 AND to_base(b."Byte", 2) = '1000'
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToString_Short_with_base()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Short > 0 && Convert.ToString(e.Short, 2) == "1000"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Short > 0 && Convert.ToString(e.Short, 2) == "1000"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Short" > 0 AND to_base(b."Short", 2) = '1000'
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToString_Int_with_base()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToString(e.Int, 2) == "1000"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Int > 0 && Convert.ToString(e.Int, 2) == "1000"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Int" > 0 AND to_base(b."Int", 2) = '1000'
            """);
    }

    [ConditionalFact]
    public async Task Convert_ToString_Long_with_base()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Long > 0 && Convert.ToString(e.Long, 2) == "1000"),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Long > 0 && Convert.ToString(e.Long, 2) == "1000"),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Long" > 0 AND to_base(b."Long", 2) = '1000'
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
