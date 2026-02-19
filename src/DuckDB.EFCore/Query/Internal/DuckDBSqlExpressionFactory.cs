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
        return Function(
            name: "date_add",
            arguments: [timestamp, ToYears(years)],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: returnType);
    }

    public SqlExpression AddMonths(SqlExpression timestamp, SqlExpression months, Type returnType)
    {
        return Function(
            name: "date_add",
            arguments: [timestamp, ToMonths(months)],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: returnType);
    }

    public SqlExpression ToYears(SqlExpression years)
    {
        return Function(
            name: "to_years",
            arguments: [years],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(TimeSpan));
    }

    public SqlExpression ToMonths(SqlExpression months)
    {
        return Function(
            name: "to_months",
            arguments: [months],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(TimeSpan));
    }
}
