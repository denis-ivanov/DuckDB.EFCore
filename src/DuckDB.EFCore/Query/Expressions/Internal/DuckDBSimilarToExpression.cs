using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

/// <summary>
///     An expression that represents a SIMILAR TO operation in a SQL tree.
/// </summary>
/// <remarks>
///     <para>
///         See <see href="https://duckdb.org/docs/current/sql/functions/pattern_matching#similar-to">Pattern Matching</see> for more information.
///     </para>
///     <para>
///         This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///         the same compatibility standards as public APIs. It may be changed or removed without notice in
///         any release. You should only use it directly in your code with extreme caution and knowing that
///         doing so can result in application failures when updating to a new Entity Framework Core release.
///     </para>
/// </remarks>
public class DuckDBSimilarToExpression : SqlExpression, IEquatable<DuckDBSimilarToExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    /// <summary>
    ///     Creates a new instance of the <see cref="DuckDBSimilarToExpression" /> class.
    /// </summary>
    /// <param name="match">An expression to match.</param>
    /// <param name="pattern">A pattern to match.</param>
    /// <param name="typeMapping">The <see cref="RelationalTypeMapping" /> associated with the expression.</param>
    public DuckDBSimilarToExpression(
        SqlExpression match,
        SqlExpression pattern,
        RelationalTypeMapping? typeMapping)
        : base(typeof(bool), typeMapping)
    {
        Match = match;
        Pattern = pattern;
    }
    
    /// <summary>
    ///     The expression to match.
    /// </summary>
    public virtual SqlExpression Match { get; set; }
    
    /// <summary>
    ///     The pattern to match.
    /// </summary>
    public virtual SqlExpression Pattern { get; set; }

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => Update(
            (SqlExpression)visitor.Visit(Match),
            (SqlExpression)visitor.Visit(Pattern));

    /// <summary>
    ///     Creates a new expression that is like this one, but using the supplied children. If all of the children are the same, it will
    ///     return this expression.
    /// </summary>
    /// <param name="match">The <see cref="Match" /> property of the result.</param>
    /// <param name="pattern">The <see cref="Pattern" /> property of the result.</param>
    /// <returns>This expression if no children changed, or an expression with the updated children.</returns>
    public virtual DuckDBSimilarToExpression Update(
        SqlExpression match,
        SqlExpression pattern)
    {
        return match == Match && pattern == Pattern
            ? this
            : new DuckDBSimilarToExpression(match, pattern, TypeMapping);
    }

    /// <inheritdoc />
    public override Expression Quote()
    {
        return New(
            _quotingConstructor ??= typeof(DuckDBSimilarToExpression).GetConstructor(
                new[] { typeof(SqlExpression), typeof(SqlExpression), typeof(RelationalTypeMapping) })!,
            Match.Quote(),
            Pattern.Quote(),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is DuckDBSimilarToExpression other && Equals(other);
    }
    
    /// <inheritdoc />
    public virtual bool Equals(DuckDBSimilarToExpression? other)
    {
        return ReferenceEquals(this, other)
            || other is not null
            && base.Equals(other)
            && Equals(Match, other.Match)
            && Equals(Pattern, other.Pattern);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Match, Pattern);
    }

    /// <inheritdoc />
    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Visit(Match);
        expressionPrinter.Append(" SIMILAR TO ");
        expressionPrinter.Visit(Pattern);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Match} SIMILAR TO {Pattern}";
    }
}
