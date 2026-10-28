using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTInheritanceQueryDuckDBTest : TPTInheritanceQueryTestBase<TPTInheritanceQueryDuckDBFixture>
{
    public TPTInheritanceQueryDuckDBTest(TPTInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Is_operator_on_result_of_FirstOrDefault(bool async)
    {
        return base.Is_operator_on_result_of_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Selecting_only_base_properties_on_base_type(bool async)
    {
        return base.Selecting_only_base_properties_on_base_type(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Setting_foreign_key_to_a_different_type_throws()
    {
        return base.Setting_foreign_key_to_a_different_type_throws();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}
