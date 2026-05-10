using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace DuckDB.EFCore.NTS.Storage.ValueConversion.Internal;

public class GeometryValueConverter<TGeometry> : ValueConverter<TGeometry, byte[]>
    where TGeometry : Geometry
{
    public GeometryValueConverter(WKBReader reader, WKBWriter writer)
        : base(
            g => writer.Write(g),
            b => (TGeometry)reader.Read(b))
    {
    }
}

