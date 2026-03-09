using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

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

    public SqlExpression AddDays(SqlExpression timestamp, SqlExpression days, Type returnType)
    {
        return Function(
            name: "date_add",
            arguments: [timestamp, ToDays(days)],
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
    
    public SqlExpression ToDays(SqlExpression days)
    {
        return Function(
            name: "to_days",
            arguments: [days],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(TimeSpan));
    }

    public SqlExpression DateDiff(string unit, SqlExpression left, SqlExpression right)
    {
        return Convert(
            Function(
                name: "date_diff",
                arguments: [Constant(unit), left, right],
                argumentsPropagateNullability: [true, true, true],
                nullable: true,
                returnType: typeof(int)),
            typeof(double)
        );
    }

    public virtual DuckDBArrayIndexExpression ArrayIndex(
        SqlExpression array,
        SqlExpression index,
        bool nullable,
        RelationalTypeMapping? typeMapping = null)
    {
        if (!array.Type.TryGetElementType(out var elementType))
        {
            throw new ArgumentException("Array expression must be of an array or List<> type", nameof(array));
        }

        return (DuckDBArrayIndexExpression)ApplyTypeMapping(
            new DuckDBArrayIndexExpression(array, index, nullable, elementType, typeMapping: null),
            typeMapping);
    }

    [return: NotNullIfNotNull("sqlExpression")]
    public override SqlExpression? ApplyTypeMapping(SqlExpression? sqlExpression, RelationalTypeMapping? typeMapping)
    {
        if (sqlExpression is { TypeMapping: null } && typeMapping != null)
        {
            sqlExpression = sqlExpression switch
            {
                DuckDBArrayIndexExpression e => ApplyTypeMappingOnArrayIndex(e, typeMapping),
                _ => base.ApplyTypeMapping(sqlExpression, typeMapping)
            };

            return sqlExpression;
        }

        return base.ApplyTypeMapping(sqlExpression, typeMapping);
    }
    
    private SqlExpression ApplyTypeMappingOnArrayIndex(
        DuckDBArrayIndexExpression arrayIndexExpression,
        RelationalTypeMapping? typeMapping)
    {
        var (_, array) = typeMapping is not null
            ? ApplyTypeMappingsOnItemAndArray(Constant(null, typeMapping.ClrType, typeMapping), arrayIndexExpression.Array)
            : (null, ApplyDefaultTypeMapping(arrayIndexExpression.Array));

        return new DuckDBArrayIndexExpression(
            array,
            ApplyDefaultTypeMapping(arrayIndexExpression.Index),
            arrayIndexExpression.IsNullable,
            arrayIndexExpression.Type,
            arrayIndexExpression.Array.TypeMapping is DuckDBArrayTypeMapping arrayMapping
                ? arrayMapping.ElementTypeMapping
                : typeMapping
                  ?? Dependencies.TypeMappingSource.FindMapping(arrayIndexExpression.Type, Dependencies.Model));
    }

    internal (SqlExpression, SqlExpression) ApplyTypeMappingsOnItemAndArray(SqlExpression itemExpression, SqlExpression arrayExpression)
    {
        var arrayMapping = arrayExpression.TypeMapping;

        var itemMapping =
            itemExpression.TypeMapping
            ?? (itemExpression is SqlUnaryExpression { OperatorType: ExpressionType.Convert } unary && unary.Type == typeof(object)
                ? unary.Operand.TypeMapping
                : null)
            ?? (RelationalTypeMapping?)arrayMapping?.ElementTypeMapping
            ?? Dependencies.TypeMappingSource.FindMapping(itemExpression.Type, Dependencies.Model);

        if (itemMapping is null)
        {
            throw new InvalidOperationException("Couldn't find element type mapping when applying item/array mappings");
        }

        if (arrayMapping is null)
        {
            if (itemMapping.Converter is not null)
            {
                arrayMapping = Dependencies.TypeMappingSource.FindMapping(arrayExpression.Type, Dependencies.Model, itemMapping);
            }
            else
            {
                arrayMapping = arrayExpression.Type.TryGetSequenceType() == typeof(object)
                    ? Dependencies.TypeMappingSource.FindMapping(itemMapping.StoreType + "[]")
                    : Dependencies.TypeMappingSource.FindMapping(arrayExpression.Type, itemMapping.StoreType + "[]");
            }

            if (arrayMapping is null)
            {
                throw new InvalidOperationException("Couldn't find array type mapping when applying item/array mappings");
            }
        }

        return (ApplyTypeMapping(itemExpression, itemMapping), ApplyTypeMapping(arrayExpression, arrayMapping));
    }
}
