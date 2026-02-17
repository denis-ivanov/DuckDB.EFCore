using Microsoft.EntityFrameworkCore.Migrations;

namespace DuckDB.EFCore.Migrations.Internal;

public class DuckDBHistoryRepository : HistoryRepository
{
    public DuckDBHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
    {
    }

    protected override bool InterpretExistsResult(object? value)
    {
        throw new NotImplementedException();
    }

    public override IMigrationsDatabaseLock AcquireDatabaseLock()
    {
        throw new NotImplementedException();
    }

    public override Task<IMigrationsDatabaseLock> AcquireDatabaseLockAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public override string GetCreateIfNotExistsScript()
    {
        throw new NotImplementedException();
    }

    public override string GetBeginIfNotExistsScript(string migrationId)
    {
        throw new NotImplementedException();
    }

    public override string GetBeginIfExistsScript(string migrationId)
    {
        throw new NotImplementedException();
    }

    public override string GetEndIfScript()
    {
        throw new NotImplementedException();
    }

    public override LockReleaseBehavior LockReleaseBehavior { get; }

    protected override string ExistsSql { get; }
}