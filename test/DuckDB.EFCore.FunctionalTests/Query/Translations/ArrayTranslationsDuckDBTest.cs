using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class ArrayTranslationsDuckDBTest : QueryTestBase<BasicTypesQueryDuckDBFixture>
{
    public ArrayTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact]
    public async Task ArrayValue_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => EF.Functions.ArrayValue(e.Float, 1f, 2f)),
            expectedQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => new[] { e.Float, 1f, 2f }),
            elementAsserter: (e, a) => Assert.Equal(e, a));

        AssertSql(
            """
            SELECT array_value(b."Float", 1, 2)
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayValue_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => EF.Functions.ArrayValue(e.Double, 1.0, 2.0)),
            expectedQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => new[] { e.Double, 1.0, 2.0 }),
            elementAsserter: (e, a) => Assert.Equal(e, a));

        AssertSql(
            """
            SELECT array_value(b."Double", 1.0, 2.0)
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayValue_Int()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => EF.Functions.ArrayValue(e.Int, 1, 2)),
            expectedQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => new[] { e.Int, 1, 2 }),
            elementAsserter: (e, a) => Assert.Equal(e, a));

        AssertSql(
            """
            SELECT array_value(b."Int", 1, 2)
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayValue_String()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => EF.Functions.ArrayValue(e.String, "a", "b")),
            expectedQuery: ss => ss.Set<BasicTypesEntity>().Where(e => e.Id == 1).Select(e => new[] { e.String, "a", "b" }),
            elementAsserter: (e, a) => Assert.Equal(e, a));

        AssertSql(
            """
            SELECT array_value(b."String", 'a', 'b')
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayCosineDistance_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayCosineDistance(EF.Functions.ArrayValue(e.Float, 1f), EF.Functions.ArrayValue(e.Float, 1f)) == 0f),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_cosine_distance(array_value(b."Float", 1), array_value(b."Float", 1)) = 0
            """);
    }

    [ConditionalFact]
    public async Task ArrayCosineDistance_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayCosineDistance(EF.Functions.ArrayValue(e.Double, 1.0), EF.Functions.ArrayValue(e.Double, 1.0)) == 0.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_cosine_distance(array_value(b."Double", 1.0), array_value(b."Double", 1.0)) = 0.0
            """);
    }

    [ConditionalFact]
    public async Task ArrayCosineSimilarity_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayCosineSimilarity(EF.Functions.ArrayValue(e.Float, 1f), EF.Functions.ArrayValue(e.Float, 1f)) == 1f),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_cosine_similarity(array_value(b."Float", 1), array_value(b."Float", 1)) = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayCosineSimilarity_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayCosineSimilarity(EF.Functions.ArrayValue(e.Double, 1.0), EF.Functions.ArrayValue(e.Double, 1.0)) == 1.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_cosine_similarity(array_value(b."Double", 1.0), array_value(b."Double", 1.0)) = 1.0
            """);
    }

    [ConditionalFact]
    public async Task ArrayCrossProduct_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1)
                .Select(e => EF.Functions.ArrayCrossProduct(EF.Functions.ArrayValue(e.Float, 1f, 2f), EF.Functions.ArrayValue(e.Float, 2f, 3f))),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1)
                .Select(e => new[] { -1f, -e.Float, e.Float }),
            elementAsserter: (e, a) =>
            {
                Assert.Equal(e.Length, a.Length);
                for (var i = 0; i < e.Length; i++)
                {
                    Assert.Equal(e[i], a[i], 3);
                }
            });

        AssertSql(
            """
            SELECT array_cross_product(array_value(b."Float", 1, 2), array_value(b."Float", 2, 3))
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayCrossProduct_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1)
                .Select(e => EF.Functions.ArrayCrossProduct(EF.Functions.ArrayValue(e.Double, 1.0, 2.0), EF.Functions.ArrayValue(e.Double, 2.0, 3.0))),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1)
                .Select(e => new[] { -1.0, -e.Double, e.Double }),
            elementAsserter: (e, a) =>
            {
                Assert.Equal(e.Length, a.Length);
                for (var i = 0; i < e.Length; i++)
                {
                    Assert.Equal(e[i], a[i], 5);
                }
            });

        AssertSql(
            """
            SELECT array_cross_product(array_value(b."Double", 1.0, 2.0), array_value(b."Double", 2.0, 3.0))
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1
            """);
    }

    [ConditionalFact]
    public async Task ArrayDistance_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayDistance(EF.Functions.ArrayValue(e.Float, 1f), EF.Functions.ArrayValue(e.Float, 1f)) == 0f),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_distance(array_value(b."Float", 1), array_value(b."Float", 1)) = 0
            """);
    }

    [ConditionalFact]
    public async Task ArrayDistance_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayDistance(EF.Functions.ArrayValue(e.Double, 1.0), EF.Functions.ArrayValue(e.Double, 1.0)) == 0.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_distance(array_value(b."Double", 1.0), array_value(b."Double", 1.0)) = 0.0
            """);
    }

    [ConditionalFact]
    public async Task ArrayInnerProduct_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayInnerProduct(EF.Functions.ArrayValue(e.Float, 1f), EF.Functions.ArrayValue(e.Float, 1f)) != 0f),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_inner_product(array_value(b."Float", 1), array_value(b."Float", 1)) <> 0
            """);
    }

    [ConditionalFact]
    public async Task ArrayInnerProduct_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayInnerProduct(EF.Functions.ArrayValue(e.Double, 1.0), EF.Functions.ArrayValue(e.Double, 1.0)) != 0.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_inner_product(array_value(b."Double", 1.0), array_value(b."Double", 1.0)) <> 0.0
            """);
    }

    [ConditionalFact]
    public async Task ArrayNegativeInnerProduct_Float()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayNegativeInnerProduct(EF.Functions.ArrayValue(e.Float, 1f), EF.Functions.ArrayValue(e.Float, 1f)) != 0f),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_negative_inner_product(array_value(b."Float", 1), array_value(b."Float", 1)) <> 0
            """);
    }

    [ConditionalFact]
    public async Task ArrayNegativeInnerProduct_Double()
    {
        await AssertQuery(
            actualQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1 && EF.Functions.ArrayNegativeInnerProduct(EF.Functions.ArrayValue(e.Double, 1.0), EF.Functions.ArrayValue(e.Double, 1.0)) != 0.0),
            expectedQuery: ss => ss.Set<BasicTypesEntity>()
                .Where(e => e.Id == 1),
            assertEmpty: false);

        AssertSql(
            """
            SELECT b."Id", b."Bool", b."Byte", b."ByteArray", b."DateOnly", b."DateTime", b."DateTimeOffset", b."Decimal", b."Double", b."Enum", b."FlagsEnum", b."Float", b."Guid", b."Int", b."Long", b."Short", b."String", b."TimeOnly", b."TimeSpan"
            FROM "BasicTypesEntities" AS b
            WHERE b."Id" = 1 AND array_negative_inner_product(array_value(b."Double", 1.0), array_value(b."Double", 1.0)) <> 0.0
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
