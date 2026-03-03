using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBCollectionTypeMapping : RelationalTypeMapping
{
    public DuckDBCollectionTypeMapping(
        RelationalTypeMapping elementTypeMapping,
        Type clrType,
        Type elementType,
        bool isFixedLength,
        int? size)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    clrType,
                    converter: null,
                    comparer: null,
                    keyComparer: null,
                    providerValueComparer: null,
                    valueGeneratorFactory: null,
                    elementMapping: elementTypeMapping,
                    jsonValueReaderWriter: null),
                storeType: elementTypeMapping.StoreType + (isFixedLength ? $"[{size}]" : "[]"),
                storeTypePostfix: StoreTypePostfix.None,
                dbType: System.Data.DbType.Object,
                unicode: false,
                fixedLength: isFixedLength,
                size: size,
                precision: null,
                scale: null))
    {
        ElementType = elementType;
    }

    protected DuckDBCollectionTypeMapping(RelationalTypeMappingParameters parameters, Type elementType) : base(parameters)
    {
        ElementType = elementType;
    }

    protected Type ElementType { get; private set; }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBCollectionTypeMapping(parameters, ElementType);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return GetDataReaderMethod(typeof(List<>).MakeGenericType(ElementType.IsNullableType() && ElementType.UnwrapNullableType() != typeof(string)
            ? typeof(Nullable<>).MakeGenericType(ElementTypeMapping!.ClrType)
            : ElementTypeMapping.ClrType));
    }

    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        var toArrayMethod = typeof(Enumerable)
            .GetMethod(nameof(Enumerable.ToArray), BindingFlags.Static | BindingFlags.Public)!
            .MakeGenericMethod(ElementType);

        return Expression.Call(toArrayMethod, expression);
    }
}
