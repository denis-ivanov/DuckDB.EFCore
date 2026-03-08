using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryTranslationPostprocessor : RelationalQueryTranslationPostprocessor
{
    public DuckDBQueryTranslationPostprocessor(
        QueryTranslationPostprocessorDependencies dependencies,
        RelationalQueryTranslationPostprocessorDependencies relationalDependencies,
        RelationalQueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }

    protected override Expression ProcessTypeMappings(Expression expression)
    {
        return new DuckDBTypeMappingPostprocessor(
                Dependencies,
                RelationalDependencies,
                (RelationalQueryCompilationContext)QueryCompilationContext)
            .Process(expression);
    }
}
