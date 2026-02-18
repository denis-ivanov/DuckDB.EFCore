using DuckDB.NET.Data;

namespace DuckDB.EFCore.Extensions.Internal;

internal static class DuckDBParameterExtensions
{
    public static DuckDBParameter RemoveDollarSign(this DuckDBParameter parameter)
    {
        if (parameter.ParameterName.StartsWith('$'))
        {
            parameter.ParameterName = parameter.ParameterName[1..];
        }

        return parameter;
    }
}
