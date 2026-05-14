using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Infrastructure.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBRelationalConnection : RelationalConnection, IDuckDBRelationalConnection
{
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
    private readonly IDiagnosticsLogger<DbLoggerCategory.Infrastructure> _logger;
    private readonly bool _loadSpatial;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBRelationalConnection(
        RelationalConnectionDependencies dependencies,
        IRawSqlCommandBuilder rawSqlCommandBuilder,
        IDiagnosticsLogger<DbLoggerCategory.Infrastructure> logger)
        : base(dependencies)
    {
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
        _logger = logger;

        var optionsExtension = dependencies.ContextOptions.FindExtension<DuckDBOptionsExtension>();
        _loadSpatial = optionsExtension?.LoadSpatialite == true;
    }

    // DuckDB.NET only supports IsolationLevel.Unspecified and IsolationLevel.Snapshot.
    // We expose IsolationLevel.Snapshot to callers so that EF Core's interception infrastructure
    // always sees a concrete isolation level instead of Unspecified.
    private const IsolationLevel DuckDBDefaultIsolationLevel = IsolationLevel.Snapshot;

    /// <inheritdoc />
    protected override DbConnection CreateDbConnection()
    {
        var connection = new DuckDBConnection(GetValidatedConnectionString());

        return connection;
    }

    /// <inheritdoc />
    /// <remarks>
    ///     Overrides the no-arg overload so that EF Core's interception pipeline sees
    ///     <see cref="IsolationLevel.Snapshot" /> (DuckDB's actual isolation level) instead of
    ///     <see cref="IsolationLevel.Unspecified" /> in the event data.
    /// </remarks>
    public override IDbContextTransaction BeginTransaction()
        => BeginTransaction(DuckDBDefaultIsolationLevel);

    /// <inheritdoc />
    public override Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => BeginTransactionAsync(DuckDBDefaultIsolationLevel, cancellationToken);

    /// <inheritdoc />
    protected override DbTransaction ConnectionBeginTransaction(IsolationLevel isolationLevel)
    {
        // DuckDB.NET only accepts Unspecified and Snapshot; map unsupported levels to Unspecified.
        var driverLevel = ToDuckDBIsolationLevel(isolationLevel);
        var transaction = base.ConnectionBeginTransaction(driverLevel);

        return new DuckDBDbTransactionWrapper(transaction, isolationLevel);
    }

    /// <inheritdoc />
    protected override async ValueTask<DbTransaction> ConnectionBeginTransactionAsync(
        IsolationLevel isolationLevel,
        CancellationToken cancellationToken = default)
    {
        // DuckDB.NET only accepts Unspecified and Snapshot; map unsupported levels to Unspecified.
        var driverLevel = ToDuckDBIsolationLevel(isolationLevel);
        var transaction = await base.ConnectionBeginTransactionAsync(driverLevel, cancellationToken);

        return new DuckDBDbTransactionWrapper(transaction, isolationLevel);
    }

    /// <summary>
    ///     Maps any <see cref="IsolationLevel" /> to one that DuckDB.NET accepts
    ///     (<see cref="IsolationLevel.Unspecified" /> or <see cref="IsolationLevel.Snapshot" />).
    ///     Unsupported levels fall back to <see cref="IsolationLevel.Unspecified" />.
    /// </summary>
    private static IsolationLevel ToDuckDBIsolationLevel(IsolationLevel isolationLevel)
        => isolationLevel is IsolationLevel.Unspecified or IsolationLevel.Snapshot
            ? isolationLevel
            : IsolationLevel.Unspecified;

    /// <summary>
    ///     Wraps a <see cref="DbTransaction" /> to expose a concrete <see cref="IsolationLevel" /> because
    ///     DuckDB.NET reports <see cref="IsolationLevel.Unspecified" /> for all transactions.
    /// </summary>
    private sealed class DuckDBDbTransactionWrapper(DbTransaction inner, IsolationLevel isolationLevel) : DbTransaction
    {
        public override IsolationLevel IsolationLevel { get; } = isolationLevel;
        protected override DbConnection DbConnection => inner.Connection!;
        public override void Commit() => inner.Commit();
        public override void Rollback() => inner.Rollback();
        public override Task CommitAsync(CancellationToken cancellationToken = default) => inner.CommitAsync(cancellationToken);
        public override Task RollbackAsync(CancellationToken cancellationToken = default) => inner.RollbackAsync(cancellationToken);
        protected override void Dispose(bool disposing) { if (disposing) inner.Dispose(); }
        public override ValueTask DisposeAsync() => inner.DisposeAsync();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual IDuckDBRelationalConnection CreateReadOnlyConnection()
    {
        var connectionStringBuilder = new DuckDBConnectionStringBuilder()
        {
            ConnectionString = GetValidatedConnectionString()
        };

        var contextOptions = new DbContextOptionsBuilder().UseDuckDB(connectionStringBuilder.ToString()).Options;

        return new DuckDBRelationalConnection(Dependencies with { ContextOptions = contextOptions }, _rawSqlCommandBuilder, _logger);
    }

    protected override void CloseDbConnection()
    {
        var connection = (DuckDBConnection)DbConnection;

        if (connection.State != ConnectionState.Closed)
        {
            connection.Close();
        }
    }

    protected override async Task CloseDbConnectionAsync()
    {
        var connection = (DuckDBConnection)DbConnection;

        if (connection.State != ConnectionState.Closed)
        {
            await connection.CloseAsync();
        }
    }

    protected override void OpenDbConnection(bool errorsExpected)
    {
        var connection = (DuckDBConnection)DbConnection;

        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
            LoadSpatialExtensionIfNeeded();
        }
    }

    protected override async Task OpenDbConnectionAsync(bool errorsExpected, CancellationToken cancellationToken)
    {
        var connection = (DuckDBConnection)DbConnection;

        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync(cancellationToken);
            await LoadSpatialExtensionIfNeededAsync(cancellationToken);
        }
    }

    private void LoadSpatialExtensionIfNeeded()
    {
        if (!_loadSpatial)
        {
            return;
        }

        var paramObj = new RelationalCommandParameterObject(this, null, null, null, null);
        _rawSqlCommandBuilder.Build("INSTALL spatial").ExecuteNonQuery(paramObj);
        _rawSqlCommandBuilder.Build("LOAD spatial").ExecuteNonQuery(paramObj);
    }

    private async Task LoadSpatialExtensionIfNeededAsync(CancellationToken cancellationToken)
    {
        if (!_loadSpatial)
        {
            return;
        }

        var paramObj = new RelationalCommandParameterObject(this, null, null, null, null);
        await _rawSqlCommandBuilder.Build("INSTALL spatial").ExecuteNonQueryAsync(paramObj, cancellationToken);
        await _rawSqlCommandBuilder.Build("LOAD spatial").ExecuteNonQueryAsync(paramObj, cancellationToken);
    }
}
