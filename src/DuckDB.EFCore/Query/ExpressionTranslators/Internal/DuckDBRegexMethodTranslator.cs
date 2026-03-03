using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBRegexMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo IsMatch = typeof(Regex).GetMethod(nameof(Regex.IsMatch), [typeof(string), typeof(string)])!;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBRegexMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == IsMatch)
        {
            return _sqlExpressionFactory.Function(
                name: "regexp_matches",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        return null;
    }
}