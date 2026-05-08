using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

namespace DuckDB.EFCore.Metadata.Conventions;

/// <summary>
///     A convention that applies parquet path metadata from <see cref="FromParquetAttribute" />.
/// </summary>
/// <remarks>
///     When an entity type is added to the model, this convention reads <see cref="FromParquetAttribute" />
///     from the CLR type and stores the configured path in the DuckDB parquet path annotation.
/// </remarks>
public sealed class DuckDBParquetConvention : IEntityTypeAddedConvention
{
    public void ProcessEntityTypeAdded(
        IConventionEntityTypeBuilder entityTypeBuilder,
        IConventionContext<IConventionEntityTypeBuilder> context)
    {
        var parquetAttribute = entityTypeBuilder.Metadata.ClrType?.GetCustomAttribute<FromParquetAttribute>(inherit: true);

        if (parquetAttribute is null)
        {
            return;
        }

        entityTypeBuilder.HasAnnotation(DuckDBAnnotationNames.ParquetPath, parquetAttribute.Path);
    }
}
