using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBRandomMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo Random = typeof(DbFunctionsExtensions).GetRuntimeMethod(nameof(DbFunctionsExtensions.Random), [typeof(DbFunctions)])!;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBRandomMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == Random)
        {
            return _sqlExpressionFactory.Function(
                name: "random",
                arguments: [],
                nullable: false,
                argumentsPropagateNullability: [],
                returnType: typeof(double));
        }

        return null;
    }
}