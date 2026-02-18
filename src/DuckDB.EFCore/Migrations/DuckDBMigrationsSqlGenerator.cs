using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DuckDB.EFCore.Migrations;

public class DuckDBMigrationsSqlGenerator : MigrationsSqlGenerator
{
    public DuckDBMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override void Generate(
        AddForeignKeyOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder,
        bool terminate = true)
    {
    }

    protected override void Generate(
        DropForeignKeyOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder,
        bool terminate = true)
    {
    }

    protected override void CreateTableForeignKeys(CreateTableOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
    }

    protected override void Generate(RenameTableOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
        builder.Append("ALTER TABLE ").AppendLine(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema))
            .Append(" RENAME TO ").Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.NewName, operation.NewSchema));
    }

    protected override void Generate(DropIndexOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        builder.Append("DROP INDEX ").Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));

        if (terminate)
        {
            EndStatement(builder);
        }
    }

    protected override void Generate(CreateSequenceOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
        builder
            .Append("CREATE SEQUENCE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema));

        var typeMapping = Dependencies.TypeMappingSource.FindMapping(operation.ClrType);

        builder
            .Append(" START WITH ")
            .Append(typeMapping.GenerateSqlLiteral(operation.StartValue));

        SequenceOptions(operation, model, builder);

        builder.AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator);

        EndStatement(builder);
    }

    protected override void Generate(EnsureSchemaOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
        builder.Append("CREATE SCHEMA IF NOT EXISTS ").Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));
        EndStatement(builder);
    }

    protected override void Generate(
        CreateTableOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder,
        bool terminate = true)
    {
        base.Generate(operation, model, builder, terminate);

        if (!string.IsNullOrEmpty(operation.Comment))
        {
            Comment(builder, "TABLE", Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema), operation.Comment);
        }

        foreach (var addColumnOperation in operation.Columns.Where(c => c.Comment != null))
        {
            Comment(
                builder,
                "COLUMN",
                Dependencies.SqlGenerationHelper.DelimitIdentifier(addColumnOperation.Name, operation.Name),
                addColumnOperation.Comment);
        }
    }

    protected override void Generate(AlterTableOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
        base.Generate(operation, model, builder);

        if (operation.OldTable.Comment != operation.Comment)
        {
            Comment(
                builder,
                "TABLE",
                Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Schema),
                operation.Comment);
        }
    }

    protected override void Generate(AlterColumnOperation operation, IModel? model, MigrationCommandListBuilder builder)
    {
        if (operation.OldColumn.Name != operation.Name ||
            operation.OldColumn.Schema != operation.Schema ||
            operation.OldColumn.Table != operation.Table ||
            operation.OldColumn.ColumnType != operation.ColumnType ||
            operation.OldColumn.IsUnicode != operation.IsUnicode ||
            operation.OldColumn.IsFixedLength != operation.IsFixedLength ||
            operation.OldColumn.MaxLength != operation.MaxLength ||
            operation.OldColumn.Precision != operation.Precision ||
            operation.OldColumn.Scale != operation.Scale ||
            operation.OldColumn.IsRowVersion != operation.IsRowVersion ||
            operation.OldColumn.IsNullable != operation.IsNullable ||
            operation.OldColumn.DefaultValue != operation.DefaultValue ||
            operation.OldColumn.DefaultValueSql != operation.DefaultValueSql ||
            operation.OldColumn.ComputedColumnSql != operation.ComputedColumnSql ||
            operation.OldColumn.IsStored != operation.IsStored ||
            operation.OldColumn.Collation != operation.Collation)
        {
            // base.Generate(operation, model, builder);
        }

        if (operation.OldColumn.Comment != operation.Comment)
        {
            Comment(builder, "COLUMN", Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Table), operation.Comment);
        }
    }

    protected override void Generate(AddColumnOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        base.Generate(operation, model, builder, terminate);

        if (operation.Comment != null)
        {
            Comment(builder, "COLUMN", Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name, operation.Table), operation.Comment);
        }
    }

    protected virtual void Comment(MigrationCommandListBuilder builder, string objectType, string objectName, string? comment)
    {
        var stringTypeMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string))!;

        builder.Append("COMMENT ON ").Append(objectType).Append(" ")
            .Append(objectName)
            .Append(" IS ")
            .AppendLine(stringTypeMapping.GenerateSqlLiteral(comment))
            .AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator);

        EndStatement(builder);
    }
}
