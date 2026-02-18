using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBBlobTypeMapping : ByteArrayTypeMapping
{
    public static new DuckDBBlobTypeMapping Default { get; } = new(DuckDBTypeMappingSource.BlobTypeName);
    
    public DuckDBBlobTypeMapping(string storeType, DbType? dbType = System.Data.DbType.Binary)
        : this(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    typeof(byte[])),
                storeType,
                dbType: dbType))
    {
    }

    protected DuckDBBlobTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBBlobTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetStream), [typeof(int)])!;
    }

    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        var streamType = typeof(Stream);
        var readStreamMethod = typeof(DuckDBBlobTypeMapping).GetMethod(nameof(ReadStream), BindingFlags.Static | BindingFlags.NonPublic)!;
        return Expression.Call(readStreamMethod, expression); 
    }

    private static byte[] ReadStream(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
