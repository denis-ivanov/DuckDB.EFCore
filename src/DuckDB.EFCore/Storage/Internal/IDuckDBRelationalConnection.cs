using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Storage.Internal;

public interface IDuckDBRelationalConnection : IRelationalConnection
{
    IDuckDBRelationalConnection CreateReadOnlyConnection();
}
