using DuckDB.EFCore.Query.ExpressionTranslators.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBMemberTranslatorProvider : RelationalMemberTranslatorProvider
{
    public DuckDBMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies)
        : base(dependencies)
    {
        AddTranslators([
            new DuckDBStringMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateOnlyMemberTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
