using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class OperatorsQueryDuckDbTest : OperatorsQueryTestBase
{
    public OperatorsQueryDuckDbTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_predicate_with_bitwise_and_modulo_and_negation()
    {
        return base.Complex_predicate_with_bitwise_and_modulo_and_negation();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Concat_and_json_scalar(bool async)
    {
        return base.Concat_and_json_scalar(async);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projection_with_not_and_negation_on_integer()
    {
        return base.Projection_with_not_and_negation_on_integer();
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
