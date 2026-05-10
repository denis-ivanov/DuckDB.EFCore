using DuckDB.EFCore.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NetTopologySuite.Geometries;

namespace DuckDB.EFCore.NTS.Query.Internal;

/// <summary>
/// Helper methods for DuckDB spatial SQL expression generation.
/// DuckDB stores geometry as BLOB (WKB format). When passing a BLOB column or parameter
/// to a spatial function, it must be wrapped with ST_GeomFromWKB() to convert to GEOMETRY type.
/// </summary>
internal static class DuckDBSpatialHelpers
{
    /// <summary>
    /// Wraps a geometry expression with ST_GeomFromWKB() if it is a raw BLOB value
    /// (i.e., a column or parameter with a DuckDB geometry type mapping).
    /// Function result expressions (e.g., ST_Centroid(...)) are already in DuckDB GEOMETRY
    /// format and do not need wrapping.
    /// </summary>
    public static SqlExpression AsGeometry(SqlExpression expression, ISqlExpressionFactory factory)
    {
        // Only wrap column references and parameters – they contain raw WKB BLOB data.
        // Function results and constants are already proper DuckDB GEOMETRY expressions.
        if (expression.TypeMapping is IDuckDBGeometryTypeMapping
            && expression is ColumnExpression or SqlParameterExpression or SqlConstantExpression { Value: Geometry })
        {
            // SQL constants already generate ST_GeomFromText(...) via GenerateNonNullSqlLiteral
            // – no extra wrap needed for those.
            if (expression is SqlConstantExpression)
                return expression;

            return factory.Function(
                "ST_GeomFromWKB",
                [expression],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: expression.Type,
                typeMapping: null); // null = raw DuckDB GEOMETRY (not mapped to CLR byte[])
        }

        return expression;
    }
}

