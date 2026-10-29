using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class InheritanceQueryDuckDBTest : TPHInheritanceQueryTestBase<TPHInheritanceQueryDuckDBFixture>
{
    public InheritanceQueryDuckDBTest(TPHInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Setting_foreign_key_to_a_different_type_throws()
    {
        return base.Setting_foreign_key_to_a_different_type_throws();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}
