using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Migrations.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBHistoryRepository : HistoryRepository
{
    private static readonly TimeSpan _retryDelay = TimeSpan.FromSeconds(1);

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override bool InterpretExistsResult(object? value)
    {
        return value is true;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IMigrationsDatabaseLock AcquireDatabaseLock()
    {
        Dependencies.MigrationsLogger.AcquiringMigrationLock();

        if (!InterpretExistsResult(
                Dependencies.RawSqlCommandBuilder.Build(CreateExistsSql(LockTableName))
                    .ExecuteScalar(CreateRelationalCommandParameters())))
        {
            CreateLockTableCommand().ExecuteNonQuery(CreateRelationalCommandParameters());
        }

        var retryDelay = _retryDelay;
        while (true)
        {
            var dbLock = CreateMigrationDatabaseLock();
            var insertCount = CreateInsertLockCommand(DateTimeOffset.UtcNow)
                .ExecuteScalar(CreateRelationalCommandParameters());
            if ((int)insertCount! == 1)
            {
                return dbLock;
            }

            Thread.Sleep(retryDelay);
            if (retryDelay < TimeSpan.FromMinutes(1))
            {
                retryDelay = retryDelay.Add(retryDelay);
            }
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override async Task<IMigrationsDatabaseLock> AcquireDatabaseLockAsync(CancellationToken cancellationToken = new())
    {
        Dependencies.MigrationsLogger.AcquiringMigrationLock();
        
        if (!InterpretExistsResult(
                await Dependencies.RawSqlCommandBuilder.Build(CreateExistsSql(LockTableName))
                    .ExecuteScalarAsync(CreateRelationalCommandParameters(), cancellationToken).ConfigureAwait(false)))
        {
            await CreateLockTableCommand().ExecuteNonQueryAsync(CreateRelationalCommandParameters(), cancellationToken)
                .ConfigureAwait(false);
        }

        var retryDelay = _retryDelay;
        while (true)
        {
            var dbLock = CreateMigrationDatabaseLock();
            var insertCount = await CreateInsertLockCommand(DateTimeOffset.UtcNow)
                .ExecuteScalarAsync(CreateRelationalCommandParameters(), cancellationToken)
                .ConfigureAwait(false);
            if ((int)insertCount! == 1)
            {
                return dbLock;
            }

            await Task.Delay(_retryDelay, cancellationToken).ConfigureAwait(true);
            if (retryDelay < TimeSpan.FromMinutes(1))
            {
                retryDelay = retryDelay.Add(retryDelay);
            }
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override string GetCreateIfNotExistsScript()
    {
        var script = GetCreateScript();
        return script.Insert(script.IndexOf("CREATE TABLE", StringComparison.Ordinal) + 12, " IF NOT EXISTS");
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override string GetBeginIfNotExistsScript(string migrationId)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override string GetBeginIfExistsScript(string migrationId)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override string GetEndIfScript()
    {
        throw new NotSupportedException();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override LockReleaseBehavior LockReleaseBehavior => LockReleaseBehavior.Explicit;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override string ExistsSql => CreateExistsSql(TableName);

    /// <summary>
    ///     The name of the table that will serve as a database-wide lock for migrations.
    /// </summary>
    protected virtual string LockTableName { get; } = "__EFMigrationsLock";

    private string CreateExistsSql(string tableName)
    {
        var stringTypeMapping = Dependencies.TypeMappingSource.GetMapping(typeof(string));

        return $"""
                SELECT coalesce(any_value(true), false) FROM duckdb_tables() WHERE "table_name" = {stringTypeMapping.GenerateSqlLiteral(tableName)};
                """;
    }

    private IRelationalCommand CreateLockTableCommand()
        => Dependencies.RawSqlCommandBuilder.Build(
            $"""
             CREATE TABLE IF NOT EXISTS "{LockTableName}" (
                 "Id" INTEGER NOT NULL CONSTRAINT "PK_{LockTableName}" PRIMARY KEY,
                 "Timestamp" TEXT NOT NULL
             );
             """);

    private IRelationalCommand CreateInsertLockCommand(DateTimeOffset timestamp)
    {
        var timestampLiteral = Dependencies.TypeMappingSource.GetMapping(typeof(DateTimeOffset)).GenerateSqlLiteral(timestamp);

        return Dependencies.RawSqlCommandBuilder.Build(
            $"""
             INSERT OR IGNORE INTO "{LockTableName}"("Id", "Timestamp")
             VALUES(1, {timestampLiteral})
             RETURNING "Id"
             """);
    }

    private IRelationalCommand CreateDeleteLockCommand(int? id = null)
    {
        var sql = $"""
                   DELETE FROM "{LockTableName}"
                   """;
        if (id != null)
        {
            sql += $""" WHERE "Id" = {id}""";
        }

        sql += ";";
        return Dependencies.RawSqlCommandBuilder.Build(sql);
    }

    private DuckDBMigrationDatabaseLock CreateMigrationDatabaseLock()
        => new(CreateDeleteLockCommand(), CreateRelationalCommandParameters(), this);

    private RelationalCommandParameterObject CreateRelationalCommandParameters()
        => new(
            Dependencies.Connection,
            null,
            null,
            Dependencies.CurrentContext.Context,
            Dependencies.CommandLogger, CommandSource.Migrations);
}
