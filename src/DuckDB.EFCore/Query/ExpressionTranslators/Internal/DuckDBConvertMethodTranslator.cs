using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBConvertMethodTranslator : IMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBConvertMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType == typeof(Convert) && arguments.Count == 1)
        {
            return method.Name switch
            {
                nameof(Convert.ToBoolean) => _sqlExpressionFactory.Convert(arguments[0], typeof(bool)),
                nameof(Convert.ToByte) => _sqlExpressionFactory.Convert(arguments[0], typeof(byte)),
                nameof(Convert.ToDecimal) => _sqlExpressionFactory.Convert(arguments[0], typeof(decimal)),
                nameof(Convert.ToDouble) => _sqlExpressionFactory.Convert(arguments[0], typeof(double)),
                nameof(Convert.ToInt16) => _sqlExpressionFactory.Convert(arguments[0], typeof(short)),
                nameof(Convert.ToInt32) => _sqlExpressionFactory.Convert(arguments[0], typeof(int)),
                nameof(Convert.ToInt64) => _sqlExpressionFactory.Convert(arguments[0], typeof(long)),
                nameof(Convert.ToString) => _sqlExpressionFactory.Convert(arguments[0], typeof(string)),
                _ => null
            };
        }

        return null;
    }
}
