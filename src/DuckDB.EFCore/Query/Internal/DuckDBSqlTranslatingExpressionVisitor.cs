using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
{
    private static readonly Dictionary<string, string> TimeUnits = new()
    {
        [nameof(TimeSpan.TotalDays)] = "day",
        [nameof(TimeSpan.TotalHours)] = "hour",
        [nameof(TimeSpan.TotalMinutes)] = "minute",
        [nameof(TimeSpan.TotalSeconds)] = "second",
        [nameof(TimeSpan.TotalMilliseconds)] = "millisecond",
        [nameof(TimeSpan.TotalMicroseconds)] = "microsecond",
        [nameof(TimeSpan.TotalNanoseconds)] = "nanosecond"
    };

    public DuckDBSqlTranslatingExpressionVisitor(RelationalSqlTranslatingExpressionVisitorDependencies dependencies, QueryCompilationContext queryCompilationContext, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor) : base(dependencies, queryCompilationContext, queryableMethodTranslatingExpressionVisitor)
    {
    }

    public override SqlExpression? GenerateGreatest(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("greatest", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
    }

    public override SqlExpression? GenerateLeast(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("least", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
    }

    protected override Expression VisitMember(MemberExpression memberExpression)
    {
        if (memberExpression.Expression is BinaryExpression { NodeType: ExpressionType.Subtract } binaryExpression)
        {
            var sqlExpressionFactory = (DuckDBSqlExpressionFactory)Dependencies.SqlExpressionFactory;

            if ((binaryExpression.Left.Type == typeof(DateTime) && binaryExpression.Right.Type == typeof(DateTime)) ||
                (binaryExpression.Left.Type == typeof(DateTimeOffset) && binaryExpression.Right.Type == typeof(DateTimeOffset)))
            {
                if (TimeUnits.TryGetValue(memberExpression.Member.Name, out var unit))
                {
                    return sqlExpressionFactory.DateDiff(
                        unit,
                        Translate(binaryExpression.Left)!,
                        Translate(binaryExpression.Right)!);
                }
            }
        }

        return base.VisitMember(memberExpression);
    }

    protected override Expression VisitUnary(UnaryExpression unaryExpression)
    {
        if (unaryExpression.NodeType == ExpressionType.ArrayLength)
        {
            if (TranslationFailed(unaryExpression.Operand, Visit(unaryExpression.Operand), out var sqlOperand))
            {
                return QueryCompilationContext.NotTranslatedExpression;
            }

            if (sqlOperand!.Type == typeof(byte[]) && sqlOperand.TypeMapping is DuckDBBlobTypeMapping or null)
            {
                return this.Dependencies.SqlExpressionFactory.Function(
                    "octet_length",
                    [sqlOperand],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    typeof(int));
            }
        }

        return base.VisitUnary(unaryExpression);
    }

    [DebuggerStepThrough]
    private static bool TranslationFailed(Expression? original, Expression? translation, out SqlExpression? castTranslation)
    {
        if (original is not null && translation is not SqlExpression)
        {
            castTranslation = null;
            return true;
        }

        castTranslation = translation as SqlExpression;
        return false;
    }
}
