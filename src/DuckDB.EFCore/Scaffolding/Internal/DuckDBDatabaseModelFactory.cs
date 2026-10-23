using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using DuckDB.EFCore.Storage.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Scaffolding.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBDatabaseModelFactory : DatabaseModelFactory
{
    /// <inheritdoc />
    public override DatabaseModel Create(string connectionString, DatabaseModelFactoryOptions options)
    {
        using var connection = new DuckDBConnection(connectionString);
        return Create(connection, options);
    }

    /// <inheritdoc />
    public override DatabaseModel Create(DbConnection connection, DatabaseModelFactoryOptions options)
    {
        var databaseModel = new DatabaseModel
        {
            DatabaseName = connection.Database,
            DefaultSchema = "main"
        };

        var connectionStartedOpen = connection.State == ConnectionState.Open;

        if (!connectionStartedOpen)
        {
            connection.Open();
        }

        try
        {
            FillTables((DuckDBConnection)connection, databaseModel, options.Tables);
            FillViews((DuckDBConnection)connection, databaseModel, options.Tables);
            FillColumns((DuckDBConnection)connection, databaseModel);
            FillConstraints((DuckDBConnection)connection, databaseModel);
            FillIndexes((DuckDBConnection)connection, databaseModel);
            FillSequences((DuckDBConnection)connection, databaseModel);
        }
        finally
        {
            if (!connectionStartedOpen)
            {
                connection.Close();
            }
        }

        return databaseModel;
    }

    private void FillTables(DuckDBConnection connection, DatabaseModel databaseModel, IEnumerable<string> tables)
    {
        using var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT *
                                FROM duckdb_tables()
                               WHERE table_name != $default_table_name
                                 AND (array_length(CAST($tables AS VARCHAR[])) = 0 OR table_name = ANY(CAST($tables AS VARCHAR[])));
                              """;

        var defaultTableNameParameter = (DuckDBParameter)command.CreateParameter();
        defaultTableNameParameter.ParameterName = "default_table_name";
        defaultTableNameParameter.Value = HistoryRepository.DefaultTableName;
        defaultTableNameParameter.DbType = DbType.String;

        var tablesParameter = (DuckDBParameter)command.CreateParameter();
        tablesParameter.ParameterName = "tables";
        tablesParameter.Value = tables.ToList();
        tablesParameter.DbType = DbType.Object;

        command.Parameters.Add(defaultTableNameParameter);
        command.Parameters.Add(tablesParameter);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var name = reader.GetString("table_name");
            var schema = reader.GetString("schema_name");
            var comment = reader.IsDBNull("comment") ? null : reader.GetString("comment");

            var table = new DatabaseTable
            {
                Database = databaseModel,
                Name = name,
                Schema = schema,
                Comment = comment
            };

            databaseModel.Tables.Add(table);
        }
    }

    private void FillViews(DuckDBConnection connection, DatabaseModel databaseModel, IEnumerable<string> tables)
    {
        using var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT *
                                FROM duckdb_views()
                               WHERE internal = false 
                                 AND view_name != $default_table_name
                                 AND (array_length(CAST($tables AS VARCHAR[])) = 0 OR view_name = ANY(CAST($tables AS VARCHAR[])));
                              """;

        var defaultTableNameParameter = (DuckDBParameter)command.CreateParameter();
        defaultTableNameParameter.ParameterName = "default_table_name";
        defaultTableNameParameter.Value = HistoryRepository.DefaultTableName;
        defaultTableNameParameter.DbType = DbType.String;

        var tablesParameter = (DuckDBParameter)command.CreateParameter();
        tablesParameter.ParameterName = "tables";
        tablesParameter.Value = tables.ToList();
        tablesParameter.DbType = DbType.Object;

        command.Parameters.Add(defaultTableNameParameter);
        command.Parameters.Add(tablesParameter);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var name = reader.GetString("view_name");
            var schema = reader.GetString("schema_name");
            var comment = reader.IsDBNull("comment") ? null : reader.GetString("comment");

            var table = new DatabaseView { Database = databaseModel, Name = name, Schema = schema, Comment = comment };

            databaseModel.Tables.Add(table);
        }
    }

    private void FillColumns(DuckDBConnection connection, DatabaseModel database)
    {
        foreach (var table in database.Tables)
        {
            using var command = connection.CreateCommand();
            if (table is DatabaseView)
            {
                command.CommandText = """
                                      SELECT c.*, NULL AS compression
                                        FROM duckdb_columns c
                                       WHERE c.table_name = $table_name
                                         AND c.schema_name = $table_schema
                                      """;
            }
            else
            {
                
                var tableName = string.IsNullOrEmpty(table.Schema)
                    ? table.Name.Replace("'", "''")
                    : $"{table.Schema.Replace("'", "''")}.{table.Name.Replace("'", "''")}";

                command.CommandText = $"""
                                       SELECT c.*, s.compression
                                         FROM duckdb_columns c
                                         LEFT
                                         JOIN (SELECT column_name, FIRST(compression) AS compression FROM pragma_storage_info('{tableName}') GROUP BY column_name) s
                                           ON c.column_name = s.column_name
                                        WHERE c.table_name = $table_name
                                          AND c.schema_name = $table_schema
                                       """;
            }

            command.Parameters.Add(new DuckDBParameter("table_name", table.Name));
            command.Parameters.Add(new DuckDBParameter("table_schema", table.Schema));

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var columnName = reader.GetString("column_name");
                var dataType = reader.GetString("data_type");
                var isNullable = reader.GetBoolean("is_nullable");
                var defaultValueSql = !reader.IsDBNull("column_default") ? reader.GetString("column_default") : null;
                var columnComment = reader.IsDBNull("comment") ? null : reader.GetString("comment");
                var columnDefault = reader.IsDBNull("column_default") ? null : reader.GetString("column_default");
                var characterMaximumLength = reader.IsDBNull("character_maximum_length") ? (int?)null : reader.GetInt32("character_maximum_length");
                var numericPrecision = reader.IsDBNull("numeric_precision") ? (int?)null : reader.GetInt32("numeric_precision");
                var numericScale = reader.IsDBNull("numeric_scale") ? (int?)null : reader.GetInt32("numeric_scale");
                var compression = reader.IsDBNull("compression") ? null : reader.GetString("compression");

                var column = new DatabaseColumn
                {
                    Table = table,
                    Name = columnName,
                    StoreType = dataType,
                    IsNullable = isNullable,
                    DefaultValueSql = defaultValueSql,
                    ValueGenerated = !string.IsNullOrWhiteSpace(defaultValueSql) && defaultValueSql.StartsWith("nextval(") && defaultValueSql.EndsWith(")")
                        ? ValueGenerated.OnAdd
                        : null,
                    Comment = columnComment,
                    DefaultValue = columnDefault
                };

                if (characterMaximumLength.HasValue)
                {
                    column.SetAnnotation(CoreAnnotationNames.MaxLength, characterMaximumLength.Value);
                }

                if (numericPrecision.HasValue)
                {
                    column.SetAnnotation(CoreAnnotationNames.Precision, numericPrecision.Value);
                }

                if (numericScale.HasValue)
                {
                    column.SetAnnotation(CoreAnnotationNames.Scale, numericScale.Value);
                }

                if (!string.IsNullOrWhiteSpace(compression) && Enum.TryParse<CompressionType>(compression, out var compressionType))
                {
                    column.SetAnnotation(DuckDBAnnotationNames.CompressionType, compressionType);
                }

                table.Columns.Add(column);
            }
        }
    }

    private void FillConstraints(DuckDBConnection connection, DatabaseModel database)
    {
        var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT cnts.*, rc.delete_rule
                                FROM duckdb_constraints() AS cnts
                                LEFT
                                JOIN information_schema.referential_constraints AS rc
                                  ON cnts.constraint_name = rc.constraint_name
                                 AND cnts.schema_name = rc.constraint_schema
                                 AND cnts.constraint_type = 'FOREIGN KEY'
                              """;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string? schemaName = reader.IsDBNull("schema_name") ? null : reader.GetString("schema_name");
            string? tableName = reader.IsDBNull("table_name") ? null : reader.GetString("table_name");

            var table = database.Tables.SingleOrDefault(e => e.Schema == schemaName && e.Name == tableName);

            if (table is null)
            {
                continue;
            }

            string? constraintType = reader.IsDBNull("constraint_type") ? null : reader.GetString("constraint_type");
            List<string>? constraintColumnNames = reader.IsDBNull("constraint_column_names") ? null : (List<string>)reader.GetValue("constraint_column_names");
            string? constraintName = reader.IsDBNull("constraint_name") ? null : reader.GetString("constraint_name");
            string? referencedTable = reader.IsDBNull("referenced_table") ? null : reader.GetString("referenced_table");
            List<string>? referencedColumnNames = reader.IsDBNull("referenced_column_names") ? null : (List<string>)reader.GetValue("referenced_column_names");
            string? deleteRule = reader.IsDBNull("delete_rule") ? null : reader.GetString("delete_rule");

            switch (constraintType)
            {
                case "CHECK":
                    // Could be usefull
                    break;

                case "FOREIGN KEY":
                    {
                        var principalTable = database.Tables.Single(e => e.Name == referencedTable);
                        var foreignKey = new DatabaseForeignKey
                        {
                            Table = table,
                            Name = constraintName ?? $"FK_{table.Name}_{string.Join("_", constraintColumnNames!)}_{referencedTable}",
                            PrincipalTable = principalTable,
                            OnDelete = ConvertToReferentialAction(deleteRule)
                        };

                        foreach (string constraintColumnName in constraintColumnNames!)
                        {
                            foreignKey.Columns.Add(table.Columns.Single(e => e.Name == constraintColumnName));
                        }

                        foreach(string referencedColumnName in referencedColumnNames!)
                        {
                            foreignKey.PrincipalColumns.Add(principalTable.Columns.Single(e => e.Name == referencedColumnName));
                        }

                        table.ForeignKeys.Add(foreignKey);
                        break;
                    }

                case "PRIMARY KEY":
                    {
                        var primaryKey = new DatabasePrimaryKey
                        {
                            Table = table, Name = constraintName ?? $"PK_{table.Name}",
                        };

                        foreach (var constraintColumnName in constraintColumnNames!)
                        {
                            primaryKey.Columns.Add(table.Columns.Single(e => e.Name == constraintColumnName));
                        }

                        table.PrimaryKey = primaryKey;
                        break;
                    }

                case "NOT NULL":
                    break;

                case "UNIQUE":
                    {
                        var uniqueConstraint = new DatabaseUniqueConstraint
                        {
                            Table = table,
                            Name = constraintName ?? $"UQ_{table.Name}_{string.Join("_", constraintColumnNames!)}"
                        };

                        foreach (var constraintColumnName in constraintColumnNames!)
                        {
                            uniqueConstraint.Columns.Add(table.Columns.Single(e => e.Name == constraintColumnName));
                        }

                        break;
                    }
            }
        }
    }

    private void FillIndexes(DuckDBConnection connection, DatabaseModel database)
    {
        using var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT *
                                FROM duckdb_indexes
                              """;

        command.Parameters.Add(new DuckDBParameter("database_name", DbType.String, database.DatabaseName));

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var schemaName = reader.IsDBNull("schema_name") ? null : reader.GetString("schema_name");
            var tableName = reader.IsDBNull("table_name") ? null : reader.GetString("table_name");

            var table = database.Tables.SingleOrDefault(e => e.Schema == schemaName && e.Name == tableName);

            if (table is null)
            {
                continue;
            }

            var index = new DatabaseIndex
            {
                Name = reader.GetString("index_name"),
                Table = table,
                IsUnique = reader.GetBoolean("is_unique")
            };

            var expressions = reader.GetFieldValue<string>("expressions");
            var columns = Array.ConvertAll(expressions.TrimStart('[').TrimEnd(']').Split(','), e => e.Trim().Trim(['\'', '\"']));

            foreach (var column in columns)
            {
                var tableColumn = table.Columns.Single(c => c.Name == column);

                index.Columns.Add(tableColumn);
                index.IsDescending.Add(false);
            }

            table.Indexes.Add(index);
        }
    }

    private void FillSequences(DuckDBConnection connection, DatabaseModel database)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM duckdb_sequences()";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sequence = new DatabaseSequence
            {
                Name = reader.GetString("sequence_name"),
                Schema = reader.GetString("schema_name"),
                Database = database,
                IncrementBy = reader.GetInt32("increment_by"),
                StartValue = reader.GetInt64("start_value"),
                MinValue = reader.GetInt64("min_value"),
                MaxValue = reader.GetInt64("max_value"),
                IsCyclic = reader.GetBoolean("cycle"),
                StoreType = DuckDBInt64TypeMapping.Default.StoreType
            };

            database.Sequences.Add(sequence);
        }
    }

    private static ReferentialAction? ConvertToReferentialAction(string? value)
        => value switch
        {
            "RESTRICT" => ReferentialAction.Restrict,
            "CASCADE" => ReferentialAction.Cascade,
            "SET NULL" => ReferentialAction.SetNull,
            "SET DEFAULT" => ReferentialAction.SetDefault,
            "NO ACTION" => ReferentialAction.NoAction,
            _ => null
        };
}
