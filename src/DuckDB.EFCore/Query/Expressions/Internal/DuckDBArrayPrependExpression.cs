using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBArrayPrependExpression : Expression
{
    public DuckDBArrayPrependExpression(Expression source, Expression value, Type expressionType)
    {
        Source = source;
        Value = value;
        Type = expressionType;
    }
    
    public Expression Source { get; set; }
    
    public Expression Value { get; set; }

    public override ExpressionType NodeType => ExpressionType.Extension;

    public override Type Type { get; }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        var source = visitor.Visit(Source);
        var value = visitor.Visit(Value);

        return source != Source || value != Value
            ? new DuckDBArrayPrependExpression(source, value, Type)
            : this;
    }
}
