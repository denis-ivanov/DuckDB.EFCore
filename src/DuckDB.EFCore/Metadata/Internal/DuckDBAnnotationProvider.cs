using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DuckDB.EFCore.Metadata.Internal;

public class DuckDBAnnotationProvider : RelationalAnnotationProvider
{
    public DuckDBAnnotationProvider(RelationalAnnotationProviderDependencies dependencies) : base(dependencies)
    {
    }

    public override IEnumerable<IAnnotation> For(IColumn column, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        var property = column.PropertyMappings
            .Select(m => m.Property)
            .FirstOrDefault(p => p.GetValueGenerationStrategy() != DuckDBValueGenerationStrategy.None);

        if (property != null)
        {
            var strategy = property.GetValueGenerationStrategy();
            if (strategy != DuckDBValueGenerationStrategy.None)
            {
                yield return new Annotation(DuckDBAnnotationNames.ValueGenerationStrategy, strategy);
            }
        }
    }
}