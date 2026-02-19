using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlExpressionFactory : SqlExpressionFactory
{
    public DuckDBSqlExpressionFactory(SqlExpressionFactoryDependencies dependencies) : base(dependencies)
    {
    }

    public SqlExpression Year(SqlExpression? expression)
    {
        return Function(
            name: "year",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression Month(SqlExpression? expression)
    {
        return Function(
            name: "month",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression Day(SqlExpression? expression)
    {
        return Function(
            name: "day",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression Hour(SqlExpression? expression)
    {
        return Function(
            name: "hour",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression Minute(SqlExpression? expression)
    {
        return Function(
            name: "minute",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression Second(SqlExpression? expression)
    {
        return Function(
            name: "second",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int));
    }

    public SqlExpression AddYears(SqlExpression timestamp, SqlExpression years, Type returnType)
    {
        var intervalExpression = Function(
            name: "to_years",
            arguments: 
            [
                Convert(years, typeof(int), this.Dependencies.TypeMappingSource.FindMapping(typeof(int)))
            ],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(TimeSpan));

        return Function(
            name: "date_add",
            arguments: [timestamp, intervalExpression],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: returnType);
    } 
}
