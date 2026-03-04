using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Infrastructure;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace DuckDB.EFCore.FunctionalTests.TestUtilities;

public class DuckDBTestStore : RelationalTestStore
{
    public const int CommandTimeout = 30;

    public static DuckDBTestStore GetOrCreate(string name, bool sharedCache = false)
        => new(name, sharedCache: sharedCache);

    public static async Task<DuckDBTestStore> GetOrCreateInitializedAsync(string name)
        => await new DuckDBTestStore(name).InitializeDuckDBAsync(
            new ServiceCollection().AddEntityFrameworkDuckDB().BuildServiceProvider(validateScopes: true),
            (Func<DbContext>?)null,
            null);

    public static DuckDBTestStore GetExisting(string name)
        => new(name, seed: false);

    public static DuckDBTestStore Create(string name)
        => new(name, shared: false);

    private readonly bool _seed;

    private DuckDBTestStore(string name, bool seed = true, bool sharedCache = false, bool shared = true)
        : base(name, shared, CreateConnection(name, sharedCache))
        => _seed = seed;

    public virtual DbContextOptionsBuilder AddProviderOptions(
        DbContextOptionsBuilder builder,
        Action<DuckDBDbContextOptionsBuilder>? configureDuckDB)
        => UseConnectionString
            ? builder.UseDuckDB(
                ConnectionString, b =>
                {
                    b.CommandTimeout(CommandTimeout);
                    b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    configureDuckDB?.Invoke(b);
                })
            : builder.UseDuckDB(
                Connection, b =>
                {
                    b.CommandTimeout(CommandTimeout);
                    b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    configureDuckDB?.Invoke(b);
                });

    public override DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder)
        => AddProviderOptions(builder, configureDuckDB: null);

    public async Task<DuckDBTestStore> InitializeDuckDBAsync(
        IServiceProvider? serviceProvider,
        Func<DbContext>? createContext,
        Func<DbContext, Task>? seed)
        => (DuckDBTestStore)await InitializeAsync(serviceProvider, createContext, seed);

    public async Task<DuckDBTestStore> InitializeDuckDBAsync(
        IServiceProvider serviceProvider,
        Func<DuckDBTestStore, DbContext> createContext,
        Func<DbContext, Task> seed)
        => (DuckDBTestStore)await InitializeAsync(serviceProvider, () => createContext(this), seed);

    public override Task CleanAsync(DbContext context)
    {
        context.Database.EnsureClean();
        return Task.CompletedTask;
    }

    public int ExecuteNonQuery(string sql, params object[] parameters)
    {
        using var command = CreateCommand(sql, parameters);
        return command.ExecuteNonQuery();
    }

    public T ExecuteScalar<T>(string sql, params object[] parameters)
    {
        using var command = CreateCommand(sql, parameters);
        return (T)command.ExecuteScalar()!;
    }

    private DbCommand CreateCommand(string commandText, object[] parameters)
    {
        var command = (DuckDBCommand)Connection.CreateCommand();

        command.CommandText = commandText;
        command.CommandTimeout = CommandTimeout;

        for (var i = 0; i < parameters.Length; i++)
        {
            command.Parameters.Add(new DuckDBParameter("p" + i, parameters[i]));
        }

        return command;
    }

    private static DuckDBConnection CreateConnection(string name, bool sharedCache)
    {
        var connectionString = new DuckDBConnectionStringBuilder
        {
            DataSource = sharedCache
                ? DuckDBConnectionStringBuilder.InMemorySharedDataSource
                : name + ".db"
        }.ToString();

        return new DuckDBConnection(connectionString);
    }

    protected override string OpenDelimiter => "\"";

    protected override string CloseDelimiter => "\"";
}
