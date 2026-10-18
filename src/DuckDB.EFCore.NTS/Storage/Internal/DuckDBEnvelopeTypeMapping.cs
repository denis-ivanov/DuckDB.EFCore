using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite.Geometries;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.NTS.Storage.Internal;

public class DuckDBEnvelopeTypeMapping : RelationalTypeMapping
{
    private static readonly MethodInfo GetValueMethod
        = typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;

    private static readonly MethodInfo CreateEnvelopeMethod
        = typeof(DuckDBEnvelopeTypeMapping).GetRuntimeMethod(nameof(CreateEnvelopeFromBox2D), [typeof(object)])!;

    public DuckDBEnvelopeTypeMapping(string storeType = "BOX_2D")
        : base(new RelationalTypeMappingParameters(
            new CoreTypeMappingParameters(typeof(Envelope)),
            storeType))
    {
    }

    protected DuckDBEnvelopeTypeMapping(RelationalTypeMappingParameters parameters)
        : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new DuckDBEnvelopeTypeMapping(parameters);

    public override MethodInfo GetDataReaderMethod() => GetValueMethod;

    public override Expression CustomizeDataReaderExpression(Expression expression)
        => Expression.Call(CreateEnvelopeMethod, expression);

    public static Envelope? CreateEnvelopeFromBox2D(object? value)
    {
        if (value is null or DBNull)
        {
            return null;
        }

        if (value is Dictionary<string, object> dict)
        {
            var minX = Convert.ToDouble(dict["min_x"]);
            var minY = Convert.ToDouble(dict["min_y"]);
            var maxX = Convert.ToDouble(dict["max_x"]);
            var maxY = Convert.ToDouble(dict["max_y"]);
            return new Envelope(minX, maxX, minY, maxY);
        }

        if (value is Envelope envelope)
        {
            return envelope;
        }

        return null;
    }
}
