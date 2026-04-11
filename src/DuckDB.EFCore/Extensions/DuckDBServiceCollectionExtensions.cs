using DuckDB.EFCore.Diagnostics.Internal;
using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.Infrastructure.Internal;
using DuckDB.EFCore.Internal;
using DuckDB.EFCore.Metadata.Conventions;
using DuckDB.EFCore.Metadata.Internal;
using DuckDB.EFCore.Migrations;
using DuckDB.EFCore.Migrations.Internal;
using DuckDB.EFCore.Query.Internal;
using DuckDB.EFCore.Storage.Internal;
using DuckDB.EFCore.Update.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBServiceCollectionExtensions
{
    public static IServiceCollection AddDuckDB<TContext>(
        this IServiceCollection serviceCollection,
        string? connectionString,
        Action<DuckDBDbContextOptionsBuilder>? DuckDBOptionsAction = null,
        Action<DbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
        => serviceCollection.AddDbContext<TContext>(
            (_, options) =>
            {
                optionsAction?.Invoke(options);
                options.UseDuckDB(connectionString, DuckDBOptionsAction);
            });
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IServiceCollection AddEntityFrameworkDuckDB(this IServiceCollection serviceCollection)
    {
        var builder = new EntityFrameworkRelationalServicesBuilder(serviceCollection)
            .TryAdd<LoggingDefinitions, DuckDBLoggingDefinitions>()
            .TryAdd<IDatabaseProvider, DatabaseProvider<DuckDBOptionsExtension>>()
            .TryAdd<IRelationalTypeMappingSource, DuckDBTypeMappingSource>()
            .TryAdd<ISqlGenerationHelper, DuckDBSqlGenerationHelper>()
            .TryAdd<IRelationalAnnotationProvider, DuckDBAnnotationProvider>()
            .TryAdd<IModelValidator, DuckDBModelValidator>()
            .TryAdd<IProviderConventionSetBuilder, DuckDBConventionSetBuilder>()
            .TryAdd<IModificationCommandBatchFactory, DuckDBModificationCommandBatchFactory>()
            .TryAdd<IModificationCommandFactory, DuckDBModificationCommandFactory>()
            .TryAdd<IRelationalConnection>(p => p.GetRequiredService<IDuckDBRelationalConnection>())
            .TryAdd<IMigrationsSqlGenerator, DuckDBMigrationsSqlGenerator>()
            .TryAdd<IRelationalDatabaseCreator, DuckDBDatabaseCreator>()
            .TryAdd<IHistoryRepository, DuckDBHistoryRepository>()
            .TryAdd<ICompiledQueryCacheKeyGenerator, DuckDBCompiledQueryCacheKeyGenerator>()
            .TryAdd<IQueryCompilationContextFactory, DuckDBQueryCompilationContextFactory>()
            .TryAdd<IMethodCallTranslatorProvider, DuckDBMethodCallTranslatorProvider>()
            .TryAdd<IAggregateMethodCallTranslatorProvider, DuckDBAggregateMethodCallTranslatorProvider>()
            .TryAdd<IMemberTranslatorProvider, DuckDBMemberTranslatorProvider>()
            .TryAdd<IEvaluatableExpressionFilter, DuckDBEvaluatableExpressionFilter>()
            .TryAdd<IQuerySqlGeneratorFactory, DuckDBQuerySqlGeneratorFactory>()
            .TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, DuckDBQueryableMethodTranslatingExpressionVisitorFactory>()
            .TryAdd<IRelationalSqlTranslatingExpressionVisitorFactory, DuckDBSqlTranslatingExpressionVisitorFactory>()
            .TryAdd<IQueryTranslationPostprocessorFactory, DuckDBQueryTranslationPostprocessorFactory>()
            .TryAdd<IUpdateSqlGenerator, DuckDBUpdateSqlGenerator>()
            .TryAdd<ISqlExpressionFactory, DuckDBSqlExpressionFactory>()
            .TryAdd<IRelationalParameterBasedSqlProcessorFactory, DuckDBParameterBasedSqlProcessorFactory>()
            .TryAdd<ISingletonOptions, IDuckDBSingletonOptions>(p => p.GetRequiredService<IDuckDBSingletonOptions>())
            .TryAddProviderSpecificServices(b => b
                .TryAddSingleton<IDuckDBSingletonOptions, DuckDBSingletonOptions>()
                .TryAddScoped<IDuckDBRelationalConnection, DuckDBRelationalConnection>());

        builder.TryAddCoreServices();

        return serviceCollection;
    }
}