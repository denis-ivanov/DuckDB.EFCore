using DuckDB.EFCore.Extensions.Internal;
using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    public const string JsonEachKeyColumnName = "key";
    public const string JsonEachValueColumnName = "value";

    private readonly RelationalQueryCompilationContext _queryCompilationContext;
    private readonly DuckDBTypeMappingSource _typeMappingSource;
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;
    private readonly SqlAliasManager _sqlAliasManager;
    private RelationalTypeMapping? _ordinalityTypeMapping;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBQueryableMethodTranslatingExpressionVisitor(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
        RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
        RelationalQueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
        _queryCompilationContext = queryCompilationContext;
        _typeMappingSource = (DuckDBTypeMappingSource)relationalDependencies.TypeMappingSource;
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)relationalDependencies.SqlExpressionFactory;
        _sqlAliasManager = queryCompilationContext.SqlAliasManager;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected DuckDBQueryableMethodTranslatingExpressionVisitor(DuckDBQueryableMethodTranslatingExpressionVisitor parentVisitor)
        : base(parentVisitor)
    {
        _queryCompilationContext = parentVisitor._queryCompilationContext;
        _typeMappingSource = parentVisitor._typeMappingSource;
        _sqlExpressionFactory = parentVisitor._sqlExpressionFactory;
        _sqlAliasManager = parentVisitor._sqlAliasManager;
    }

    /// <inheritdoc />
    protected override QueryableMethodTranslatingExpressionVisitor CreateSubqueryVisitor()
    {
        return new DuckDBQueryableMethodTranslatingExpressionVisitor(this);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression TranslateDistinct(ShapedQueryExpression source)
    {
        if (source.TryExtractArray(out var array, out var projectedColumn, ignoreOrderings: true) ||
            (source.TryConvertToArray(out array, ignoreOrderings: true) && (projectedColumn = null) == null))
        {
            var elementClrType = array.Type.GetSequenceType();
            var isElementNullable = elementClrType.IsNullableType();

            if (!isElementNullable)
            {
                var listDistinct = _sqlExpressionFactory.Function(
                    "list_distinct",
                    [array],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    array.Type,
                    array.TypeMapping);

                var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
                var selectExpression = new SelectExpression(
                    [new DuckDBUnnestExpression(tableAlias, listDistinct, "unnest")],
                    new ColumnExpression("unnest", tableAlias, projectedColumn!.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                    [GenerateOrdinalityIdentifier(tableAlias)],
                    _queryCompilationContext.SqlAliasManager);

                Expression shaperExpression = new ProjectionBindingExpression(
                    selectExpression, new ProjectionMember(), source.ShaperExpression.Type.MakeNullable());

                if (source.ShaperExpression.Type != shaperExpression.Type)
                {
                    shaperExpression = Expression.Convert(shaperExpression, source.ShaperExpression.Type);
                }

                return new ShapedQueryExpression(selectExpression, shaperExpression);
            }
        }

        return base.TranslateDistinct(source);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslatePrimitiveCollection(SqlExpression sqlExpression, IProperty? property, string tableAlias)
    {
        var elementClrType = sqlExpression.Type.GetSequenceType();
        var elementTypeMapping = (RelationalTypeMapping?)sqlExpression.TypeMapping?.ElementTypeMapping;

        var isElementNullable = property?.GetElementType() is null
            ? elementClrType.IsNullableType()
            : property.GetElementType()!.IsNullable;

        SelectExpression selectExpression;

#pragma warning disable EF1001 // SelectExpression constructors are pubternal
        switch (sqlExpression.TypeMapping)
        {
            case DuckDBArrayTypeMapping or null:
            {
                var (ordinalityColumn, ordinalityComparer) = GenerateOrdinalityIdentifier(tableAlias);
                selectExpression = new SelectExpression(
                    [new DuckDBUnnestExpression(tableAlias, sqlExpression, "unnest")],
                    new ColumnExpression(
                        "unnest",
                        tableAlias,
                        elementClrType.UnwrapNullableType(),
                        elementTypeMapping,
                        isElementNullable),
                    identifier: [(ordinalityColumn, ordinalityComparer)],
                    _queryCompilationContext.SqlAliasManager);

                selectExpression.AppendOrdering(new OrderingExpression(ordinalityColumn, ascending: true));
                break;
            }

            case DuckDBJsonTypeMapping:
                {
                    var keyColumnTypeMapping = _typeMappingSource.FindMapping(typeof(int))!;
                    var jsonEachExpression = new DuckDBJsonEachExpression(tableAlias, sqlExpression);
                    selectExpression = new SelectExpression(
                        [jsonEachExpression],
                        new ColumnExpression(
                            JsonEachValueColumnName,
                            tableAlias,
                            elementClrType.UnwrapNullableType(),
                            elementTypeMapping,
                            isElementNullable),
                        identifier:
                        [
                            (new ColumnExpression(JsonEachKeyColumnName, tableAlias, typeof(int), keyColumnTypeMapping, nullable: false),
                                keyColumnTypeMapping.Comparer)
                        ],
                        _sqlAliasManager);
                    break;
                }
            
            default:
                throw new UnreachableException();
        }
#pragma warning restore EF1001 // SelectExpression constructors are pubternal

        Expression shaperExpression = new ProjectionBindingExpression(
            selectExpression, new ProjectionMember(), elementClrType.MakeNullable());

        if (elementClrType != shaperExpression.Type)
        {
            Debug.Assert(
                elementClrType.MakeNullable() == shaperExpression.Type,
                "expression.Type must be nullable of targetType");

            shaperExpression = Expression.Convert(shaperExpression, elementClrType);
        }

        return new ShapedQueryExpression(selectExpression, shaperExpression);
    }

    protected override ShapedQueryExpression? TransformJsonQueryToTable(JsonQueryExpression jsonQueryExpression)
    {
        var structuralType = jsonQueryExpression.StructuralType;
        var textTypeMapping = _typeMappingSource.FindMapping(typeof(string));

        // TODO: Refactor this out
        // Calculate the table alias for the json_each expression based on the last named path segment
        // (or the JSON column name if there are none)
        var lastNamedPathSegment = jsonQueryExpression.Path.LastOrDefault(ps => ps.PropertyName is not null);
        var tableAlias = _sqlAliasManager.GenerateTableAlias(lastNamedPathSegment.PropertyName ?? jsonQueryExpression.JsonColumn.Name);

        // Handling a non-primitive JSON array is complicated on SQLite; unlike SQL Server OPENJSON and PostgreSQL jsonb_to_recordset,
        // SQLite's json_each can only project elements of the array, and not properties within those elements. For example:
        // SELECT value FROM json_each('[{"a":1,"b":"foo"}, {"a":2,"b":"bar"}]')
        // This will return two rows, each with a string column representing an array element (i.e. {"a":1,"b":"foo"}). To decompose that
        // into a and b columns, a further extraction is needed:
        // SELECT value ->> 'a' AS a, value ->> 'b' AS b FROM json_each('[{"a":1,"b":"foo"}, {"a":2,"b":"bar"}]')

        // We therefore generate a minimal subquery projecting out all the properties and navigations, wrapped by a SelectExpression
        // containing that:
        // SELECT ...
        // FROM (SELECT value ->> 'a' AS a, value ->> 'b' AS b FROM json_each(<JSON column>, <path>)) AS j
        // WHERE j.a = 8;

        // Unfortunately, while the subquery projects the entity, our EntityProjectionExpression currently supports only bare
        // ColumnExpression (the above requires JsonScalarExpression). So we hack as if the subquery projects an anonymous type instead,
        // with a member for each JSON property that needs to be projected. We then wrap it with a SelectExpression the projects a proper
        // EntityProjectionExpression.

        var jsonEachExpression = new DuckDBJsonEachExpression(tableAlias, jsonQueryExpression.JsonColumn, jsonQueryExpression.Path);

#pragma warning disable EF1001 // Internal EF Core API usage.
        var selectExpression = CreateSelect(
            jsonQueryExpression,
            jsonEachExpression,
            JsonEachKeyColumnName,
            typeof(int),
            _typeMappingSource.FindMapping(typeof(int))!);
#pragma warning restore EF1001 // Internal EF Core API usage.

        selectExpression.AppendOrdering(
            new OrderingExpression(
                selectExpression.CreateColumnExpression(
                    jsonEachExpression,
                    JsonEachKeyColumnName,
                    typeof(int),
                    typeMapping: _typeMappingSource.FindMapping(typeof(int)),
                    columnNullable: false),
                ascending: true));

        var propertyJsonScalarExpression = new Dictionary<ProjectionMember, Expression>();

        var jsonColumn = selectExpression.CreateColumnExpression(
            jsonEachExpression, JsonEachValueColumnName, typeof(string), _typeMappingSource.FindMapping(typeof(string))); // TODO: nullable?

        // First step: build a SelectExpression that will execute json_each and project all properties and navigations out, e.g.
        // (SELECT value ->> 'a' AS a, value ->> 'b' AS b FROM json_each(c."JsonColumn", '$.Something.SomeCollection')

        // We're only interested in properties which actually exist in the JSON, filter out uninteresting synthetic keys
        foreach (var property in structuralType.GetPropertiesInHierarchy())
        {
            if (property.GetJsonPropertyName() is { } jsonPropertyName)
            {
                // HACK: currently the only way to project multiple values from a SelectExpression is to simulate a Select out to an anonymous
                // type; this requires the MethodInfos of the anonymous type properties, from which the projection alias gets taken.
                // So we create fake members to hold the JSON property name for the alias.
                var projectionMember = new ProjectionMember().Append(new FakeMemberInfo(jsonPropertyName));

                propertyJsonScalarExpression[projectionMember] = new JsonScalarExpression(
                    jsonColumn,
                    [new PathSegment(property.GetJsonPropertyName()!)],
                    property.ClrType.UnwrapNullableType(),
                    property.GetRelationalTypeMapping(),
                    property.IsNullable);
            }
        }

        if (structuralType is IEntityType entityType)
        {
            foreach (var navigation in entityType.GetNavigationsInHierarchy()
                         .Where(n => n.ForeignKey.IsOwnership
                             && n.TargetEntityType.IsMappedToJson()
                             && n.ForeignKey.PrincipalToDependent == n))
            {
                var jsonNavigationName = navigation.TargetEntityType.GetJsonPropertyName();
                Debug.Assert(jsonNavigationName is not null, "Invalid navigation found on JSON-mapped entity");

                var projectionMember = new ProjectionMember().Append(new FakeMemberInfo(jsonNavigationName));

                propertyJsonScalarExpression[projectionMember] = new JsonScalarExpression(
                    jsonColumn,
                    [new PathSegment(jsonNavigationName)],
                    typeof(string),
                    textTypeMapping,
                    !navigation.ForeignKey.IsRequiredDependent);
            }
        }

        foreach (var complexProperty in structuralType.GetComplexProperties())
        {
            var jsonNavigationName = complexProperty.ComplexType.GetJsonPropertyName();
            Debug.Assert(jsonNavigationName is not null, "Invalid complex property found on JSON-mapped structural type");

            var projectionMember = new ProjectionMember().Append(new FakeMemberInfo(jsonNavigationName));

            propertyJsonScalarExpression[projectionMember] = new JsonScalarExpression(
                jsonColumn,
                [new PathSegment(jsonNavigationName)],
                typeof(string),
                textTypeMapping,
                jsonQueryExpression.IsNullable || complexProperty.IsNullable);
        }

        selectExpression.ReplaceProjection(propertyJsonScalarExpression);

        // Second step: push the above SelectExpression down to a subquery, and project an entity projection from the outer
        // SelectExpression, i.e.
        // SELECT "t"."a", "t"."b"
        // FROM (SELECT value ->> 'a' ... FROM json_each(...))

        selectExpression.PushdownIntoSubquery();
        var subquery = selectExpression.Tables[0];

#pragma warning disable EF1001 // Internal EF Core API usage.
        var newOuterSelectExpression = CreateSelect(
            jsonQueryExpression,
            subquery,
            JsonEachKeyColumnName,
            typeof(int),
            _typeMappingSource.FindMapping(typeof(int))!);
#pragma warning restore EF1001 // Internal EF Core API usage.

        newOuterSelectExpression.AppendOrdering(
            new OrderingExpression(
                selectExpression.CreateColumnExpression(
                    subquery,
                    JsonEachKeyColumnName,
                    typeof(int),
                    typeMapping: _typeMappingSource.FindMapping(typeof(int)),
                    columnNullable: false),
                ascending: true));

        return new ShapedQueryExpression(
            newOuterSelectExpression,
            new RelationalStructuralTypeShaperExpression(
                jsonQueryExpression.StructuralType,
                new ProjectionBindingExpression(
                    newOuterSelectExpression,
                    new ProjectionMember(),
                    typeof(ValueBuffer)),
                false));
    }

    protected override ShapedQueryExpression? TranslateAll(ShapedQueryExpression source, LambdaExpression predicate)
    {
        return base.TranslateAll(source, predicate);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateAny(ShapedQueryExpression source, LambdaExpression? predicate)
    {
        if (source.QueryExpression is SelectExpression { Tables: [{ Alias: var tableAlias }] })
        {
            if (source.TryExtractArray(out var array, ignoreOrderings: true)
                || source.TryConvertToArray(out array, ignoreOrderings: true))
            {
                // Pattern match: x.Array.Any()
                // Translation: array_length(x.array) > 0 instead of EXISTS (SELECT 1 FROM FROM unnest(x.Array))
                if (predicate is null)
                {
                    return BuildSimplifiedShapedQuery(
                        source,
                        _sqlExpressionFactory.GreaterThan(
                            _sqlExpressionFactory.Function(
                                "array_length",
                                [array],
                                nullable: true,
                                argumentsPropagateNullability: [true],
                                typeof(int)),
                            _sqlExpressionFactory.Constant(0)));
                }
            }
        }

        return base.TranslateAny(source, predicate);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateElementAtOrDefault(
        ShapedQueryExpression source,
        Expression index,
        bool returnDefault)
    {
        if (!returnDefault && TranslateExpression(index) is { } translatedIndex)
        {
            switch (source)
            {
                case var _ when source.TryExtractArray(out var array, out var projectedColumn):
                {
                    return source.UpdateQueryExpression(
                        new SelectExpression(
                            _sqlExpressionFactory.ArrayIndex(
                                array,
                                GenerateOneBasedIndexExpression(translatedIndex), projectedColumn.IsNullable),
                            ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager));
                }
            }
        }

        return base.TranslateElementAtOrDefault(source, index, returnDefault);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateSkip(ShapedQueryExpression source, Expression count)
    {
        if (source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(count) is { } translatedCount)
        {
#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [
                    new DuckDBUnnestExpression(
                        tableAlias,
                        _sqlExpressionFactory.ArraySlice(
                            array,
                            lowerBound: GenerateOneBasedIndexExpression(translatedCount),
                            upperBound: null,
                            projectedColumn.IsNullable),
                        "value"),
                ],
                new ColumnExpression("value", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                identifier: [GenerateOrdinalityIdentifier(tableAlias)],
                _queryCompilationContext.SqlAliasManager);
#pragma warning restore EF1001

            // TODO: Simplify by using UpdateQueryExpression after https://github.com/dotnet/efcore/issues/31511
            Expression shaperExpression = new ProjectionBindingExpression(
                selectExpression, new ProjectionMember(), source.ShaperExpression.Type.MakeNullable());

            if (source.ShaperExpression.Type != shaperExpression.Type)
            {
                Debug.Assert(
                    source.ShaperExpression.Type.MakeNullable() == shaperExpression.Type,
                    "expression.Type must be nullable of targetType");

                shaperExpression = Expression.Convert(shaperExpression, source.ShaperExpression.Type);
            }

            return new ShapedQueryExpression(selectExpression, shaperExpression);
        }

        return base.TranslateSkip(source, count);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateTake(ShapedQueryExpression source, Expression count)
    {
        if (source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(count) is { } translatedCount)
        {
            DuckDBArraySliceExpression sliceExpression;

            if (array is DuckDBArraySliceExpression existingSliceExpression)
            {
                if (existingSliceExpression is
                    {
                        LowerBound: SqlConstantExpression { Value: int lowerBoundValue } lowerBound,
                        UpperBound: null
                    })
                {
                    sliceExpression = existingSliceExpression.Update(
                        existingSliceExpression.Array,
                        existingSliceExpression.LowerBound,
                        translatedCount is SqlConstantExpression { Value: int takeCount }
                            ? _sqlExpressionFactory.Constant(lowerBoundValue + takeCount - 1, lowerBound.TypeMapping)
                            : _sqlExpressionFactory.Subtract(
                                _sqlExpressionFactory.Add(lowerBound, translatedCount),
                                _sqlExpressionFactory.Constant(1, lowerBound.TypeMapping)));
                }
                else
                {
                    return base.TranslateTake(source, count);
                }
            }
            else
            {
                sliceExpression = _sqlExpressionFactory.ArraySlice(
                    array,
                    lowerBound: null,
                    upperBound: translatedCount,
                    projectedColumn.IsNullable);
            }

#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [new DuckDBUnnestExpression(tableAlias, sliceExpression, "unnest")],
                new ColumnExpression("unnest", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                [GenerateOrdinalityIdentifier(tableAlias)],
                ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager);
#pragma warning restore EF1001 // Internal EF Core API usage.

            Expression shaperExpression = new ProjectionBindingExpression(
                selectExpression, new ProjectionMember(), source.ShaperExpression.Type.MakeNullable());

            if (source.ShaperExpression.Type != shaperExpression.Type)
            {
                Debug.Assert(
                    source.ShaperExpression.Type.MakeNullable() == shaperExpression.Type,
                    "expression.Type must be nullable of targetType");

                shaperExpression = Expression.Convert(shaperExpression, source.ShaperExpression.Type);
            }

            return new ShapedQueryExpression(selectExpression, shaperExpression);
        }
        
        return base.TranslateTake(source, count);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateWhere(ShapedQueryExpression source, LambdaExpression predicate)
    {
        // Simplify x.Array.Where(i => i != 3) => array_remove(x.Array, 3) instead of subquery
        if (predicate.Body is BinaryExpression
            {
                NodeType: ExpressionType.NotEqual,
                Left: var left,
                Right: var right
            }
            && (left == predicate.Parameters[0] ? right : right == predicate.Parameters[0] ? left : null) is Expression itemToFilterOut
            && source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(itemToFilterOut) is SqlExpression translatedItemToFilterOut)
        {
            var simplifiedTranslation = _sqlExpressionFactory.Function(
                "array_remove",
                [array, translatedItemToFilterOut],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                array.Type,
                array.TypeMapping);

#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [new DuckDBUnnestExpression(tableAlias, simplifiedTranslation, "unnest")],
                new ColumnExpression("unnest", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                [GenerateOrdinalityIdentifier(tableAlias)],
                _queryCompilationContext.SqlAliasManager);
#pragma warning restore EF1001 // Internal EF Core API usage.

            // TODO: Simplify by using UpdateQueryExpression after https://github.com/dotnet/efcore/issues/31511
            Expression shaperExpression = new ProjectionBindingExpression(
                selectExpression, new ProjectionMember(), source.ShaperExpression.Type.MakeNullable());

            if (source.ShaperExpression.Type != shaperExpression.Type)
            {
                Debug.Assert(
                    source.ShaperExpression.Type.MakeNullable() == shaperExpression.Type,
                    "expression.Type must be nullable of targetType");

                shaperExpression = Expression.Convert(shaperExpression, source.ShaperExpression.Type);
            }

            return new ShapedQueryExpression(selectExpression, shaperExpression);
        }

        return base.TranslateWhere(source, predicate);
    }

    /// <inheritdoc />
    protected override ShapedQueryExpression? TranslateCount(ShapedQueryExpression source, LambdaExpression? predicate)
    {
        // Simplify x.Array.Count() => array_length(x.Array) instead of SELECT COUNT(*) FROM unnest(x.Array)
        if (predicate is null)
        {
            if (source.TryExtractArray(out var array, ignoreOrderings: true))
            {
                var translation = _sqlExpressionFactory.Function(
                    "array_length",
                    [array],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    typeof(int));

#pragma warning disable EF1001
                // SelectExpression constructors are currently internal
                return source.Update(
                    new SelectExpression(translation, _queryCompilationContext.SqlAliasManager),
                    Expression.Convert(
                        new ProjectionBindingExpression(source.QueryExpression, new ProjectionMember(), typeof(int?)),
                        typeof(int)));
#pragma warning restore EF1001
            }

            if (source.QueryExpression is SelectExpression
                {
                    Tables: [TableValuedFunctionExpression { Name: "json_each", Schema: null, IsBuiltIn: true, Arguments: [var jsonArray] }],
                    Predicate: null,
                    GroupBy: [],
                    Having: null,
                    IsDistinct: false,
                    Limit: null,
                    Offset: null
                })
            {
                var translation = _sqlExpressionFactory.Function(
                    "json_array_length",
                    [jsonArray],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    typeof(int));

#pragma warning disable EF1001
                return source.UpdateQueryExpression(new SelectExpression(translation, _sqlAliasManager));
#pragma warning restore EF1001
            }
        }

        return base.TranslateCount(source, predicate);
    }

    /// <inheritdoc />
    protected override bool IsNaturallyOrdered(SelectExpression selectExpression)
    {
        var result1 = selectExpression is { Tables: [DuckDBUnnestExpression unnest, ..] }
               && (selectExpression.Orderings is []
                   || selectExpression.Orderings is
                       [{ Expression: ColumnExpression { Name: "ordinality", TableAlias: var orderingTableAlias } }]
                   && orderingTableAlias == unnest.Alias);

        var result2 = selectExpression is
                      {
                          Tables: [var mainTable, ..],
                          Orderings:
                          [
                              {
                                  Expression: ColumnExpression { Name: JsonEachKeyColumnName } orderingColumn,
                                  IsAscending: true
                              }
                          ]
                      }
                      && orderingColumn.TableAlias == mainTable.Alias
                      && IsJsonEachKeyColumn(selectExpression, orderingColumn);

        // TODO Refactor.
        return result1 || result2;
        
        bool IsJsonEachKeyColumn(SelectExpression selectExpression, ColumnExpression orderingColumn)
            => selectExpression.Tables.FirstOrDefault(t => t.Alias == orderingColumn.TableAlias)?.UnwrapJoin() is { } table
               && (table is DuckDBJsonEachExpression
                   || (table is SelectExpression subquery
                       && subquery.Projection.FirstOrDefault(p => p.Alias == JsonEachKeyColumnName)?.Expression is ColumnExpression
                           projectedColumn
                       && IsJsonEachKeyColumn(subquery, projectedColumn)));
    }

    private (ColumnExpression, ValueComparer) GenerateOrdinalityIdentifier(string tableAlias)
    {
        _ordinalityTypeMapping ??= RelationalDependencies.TypeMappingSource.FindMapping("INT")!;
        return (new ColumnExpression("ordinality", tableAlias, typeof(int), _ordinalityTypeMapping, nullable: false),
            _ordinalityTypeMapping.Comparer);
    }

    private SqlExpression GenerateOneBasedIndexExpression(SqlExpression expression)
        => expression is SqlConstantExpression constant
            ? _sqlExpressionFactory.Constant(Convert.ToInt32(constant.Value) + 1, constant.TypeMapping)
            : _sqlExpressionFactory.Add(expression, _sqlExpressionFactory.Constant(1));
    
#pragma warning disable EF1001 // SelectExpression constructors are currently internal
    private ShapedQueryExpression BuildSimplifiedShapedQuery(ShapedQueryExpression source, SqlExpression translation)
        => source.Update(
            new SelectExpression(translation, _queryCompilationContext.SqlAliasManager),
            Expression.Convert(
                new ProjectionBindingExpression(translation, new ProjectionMember(), typeof(bool?)), typeof(bool)));
#pragma warning restore EF1001
    
    private sealed class FakeMemberInfo(string name) : MemberInfo
    {
        public override string Name { get; } = name;

        public override object[] GetCustomAttributes(bool inherit)
            => throw new NotSupportedException();

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            => throw new NotSupportedException();

        public override bool IsDefined(Type attributeType, bool inherit)
            => throw new NotSupportedException();

        public override Type? DeclaringType
            => throw new NotSupportedException();

        public override MemberTypes MemberType
            => throw new NotSupportedException();

        public override Type? ReflectedType
            => throw new NotSupportedException();
    }
}
