using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBTypeMappingPostprocessor : RelationalTypeMappingPostprocessor
{
    public DuckDBTypeMappingPostprocessor(QueryTranslationPostprocessorDependencies dependencies, RelationalQueryTranslationPostprocessorDependencies relationalDependencies, RelationalQueryCompilationContext queryCompilationContext) : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }
}