using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlExpressionFactory : SqlExpressionFactory
{
    private readonly DuckDBTypeMappingSource _typeMappingSource;
    private readonly RelationalTypeMapping _boolTypeMapping;
    
    public DuckDBSqlExpressionFactory(SqlExpressionFactoryDependencies dependencies) : base(dependencies)
    {
        _typeMappingSource = (DuckDBTypeMappingSource)dependencies.TypeMappingSource;
        _boolTypeMapping = _typeMappingSource.FindMapping(typeof(bool), dependencies.Model)!;
    }

    public virtual DuckDBAnyExpression Any(SqlExpression item, SqlExpression array)
    {
        return (DuckDBAnyExpression)ApplyDefaultTypeMapping(new DuckDBAnyExpression(item, array, null));
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

    public SqlExpression Millisecond(SqlExpression? expression)
    {
        return Function(
            name: "millisecond",
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

    public virtual DuckDBArraySliceExpression ArraySlice(
        SqlExpression array,
        SqlExpression? lowerBound,
        SqlExpression? upperBound,
        bool nullable,
        RelationalTypeMapping? typeMapping = null)
        => (DuckDBArraySliceExpression)ApplyTypeMapping(
            new DuckDBArraySliceExpression(array, lowerBound, upperBound, nullable, array.Type, typeMapping: null),
            typeMapping);
    
    [return: NotNullIfNotNull("sqlExpression")]
    public override SqlExpression? ApplyTypeMapping(SqlExpression? sqlExpression, RelationalTypeMapping? typeMapping)
    {
        if (sqlExpression is not null && sqlExpression.TypeMapping is null)
        {
            sqlExpression = sqlExpression switch
            {
                SqlBinaryExpression e => ApplyTypeMappingOnSqlBinary(e, typeMapping),

                DuckDBAnyExpression e => ApplyTypeMappingOnAny(e),
                DuckDBArrayIndexExpression e => ApplyTypeMappingOnArrayIndex(e, typeMapping),
                DuckDBArraySliceExpression e => ApplyTypeMappingOnArraySlice(e, typeMapping),
                DuckDBRowValueExpression e => ApplyTypeMappingOnRowValue(e, typeMapping),
                _ => base.ApplyTypeMapping(sqlExpression, typeMapping)
            };

            return sqlExpression;
        }

        return base.ApplyTypeMapping(sqlExpression, typeMapping);
    }

    private SqlBinaryExpression ApplyTypeMappingOnSqlBinary(SqlBinaryExpression binary, RelationalTypeMapping? typeMapping)
    {
        if (IsComparison(binary.OperatorType)
            && TryGetRowValueValues(binary.Left, out var leftValues)
            && TryGetRowValueValues(binary.Right, out var rightValues))
        {
            if (leftValues.Count != rightValues.Count)
            {
                throw new ArgumentException("Tuples are not the same length in row value comparison");
            }

            var count = leftValues.Count;
            var updatedLeftValues = new SqlExpression[count];
            var updatedRightValues = new SqlExpression[count];

            for (var i = 0; i < count; i++)
            {
                var updatedElementBinaryExpression = MakeBinary(binary.OperatorType, leftValues[i], rightValues[i], typeMapping: null)!;

                if (updatedElementBinaryExpression is not SqlBinaryExpression
                    {
                        Left: var updatedLeft,
                        Right: var updatedRight,
                        OperatorType: var updatedOperatorType
                    }
                    || updatedOperatorType != binary.OperatorType)
                {
                    throw new UnreachableException("MakeBinary modified binary expression type/operator when doing row value comparison");
                }

                updatedLeftValues[i] = updatedLeft;
                updatedRightValues[i] = updatedRight;
            }

            binary = new SqlBinaryExpression(
                binary.OperatorType,
                new DuckDBRowValueExpression(updatedLeftValues, binary.Left.Type),
                new DuckDBRowValueExpression(updatedRightValues, binary.Right.Type),
                binary.Type,
                binary.TypeMapping);
        }
        
        return (SqlBinaryExpression)base.ApplyTypeMapping(binary, typeMapping);

        static bool IsComparison(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return true;
                default:
                    return false;
            }
        }

        bool TryGetRowValueValues(SqlExpression e, [NotNullWhen(true)] out IReadOnlyList<SqlExpression>? values)
        {
            switch (e)
            {
                case DuckDBRowValueExpression rowValueExpression:
                    values = rowValueExpression.Values;
                    return true;

                case SqlConstantExpression { Value : ITuple constantTuple }:
                    var v = new SqlExpression[constantTuple.Length];

                    for (var i = 0; i < v.Length; i++)
                    {
                        v[i] = Constant(constantTuple[i], typeof(object));
                    }

                    values = v;
                    return true;

                default:
                    values = null;
                    return false;
            }
        }
    }

    private SqlExpression ApplyTypeMappingOnRowValue(
        DuckDBRowValueExpression pgRowValueExpression,
        RelationalTypeMapping? typeMapping)
    {
        var updatedValues = new SqlExpression[pgRowValueExpression.Values.Count];

        for (var i = 0; i < updatedValues.Length; i++)
        {
            updatedValues[i] = ApplyDefaultTypeMapping(pgRowValueExpression.Values[i]);
        }

        return new DuckDBRowValueExpression(updatedValues, pgRowValueExpression.Type, typeMapping);
    }

    private SqlExpression ApplyTypeMappingOnAny(DuckDBAnyExpression duckDbAnyExpression)
    {
        var (item, array) = ApplyTypeMappingsOnItemAndArray(duckDbAnyExpression.Item, duckDbAnyExpression.Array);
        return new DuckDBAnyExpression(item, array, _boolTypeMapping);
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

    private SqlExpression ApplyTypeMappingOnArraySlice(
        DuckDBArraySliceExpression slice,
        RelationalTypeMapping? typeMapping)
    {
        var array = ApplyTypeMapping(slice.Array, typeMapping);

        return new DuckDBArraySliceExpression(
            array,
            slice.LowerBound is null ? null : ApplyDefaultTypeMapping(slice.LowerBound),
            slice.UpperBound is null ? null : ApplyDefaultTypeMapping(slice.UpperBound),
            slice.IsNullable,
            slice.Type,
            array.TypeMapping);
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
