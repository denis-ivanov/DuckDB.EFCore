using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Inheritance;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTInheritanceQueryDuckDBTest : TPTInheritanceQueryTestBase<TPTInheritanceQueryDuckDBFixture>
{
    public TPTInheritanceQueryDuckDBTest(TPTInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Is_operator_on_result_of_FirstOrDefault(bool async)
    {
        await base.Is_operator_on_result_of_FirstOrDefault(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Selecting_only_base_properties_on_base_type(bool async)
    {
        await base.Selecting_only_base_properties_on_base_type(async);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Setting_foreign_key_to_a_different_type_throws()
    {
        await base.Setting_foreign_key_to_a_different_type_throws();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}
