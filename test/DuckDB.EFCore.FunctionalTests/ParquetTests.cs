using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests;

public class ParquetTests : IClassFixture<ParquetTests.ParquetFixture>
{
    public ParquetTests(ParquetFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;

        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    private ParquetFixture Fixture { get; }

    [Fact]
    public void Simple_query_uses_read_parquet()
    {
        using var context = CreateContext();

        AssertSql(
            context.MyData.ToQueryString(),
            """
            SELECT m."Id"
            FROM read_parquet('data/*.parquet') AS m
            """
        );
    }

    [Fact]
    public void Where_query_uses_read_parquet()
    {
        using var context = CreateContext();

        AssertSql(
            context.MyData.Where(x => x.Id > 10).ToQueryString(),
            """
            SELECT m."Id"
            FROM read_parquet('data/*.parquet') AS m
            WHERE m."Id" > 10
            """
        );
    }

    [Fact]
    public void Join_query_uses_read_parquet()
    {
        using var context = CreateContext();
        var query =
            from parquetRow in context.MyData
            join otherRow in context.Others on parquetRow.Id equals otherRow.Id
            select parquetRow;

        AssertSql(
            query.ToQueryString(),
            """
            SELECT m."Id"
            FROM read_parquet('data/*.parquet') AS m
            INNER JOIN "Others" AS o ON m."Id" = o."Id"
            """
        );
    }

    [Fact]
    public void Relationship_join_between_two_parquet_sets_uses_read_parquet_for_both()
    {
        using var context = CreateContext();
        var relationshipQuery = context.MyData.SelectMany(
            m => m.Related,
            (m, r) => new { m.Id, r.Value }
        );
        AssertSql(
            relationshipQuery.ToQueryString(),
            """
            SELECT m."Id", r."Value"
            FROM read_parquet('data/*.parquet') AS m
            INNER JOIN read_parquet('related/*.parquet') AS r ON m."Id" = r."MyDataId"
            """
        );
    }

    [Fact]
    public void Dynamic_parquet_path_from_context_configuration_uses_read_parquet()
    {
        using var context = CreateDynamicContext("dynamic/*.parquet");

        AssertSql(
            context.DynamicMyData.ToQueryString(),
            """
            SELECT d."Id"
            FROM read_parquet('dynamic/*.parquet') AS d
            """
        );
    }

    private void AssertSql(string actual, params string[] expected)
        => Fixture.AssertSql(actual, expected);

    private ParquetContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ParquetContext>()
            .UseInternalServiceProvider(Fixture.ServiceProvider)
            .UseDuckDB("DataSource=:memory:")
            .Options;

        return new ParquetContext(options);
    }

    private DynamicParquetContext CreateDynamicContext(string parquetPath)
    {
        var options = new DbContextOptionsBuilder<DynamicParquetContext>()
            .UseInternalServiceProvider(Fixture.ServiceProvider)
            .UseDuckDB("DataSource=:memory:")
            .Options;

        return new DynamicParquetContext(options, parquetPath);
    }

    private sealed class ParquetContext : DbContext
    {
        public ParquetContext(DbContextOptions<ParquetContext> options)
            : base(options) { }

        public DbSet<MyData> MyData => Set<MyData>();
        public DbSet<OtherData> Others => Set<OtherData>();
        public DbSet<RelatedParquetData> RelatedParquetData => Set<RelatedParquetData>();
    }

    [FromParquet("data/*.parquet")]
    private sealed class MyData
    {
        public int Id { get; set; }
        public List<RelatedParquetData> Related { get; set; } = [];
    }

    private sealed class OtherData
    {
        public int Id { get; set; }
    }

    private sealed class DynamicMyData
    {
        public int Id { get; set; }
    }

    [FromParquet("related/*.parquet")]
    private sealed class RelatedParquetData
    {
        public int Id { get; set; }
        public int MyDataId { get; set; }
        public int Value { get; set; }
        public MyData? MyData { get; set; }
    }

    private sealed class DynamicParquetContext : DbContext
    {
        private readonly string _parquetPath;

        public DynamicParquetContext(
            DbContextOptions<DynamicParquetContext> options,
            string parquetPath
        )
            : base(options)
        {
            _parquetPath = parquetPath;
        }

        public DbSet<DynamicMyData> DynamicMyData => Set<DynamicMyData>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DynamicMyData>().FromParquet(_parquetPath);
        }
    }

    public sealed class ParquetFixture
        : ServiceProviderFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        public void AssertSql(string actual, params string[] expected)
            => Assert.Equal(Normalize(expected), Normalize(actual));

        private static string Normalize(params string[] sql)
            => string.Join("\n\n", sql.Select(s => Normalize(s)));

        private static string Normalize(string sql)
            => sql.Replace("\r\n", "\n").Trim();
    }
}

