using System.Reflection;

namespace DuckDB.EFCore;

internal static class DuckDBMethods
{
    public static readonly MethodInfo DateOnlyAddDays = typeof(DateOnly).GetMethod(nameof(DateOnly.AddDays), [typeof(int)])!;
}
