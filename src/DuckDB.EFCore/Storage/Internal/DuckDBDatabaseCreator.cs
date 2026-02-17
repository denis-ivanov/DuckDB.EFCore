using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        var count = (long)_rawSqlCommandBuilder
            .Build("SELECT COUNT(*) FROM information_schema.tables")
            .ExecuteScalar(
                new RelationalCommandParameterObject(
                    Dependencies.Connection,
                    null,
                    null,
                    null,
                    Dependencies.CommandLogger, CommandSource.Migrations))!;

        return count != 0;
    }

    public override void Create()
    {
        throw new NotImplementedException();
    }

    public override void Delete()
    {
        throw new NotImplementedException();
    }
}