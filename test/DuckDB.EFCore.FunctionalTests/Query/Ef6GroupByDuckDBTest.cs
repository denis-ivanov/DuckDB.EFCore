using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class Ef6GroupByDuckDBTest : Ef6GroupByTestBase<Ef6GroupByDuckDBTest.Ef6GroupByDuckDBFixture>
{
    public Ef6GroupByDuckDBTest(Ef6GroupByDuckDBFixture fixture) : base(fixture)
    {
    }

    public class Ef6GroupByDuckDBFixture : Ef6GroupByFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task All_Grouped_from_LINQ_101(bool async)
    {
        return base.All_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Any_Grouped_from_LINQ_101(bool async)
    {
        return base.Any_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Average_Grouped_from_LINQ_101(bool async)
    {
        return base.Average_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Count_Grouped_from_LINQ_101(bool async)
    {
        return base.Count_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Cross_Join_with_Group_Join_from_LINQ_101(bool async)
    {
        return base.Cross_Join_with_Group_Join_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Group_Join_from_LINQ_101(bool async)
    {
        return base.Group_Join_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_filtering_and_projecting_anonymous_type_with_group_key_and_function_aggregate(bool async)
    {
        return base.GroupBy_is_optimized_when_filtering_and_projecting_anonymous_type_with_group_key_and_function_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_grouping_by_row_and_projecting_column_of_the_key_row(bool async)
    {
        return base.GroupBy_is_optimized_when_grouping_by_row_and_projecting_column_of_the_key_row(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_aggregate_on_the_group(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_aggregate_on_the_group(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_anonymous_type_containing_group_key_and_group_aggregate(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_anonymous_type_containing_group_key_and_group_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_anonymous_type_containing_group_key_and_multiple_group_aggregates(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_anonymous_type_containing_group_key_and_multiple_group_aggregates(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_conditional_expression_containing_group_key(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_conditional_expression_containing_group_key(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_expression_containing_group_key(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_expression_containing_group_key(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_expression_with_multiple_function_aggregates(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_expression_with_multiple_function_aggregates(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_function_aggregate_with_expression(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_function_aggregate_with_expression(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_group_count(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_group_count(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_is_optimized_when_projecting_group_key(bool async)
    {
        return base.GroupBy_is_optimized_when_projecting_group_key(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_Nested_from_LINQ_101(bool async)
    {
        return base.GroupBy_Nested_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_Simple_1_from_LINQ_101(bool async)
    {
        return base.GroupBy_Simple_1_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_Simple_2_from_LINQ_101(bool async)
    {
        return base.GroupBy_Simple_2_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_Simple_3_from_LINQ_101(bool async)
    {
        return base.GroupBy_Simple_3_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_doesnt_produce_a_groupby_statement(bool async)
    {
        return base.Grouping_by_all_columns_doesnt_produce_a_groupby_statement(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_1(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_10(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_10(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_2(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_3(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_3(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_4(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_4(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_5(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_5(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_6(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_6(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_7(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_7(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_8(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_8(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Grouping_by_all_columns_with_aggregate_function_works_9(bool async)
    {
        return base.Grouping_by_all_columns_with_aggregate_function_works_9(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Left_Outer_Join_with_Group_Join_from_LINQ_101(bool async)
    {
        return base.Left_Outer_Join_with_Group_Join_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task LongCount_Grouped_from_LINQ_101(bool async)
    {
        return base.LongCount_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Max_Elements_from_LINQ_101(bool async)
    {
        return base.Max_Elements_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Max_Grouped_from_LINQ_101(bool async)
    {
        return base.Max_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Min_Elements_from_LINQ_101(bool async)
    {
        return base.Min_Elements_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Min_Grouped_from_LINQ_101(bool async)
    {
        return base.Min_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Sum_Grouped_from_LINQ_101(bool async)
    {
        return base.Sum_Grouped_from_LINQ_101(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_1(bool async)
    {
        return base.Whats_new_2021_sample_1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_10(bool async)
    {
        return base.Whats_new_2021_sample_10(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_11(bool async)
    {
        return base.Whats_new_2021_sample_11(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_12(bool async)
    {
        return base.Whats_new_2021_sample_12(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_13(bool async)
    {
        return base.Whats_new_2021_sample_13(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_14(bool async)
    {
        return base.Whats_new_2021_sample_14(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_15(bool async)
    {
        return base.Whats_new_2021_sample_15(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_16(bool async)
    {
        return base.Whats_new_2021_sample_16(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_2(bool async)
    {
        return base.Whats_new_2021_sample_2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_3(bool async)
    {
        return base.Whats_new_2021_sample_3(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_4(bool async)
    {
        return base.Whats_new_2021_sample_4(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_5(bool async)
    {
        return base.Whats_new_2021_sample_5(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_6(bool async)
    {
        return base.Whats_new_2021_sample_6(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_7(bool async)
    {
        return base.Whats_new_2021_sample_7(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_8(bool async)
    {
        return base.Whats_new_2021_sample_8(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Whats_new_2021_sample_9(bool async)
    {
        return base.Whats_new_2021_sample_9(async);
    }

}
