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

    /// <inheritdoc />
    protected override DbConnection CreateDbConnection()
    {
        var connection = new DuckDBConnection(GetValidatedConnectionString());

        return connection;
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
