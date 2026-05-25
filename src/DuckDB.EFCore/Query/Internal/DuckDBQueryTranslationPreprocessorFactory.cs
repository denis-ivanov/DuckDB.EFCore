using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryTranslationPreprocessorFactory : RelationalQueryTranslationPreprocessorFactory
{
    public DuckDBQueryTranslationPreprocessorFactory(
        QueryTranslationPreprocessorDependencies dependencies,
        RelationalQueryTranslationPreprocessorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override QueryTranslationPreprocessor Create(QueryCompilationContext queryCompilationContext)
    {
        return new DuckDBQueryTranslationPreprocessor(
            Dependencies,
            RelationalDependencies,
            queryCompilationContext);
    }
}
