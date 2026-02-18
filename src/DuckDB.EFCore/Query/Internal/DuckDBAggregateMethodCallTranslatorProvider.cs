using DuckDB.EFCore.Query.ExpressionTranslators.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBAggregateMethodCallTranslatorProvider : RelationalAggregateMethodCallTranslatorProvider
{
    public DuckDBAggregateMethodCallTranslatorProvider(RelationalAggregateMethodCallTranslatorProviderDependencies dependencies) : base(dependencies)
    {
        AddTranslators([
            new DuckDBQueryableAggregateMethodTranslator(Dependencies.SqlExpressionFactory),
            new DuckDBStringAggregateMethodTranslator()
        ]);
    }
}