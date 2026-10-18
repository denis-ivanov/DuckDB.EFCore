using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

/// <summary>
///     An expression that represents an ILIKE operation in a SQL tree.
/// </summary>
/// <remarks>
///     <para>
///         See <see href="https://duckdb.org/docs/current/sql/functions/pattern_matching">Pattern Matching</see> for more information.
///     </para>
///     <para>
///         This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///         the same compatibility standards as public APIs. It may be changed or removed without notice in
///         any release. You should only use it directly in your code with extreme caution and knowing that
///         doing so can result in application failures when updating to a new Entity Framework Core release.
///     </para>
/// </remarks>
public class DuckDBILikeExpression : SqlExpression, IEquatable<DuckDBILikeExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    /// <summary>
    ///     Creates a new instance of the <see cref="DuckDBILikeExpression" /> class.
    /// </summary>
    /// <param name="match">An expression to match.</param>
    /// <param name="pattern">A pattern to match.</param>
    /// <param name="escapeChar">An optional escape character.</param>
    /// <param name="typeMapping">The <see cref="RelationalTypeMapping" /> associated with the expression.</param>
    public DuckDBILikeExpression(
        SqlExpression match,
        SqlExpression pattern,
        SqlExpression? escapeChar,
        RelationalTypeMapping? typeMapping)
        : base(typeof(bool), typeMapping)
    {
        Match = match;
        Pattern = pattern;
        EscapeChar = escapeChar;
    }
    
    /// <summary>
    ///     The expression to match.
    /// </summary>
    public virtual SqlExpression Match { get; set; }
    
    /// <summary>
    ///     The pattern to match.
    /// </summary>
    public virtual SqlExpression Pattern { get; set; }
    
    /// <summary>
    ///     The escape character.
    /// </summary>
    public virtual SqlExpression? EscapeChar { get; set; }

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        return Update(
            (SqlExpression)visitor.Visit(Match),
            (SqlExpression)visitor.Visit(Pattern),
            EscapeChar is null ? null : (SqlExpression)visitor.Visit(EscapeChar));
    }

    /// <summary>
    ///     Creates a new expression that is like this one, but using the supplied children. If all of the children are the same, it will
    ///     return this expression.
    /// </summary>
    /// <param name="match">The <see cref="Match" /> property of the result.</param>
    /// <param name="pattern">The <see cref="Pattern" /> property of the result.</param>
    /// <param name="escapeChar">The <see cref="EscapeChar" /> property of the result.</param>
    /// <returns>This expression if no children changed, or an expression with the updated children.</returns>
    public virtual DuckDBILikeExpression Update(
        SqlExpression match,
        SqlExpression pattern,
        SqlExpression? escapeChar)
    {
        return match == Match && pattern == Pattern && escapeChar == EscapeChar
            ? this
            : new DuckDBILikeExpression(match, pattern, escapeChar, TypeMapping);
    }
    
    /// <inheritdoc />
    public override Expression Quote()
        => New(
            _quotingConstructor ??= typeof(DuckDBILikeExpression).GetConstructor(
                [typeof(SqlExpression), typeof(SqlExpression), typeof(SqlExpression), typeof(RelationalTypeMapping)])!,
            Match.Quote(),
            Pattern.Quote(),
            RelationalExpressionQuotingUtilities.QuoteOrNull(EscapeChar),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is DuckDBILikeExpression other && Equals(other);
    }
    
    /// <inheritdoc />
    public virtual bool Equals(DuckDBILikeExpression? other)
    {
        return ReferenceEquals(this, other)
            || other is not null
            && base.Equals(other)
            && Equals(Match, other.Match)
            && Equals(Pattern, other.Pattern)
            && Equals(EscapeChar, other.EscapeChar);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Match, Pattern, EscapeChar);
    }

    /// <inheritdoc />
    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Visit(Match);
        expressionPrinter.Append(" ILIKE ");
        expressionPrinter.Visit(Pattern);
        
        if (EscapeChar is not null)
        {
            expressionPrinter.Append(" ESCAPE ");
            expressionPrinter.Visit(EscapeChar);
        }
    }

    /// <inheritdoc />
    public override string ToString()
        => $"{Match} ILIKE {Pattern}{(EscapeChar is null ? "" : $" ESCAPE {EscapeChar}")}";
}
