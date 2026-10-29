using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class NorthwindSelectQueryDuckDBTest : NorthwindSelectQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindSelectQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Correlated_collection_after_distinct_with_complex_projection_not_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_distinct_with_complex_projection_not_containing_original_identifier(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Member_binding_after_ctor_arguments_fails_with_client_eval(bool async)
    {
        return base.Member_binding_after_ctor_arguments_fails_with_client_eval(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault_with_parameter(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault_with_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projection_containing_DateTime_subtraction(bool async)
    {
        return base.Projection_containing_DateTime_subtraction(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Reverse_in_projection_subquery(bool async)
    {
        return base.Reverse_in_projection_subquery(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Set_operation_in_pending_collection(bool async)
    {
        return base.Set_operation_in_pending_collection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SelectMany_with_collection_being_correlated_subquery_which_references_non_mapped_properties_from_inner_and_outer_entity(bool async)
    {
        await base.SelectMany_with_collection_being_correlated_subquery_which_references_non_mapped_properties_from_inner_and_outer_entity(async);
    }
}
