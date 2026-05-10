using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;
using NetTopologySuite.Operation.Union;
using System.Reflection;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBNetTopologySuiteAggregateMethodTranslator : IAggregateMethodCallTranslator
{
    private static readonly MethodInfo GeometryCombineMethod
        = typeof(GeometryCombiner).GetRuntimeMethod(nameof(GeometryCombiner.Combine), [typeof(IEnumerable<Geometry>)])!;

    private static readonly MethodInfo ConvexHullMethod
        = typeof(ConvexHull).GetRuntimeMethod(nameof(ConvexHull.Create), [typeof(IEnumerable<Geometry>)])!;

    private static readonly MethodInfo UnionMethod
        = typeof(UnaryUnionOp).GetRuntimeMethod(nameof(UnaryUnionOp.Union), [typeof(IEnumerable<Geometry>)])!;

    private static readonly MethodInfo EnvelopeCombineMethod
        = typeof(EnvelopeCombiner).GetRuntimeMethod(nameof(EnvelopeCombiner.CombineAsGeometry), [typeof(IEnumerable<Geometry>)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBNetTopologySuiteAggregateMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
        => _sqlExpressionFactory = sqlExpressionFactory;

    public SqlExpression? Translate(
        MethodInfo method,
        EnumerableExpression source,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (source.Selector is not SqlExpression sqlExpression)
        {
            return null;
        }

        if (method == ConvexHullMethod)
        {
            CombineAggregateTerms();

            // DuckDB has no built-in aggregate convex hull — collect first, then compute convex hull
            return _sqlExpressionFactory.Function(
                "ST_ConvexHull",
                [
                    _sqlExpressionFactory.Function(
                        "ST_Collect",
                        [DuckDBSpatialHelpers.AsGeometry(sqlExpression, _sqlExpressionFactory)],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        typeof(Geometry))
                ],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(Geometry));
        }

        if (method == EnvelopeCombineMethod)
        {
            CombineAggregateTerms();

            return _sqlExpressionFactory.Function(
                "ST_Envelope",
                [
                    _sqlExpressionFactory.Function(
                        "ST_Collect",
                        [DuckDBSpatialHelpers.AsGeometry(sqlExpression, _sqlExpressionFactory)],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        typeof(Geometry))
                ],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(Geometry));
        }

        var functionName = method == UnionMethod
            ? "ST_Union_Agg"
            : method == GeometryCombineMethod
                ? "ST_Collect"
                : null;

        if (functionName is null)
        {
            return null;
        }

        CombineAggregateTerms();

        return _sqlExpressionFactory.Function(
            functionName,
            [DuckDBSpatialHelpers.AsGeometry(sqlExpression, _sqlExpressionFactory)],
            nullable: true,
            argumentsPropagateNullability: [false],
            typeof(Geometry));

        void CombineAggregateTerms()
        {
            if (source.Predicate != null)
            {
                sqlExpression = _sqlExpressionFactory.Case(
                    new List<CaseWhenClause> { new(source.Predicate, sqlExpression) },
                    elseResult: null);
            }

            if (source.IsDistinct)
            {
                sqlExpression = new DistinctExpression(sqlExpression);
            }
        }
    }
}