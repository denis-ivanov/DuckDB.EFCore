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

    public override bool CanReduce => true;

    public override Expression Reduce()
    {
        return this;
    }
}
