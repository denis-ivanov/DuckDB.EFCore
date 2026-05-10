using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace DuckDB.EFCore.NTS.Storage.Internal;

public class DuckDBNetTopologySuiteTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
{
    // All geometry types are stored as BLOB (WKB). We also still recognise the named
    // geometry store-type strings so that HasColumnType("GEOMETRY") etc. keeps working.
    private static readonly Dictionary<string, Type> StoreTypeMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        { "BLOB", typeof(Geometry) },
        { "GEOMETRY", typeof(Geometry) },
        { "GEOMETRYZ", typeof(Geometry) },
        { "GEOMETRYM", typeof(Geometry) },
        { "GEOMETRYZM", typeof(Geometry) },
        { "GEOMETRYCOLLECTION", typeof(GeometryCollection) },
        { "GEOMETRYCOLLECTIONZ", typeof(GeometryCollection) },
        { "GEOMETRYCOLLECTIONM", typeof(GeometryCollection) },
        { "GEOMETRYCOLLECTIONZM", typeof(GeometryCollection) },
        { "LINESTRING", typeof(LineString) },
        { "LINESTRINGZ", typeof(LineString) },
        { "LINESTRINGM", typeof(LineString) },
        { "LINESTRINGZM", typeof(LineString) },
        { "MULTILINESTRING", typeof(MultiLineString) },
        { "MULTILINESTRINGZ", typeof(MultiLineString) },
        { "MULTILINESTRINGM", typeof(MultiLineString) },
        { "MULTILINESTRINGZM", typeof(MultiLineString) },
        { "MULTIPOINT", typeof(MultiPoint) },
        { "MULTIPOINTZ", typeof(MultiPoint) },
        { "MULTIPOINTM", typeof(MultiPoint) },
        { "MULTIPOINTZM", typeof(MultiPoint) },
        { "MULTIPOLYGON", typeof(MultiPolygon) },
        { "MULTIPOLYGONZ", typeof(MultiPolygon) },
        { "MULTIPOLYGONM", typeof(MultiPolygon) },
        { "MULTIPOLYGONZM", typeof(MultiPolygon) },
        { "POINT", typeof(Point) },
        { "POINTZ", typeof(Point) },
        { "POINTM", typeof(Point) },
        { "POINTZM", typeof(Point) },
        { "POLYGON", typeof(Polygon) },
        { "POLYGONZ", typeof(Polygon) },
        { "POLYGONM", typeof(Polygon) },
        { "POLYGONZM", typeof(Polygon) }
    };

    private readonly NtsGeometryServices _geometryServices;

    public DuckDBNetTopologySuiteTypeMappingSourcePlugin(NtsGeometryServices geometryServices)
        => _geometryServices = geometryServices;

    public RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;
        var storeTypeName = mappingInfo.StoreTypeName;
        string? defaultStoreType = null;
        Type? defaultClrType = null;

        return (clrType != null && TryGetDefaultStoreType(clrType, out defaultStoreType))
            || (storeTypeName != null && StoreTypeMappings.TryGetValue(storeTypeName, out defaultClrType))
            ? (RelationalTypeMapping)Activator.CreateInstance(
                typeof(DuckDBGeometryTypeMapping<>).MakeGenericType(clrType ?? defaultClrType ?? typeof(Geometry)),
                _geometryServices,
                storeTypeName ?? defaultStoreType ?? "BLOB")!
            : null;
    }

    private static bool TryGetDefaultStoreType(Type type, [NotNullWhen(true)] out string? defaultStoreType)
    {
        if (typeof(Geometry).IsAssignableFrom(type))
        {
            defaultStoreType = "BLOB";
        }
        else
        {
            defaultStoreType = null;
        }

        return defaultStoreType != null;
    }
}