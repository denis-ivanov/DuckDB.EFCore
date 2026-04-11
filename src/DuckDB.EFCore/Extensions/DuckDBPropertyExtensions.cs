using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DuckDB.EFCore.Extensions;

public static class DuckDBPropertyExtensions
{
    public static DuckDBValueGenerationStrategy GetValueGenerationStrategy(this IReadOnlyProperty property)
    {
        var annotation = property.FindAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy);
        if (annotation?.Value != null)
        {
            return (DuckDBValueGenerationStrategy)annotation.Value;
        }

        return DuckDBValueGenerationStrategy.None;
    }

    public static void SetValueGenerationStrategy(
        this IMutableProperty property,
        DuckDBValueGenerationStrategy? value)
    {
        property.SetOrRemoveAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy, value);
    }

    public static DuckDBValueGenerationStrategy? SetValueGenerationStrategy(
        this IConventionProperty property,
        DuckDBValueGenerationStrategy? value,
        bool fromDataAnnotation = false)
    {
        property.SetOrRemoveAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy, value, fromDataAnnotation);
        return value;
    }
}