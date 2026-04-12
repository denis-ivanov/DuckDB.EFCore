using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Migrations.Internal;

public class DuckDBMigrationDatabaseLock : IMigrationsDatabaseLock
{
    private readonly IRelationalCommand _releaseLockCommand;
    private readonly RelationalCommandParameterObject _relationalCommandParameters;
    private readonly CancellationToken _cancellationToken;

    public DuckDBMigrationDatabaseLock(
        IRelationalCommand releaseLockCommand,
        RelationalCommandParameterObject relationalCommandParameters,
        IHistoryRepository historyRepository,
        CancellationToken cancellationToken = default)
    {
        _releaseLockCommand = releaseLockCommand;
        _relationalCommandParameters = relationalCommandParameters;
        _cancellationToken = cancellationToken;
        HistoryRepository = historyRepository;
    }

    public void Dispose()
    {
        _releaseLockCommand.ExecuteScalar(_relationalCommandParameters);
    }

    public async ValueTask DisposeAsync()
    {
        await _releaseLockCommand.ExecuteScalarAsync(_relationalCommandParameters, _cancellationToken);
    }

    public IHistoryRepository HistoryRepository { get; }
}
