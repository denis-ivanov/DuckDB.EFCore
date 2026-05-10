using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using DuckDB.EFCore.NTS.Storage.Json;
using DuckDB.EFCore.NTS.Storage.ValueConversion.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace DuckDB.EFCore.NTS.Storage.Internal;

public class DuckDBGeometryTypeMapping<TGeometry> : RelationalGeometryTypeMapping<TGeometry, byte[]>, IDuckDBGeometryTypeMapping
    where TGeometry : Geometry
{
    // DuckDB stores BLOB columns and returns them as Streams via GetStream(i)
    private static readonly MethodInfo GetStreamMethod
        = typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetStream), [typeof(int)])!;

    private static readonly MethodInfo ReadAllBytesMethod
        = typeof(DuckDBGeometryTypeMapping<TGeometry>)
            .GetMethod(nameof(ReadAllBytes), BindingFlags.Static | BindingFlags.NonPublic)!;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public DuckDBGeometryTypeMapping(NtsGeometryServices geometryServices, string storeType)
        : base(
            new GeometryValueConverter<TGeometry>(CreateReader(geometryServices), CreateWriter()),
            storeType,
            DuckDBJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected DuckDBGeometryTypeMapping(
        RelationalTypeMappingParameters parameters,
        ValueConverter<TGeometry, byte[]>? converter)
        : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new DuckDBGeometryTypeMapping<TGeometry>(parameters, SpatialConverter);

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        var geometry = (Geometry)value;
        var builder = new StringBuilder("ST_GeomFromText('");
        builder.Append(geometry.AsText()).Append('\'');
        if (geometry.SRID != 0)
            builder.Append(", ").Append(geometry.SRID);
        builder.Append(')');
        return builder.ToString();
    }

    /// <summary>
    /// DuckDB BLOB columns are exposed as Stream via GetStream(). Type 40 (GEOMETRY) is not
    /// supported by DuckDB.NET, so we must use BLOB columns and read via GetStream.
    /// </summary>
    public override MethodInfo GetDataReaderMethod() => GetStreamMethod;

    /// <summary>
    /// Converts the Stream returned by GetStream(i) into TGeometry using WKBReader.
    /// EF Core calls this to get the custom C# expression for materializing the column value.
    /// </summary>
    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        // expression is of type Stream (result of reader.GetStream(i))
        // Step 1: Stream -> byte[] via ReadAllBytes()
        var bytesExpression = Expression.Call(ReadAllBytesMethod, expression);

        // Step 2: byte[] -> TGeometry via WKB spatial converter
        if (SpatialConverter == null)
            return bytesExpression;

        return ReplacingExpressionVisitor.Replace(
            SpatialConverter.ConvertFromProviderExpression.Parameters.Single(),
            bytesExpression,
            SpatialConverter.ConvertFromProviderExpression.Body);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        // DuckDB uses $name in SQL; parameter object must be registered without $ prefix
        if (parameter is DuckDBParameter duckParam && duckParam.ParameterName.StartsWith('$'))
            duckParam.ParameterName = duckParam.ParameterName[1..];
        base.ConfigureParameter(parameter);
    }

    protected override string AsText(object value)
        => ((Geometry)value).AsText();

    protected override int GetSrid(object value)
        => ((Geometry)value).SRID;

    protected override Type WktReaderType
        => typeof(WKTReader);

    private static WKBReader CreateReader(NtsGeometryServices geometryServices)
        => new(geometryServices);

    /// <summary>
    /// Always write all ordinates that the geometry actually contains (X, Y, Z, M).
    /// Ordinates.XYZM is intersected with the geometry's actual ordinates at write time by NTS.
    /// </summary>
    private static WKBWriter CreateWriter()
        => new(ByteOrder.LittleEndian) { HandleOrdinates = Ordinates.XYZM };

    /// <summary>Helper to read all bytes from a stream (used in the materialization expression).</summary>
    internal static byte[] ReadAllBytes(System.IO.Stream stream)
    {
        using var ms = new System.IO.MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }
}