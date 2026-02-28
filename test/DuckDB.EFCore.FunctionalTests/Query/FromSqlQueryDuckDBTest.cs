using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class FromSqlQueryDuckDBTest : FromSqlQueryTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public FromSqlQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    protected override DbParameter CreateDbParameter(string name, object value)
    {
        return new DuckDBParameter
        {
            ParameterName = name.StartsWith('$')
                ? name.Substring(1)
                : name,
            Value = value
        };
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bad_data_error_handling_invalid_cast(bool async)
    {
        return base.Bad_data_error_handling_invalid_cast(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bad_data_error_handling_invalid_cast_projection(bool async)
    {
        return base.Bad_data_error_handling_invalid_cast_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bad_data_error_handling_null(bool async)
    {
        return base.Bad_data_error_handling_null(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bad_data_error_handling_null_no_tracking(bool async)
    {
        return base.Bad_data_error_handling_null_no_tracking(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Bad_data_error_handling_null_projection(bool async)
    {
        return base.Bad_data_error_handling_null_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSql_with_inlined_db_parameter(bool async)
    {
        return base.FromSql_with_inlined_db_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlInterpolated_with_inlined_db_parameter(bool async)
    {
        return base.FromSqlInterpolated_with_inlined_db_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_in_subquery_with_dbParameter(bool async)
    {
        return base.FromSqlRaw_in_subquery_with_dbParameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_in_subquery_with_positional_dbParameter_with_name(bool async)
    {
        return base.FromSqlRaw_in_subquery_with_positional_dbParameter_with_name(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_in_subquery_with_positional_dbParameter_without_name(bool async)
    {
        return base.FromSqlRaw_in_subquery_with_positional_dbParameter_without_name(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_queryable_composed_compiled_with_DbParameter(bool async)
    {
        return base.FromSqlRaw_queryable_composed_compiled_with_DbParameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_queryable_composed_compiled_with_nameless_DbParameter(bool async)
    {
        return base.FromSqlRaw_queryable_composed_compiled_with_nameless_DbParameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_queryable_simple_projection_composed(bool async)
    {
        return base.FromSqlRaw_queryable_simple_projection_composed(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task<string?> FromSqlRaw_queryable_with_parameters_and_closure(bool async)
    {
        return base.FromSqlRaw_queryable_with_parameters_and_closure(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_db_parameters_called_multiple_times(bool async)
    {
        return base.FromSqlRaw_with_db_parameters_called_multiple_times(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_dbParameter(bool async)
    {
        return base.FromSqlRaw_with_dbParameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_dbParameter_and_regular_parameter_with_same_name(bool async)
    {
        return base.FromSqlRaw_with_dbParameter_and_regular_parameter_with_same_name(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_dbParameter_mixed(bool async)
    {
        return base.FromSqlRaw_with_dbParameter_mixed(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_dbParameter_mixed_in_subquery(bool async)
    {
        return base.FromSqlRaw_with_dbParameter_mixed_in_subquery(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSqlRaw_with_dbParameter_without_name_prefix(bool async)
    {
        return base.FromSqlRaw_with_dbParameter_without_name_prefix(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_closed_connection_opened_by_it_when_buffering(bool async)
    {
        return base.Include_closed_connection_opened_by_it_when_buffering(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_does_not_close_user_opened_connection_for_empty_result(bool async)
    {
        return base.Include_does_not_close_user_opened_connection_for_empty_result(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multiple_occurrences_of_FromSql_with_db_parameter_adds_two_parameters(bool async)
    {
        return base.Multiple_occurrences_of_FromSql_with_db_parameter_adds_two_parameters(async);
    }
}
