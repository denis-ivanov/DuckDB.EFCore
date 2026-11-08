using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

namespace DuckDB.EFCore.ChangeTracking.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBBitArrayValueComparer : ValueComparer<BitArray>
{
    private static readonly ConstructorInfo? HashCodeConstructor
        = typeof(HashCode).GetConstructor(BindingFlags.Instance | BindingFlags.Public, Type.EmptyTypes)
          ?? typeof(HashCode).GetConstructor(Type.EmptyTypes);

    private static new readonly MethodInfo HashCodeAddMethod
        = typeof(HashCode).GetMethods().Single(m =>
                m is { Name: nameof(HashCode.Add), IsGenericMethod: true } && m.GetParameters().Length == 1)
            .MakeGenericMethod(typeof(bool))!;

    private static readonly MethodInfo HashCodeToHashCodeMethod
        = typeof(HashCode).GetMethod(nameof(HashCode.ToHashCode), Type.EmptyTypes)!;

    private static readonly PropertyInfo BitArrayCountProperty
        = typeof(BitArray).GetProperty(nameof(BitArray.Count))!;

    private static readonly MethodInfo BitArrayGetMethod
        = typeof(BitArray).GetMethod(nameof(BitArray.Get), [typeof(int)])!;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static DuckDBBitArrayValueComparer Instance { get; } = new();

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBBitArrayValueComparer()
        : base(
            GetEqualsExpression(),
            GetHashCodeExpression(),
            GetSnapshotExpression())
    {
    }

    private static Expression<Func<BitArray?, BitArray?, bool>> GetEqualsExpression()
    {
        var type = typeof(BitArray);
        var paramA = Parameter(type, "a");
        var paramB = Parameter(type, "b");

        var indexVar = Variable(typeof(int), "i");
        var returnLabel = Label(typeof(bool), "return");

        var loop = Loop(
            IfThenElse(
                LessThan(indexVar, Property(paramA, BitArrayCountProperty)),
                Block(
                    IfThen(
                        NotEqual(
                            Call(paramA, BitArrayGetMethod, indexVar),
                            Call(paramB, BitArrayGetMethod, indexVar)),
                        Return(returnLabel, Constant(false))
                    ),
                    PostIncrementAssign(indexVar)
                ),
                Return(returnLabel, Constant(true))
            )
        );

        var loopBlock = Block(
            [indexVar],
            Assign(indexVar, Constant(0)),
            loop,
            Label(returnLabel, Constant(true))
        );

        var countCheck = Condition(
            NotEqual(Property(paramA, BitArrayCountProperty), Property(paramB, BitArrayCountProperty)),
            Constant(false),
            loopBlock
        );

        var nullCheck = Condition(
            OrElse(Equal(paramA, Constant(null, type)), Equal(paramB, Constant(null, type))),
            Constant(false),
            countCheck
        );

        var refCheck = Condition(
            ReferenceEqual(paramA, paramB),
            Constant(true),
            nullCheck
        );

        return Lambda<Func<BitArray?, BitArray?, bool>>(refCheck, paramA, paramB);
    }

    private static Expression<Func<BitArray, BitArray>> GetSnapshotExpression()
        => v => v == null ? null! : new BitArray(v);

    private static Expression<Func<BitArray, int>> GetHashCodeExpression()
    {
        var type = typeof(BitArray);
        var param = Parameter(type, "v");

        var hashCodeVar = Variable(typeof(HashCode), "hashCode");
        var indexVar = Variable(typeof(int), "i");
        var breakLabel = Label("break");

        var loop = Loop(
            IfThenElse(
                LessThan(indexVar, Property(param, BitArrayCountProperty)),
                Block(
                    Call(hashCodeVar, HashCodeAddMethod, Call(param, BitArrayGetMethod, indexVar)),
                    PostIncrementAssign(indexVar)
                ),
                Break(breakLabel)
            ),
            breakLabel
        );

        var block = Block(
            [hashCodeVar, indexVar],
            Assign(hashCodeVar, HashCodeConstructor != null ? New(HashCodeConstructor) : New(typeof(HashCode))),
            Assign(indexVar, Constant(0)),
            loop,
            Call(hashCodeVar, HashCodeToHashCodeMethod)
        );

        var nullCheck = Condition(
            Equal(param, Constant(null, type)),
            Constant(0),
            block
        );

        return Lambda<Func<BitArray, int>>(nullCheck, param);
    }
}
