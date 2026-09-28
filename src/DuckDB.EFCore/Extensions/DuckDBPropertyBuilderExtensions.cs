using DuckDB.EFCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBPropertyBuilderExtensions
{
    public static PropertyBuilder UseAutoIncrement(this PropertyBuilder propertyBuilder)
    {
        propertyBuilder.Metadata.SetValueGenerationStrategy(DuckDBValueGenerationStrategy.AutoIncrement);

        return propertyBuilder;
    }

    public static PropertyBuilder<TProperty> UseAutoIncrement<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder)
        => (PropertyBuilder<TProperty>)UseAutoIncrement((PropertyBuilder)propertyBuilder);

    public static ColumnBuilder UseAutoIncrement(
        this ColumnBuilder columnBuilder)
    {
        columnBuilder.Overrides.SetValueGenerationStrategy(DuckDBValueGenerationStrategy.AutoIncrement);

        return columnBuilder;
    }

    public static PropertyBuilder UseCompression(this PropertyBuilder propertyBuilder, CompressionType compressionType)
    {
        propertyBuilder.Metadata.SetCompressionType(compressionType);

        return propertyBuilder;
    }

    public static PropertyBuilder<TProperty> UseCompression<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder,
        CompressionType compressionType)
        => (PropertyBuilder<TProperty>)UseCompression((PropertyBuilder)propertyBuilder, compressionType);

    public static ColumnBuilder UseCompression(
        this ColumnBuilder columnBuilder,
        CompressionType compressionType)
    {
        columnBuilder.Overrides.SetCompressionType(compressionType);

        return columnBuilder;
    }
}
