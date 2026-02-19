using DuckDB.EFCore.Query.ExpressionTranslators.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
{
    public DuckDBMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies) : base(dependencies)
    {
        AddTranslators([
            new DuckDBMathTranslator(dependencies.SqlExpressionFactory),
            new DuckDBStringMethodTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateOnlyMethodTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateTimeMethodTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateTimeOffsetMethodTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
