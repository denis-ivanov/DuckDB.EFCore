using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBDbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseDuckDB(
        this DbContextOptionsBuilder optionsBuilder,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
    {
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(GetOrCreateExtension(optionsBuilder));
        
        ConfigureWarnings(optionsBuilder);
        
        duckDBOptionsAction?.Invoke(new DuckDBDbContextOptionsBuilder(optionsBuilder));

        return optionsBuilder;
    }

    public static DbContextOptionsBuilder UseDuckDB(
        this DbContextOptionsBuilder optionsBuilder,
        string? connectionString,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
    {
        var extension = (DuckDBOptionsExtension)GetOrCreateExtension(optionsBuilder).WithConnectionString(connectionString);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        
        ConfigureWarnings(optionsBuilder);
        
        duckDBOptionsAction?.Invoke(new DuckDBDbContextOptionsBuilder(optionsBuilder));

        return optionsBuilder;
    }
    
    public static DbContextOptionsBuilder UseDuckDB(
        this DbContextOptionsBuilder optionsBuilder,
        DbConnection connection,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
        => UseDuckDB(optionsBuilder, connection, false, duckDBOptionsAction);
    
    public static DbContextOptionsBuilder UseDuckDB(
        this DbContextOptionsBuilder optionsBuilder,
        DbConnection connection,
        bool contextOwnsConnection,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var extension = (DuckDBOptionsExtension)GetOrCreateExtension(optionsBuilder).WithConnection(connection, contextOwnsConnection);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        
        ConfigureWarnings(optionsBuilder);
        
        duckDBOptionsAction?.Invoke(new DuckDBDbContextOptionsBuilder(optionsBuilder));

        return optionsBuilder;
    }

    public static DbContextOptionsBuilder<TContext> UseDuckDB<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseDuckDB(
            (DbContextOptionsBuilder)optionsBuilder, duckDBOptionsAction);

    public static DbContextOptionsBuilder<TContext> UseDuckDB<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        string? connectionString,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseDuckDB(
            (DbContextOptionsBuilder)optionsBuilder, connectionString, duckDBOptionsAction);
    
    public static DbContextOptionsBuilder<TContext> UseDuckDB<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        DbConnection connection,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseDuckDB(
            (DbContextOptionsBuilder)optionsBuilder, connection, duckDBOptionsAction);
    
    public static DbContextOptionsBuilder<TContext> UseDuckDB<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        DbConnection connection,
        bool contextOwnsConnection,
        Action<DuckDBDbContextOptionsBuilder>? duckDBOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseDuckDB(
            (DbContextOptionsBuilder)optionsBuilder, connection, contextOwnsConnection, duckDBOptionsAction);
    
    private static DuckDBOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder options)
        => options.Options.FindExtension<DuckDBOptionsExtension>()
           ?? new DuckDBOptionsExtension();

    private static void ConfigureWarnings(DbContextOptionsBuilder optionsBuilder)
    {
        var coreOptionsExtension
            = optionsBuilder.Options.FindExtension<CoreOptionsExtension>()
              ?? new CoreOptionsExtension();

        coreOptionsExtension = RelationalOptionsExtension.WithDefaultWarningConfiguration(coreOptionsExtension);

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(coreOptionsExtension);
    }
}