using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DuckDB.EFCore.Extensions;

/// <summary>
///     Entity type extension methods for DuckDB-specific metadata.
/// </summary>
public static class DuckDBEntityTypeExtensions
{
    public static string? GetParquetPath(this IEntityType entityType)
        => entityType.FindAnnotation(DuckDBAnnotationNames.ParquetPath)?.Value as string;

    public static string? GetParquetPathFactoryValue(this IEntityType entityType)
        => entityType.FindAnnotation(DuckDBAnnotationNames.ParquetPathFactoryValue)?.Value as string;

    public static Func<ServiceProvider, string>? GetParquetPathFactory(this IEntityType entityType)
        => entityType.FindAnnotation(DuckDBAnnotationNames.ParquetPathFactory)?.Value as Func<ServiceProvider, string>;

    public static EntityTypeBuilder<TEntity> FromParquet<TEntity>(
        this EntityTypeBuilder<TEntity> entityTypeBuilder,
        string path)
        where TEntity : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        entityTypeBuilder.Metadata.SetAnnotation(DuckDBAnnotationNames.ParquetPath, path);
        entityTypeBuilder.Metadata.RemoveAnnotation(DuckDBAnnotationNames.ParquetPathFactory);
        entityTypeBuilder.Metadata.RemoveAnnotation(DuckDBAnnotationNames.ParquetPathFactoryValue);

        return entityTypeBuilder;
    }

    public static EntityTypeBuilder<TEntity> FromParquet<TEntity>(
        this EntityTypeBuilder<TEntity> entityTypeBuilder,
        Func<ServiceProvider, string> parquetPathFactory)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(parquetPathFactory);

        var serviceProvider = new ServiceCollection().BuildServiceProvider();
        var initialPath = parquetPathFactory(serviceProvider);
        ArgumentException.ThrowIfNullOrWhiteSpace(initialPath);

        entityTypeBuilder.Metadata.SetAnnotation(DuckDBAnnotationNames.ParquetPathFactory, parquetPathFactory);
        entityTypeBuilder.Metadata.SetAnnotation(DuckDBAnnotationNames.ParquetPathFactoryValue, initialPath);
        entityTypeBuilder.Metadata.RemoveAnnotation(DuckDBAnnotationNames.ParquetPath);

        return entityTypeBuilder;
    }
}
