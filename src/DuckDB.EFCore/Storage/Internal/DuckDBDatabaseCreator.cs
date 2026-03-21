using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBDatabaseCreator : RelationalDatabaseCreator
{
    private readonly IDuckDBRelationalConnection _connection;
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;

    public DuckDBDatabaseCreator(
        RelationalDatabaseCreatorDependencies dependencies,
        IDuckDBRelationalConnection connection,
        IRawSqlCommandBuilder rawSqlCommandBuilder)
        : base(dependencies)
    {
        _connection = connection;
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
    }

    public override bool Exists()
    {
        var connectionOptions = new DuckDBConnectionStringBuilder
        {
            ConnectionString = _connection.ConnectionString
        };

        if (connectionOptions.DataSource.Equals(DuckDBConnectionStringBuilder.InMemoryDataSource, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        using var readOnlyConnection = _connection.CreateReadOnlyConnection();

        try
        {
            readOnlyConnection.Open(errorsExpected: true);
        }
        catch (DuckDBException ex) // TODO Verify error code
        {
            return false;
        }

        return true;
    }

    public override bool HasTables()
    {
        return (bool)_rawSqlCommandBuilder
            .Build(
                """
                SELECT coalesce(any_value(true), false)
                  FROM duckdb_tables
                 WHERE table_name != $default_table_name
                """,
                [
                    new DuckDBParameter("default_table_name", HistoryRepository.DefaultTableName)
                ]).RelationalCommand.ExecuteScalar(new RelationalCommandParameterObject(
                Dependencies.Connection,
                null,
                null,
                null,
                Dependencies.CommandLogger, CommandSource.Migrations))!;
    }

    public override void Create()
    {
        Dependencies.Connection.Open();
        Dependencies.Connection.Close();
    }

    public override void Delete()
    {
        var connection = (DuckDBConnection)Dependencies.Connection.DbConnection;
        connection.Close();

        if (File.Exists(connection.DataSource))
        {
            File.Delete(connection.DataSource);
        }
    }
}