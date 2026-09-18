using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;
using System.Security.Cryptography;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBBlobMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo ToBase64String = typeof(Convert).GetRuntimeMethod(nameof(Convert.ToBase64String), [typeof(byte[])])!;
    private static readonly MethodInfo FromBase64String = typeof(Convert).GetRuntimeMethod(nameof(Convert.FromBase64String), [typeof(string)])!;
    private static readonly MethodInfo ToHexString = typeof(Convert).GetRuntimeMethod(nameof(Convert.ToHexString), [typeof(byte[])])!;
    private static readonly MethodInfo FromHexString = typeof(Convert).GetRuntimeMethod(nameof(Convert.FromHexString), [typeof(string)])!;
    private static readonly MethodInfo Md5HashData = typeof(MD5).GetRuntimeMethod(nameof(MD5.HashData), [typeof(byte[])])!;
    private static readonly MethodInfo Sha1HashData = typeof(SHA1).GetRuntimeMethod(nameof(SHA1.HashData), [typeof(byte[])])!;
    private static readonly MethodInfo Sha256HashData = typeof(SHA256).GetRuntimeMethod(nameof(SHA256.HashData), [typeof(byte[])])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBBlobMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == ToBase64String)
        {
            return _sqlExpressionFactory.Function(
                "to_base64",
                [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(string));
        }

        if (method == FromBase64String)
        {
            return _sqlExpressionFactory.Function(
                "from_base64",
                [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(byte[]));
        }

        if (method == ToHexString)
        {
            if (arguments[0] is SqlFunctionExpression
                {
                    Name: "unhex",
                    Arguments: [SqlFunctionExpression { Name: "md5" or "sha1" or "sha256" } hashFunction]
                })
            {
                return hashFunction;
            }

            return _sqlExpressionFactory.Function(
                "hex",
                [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(string));
        }

        if (method == FromHexString)
        {
            return _sqlExpressionFactory.Function(
                "unhex",
                [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(byte[]));
        }

        if (method == Md5HashData)
        {
            return _sqlExpressionFactory.Function(
                "unhex",
                [
                    _sqlExpressionFactory.Function(
                        "md5",
                        [arguments[0]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        typeof(string))
                ],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(byte[]));
        }

        if (method == Sha1HashData)
        {
            return _sqlExpressionFactory.Function(
                "unhex",
                [
                    _sqlExpressionFactory.Function(
                        "sha1",
                        [arguments[0]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        typeof(string))
                ],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(byte[]));
        }

        if (method == Sha256HashData)
        {
            return _sqlExpressionFactory.Function(
                "unhex",
                [
                    _sqlExpressionFactory.Function(
                        "sha256",
                        [arguments[0]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        typeof(string))
                ],
                nullable: true,
                argumentsPropagateNullability: [true],
                typeof(byte[]));
        }

        return null;
    }
}
