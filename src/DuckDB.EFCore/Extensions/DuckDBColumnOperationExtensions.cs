using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DuckDB.EFCore.Extensions;

/// <summary>
///     DuckDB specific extension methods for <see cref="ColumnOperation" />.
/// </summary>
public static class DuckDBColumnOperationExtensions
{
    /// <summary>
    ///     Gets the compression type configured for the column.
    /// </summary>
    /// <param name="columnOperation">The column operation.</param>
    /// <returns>The compression type, or <see langword="null" /> if none is configured.</returns>
    public static CompressionType? GetCompressionType(this ColumnOperation columnOperation)
    {
        return columnOperation[DuckDBAnnotationNames.CompressionType] is CompressionType compressionType ? compressionType : null;
    }
}
