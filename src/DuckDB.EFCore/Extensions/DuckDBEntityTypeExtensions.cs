using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DuckDB.EFCore.Extensions;

/// <summary>
///     Entity type extension methods for DuckDB-specific metadata.
/// </summary>
public static class DuckDBEntityTypeExtensions
{
    public static string? GetParquetPath(this IEntityType entityType)
        => entityType.FindAnnotation(DuckDBAnnotationNames.ParquetPath)?.Value as string;
}
