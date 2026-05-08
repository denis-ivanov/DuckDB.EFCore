using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class ParquetTests
{
    [Fact]
    public void Simple_query_uses_read_parquet()
    {
        using var context = CreateContext();
        var sql = context.MyData.ToQueryString();

        Assert.Contains("read_parquet('data/*.parquet')", sql);
    }

    [Fact]
    public void Where_query_uses_read_parquet()
    {
        using var context = CreateContext();
        var sql = context.MyData.Where(x => x.Id > 10).ToQueryString();

        Assert.Contains("read_parquet('data/*.parquet')", sql);
        Assert.Contains("WHERE", sql);
    }

    [Fact]
    public void Join_query_uses_read_parquet()
    {
        using var context = CreateContext();
        var sql = context.MyData.Join(context.Others, x => x.Id, y => y.Id, (x, y) => x).ToQueryString();

        Assert.Contains("read_parquet('data/*.parquet')", sql);
    }

    [Fact]
    public void Relationship_join_between_two_parquet_sets_uses_read_parquet_for_both()
    {
        using var context = CreateContext();
        var sql = context.MyData
            .SelectMany(m => m.Related, (m, r) => new { m.Id, r.Value })
            .ToQueryString();

        Assert.Contains("read_parquet('data/*.parquet')", sql);
        Assert.Contains("read_parquet('related/*.parquet')", sql);
        Assert.Contains("JOIN", sql);
    }

    [Fact]
    public void Write_throws_for_parquet_entity()
    {
        using var context = CreateContext();
        context.MyData.Add(new MyData { Id = 1 });

        Assert.ThrowsAny<Exception>(() => context.SaveChanges());
    }

    [Fact]
    public void Dynamic_parquet_path_from_service_provider_uses_read_parquet()
    {
        using var context = CreateDynamicContext("dynamic/*.parquet");
        var sql = context.DynamicMyData.ToQueryString();

        Assert.Contains("read_parquet('dynamic/*.parquet')", sql);
    }

    private static ParquetContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ParquetContext>()
            .UseDuckDB("DataSource=:memory:")
            .Options;

        return new ParquetContext(options);
    }

    private static DynamicParquetContext CreateDynamicContext(string parquetPath)
    {
        TestParquetPathService.CurrentPath = parquetPath;

        var services = new ServiceCollection();
        services.AddEntityFrameworkDuckDB();

        var serviceProvider = services.BuildServiceProvider();

        var options = new DbContextOptionsBuilder<DynamicParquetContext>()
            .UseInternalServiceProvider(serviceProvider)
            .UseDuckDB("DataSource=:memory:")
            .Options;

        return new DynamicParquetContext(options);
    }

    private sealed class ParquetContext(DbContextOptions<ParquetContext> options) : DbContext(options)
    {
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

    private static class TestParquetPathService
    {
        public static string CurrentPath { get; set; } = string.Empty;
    }

    private sealed class DynamicParquetContext(DbContextOptions<DynamicParquetContext> options) : DbContext(options)
    {
        public DbSet<DynamicMyData> DynamicMyData => Set<DynamicMyData>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DynamicMyData>()
                .FromParquet(TestParquetPathService.CurrentPath);
        }
    }
}

