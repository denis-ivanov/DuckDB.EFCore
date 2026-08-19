using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuckDB.EFCore.Extensions;

/// <summary>
///     Entity type extension methods for DuckDB-specific metadata.
/// </summary>
public static class DuckDBEntityTypeExtensions
{
    /// <summary>
    ///     Gets the parquet path configured for the specified entity type.
    /// </summary>
    /// <returns>The configured parquet path, or <see langword="null" /> if none has been configured.</returns>
    public static string? GetParquetPath(this IEntityType entityType)
        => entityType.FindAnnotation(DuckDBAnnotationNames.ParquetPath)?.Value as string;

    /// <summary>
    ///     Configures the entity type to query data from the specified parquet path.
    /// </summary>
    /// <param name="path">The parquet file path or glob pattern passed to DuckDB <c>read_parquet(...)</c>.</param>
    /// <returns>The same builder instance so that multiple calls can be chained.</returns>
    /// <remarks>
    ///     This affects query SQL generation for the entity type by translating table references to
    ///     DuckDB <c>read_parquet(...)</c>. It does not configure update pipeline behavior.
    /// </remarks>
    public static EntityTypeBuilder<TEntity> FromParquet<TEntity>(
        this EntityTypeBuilder<TEntity> entityTypeBuilder,
        string path)
        where TEntity : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        entityTypeBuilder.Metadata.SetAnnotation(DuckDBAnnotationNames.ParquetPath, path);

        return entityTypeBuilder;
    }
}
