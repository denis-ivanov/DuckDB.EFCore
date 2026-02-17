using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBParameterBasedSqlProcessor : RelationalParameterBasedSqlProcessor
{
    public DuckDBParameterBasedSqlProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
    }

    protected override Expression ProcessSqlNullability(Expression queryExpression, ParametersCacheDecorator Decorator)
    {
        return new DuckDBSqlNullabilityProcessor(Dependencies, Parameters).Process(queryExpression, Decorator);
    }
}
