using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace DuckDB.EFCore.NTS.Storage.Internal;

public class DuckDBGeometryTypeMapping<TGeometry> : RelationalGeometryTypeMapping<TGeometry, byte[]>
    where TGeometry : Geometry
{
    public DuckDBGeometryTypeMapping(ValueConverter<TGeometry, byte[]>? converter, string storeType, JsonValueReaderWriter? jsonValueReaderWriter = null) : base(converter, storeType, jsonValueReaderWriter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        throw new NotImplementedException();
    }

    protected override string AsText(object value)
    {
        throw new NotImplementedException();
    }

    protected override int GetSrid(object value)
    {
        throw new NotImplementedException();
    }

    protected override Type WktReaderType { get; }
}