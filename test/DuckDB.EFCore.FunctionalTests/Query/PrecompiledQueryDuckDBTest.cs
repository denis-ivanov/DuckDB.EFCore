using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class PrecompiledQueryDuckDBTest : PrecompiledQueryRelationalTestBase, IClassFixture<PrecompiledQueryDuckDBTest.PrecompiledQueryDuckDBFixture>
{
    public PrecompiledQueryDuckDBTest(PrecompiledQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task BinaryExpression()
    {
        return base.BinaryExpression();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Concat()
    {
        return base.Concat();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Conditional_contains_captured_variable()
    {
        return base.Conditional_contains_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Conditional_no_evaluatable()
    {
        return base.Conditional_no_evaluatable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Contains_with_parameterized_collection()
    {
        return base.Contains_with_parameterized_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbContext_as_captured_variable()
    {
        return base.DbContext_as_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbContext_as_field()
    {
        return base.DbContext_as_field();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbContext_as_local_variable()
    {
        return base.DbContext_as_local_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbContext_as_method_invocation_result()
    {
        return base.DbContext_as_method_invocation_result();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbContext_as_property()
    {
        return base.DbContext_as_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Dynamic_query_does_not_get_precompiled()
    {
        return base.Dynamic_query_does_not_get_precompiled();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task EF_Constant_is_not_supported()
    {
        return base.EF_Constant_is_not_supported();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Except()
    {
        return base.Except();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Final_GroupBy()
    {
        return base.Final_GroupBy();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Foreach_sync_over_operator()
    {
        return base.Foreach_sync_over_operator();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSql_with_FormattableString_parameters()
    {
        return base.FromSql_with_FormattableString_parameters();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw()
    {
        return base.FromSqlRaw();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_single()
    {
        return base.Include_single();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_split()
    {
        return base.Include_split();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intersect()
    {
        return base.Intersect();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ListInit_fully_evaluatable()
    {
        return base.ListInit_fully_evaluatable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ListInit_no_evaluatability()
    {
        return base.ListInit_no_evaluatability();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ListInit_with_evaluatable_with_captured_variable()
    {
        return base.ListInit_with_evaluatable_with_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ListInit_with_evaluatable_without_captured_variable()
    {
        return base.ListInit_with_evaluatable_without_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MemberInit_contains_captured_variable()
    {
        return base.MemberInit_contains_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MemberInit_evaluatable_as_constant()
    {
        return base.MemberInit_evaluatable_as_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MemberInit_evaluatable_as_parameter()
    {
        return base.MemberInit_evaluatable_as_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MemberInit_no_evaluatable()
    {
        return base.MemberInit_no_evaluatable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MethodCallExpression_fully_evaluatable()
    {
        return base.MethodCallExpression_fully_evaluatable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MethodCallExpression_no_evaluatability()
    {
        return base.MethodCallExpression_no_evaluatability();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MethodCallExpression_with_evaluatable_with_captured_variable()
    {
        return base.MethodCallExpression_with_evaluatable_with_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MethodCallExpression_with_evaluatable_without_captured_variable()
    {
        return base.MethodCallExpression_with_evaluatable_without_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multiple_queries_with_captured_variables()
    {
        return base.Multiple_queries_with_captured_variables();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task New_with_no_arguments()
    {
        return base.New_with_no_arguments();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NewArray()
    {
        return base.NewArray();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NotParameterizedAttribute_is_not_supported_with_non_constant_argument()
    {
        return base.NotParameterizedAttribute_is_not_supported_with_non_constant_argument();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task OrderBy()
    {
        return base.OrderBy();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NotParameterizedAttribute_with_constant()
    {
        return base.NotParameterizedAttribute_with_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Query_compilation_failure()
    {
        return base.Query_compilation_failure();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Same_captured_variable_twice_in_different_lambdas()
    {
        return base.Same_captured_variable_twice_in_different_lambdas();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Same_captured_variable_twice_in_same_lambda()
    {
        return base.Same_captured_variable_twice_in_same_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_anonymous_object()
    {
        return base.Select_anonymous_object();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_changes_type()
    {
        return base.Select_changes_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_New_with_captured_variable()
    {
        return base.Select_New_with_captured_variable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Skip_with_constant()
    {
        return base.Skip_with_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Take_with_constant()
    {
        return base.Take_with_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Skip_with_parameter()
    {
        return base.Skip_with_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Take_with_parameter()
    {
        return base.Take_with_parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_All()
    {
        return base.Terminating_All();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AllAsync()
    {
        return base.Terminating_AllAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Any()
    {
        return base.Terminating_Any();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AnyAsync()
    {
        return base.Terminating_AnyAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AsAsyncEnumerable_on_DbSet()
    {
        return base.Terminating_AsAsyncEnumerable_on_DbSet();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AsAsyncEnumerable_on_IQueryable()
    {
        return base.Terminating_AsAsyncEnumerable_on_IQueryable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AsEnumerable()
    {
        return base.Terminating_AsEnumerable();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Average()
    {
        return base.Terminating_Average();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_AverageAsync()
    {
        return base.Terminating_AverageAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Contains()
    {
        return base.Terminating_Contains();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ContainsAsync()
    {
        return base.Terminating_ContainsAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Count()
    {
        return base.Terminating_Count();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_CountAsync()
    {
        return base.Terminating_CountAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ElementAt()
    {
        return base.Terminating_ElementAt();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ElementAtAsync()
    {
        return base.Terminating_ElementAtAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ElementAtOrDefault()
    {
        return base.Terminating_ElementAtOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ElementAtOrDefaultAsync()
    {
        return base.Terminating_ElementAtOrDefaultAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteDelete()
    {
        return base.Terminating_ExecuteDelete();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteDeleteAsync()
    {
        return base.Terminating_ExecuteDeleteAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteUpdate_with_lambda()
    {
        return base.Terminating_ExecuteUpdate_with_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteUpdate_without_lambda()
    {
        return base.Terminating_ExecuteUpdate_without_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteUpdateAsync_with_lambda()
    {
        return base.Terminating_ExecuteUpdateAsync_with_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ExecuteUpdateAsync_without_lambda()
    {
        return base.Terminating_ExecuteUpdateAsync_without_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_First()
    {
        return base.Terminating_First();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_FirstAsync()
    {
        return base.Terminating_FirstAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_FirstOrDefault()
    {
        return base.Terminating_FirstOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_FirstOrDefaultAsync()
    {
        return base.Terminating_FirstOrDefaultAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_GetEnumerator()
    {
        return base.Terminating_GetEnumerator();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Last()
    {
        return base.Terminating_Last();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_LastAsync()
    {
        return base.Terminating_LastAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_LastOrDefault()
    {
        return base.Terminating_LastOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_LastOrDefaultAsync()
    {
        return base.Terminating_LastOrDefaultAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_LongCount()
    {
        return base.Terminating_LongCount();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_LongCountAsync()
    {
        return base.Terminating_LongCountAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Max()
    {
        return base.Terminating_Max();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_MaxAsync()
    {
        return base.Terminating_MaxAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Min()
    {
        return base.Terminating_Min();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_MinAsync()
    {
        return base.Terminating_MinAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Single()
    {
        return base.Terminating_Single();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_SingleAsync()
    {
        return base.Terminating_SingleAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_SingleOrDefault()
    {
        return base.Terminating_SingleOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_SingleOrDefaultAsync()
    {
        return base.Terminating_SingleOrDefaultAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_Sum()
    {
        return base.Terminating_Sum();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_SumAsync()
    {
        return base.Terminating_SumAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToArray()
    {
        return base.Terminating_ToArray();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToArrayAsync()
    {
        return base.Terminating_ToArrayAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToDictionary()
    {
        return base.Terminating_ToDictionary();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToDictionaryAsync()
    {
        return base.Terminating_ToDictionaryAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToHashSet()
    {
        return base.Terminating_ToHashSet();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToHashSetAsync()
    {
        return base.Terminating_ToHashSetAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToList()
    {
        return base.Terminating_ToList();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToListAsync()
    {
        return base.Terminating_ToListAsync();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_ToLookup()
    {
        return base.Terminating_ToLookup();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Terminating_with_cancellation_token()
    {
        return base.Terminating_with_cancellation_token();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDictionary_over_anonymous_type()
    {
        return base.ToDictionary_over_anonymous_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToDictionaryAsync_over_anonymous_type()
    {
        return base.ToDictionaryAsync_over_anonymous_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Two_captured_variables_in_different_lambdas()
    {
        return base.Two_captured_variables_in_different_lambdas();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Two_captured_variables_in_same_lambda()
    {
        return base.Two_captured_variables_in_same_lambda();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Unary()
    {
        return base.Unary();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Union()
    {
        return base.Union();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Unsafe_accessor_gets_generated_once_for_multiple_queries()
    {
        return base.Unsafe_accessor_gets_generated_once_for_multiple_queries();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ValuesExpression()
    {
        return base.ValuesExpression();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_New_with_captured_variable()
    {
        return base.Where_New_with_captured_variable();
    }

    public class PrecompiledQueryDuckDBFixture : PrecompiledQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => DuckDBPrecompiledQueryTestHelpers.Instance;
    }
}
