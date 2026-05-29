using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

internal sealed class DuckDBArrayAppendExpression : Expression
{
    public DuckDBArrayAppendExpression(Expression source, Expression value, Type expressionType)
    {
        Source = source;
        Value = value;
        Type = expressionType;
    }

    public Expression Source { get; }

    public Expression Value { get; }

    public override ExpressionType NodeType => ExpressionType.Extension;

    public override Type Type { get; }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        var source = visitor.Visit(Source);
        var value = visitor.Visit(Value);

        return source != Source || value != Value
            ? new DuckDBArrayAppendExpression(source, value, Type)
            : this;
    }
}
