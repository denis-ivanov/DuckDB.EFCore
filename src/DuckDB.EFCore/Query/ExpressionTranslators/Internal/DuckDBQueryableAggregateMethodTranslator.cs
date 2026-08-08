using Microsoft.EntityFrameworkCore;
using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQueryableAggregateMethodTranslator : IAggregateMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBQueryableAggregateMethodTranslator(ISqlExpressionFactory sqlExpressionFactory) 
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        MethodInfo method,
        EnumerableExpression source,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType == typeof(Queryable))
        {
            var methodInfo = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : method;
            switch (methodInfo.Name)
            {
                case nameof(Queryable.Average)
                    when (QueryableMethods.IsAverageWithoutSelector(methodInfo)
                          || QueryableMethods.IsAverageWithSelector(methodInfo))
                         && source.Selector is SqlExpression averageSqlExpression:
                    var averageInputType = averageSqlExpression.Type;

                    if (averageInputType == typeof(int) || averageInputType == typeof(long))
                    {
                        averageSqlExpression = _sqlExpressionFactory.ApplyDefaultTypeMapping(
                            _sqlExpressionFactory.Convert(averageSqlExpression, typeof(double)));
                    }

                    averageSqlExpression = CombineTerms(source, averageSqlExpression);

                    if (averageInputType == typeof(decimal))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "AVG",
                                [averageSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(decimal)),
                            averageSqlExpression.Type,
                            averageSqlExpression.TypeMapping);
                    }

                    if (averageInputType == typeof(float))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "AVG",
                                [averageSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(float)),
                            averageSqlExpression.Type,
                            averageSqlExpression.TypeMapping);
                    }

                    return _sqlExpressionFactory.Function(
                        "AVG",
                        [averageSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        averageSqlExpression.Type,
                        averageSqlExpression.TypeMapping);

                case nameof(Queryable.Count)
                    when methodInfo == QueryableMethods.CountWithoutPredicate
                         || methodInfo == QueryableMethods.CountWithPredicate:
                    var countSqlExpression = (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    countSqlExpression = CombineTerms(source, countSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "COUNT",
                        [countSqlExpression],
                        nullable: false,
                        argumentsPropagateNullability: [false],
                        typeof(int));

                case nameof(Queryable.LongCount)
                    when methodInfo == QueryableMethods.LongCountWithoutPredicate
                         || methodInfo == QueryableMethods.LongCountWithPredicate:
                    var longCountSqlExpression =
                        (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    longCountSqlExpression = CombineTerms(source, longCountSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "COUNT",
                        [longCountSqlExpression],
                        nullable: false,
                        argumentsPropagateNullability: [false],
                        typeof(long));

                case nameof(Queryable.Max)
                    when (methodInfo == QueryableMethods.MaxWithoutSelector
                          || methodInfo == QueryableMethods.MaxWithSelector)
                         && source.Selector is SqlExpression maxSqlExpression:
                    maxSqlExpression = CombineTerms(source, maxSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "MAX",
                        [maxSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        maxSqlExpression.Type,
                        maxSqlExpression.TypeMapping);

                case nameof(Queryable.Min)
                    when (methodInfo == QueryableMethods.MinWithoutSelector
                          || methodInfo == QueryableMethods.MinWithSelector)
                         && source.Selector is SqlExpression minSqlExpression:
                    minSqlExpression = CombineTerms(source, minSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "MIN",
                        [minSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        minSqlExpression.Type,
                        minSqlExpression.TypeMapping);

                case nameof(Queryable.Sum)
                    when (QueryableMethods.IsSumWithoutSelector(methodInfo)
                          || QueryableMethods.IsSumWithSelector(methodInfo))
                         && source.Selector is SqlExpression sumSqlExpression:
                    sumSqlExpression = CombineTerms(source, sumSqlExpression);
                    var sumInputType = sumSqlExpression.Type;

                    if (sumInputType == typeof(float))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "SUM",
                                [sumSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(double)),
                            sumInputType,
                            sumSqlExpression.TypeMapping);
                    }

                    if (sumInputType == typeof(decimal))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "SUM",
                                [sumSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(decimal)),
                            sumInputType,
                            sumSqlExpression.TypeMapping);
                    }

                    return _sqlExpressionFactory.Function(
                        "SUM",
                        [sumSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        sumInputType,
                        sumSqlExpression.TypeMapping);
            }
        }

        // Support ANY_VALUE aggregate function (e.g., g.AnyValue(e => e.Prop))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == "AnyValueAggregate")
        {
            if (source.Selector is SqlExpression anySqlExpression)
            {
                anySqlExpression = CombineTerms(source, anySqlExpression);
                return _sqlExpressionFactory.Function(
                    "ANY_VALUE",
                    new[] { anySqlExpression },
                    nullable: true,
                    argumentsPropagateNullability: new[] { false },
                    anySqlExpression.Type,
                    anySqlExpression.TypeMapping);
            }
        }

        // Support ARG_MAX / ARG_MAX_NULL aggregate functions
        // (e.g., g.ArgMax(e => e.Prop, e => e.Value[, n]), g.ArgMaxNull(e => e.Prop, e => e.Value))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name is "ArgMaxAggregate" or "ArgMaxNullAggregate")
        {
            if (source.Selector is DuckDBRowValueExpression { Values.Count: 2 } rowValue
                && !source.IsDistinct)
            {
                var arg = rowValue.Values[0];
                var val = rowValue.Values[1];

                if (source.Predicate != null)
                {
                    arg = CombineTerms(source, arg);
                    val = CombineTerms(source, val);
                }

                var functionArguments = arguments.Count == 1
                    ? new[] { arg, val, arguments[0] }
                    : [arg, val];

                return _sqlExpressionFactory.Function(
                    method.Name == "ArgMaxNullAggregate" ? "ARG_MAX_NULL" : "ARG_MAX",
                    functionArguments,
                    nullable: true,
                    argumentsPropagateNullability: functionArguments.Select(_ => false).ToArray(),
                    method.ReturnType,
                    arguments.Count == 1 ? null : arg.TypeMapping);
            }
        }

        return null;
    }

    private SqlExpression CombineTerms(EnumerableExpression enumerableExpression, SqlExpression sqlExpression)
    {
        if (enumerableExpression.Predicate != null)
        {
            if (sqlExpression is SqlFragmentExpression)
            {
                sqlExpression = _sqlExpressionFactory.Constant(1);
            }

            sqlExpression = _sqlExpressionFactory.Case(
                new List<CaseWhenClause> { new(enumerableExpression.Predicate, sqlExpression) },
                elseResult: null);
        }

        if (enumerableExpression.IsDistinct)
        {
            sqlExpression = new DistinctExpression(sqlExpression);
        }

        return sqlExpression;
    }
}
