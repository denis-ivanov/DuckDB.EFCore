using Microsoft.EntityFrameworkCore.Migrations;

namespace DuckDB.EFCore.Migrations.Internal;

public class DuckDBMigrationDatabaseLock : IMigrationsDatabaseLock
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public IHistoryRepository HistoryRepository { get; }
}
