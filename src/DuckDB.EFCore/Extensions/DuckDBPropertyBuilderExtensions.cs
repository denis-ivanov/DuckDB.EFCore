using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBPropertyBuilderExtensions
{
    public static PropertyBuilder UseAutoIncrementStrategy(this PropertyBuilder propertyBuilder)
    {
        propertyBuilder.HasAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy, DuckDBValueGenerationStrategy.AutoIncrement);
        return propertyBuilder;
    }

    public static PropertyBuilder<TProperty> UseAutoIncrementStrategy<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
    {
        propertyBuilder.HasAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy, DuckDBValueGenerationStrategy.AutoIncrement);
        return propertyBuilder;
    }

    public static PropertyBuilder UseNoValueGenerationStrategy(this PropertyBuilder propertyBuilder)
    {
        propertyBuilder.HasAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy, DuckDBValueGenerationStrategy.None);
        return propertyBuilder;
    }
}