using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

namespace DuckDB.EFCore.Metadata.Conventions;

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
