using DuckDB.EFCore.Storage.Internal;
using DuckDB.EFCore.Update.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Text;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Update;

public class DuckDBUpdateSqlGeneratorTest : UpdateSqlGeneratorTestBase
{
    [ConditionalFact]
    public override void AppendInsertOperation_appends_insert_and_select_rowcount_if_no_store_generated_columns_exist_or_conditions_exist()
    {
        var stringBuilder = new StringBuilder();
        var command = CreateInsertCommand(false, false);

        CreateSqlGenerator().AppendInsertOperation(stringBuilder, command, 0);

        Assert.Equal(
            "INSERT INTO "
            + SchemaPrefix
            + OpenDelimiter
            + "Ducks"
            + CloseDelimiter
            + " ("
            + OpenDelimiter
            + "Id"
            + CloseDelimiter
            + ", "
            + OpenDelimiter
            + "Name"
            + CloseDelimiter
            + ", "
            + OpenDelimiter
            + "Quacks"
            + CloseDelimiter
            + ", "
            + OpenDelimiter
            + "ConcurrencyToken"
            + CloseDelimiter
            + ")"
            + Environment.NewLine
            + "VALUES ($p0, $p1, $p2, $p3);"
            + Environment.NewLine,
            stringBuilder.ToString());
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendUpdateOperation_if_store_generated_columns_dont_exist()
    {
        base.AppendUpdateOperation_if_store_generated_columns_dont_exist();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendUpdateOperation_if_store_generated_columns_exist()
    {
        base.AppendUpdateOperation_if_store_generated_columns_exist();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void GenerateNextSequenceValueOperation_correctly_handles_schemas()
    {
        base.GenerateNextSequenceValueOperation_correctly_handles_schemas();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void GenerateNextSequenceValueOperation_returns_statement_with_sanitized_sequence()
    {
        base.GenerateNextSequenceValueOperation_returns_statement_with_sanitized_sequence();
    }

    protected override void AppendDeleteOperation_creates_full_delete_command_text_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            DELETE FROM main."Ducks"
            WHERE "Id" = $p0
            RETURNING 1;
            """,
            stringBuilder.ToString());
    }

    protected override void AppendDeleteOperation_creates_full_delete_command_text_with_concurrency_check_verification(
        StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            DELETE FROM main."Ducks"
            WHERE "Id" = $p0 AND "ConcurrencyToken" IS NULL
            RETURNING 1;
            """,
            stringBuilder.ToString());
    }

    protected override void AppendInsertOperation_insert_if_store_generated_columns_exist_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            INSERT INTO main."Ducks" ("Name", "Quacks", "ConcurrencyToken")
            VALUES ($p0, $p1, $p2)
            RETURNING "Id", "Computed";
            """,
            stringBuilder.ToString());
    }

    protected override void AppendInsertOperation_for_store_generated_columns_but_no_identity_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            INSERT INTO main."Ducks" ("Id", "Name", "Quacks", "ConcurrencyToken")
            VALUES ($p0, $p1, $p2, $p3)
            RETURNING "Computed";
            """,
            stringBuilder.ToString());
    }

    protected override void AppendInsertOperation_for_only_identity_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            INSERT INTO main."Ducks" ("Name", "Quacks", "ConcurrencyToken")
            VALUES ($p0, $p1, $p2)
            RETURNING "Id";
            """,
            stringBuilder.ToString());
    }

    protected override void AppendInsertOperation_for_all_store_generated_columns_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            INSERT INTO main."Ducks"
            DEFAULT VALUES
            RETURNING "Id", "Computed";
            """,
            stringBuilder.ToString());
    }

    protected override void AppendInsertOperation_for_only_single_identity_columns_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            INSERT INTO main."Ducks"
            DEFAULT VALUES
            RETURNING "Id";
            """,
            stringBuilder.ToString());
    }

    protected override void AppendUpdateOperation_if_store_generated_columns_exist_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendUpdateOperation_if_store_generated_columns_dont_exist_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendUpdateOperation_appends_where_for_concurrency_token_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            UPDATE main."Ducks" SET "Name" = $p0, "Quacks" = $p1, "ConcurrencyToken" = $p2
            WHERE "Id" = $p3 AND "ConcurrencyToken" IS NULL
            RETURNING 1;
            """,
            stringBuilder.ToString());
    }

    protected override void AppendUpdateOperation_for_computed_property_verification(StringBuilder stringBuilder)
    {
        AssertBaseline(
            """
            UPDATE main."Ducks" SET "Name" = $p0, "Quacks" = $p1, "ConcurrencyToken" = $p2
            WHERE "Id" = $p3
            RETURNING "Computed";
            """,
            stringBuilder.ToString());
    }

    protected override IUpdateSqlGenerator CreateSqlGenerator()
    {
        return new DuckDBUpdateSqlGenerator(
            new UpdateSqlGeneratorDependencies(
                new DuckDBSqlGenerationHelper(
                    new RelationalSqlGenerationHelperDependencies()),
                TestServiceFactory.Instance.Create<DuckDBTypeMappingSource>()));
    }

    protected override string RowsAffected { get; } = "TODO";

    protected override TestHelpers TestHelpers => DuckDBTestHelpers.Instance;

    protected override string Schema => "main";

    protected override string SchemaPrefix => Schema + ".";

    private void AssertBaseline(string expected, string actual)
        => Assert.Equal(expected.TrimEnd(), actual.TrimEnd(), ignoreLineEndingDifferences: true);
}
