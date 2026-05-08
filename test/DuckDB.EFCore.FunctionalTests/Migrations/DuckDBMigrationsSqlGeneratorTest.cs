using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.NTS.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Migrations;

public class DuckDBMigrationsSqlGeneratorTest : MigrationsSqlGeneratorTestBase
{
    public DuckDBMigrationsSqlGeneratorTest()
        : base(DuckDBTestHelpers.Instance,
            new ServiceCollection().AddEntityFrameworkDuckDBNetTopologySuite(),
            DuckDBTestHelpers.Instance.AddProviderOptions(
                ((IRelationalDbContextOptionsBuilderInfrastructure)
                    new DuckDBDbContextOptionsBuilder(new DbContextOptionsBuilder()).UseNetTopologySuite())
                .OptionsBuilder).Options)
    {
    }

    protected override string GetGeometryCollectionStoreType()
    {
        throw new NotImplementedException();
    }

    public override void AddColumnOperation_without_column_type()
    {
        base.AddColumnOperation_without_column_type();
    }

    public override void AddColumnOperation_with_unicode_overridden()
    {
        base.AddColumnOperation_with_unicode_overridden();
    }

    public override void AddColumnOperation_with_unicode_no_model()
    {
        base.AddColumnOperation_with_unicode_no_model();
    }

    public override void AddColumnOperation_with_fixed_length_no_model()
    {
        base.AddColumnOperation_with_fixed_length_no_model();
    }

    public override void AddColumnOperation_with_maxLength_overridden()
    {
        base.AddColumnOperation_with_maxLength_overridden();
    }

    public override void AddColumnOperation_with_maxLength_no_model()
    {
        base.AddColumnOperation_with_maxLength_no_model();
    }

    public override void AddColumnOperation_with_precision_and_scale_overridden()
    {
        base.AddColumnOperation_with_precision_and_scale_overridden();
    }

    public override void AddColumnOperation_with_precision_and_scale_no_model()
    {
        base.AddColumnOperation_with_precision_and_scale_no_model();
    }

    public override void AddForeignKeyOperation_without_principal_columns()
    {
        base.AddForeignKeyOperation_without_principal_columns();
    }

    public override void RenameTableOperation_legacy()
    {
        base.RenameTableOperation_legacy();
    }

    public override void RenameTableOperation()
    {
        base.RenameTableOperation();
    }

    public override void AlterColumnOperation_without_column_type()
    {
        base.AlterColumnOperation_without_column_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InsertDataOperation_all_args_spatial()
    {
        base.InsertDataOperation_all_args_spatial();
    }

    public override void SqlOperation()
    {
        base.SqlOperation();
    }

    public override void InsertDataOperation_required_args()
    {
        base.InsertDataOperation_required_args();
    }

    public override void InsertDataOperation_required_args_composite()
    {
        base.InsertDataOperation_required_args_composite();
    }

    public override void InsertDataOperation_required_args_multiple_rows()
    {
        base.InsertDataOperation_required_args_multiple_rows();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InsertDataOperation_throws_for_unsupported_column_types()
    {
        base.InsertDataOperation_throws_for_unsupported_column_types();
    }

    public override void DeleteDataOperation_all_args()
    {
        base.DeleteDataOperation_all_args();
    }

    public override void DeleteDataOperation_all_args_composite()
    {
        base.DeleteDataOperation_all_args_composite();
    }

    public override void DeleteDataOperation_required_args()
    {
        base.DeleteDataOperation_required_args();
    }

    public override void DeleteDataOperation_required_args_composite()
    {
        base.DeleteDataOperation_required_args_composite();
    }

    public override void UpdateDataOperation_all_args()
    {
        base.UpdateDataOperation_all_args();
    }

    public override void UpdateDataOperation_all_args_composite()
    {
        base.UpdateDataOperation_all_args_composite();
    }

    public override void UpdateDataOperation_all_args_composite_multi()
    {
        base.UpdateDataOperation_all_args_composite_multi();
    }

    public override void UpdateDataOperation_all_args_multi()
    {
        base.UpdateDataOperation_all_args_multi();
    }

    public override void UpdateDataOperation_required_args()
    {
        base.UpdateDataOperation_required_args();
    }

    public override void UpdateDataOperation_required_args_multiple_rows()
    {
        base.UpdateDataOperation_required_args_multiple_rows();
    }

    public override void UpdateDataOperation_required_args_composite()
    {
        base.UpdateDataOperation_required_args_composite();
    }

    public override void UpdateDataOperation_required_args_composite_multi()
    {
        base.UpdateDataOperation_required_args_composite_multi();
    }

    public override void UpdateDataOperation_required_args_multi()
    {
        base.UpdateDataOperation_required_args_multi();
    }

    public override void DefaultValue_with_line_breaks(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks(isUnicode);
    }

    public override void DefaultValue_with_line_breaks_2(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks_2(isUnicode);
    }

    public override void Sequence_restart_operation(long? startsAt)
    {
        base.Sequence_restart_operation(startsAt);
    }
}
