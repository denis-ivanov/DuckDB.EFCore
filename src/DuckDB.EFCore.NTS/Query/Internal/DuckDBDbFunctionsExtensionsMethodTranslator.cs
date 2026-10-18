using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite.Geometries;
using System.Reflection;
using System.Text.Json;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBDbFunctionsExtensionsMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo AsGeoJsonMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsGeoJson),
            [typeof(DbFunctions), typeof(Geometry)])!;

    private static readonly MethodInfo AreaSpheroidGeometryMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AreaSpheroid),
            [typeof(DbFunctions), typeof(Geometry)])!;

    private static readonly MethodInfo AreaSpheroidPolygonMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AreaSpheroid),
            [typeof(DbFunctions), typeof(Polygon)])!;

    private static readonly MethodInfo AffineMethod1
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.Affine),
            [
                typeof(DbFunctions),
                typeof(Geometry),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double),
                typeof(double)
            ])!;
    
    private static readonly MethodInfo AffineMethod2 = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
        nameof(DuckDBDbFunctionsExtensions.Affine),
        [
            typeof(DbFunctions),
            typeof(Geometry),
            typeof(double),
            typeof(double),
            typeof(double),
            typeof(double),
            typeof(double),
            typeof(double)
        ])!;

    private static readonly MethodInfo AsHexWkbMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsHexWkb),
            [typeof(DbFunctions), typeof(Geometry)])!;

    private static readonly MethodInfo AsSvgMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsSvg),
            [typeof(DbFunctions), typeof(Geometry), typeof(bool), typeof(int)])!;

    private static readonly MethodInfo AzimuthGeometryMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.Azimuth),
            [typeof(DbFunctions), typeof(Geometry), typeof(Geometry)])!;

    private static readonly MethodInfo AzimuthPointMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.Azimuth),
            [typeof(DbFunctions), typeof(Geometry), typeof(Point)])!;

    private static readonly MethodInfo AsMvtGeomMethod1
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsMvtGeom),
            [typeof(DbFunctions), typeof(Geometry), typeof(Envelope), typeof(long), typeof(long), typeof(bool)])!;

    private static readonly MethodInfo AsMvtGeomMethod2
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsMvtGeom),
            [typeof(DbFunctions), typeof(Geometry), typeof(Envelope), typeof(long), typeof(long)])!;

    private static readonly MethodInfo AsMvtGeomMethod3
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsMvtGeom),
            [typeof(DbFunctions), typeof(Geometry), typeof(Envelope), typeof(long)])!;

    private static readonly MethodInfo AsMvtGeomMethod4
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.AsMvtGeom),
            [typeof(DbFunctions), typeof(Geometry), typeof(Envelope)])!;

    private static readonly MethodInfo BuildAreaMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.BuildArea),
            [typeof(DbFunctions), typeof(Geometry)])!;

    private static readonly MethodInfo ConcaveHullMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.ConcaveHull),
            [typeof(DbFunctions), typeof(Geometry), typeof(double), typeof(bool)])!;

    private static readonly MethodInfo ContainsProperlyMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.ContainsProperly),
            [typeof(DbFunctions), typeof(Geometry), typeof(Geometry)])!;

    private static readonly MethodInfo DWithinSpheroidMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.DWithinSpheroid),
            [typeof(DbFunctions), typeof(Point), typeof(Point), typeof(double)])!;

    private static readonly MethodInfo DistanceGeosMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.DistanceGeos),
            [typeof(DbFunctions), typeof(Geometry), typeof(Geometry)])!;

    private static readonly MethodInfo DistanceSphereGeometryMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.DistanceSphere),
            [typeof(DbFunctions), typeof(Geometry), typeof(Geometry)])!;

    private static readonly MethodInfo DistanceSpherePointMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.DistanceSphere),
            [typeof(DbFunctions), typeof(Point), typeof(Point)])!;

    private static readonly MethodInfo DistanceSpheroidMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.DistanceSpheroid),
            [typeof(DbFunctions), typeof(Point), typeof(Point)])!;

    private static readonly MethodInfo ExtentMethod
        = typeof(DuckDBDbFunctionsExtensions).GetRuntimeMethod(
            nameof(DuckDBDbFunctionsExtensions.Extent),
            [typeof(DbFunctions), typeof(Geometry)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    public DuckDBDbFunctionsExtensionsMethodTranslator(
        ISqlExpressionFactory sqlExpressionFactory,
        IRelationalTypeMappingSource typeMappingSource)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
        _typeMappingSource = typeMappingSource;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == AsGeoJsonMethod)
        {
            var geometry = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_AsGeoJSON",
                arguments: [geometry],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(JsonElement),
                typeMapping: _typeMappingSource.FindMapping(typeof(JsonElement), "JSON"));
        }

        if (method == AreaSpheroidGeometryMethod || method == AreaSpheroidPolygonMethod)
        {
            var geometry = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_Area_Spheroid",
                arguments: [geometry],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: method.ReturnType);
        }

        if (method == AffineMethod1 || method == AffineMethod2)
        {
            var translatedArguments = arguments
                .Skip(1)
                .Select((argument, index) => index == 0 ? argument : _sqlExpressionFactory.Convert(argument, typeof(double)))
                .ToArray();

            return _sqlExpressionFactory.Function(
                name: "ST_Affine",
                arguments: translatedArguments,
                nullable: true,
                argumentsPropagateNullability: translatedArguments.Select(_ => true).ToArray(),
                returnType: typeof(Geometry));
        }

        if (method == AsHexWkbMethod)
        {
            return _sqlExpressionFactory.Function(
                name: "ST_AsHEXWKB",
                arguments: [DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory)],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == AsSvgMethod)
        {
            return _sqlExpressionFactory.Function(
                name: "ST_AsSVG",
                arguments:
                [
                    DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory),
                    arguments[2],
                    arguments[3]
                ],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(string));
        }

        if (method == AzimuthGeometryMethod || method == AzimuthPointMethod)
        {
            return _sqlExpressionFactory.Function(
                name: "ST_Azimuth",
                arguments:
                [
                    DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory),
                    DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory)
                ],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: method.ReturnType);
        }

        if (method == AsMvtGeomMethod1 || method == AsMvtGeomMethod2 || method == AsMvtGeomMethod3 || method == AsMvtGeomMethod4)
        {
            var translatedArguments = arguments.Skip(1).ToArray();
            translatedArguments[0] = DuckDBSpatialHelpers.AsGeometry(translatedArguments[0], _sqlExpressionFactory);

            if (translatedArguments[1] is SqlConstantExpression { Value: null, TypeMapping: null })
            {
                translatedArguments[1] = _sqlExpressionFactory.ApplyTypeMapping(
                    translatedArguments[1],
                    _typeMappingSource.FindMapping(typeof(Geometry), "GEOMETRY"));
            }

            return _sqlExpressionFactory.Function(
                name: "ST_AsMVTGeom",
                arguments: translatedArguments,
                nullable: true,
                argumentsPropagateNullability: translatedArguments.Select(_ => true).ToArray(),
                returnType: typeof(Geometry));
        }

        if (method == BuildAreaMethod)
        {
            var geometry = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_BuildArea",
                arguments: [geometry],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(Geometry));
        }

        if (method == ConcaveHullMethod)
        {
            var geometry = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_ConcaveHull",
                arguments: [geometry, arguments[2], arguments[3]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(Geometry));
        }

        if (method == ContainsProperlyMethod)
        {
            var geom1 = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);
            var geom2 = DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_ContainsProperly",
                arguments: [geom1, geom2],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        if (method == DWithinSpheroidMethod)
        {
            var geom1 = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);
            var geom2 = DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_DWithin_Spheroid",
                arguments: [geom1, geom2, arguments[3]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(bool));
        }

        if (method == DistanceGeosMethod)
        {
            var geom1 = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);
            var geom2 = DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_Distance_GEOS",
                arguments: [geom1, geom2],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(double));
        }

        if (method == DistanceSphereGeometryMethod || method == DistanceSpherePointMethod)
        {
            var geom1 = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);
            var geom2 = DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_Distance_Sphere",
                arguments: [geom1, geom2],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(double));
        }

        if (method == DistanceSpheroidMethod)
        {
            var geom1 = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);
            var geom2 = DuckDBSpatialHelpers.AsGeometry(arguments[2], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_Distance_Spheroid",
                arguments: [geom1, geom2],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(double));
        }

        if (method == ExtentMethod)
        {
            var geom = DuckDBSpatialHelpers.AsGeometry(arguments[1], _sqlExpressionFactory);

            return _sqlExpressionFactory.Function(
                name: "ST_Extent",
                arguments: [geom],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(Envelope),
                typeMapping: _typeMappingSource.FindMapping(typeof(Envelope)));
        }

        return null;
    }
}
