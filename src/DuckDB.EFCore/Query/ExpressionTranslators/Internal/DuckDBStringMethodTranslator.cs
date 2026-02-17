using DuckDB.NET.Native;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBStringMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo StartsWith = typeof(string).GetRuntimeMethod(nameof(string.StartsWith), [typeof(string)])!;
    private static readonly MethodInfo StartsWithChar = typeof(string).GetRuntimeMethod(nameof(string.StartsWith), [typeof(char)])!;
    private static readonly MethodInfo Contains = typeof(string).GetRuntimeMethod(nameof(string.Contains), [typeof(string)])!;
    private static readonly MethodInfo ContainsChar = typeof(string).GetRuntimeMethod(nameof(string.Contains), [typeof(char)])!;
    private static readonly MethodInfo EndsWith = typeof(string).GetRuntimeMethod(nameof(string.EndsWith), [typeof(string)])!;
    private static readonly MethodInfo EndsWithChar = typeof(string).GetRuntimeMethod(nameof(string.EndsWith), [typeof(char)])!;
    private static readonly MethodInfo Substring = typeof(string).GetRuntimeMethod(nameof(string.Substring), [typeof(int)])!;
    private static readonly MethodInfo SubstringLength = typeof(string).GetRuntimeMethod(nameof(string.Substring), [typeof(int), typeof(int)])!;
    private static readonly MethodInfo ToUpper = typeof(string).GetRuntimeMethod(nameof(string.ToUpper), Type.EmptyTypes)!;
    private static readonly MethodInfo ToLower = typeof(string).GetRuntimeMethod(nameof(string.ToLower), Type.EmptyTypes)!;
    private static readonly MethodInfo Trim = typeof(string).GetRuntimeMethod(nameof(string.Trim), Type.EmptyTypes)!;
    private static readonly MethodInfo TrimWithChar = typeof(string).GetRuntimeMethod(nameof(string.Trim), [typeof(char)])!;
    private static readonly MethodInfo TrimStart = typeof(string).GetRuntimeMethod(nameof(string.TrimStart), Type.EmptyTypes)!;
    private static readonly MethodInfo TrimStartWithChar = typeof(string).GetRuntimeMethod(nameof(string.TrimStart), [typeof(char)])!;
    private static readonly MethodInfo TrimStartWithCharArray = typeof(string).GetRuntimeMethod(nameof(string.TrimStart), [typeof(char[])])!;
    private static readonly MethodInfo TrimEnd = typeof(string).GetRuntimeMethod(nameof(string.TrimEnd), Type.EmptyTypes)!;
    private static readonly MethodInfo IndexOf = typeof(string).GetRuntimeMethod(nameof(string.IndexOf), [typeof(string)])!;
    private static readonly MethodInfo IndexOfChar = typeof(string).GetRuntimeMethod(nameof(string.IndexOf), [typeof(char)])!;
    private static readonly MethodInfo Replace = typeof(string).GetRuntimeMethod(nameof(string.Replace), [typeof(string), typeof(string)])!;
    private static readonly MethodInfo ReplaceChar = typeof(string).GetRuntimeMethod(nameof(string.Replace), [typeof(char), typeof(char)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBStringMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == StartsWith || method == StartsWithChar)
        {
            return _sqlExpressionFactory.Function(
                name: "starts_with",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        if (method == Contains || method == ContainsChar)
        {
            return _sqlExpressionFactory.Function(
                name: "contains",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        if (method == EndsWith || method == EndsWithChar)
        {
            return _sqlExpressionFactory.Function(
                name: "ends_with",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        if (method == Substring)
        {
            return _sqlExpressionFactory.Function(
                name: "substring",
                arguments: [instance!, _sqlExpressionFactory.Add(arguments[0], _sqlExpressionFactory.Constant(1))],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == SubstringLength)
        {
            return _sqlExpressionFactory.Function(
                name: "substring",
                arguments: [instance!, _sqlExpressionFactory.Add(arguments[0], _sqlExpressionFactory.Constant(1)), arguments[1]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(string));
        }

        if (method == ToUpper)
        {
            return _sqlExpressionFactory.Function(
                name: "upper",
                arguments: [instance!],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == ToLower)
        {
            return _sqlExpressionFactory.Function(
                name: "lower",
                arguments: [instance!],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == Trim)
        {
            return _sqlExpressionFactory.Function(
                name: "trim",
                arguments: [instance!],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == TrimWithChar)
        {
            return _sqlExpressionFactory.Function(
                name: "trim",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == IndexOf || method == IndexOfChar)
        {
            return _sqlExpressionFactory.Subtract(_sqlExpressionFactory.Function(
                    name: "instr",
                    arguments: [instance!, arguments[0]],
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    returnType: typeof(int)),
                _sqlExpressionFactory.Constant(1));
        }

        if (method == TrimStart)
        {
            return _sqlExpressionFactory.Function(
                name: "ltrim",
                arguments: [instance!],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == TrimStartWithChar)
        {
            return _sqlExpressionFactory.Function(
                name: "ltrim",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == TrimStartWithCharArray && arguments[0] is SqlConstantExpression { Value: char[] } constantExpression)
        {
            var stringValue = string.Join("", (char[])constantExpression.Value);

            return _sqlExpressionFactory.Function(
                name: "ltrim",
                arguments: [instance!, _sqlExpressionFactory.Constant(stringValue, typeof(string))],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == TrimEnd)
        {
            return _sqlExpressionFactory.Function(
                name: "rtrim",
                arguments: [instance!],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == TrimStartWithChar)
        {
            return _sqlExpressionFactory.Function(
                name: "ltrim",
                arguments: [instance!, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == Replace || method == ReplaceChar)
        {
            return _sqlExpressionFactory.Function(
                name: "replace",
                arguments: [instance!, arguments[0], arguments[1]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(string));
        }

        return null;
    }
}
