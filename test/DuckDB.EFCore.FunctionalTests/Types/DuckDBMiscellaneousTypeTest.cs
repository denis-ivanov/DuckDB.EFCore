using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types.Miscellaneous;

public class BoolTypeTest : RelationalTypeTestBase<bool, BoolTypeTest.BoolTypeFixture>
{
    public BoolTypeTest(BoolTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class BoolTypeFixture : RelationalTypeFixtureBase<bool>
    {
        public override bool Value { get; } = true;
        public override bool OtherValue { get; } = false;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}

public class StringTypeTest : RelationalTypeTestBase<string, StringTypeTest.StringTypeFixture>
{
    public StringTypeTest(StringTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class StringTypeFixture : RelationalTypeFixtureBase<string>
    {
        public override string Value { get; } = "foo";
        public override string OtherValue { get; } = "bar";

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}

public class GuidTypeTest : RelationalTypeTestBase<Guid, GuidTypeTest.GuidTypeFixture>
{
    public GuidTypeTest(GuidTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public override async Task ExecuteUpdate_within_json_to_nonjson_column()
    {
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => base.ExecuteUpdate_within_json_to_nonjson_column());
        Assert.Equal(RelationalStrings.ExecuteUpdateCannotSetJsonPropertyToNonJsonColumn, exception.Message);
    }

    public class GuidTypeFixture : RelationalTypeFixtureBase<Guid>
    {
        public override Guid Value { get; } = new("8f7331d6-cde9-44fb-8611-81fff686f280");
        public override Guid OtherValue { get; } = new("ae192c36-9004-49b2-b785-8be10d169627");

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}

public class ByteArrayTypeTest : RelationalTypeTestBase<byte[], ByteArrayTypeTest.ByteArrayTypeFixture>
{
    public ByteArrayTypeTest(ByteArrayTypeFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExecuteUpdate_within_json_to_nonjson_column()
    {
        return base.ExecuteUpdate_within_json_to_nonjson_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Query_property_within_json()
    {
        return base.Query_property_within_json();
    }

    public class ByteArrayTypeFixture : RelationalTypeFixtureBase<byte[]>
    {
        public override byte[] Value { get; } = [1, 2, 3];
        public override byte[] OtherValue { get; } = [4, 5, 6, 7];

        public override Func<byte[], byte[], bool> Comparer { get; } = (a, b) => a.SequenceEqual(b);

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
