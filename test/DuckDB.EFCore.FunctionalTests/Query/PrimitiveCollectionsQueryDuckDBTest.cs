using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class PrimitiveCollectionsQueryDuckDBTest : PrimitiveCollectionsQueryRelationalTestBase<PrimitiveCollectionsQueryDuckDBTest.PrimitiveCollectionsQueryDuckDBFixture>
{
    public PrimitiveCollectionsQueryDuckDBTest(PrimitiveCollectionsQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Any()
    {
        return base.Column_collection_Any();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Contains_over_subquery()
    {
        return base.Column_collection_Contains_over_subquery();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Count_method()
    {
        return base.Column_collection_Count_method();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Count_with_predicate()
    {
        return base.Column_collection_Count_with_predicate();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Distinct()
    {
        return base.Column_collection_Distinct();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_ElementAt()
    {
        return base.Column_collection_ElementAt();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_First()
    {
        return base.Column_collection_First();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_FirstOrDefault()
    {
        return base.Column_collection_FirstOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_in_subquery_Union_parameter_collection()
    {
        return base.Column_collection_in_subquery_Union_parameter_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_index_beyond_end()
    {
        return base.Column_collection_index_beyond_end();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_index_datetime()
    {
        return base.Column_collection_index_datetime();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_index_int()
    {
        return base.Column_collection_index_int();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_index_string()
    {
        return base.Column_collection_index_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Intersect_inline_collection()
    {
        return base.Column_collection_Intersect_inline_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Length()
    {
        return base.Column_collection_Length();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Join_parameter_collection()
    {
        return base.Column_collection_Join_parameter_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_bools_Contains()
    {
        return base.Column_collection_of_bools_Contains();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_ints_Contains()
    {
        return base.Column_collection_of_ints_Contains();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_nullable_ints_Contains()
    {
        return base.Column_collection_of_nullable_ints_Contains();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_nullable_ints_Contains_null()
    {
        return base.Column_collection_of_nullable_ints_Contains_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_nullable_strings_contains_null()
    {
        return base.Column_collection_of_nullable_strings_contains_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_of_strings_contains_null()
    {
        return base.Column_collection_of_strings_contains_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_OrderByDescending_ElementAt()
    {
        return base.Column_collection_OrderByDescending_ElementAt();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_SelectMany()
    {
        return base.Column_collection_SelectMany();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_SelectMany_with_filter()
    {
        return base.Column_collection_SelectMany_with_filter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_SelectMany_with_Select_to_anonymous_type()
    {
        return base.Column_collection_SelectMany_with_Select_to_anonymous_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Single()
    {
        return base.Column_collection_Single();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_SingleOrDefault()
    {
        return base.Column_collection_SingleOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Skip()
    {
        return base.Column_collection_Skip();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Skip_Take()
    {
        return base.Column_collection_Skip_Take();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Take()
    {
        return base.Column_collection_Take();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Union_parameter_collection()
    {
        return base.Column_collection_Union_parameter_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_Count()
    {
        return base.Column_collection_Where_Count();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_ElementAt()
    {
        return base.Column_collection_Where_ElementAt();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_Skip()
    {
        return base.Column_collection_Where_Skip();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_Skip_Take()
    {
        return base.Column_collection_Where_Skip_Take();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_Take()
    {
        return base.Column_collection_Where_Take();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_Where_Union()
    {
        return base.Column_collection_Where_Union();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_Contains_with_EF_Parameter()
    {
        return base.Inline_collection_Contains_with_EF_Parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_Contains_with_IEnumerable_EF_Parameter()
    {
        return base.Inline_collection_Contains_with_IEnumerable_EF_Parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_Count_with_column_predicate_with_EF_Parameter()
    {
        return base.Inline_collection_Count_with_column_predicate_with_EF_Parameter();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_Except_column_collection()
    {
        return base.Inline_collection_Except_column_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_index_Column()
    {
        return base.Inline_collection_index_Column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_index_Column_with_EF_Constant()
    {
        return base.Inline_collection_index_Column_with_EF_Constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_Join_ordered_column_collection()
    {
        return base.Inline_collection_Join_ordered_column_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_List_value_index_Column()
    {
        return base.Inline_collection_List_value_index_Column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Inline_collection_value_index_Column()
    {
        return base.Inline_collection_value_index_Column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Non_nullable_reference_column_collection_index_equals_nullable_column()
    {
        return base.Non_nullable_reference_column_collection_index_equals_nullable_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_reference_column_collection_index_equals_nullable_column()
    {
        return base.Nullable_reference_column_collection_index_equals_nullable_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_Concat_column_collection()
    {
        return base.Parameter_collection_Concat_column_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_in_subquery_Union_column_collection()
    {
        return base.Parameter_collection_in_subquery_Union_column_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_in_subquery_Union_column_collection_nested()
    {
        return base.Parameter_collection_in_subquery_Union_column_collection_nested();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_index_Column_equal_Column()
    {
        return base.Parameter_collection_index_Column_equal_Column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_index_Column_equal_constant()
    {
        return base.Parameter_collection_index_Column_equal_constant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_with_type_inference_for_JsonScalarExpression()
    {
        return base.Parameter_collection_with_type_inference_for_JsonScalarExpression();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_collection_of_datetimes_filtered()
    {
        return base.Project_collection_of_datetimes_filtered();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_collection_of_ints_ordered()
    {
        return base.Project_collection_of_ints_ordered();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_collection_of_nullable_ints_with_paging2()
    {
        return base.Project_collection_of_nullable_ints_with_paging2();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_empty_collection_of_nullables_and_collection_only_containing_nulls()
    {
        return base.Project_empty_collection_of_nullables_and_collection_only_containing_nulls();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_inline_collection_with_Union()
    {
        return base.Project_inline_collection_with_Union();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_multiple_collections()
    {
        return base.Project_multiple_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_of_nullable_structs_Contains_nullable_struct_with_nullable_comparer()
    {
        return base.Parameter_collection_of_nullable_structs_Contains_nullable_struct_with_nullable_comparer();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_of_structs_Contains_nullable_struct_with_nullable_comparer()
    {
        return base.Parameter_collection_of_structs_Contains_nullable_struct_with_nullable_comparer();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_in_subquery_Union_column_collection_as_compiled_query()
    {
        return base.Parameter_collection_in_subquery_Union_column_collection_as_compiled_query();
    }

    public class PrimitiveCollectionsQueryDuckDBFixture : PrimitiveCollectionsQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
