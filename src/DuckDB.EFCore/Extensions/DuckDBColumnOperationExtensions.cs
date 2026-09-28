using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBColumnOperationExtensions
{
    public static CompressionType? GetCompressionType(this ColumnOperation columnOperation)
    {
        return columnOperation[DuckDBAnnotationNames.CompressionType] is CompressionType compressionType ? compressionType : null;
    }
}
