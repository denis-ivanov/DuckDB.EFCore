using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace DuckDB.EFCore.Metadata.Conventions;

/// <summary>
///     A builder for building conventions for DuckDB.
/// </summary>
public class DuckDBConventionSetBuilder : RelationalConventionSetBuilder
{
    /// <summary>
    ///     Creates a new instance of <see cref="DuckDBConventionSetBuilder" />.
    /// </summary>
    /// <param name="dependencies">The core dependencies for this service.</param>
    /// <param name="relationalDependencies">The relational dependencies for this service.</param>
    public DuckDBConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }

    /// <summary>
    ///     Builds and returns the convention set for the current database provider.
    /// </summary>
    /// <returns>The convention set for the current database provider.</returns>
    public override ConventionSet CreateConventionSet()
    {
        var conventionSet =  base.CreateConventionSet();

        var valueGenerationConvention = new DuckDBValueGenerationConvention(Dependencies, RelationalDependencies);
        conventionSet.Replace<RelationalValueGenerationConvention>(valueGenerationConvention);
        conventionSet.ModelFinalizingConventions.Add(valueGenerationConvention);

        conventionSet.Replace<RuntimeModelConvention>(new DuckDBRuntimeModelConvention(Dependencies, RelationalDependencies));
        conventionSet.EntityTypeAddedConventions.Add(new DuckDBParquetConvention());

        return conventionSet;
    }
}
