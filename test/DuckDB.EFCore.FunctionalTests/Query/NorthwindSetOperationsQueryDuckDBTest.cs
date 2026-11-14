using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class NorthwindSetOperationsQueryDuckDBTest : NorthwindSetOperationsQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindSetOperationsQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Client_eval_Union_FirstOrDefault(bool async)
    {
        return base.Client_eval_Union_FirstOrDefault(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Select_Union_different_fields_in_anonymous_with_subquery(bool async)
    {
        return base.Select_Union_different_fields_in_anonymous_with_subquery(async);
    }
}
