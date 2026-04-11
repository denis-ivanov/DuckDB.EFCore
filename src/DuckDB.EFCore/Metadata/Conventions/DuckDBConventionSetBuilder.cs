using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace DuckDB.EFCore.Metadata.Conventions;

public class DuckDBConventionSetBuilder : RelationalConventionSetBuilder
{
    public DuckDBConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }

    public override ConventionSet CreateConventionSet()
    {
        var conventionSet =  base.CreateConventionSet();
        RemoveForeignKeyIndexConvention(conventionSet.EntityTypeBaseTypeChangedConventions);
        
        conventionSet.ForeignKeyAddedConventions.Clear();
        conventionSet.ForeignKeyAnnotationChangedConventions.Clear();
        conventionSet.ForeignKeyDependentRequirednessChangedConventions.Clear();
        conventionSet.ForeignKeyNullNavigationSetConventions.Clear();
        conventionSet.ForeignKeyOwnershipChangedConventions.Clear();
        conventionSet.ForeignKeyPrincipalEndChangedConventions.Clear();
        conventionSet.ForeignKeyPropertiesChangedConventions.Clear();
        conventionSet.ForeignKeyRemovedConventions.Clear();
        conventionSet.ForeignKeyRequirednessChangedConventions.Clear();
        conventionSet.ForeignKeyUniquenessChangedConventions.Clear();
        conventionSet.SkipNavigationForeignKeyChangedConventions.Clear();
        
        var valueGenerationConvention = new DuckDBValueGenerationConvention(Dependencies, RelationalDependencies);
        conventionSet.Replace<RelationalValueGenerationConvention>(valueGenerationConvention);
        conventionSet.ModelFinalizingConventions.Add(valueGenerationConvention);

        conventionSet.Replace<RuntimeModelConvention>(new DuckDBRuntimeModelConvention(Dependencies, RelationalDependencies));

        return conventionSet;
    }
    
    private void RemoveForeignKeyIndexConvention(IList<IEntityTypeBaseTypeChangedConvention> conventions)
    {
        for (var i = conventions.Count - 1; i > -1; i--)
        {
            if (conventions[i] is ForeignKeyIndexConvention)
            {
                conventions.RemoveAt(i);
            }
        }
    }
}