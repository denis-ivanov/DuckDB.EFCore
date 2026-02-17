using Microsoft.EntityFrameworkCore.Metadata;

namespace DuckDB.EFCore.Metadata.Internal;

public class DuckDBAnnotationProvider : RelationalAnnotationProvider
{
    public DuckDBAnnotationProvider(RelationalAnnotationProviderDependencies dependencies) : base(dependencies)
    {
    }
}