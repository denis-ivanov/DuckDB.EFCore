using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Text;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Update;

public class DuckDBUpdateSqlGeneratorTest : UpdateSqlGeneratorTestBase
{
    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendDeleteOperation_creates_full_delete_command_text()
    {
        base.AppendDeleteOperation_creates_full_delete_command_text();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendDeleteOperation_creates_full_delete_command_text_with_concurrency_check()
    {
        base.AppendDeleteOperation_creates_full_delete_command_text_with_concurrency_check();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_appends_insert_and_select_rowcount_if_no_store_generated_columns_exist_or_conditions_exist()
    {
        base.AppendInsertOperation_appends_insert_and_select_rowcount_if_no_store_generated_columns_exist_or_conditions_exist();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_for_all_store_generated_columns()
    {
        base.AppendInsertOperation_for_all_store_generated_columns();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_for_only_identity()
    {
        base.AppendInsertOperation_for_only_identity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_for_only_single_identity_columns()
    {
        base.AppendInsertOperation_for_only_single_identity_columns();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_for_store_generated_columns_but_no_identity()
    {
        base.AppendInsertOperation_for_store_generated_columns_but_no_identity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendInsertOperation_insert_if_store_generated_columns_exist()
    {
        base.AppendInsertOperation_insert_if_store_generated_columns_exist();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendUpdateOperation_appends_where_for_concurrency_token()
    {
        base.AppendUpdateOperation_appends_where_for_concurrency_token();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void AppendUpdateOperation_for_computed_property()
    {
        base.AppendUpdateOperation_for_computed_property();
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
        throw new NotImplementedException();
    }

    protected override void AppendDeleteOperation_creates_full_delete_command_text_with_concurrency_check_verification(
        StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendInsertOperation_insert_if_store_generated_columns_exist_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendInsertOperation_for_store_generated_columns_but_no_identity_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendInsertOperation_for_only_identity_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendInsertOperation_for_all_store_generated_columns_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override void AppendInsertOperation_for_only_single_identity_columns_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    protected override void AppendUpdateOperation_for_computed_property_verification(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }

    protected override IUpdateSqlGenerator CreateSqlGenerator()
    {
        throw new NotImplementedException();
    }

    protected override string RowsAffected { get; } = "TODO";

    protected override TestHelpers TestHelpers => DuckDBTestHelpers.Instance;
}
