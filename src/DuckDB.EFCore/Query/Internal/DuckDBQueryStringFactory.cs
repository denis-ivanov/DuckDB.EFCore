using Microsoft.EntityFrameworkCore.Query;
using System.Data.Common;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryStringFactory : IRelationalQueryStringFactory
{
    public string Create(DbCommand command)
    {
        if (command.Parameters.Count == 0)
        {
            return command.CommandText;
        }

        throw new NotImplementedException();
    }
}
