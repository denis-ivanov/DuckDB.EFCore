using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace DuckDB.EFCore.Metadata.Conventions;

public class DuckDBValueGenerationConvention :
    RelationalValueGenerationConvention,
    IModelFinalizingConvention
{
    public DuckDBValueGenerationConvention(
        ProviderConventionSetBuilderDependencies dependencies,
        RelationalConventionSetBuilderDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override void ProcessPropertyAnnotationChanged(
        IConventionPropertyBuilder propertyBuilder,
        string name,
        IConventionAnnotation? annotation,
        IConventionAnnotation? oldAnnotation,
        IConventionContext<IConventionAnnotation> context)
    {
        if (name == DuckDBAnnotationNames.ValueGenerationStrategy)
        {
            propertyBuilder.ValueGenerated(GetValueGenerated(propertyBuilder.Metadata));
            return;
        }

        base.ProcessPropertyAnnotationChanged(propertyBuilder, name, annotation, oldAnnotation, context);
    }

    protected override ValueGenerated? GetValueGenerated(IConventionProperty property)
        => GetValueGenerationStrategy(property) switch
        {
            DuckDBValueGenerationStrategy.AutoIncrement => ValueGenerated.OnAdd,
            _ => base.GetValueGenerated(property)
        };

    public void ProcessModelFinalizing(
        IConventionModelBuilder modelBuilder,
        IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
        {
            foreach (var property in entityType.GetDeclaredProperties())
            {
                var annotation = property.FindAnnotation(DuckDBAnnotationNames.ValueGenerationStrategy);
                if (annotation?.Value != null)
                {
                    continue;
                }

                if (property.ValueGenerated == ValueGenerated.OnAdd
                    && property.ClrType.UnwrapNullableType().IsInteger()
                    && !HasConverter(property))
                {
                    property.SetValueGenerationStrategy(DuckDBValueGenerationStrategy.AutoIncrement);
                }
            }
        }
    }

    private static DuckDBValueGenerationStrategy GetValueGenerationStrategy(IConventionProperty property)
        => property.GetValueGenerationStrategy();

    private static bool HasConverter(IConventionProperty property)
        => property.FindTypeMapping()?.Converter != null
           || property.GetValueConverter() != null;
}

