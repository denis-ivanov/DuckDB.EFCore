using DuckDB.EFCore.Query.ExpressionTranslators.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBMemberTranslatorProvider : RelationalMemberTranslatorProvider
{
    public DuckDBMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies, IRelationalTypeMappingSource typeMappingSource)
        : base(dependencies)
    {
        AddTranslators([
            new DuckDBStringMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateOnlyMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBDateTimeMemberTranslator(dependencies.SqlExpressionFactory, typeMappingSource),
            new DuckDBDateTimeOffsetMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBTimeOnlyMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBTimeSpanMemberTranslator(dependencies.SqlExpressionFactory),
            new DuckDBBlobMemberTranslator()
        ]);
    }
}
