using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
{
    private readonly QuerySqlGeneratorDependencies _dependencies;
    private readonly IDuckDBSingletonOptions _duckDbSingletonOptions;

    public DuckDBQuerySqlGeneratorFactory(
        QuerySqlGeneratorDependencies dependencies,
        IDuckDBSingletonOptions duckDbSingletonOptions)
    {
        _dependencies = dependencies;
        _duckDbSingletonOptions = duckDbSingletonOptions;
    }

    public QuerySqlGenerator Create()
    {
        return new DuckDBQuerySqlGenerator(_dependencies, _duckDbSingletonOptions.ReverseNullOrderingEnabled);
    }
}