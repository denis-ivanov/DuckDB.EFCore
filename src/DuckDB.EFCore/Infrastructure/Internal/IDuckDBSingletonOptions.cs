using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Infrastructure.Internal;

public interface IDuckDBSingletonOptions : ISingletonOptions
{
    bool ReverseNullOrderingEnabled { get; }
}
