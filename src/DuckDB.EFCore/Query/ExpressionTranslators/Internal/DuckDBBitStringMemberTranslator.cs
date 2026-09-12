using DuckDB.EFCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBBitStringMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Length = typeof(BitArray).GetRuntimeProperty(nameof(BitArray.Length))!;
    
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    public DuckDBBitStringMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (instance is not null && member == Length)
        {
            return _sqlExpressionFactory.BitLength(instance);
        }

        return null;
    }
}
