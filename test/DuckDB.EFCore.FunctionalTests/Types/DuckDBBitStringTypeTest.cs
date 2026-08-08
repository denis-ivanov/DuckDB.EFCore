using DuckDB.EFCore.Extensions;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBBitStringTypeTest : IClassFixture<DuckDBBitStringTypeTest.BitStringFixture>
{
    public DuckDBBitStringTypeTest(BitStringFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    private BitStringFixture Fixture { get; }

    [ConditionalFact]
    public void Bit_columns_are_created_with_BIT_store_type()
    {
        using var context = CreateContext();

        var entityType = context.Model.FindEntityType(typeof(BitStringEntity))!;

        Assert.Equal("BIT", entityType.FindProperty(nameof(BitStringEntity.BitString))!.GetColumnType());
        Assert.Equal("BIT", entityType.FindProperty(nameof(BitStringEntity.Bits))!.GetColumnType());
        Assert.Equal("BIT", entityType.FindProperty(nameof(BitStringEntity.NullableBits))!.GetColumnType());
    }

    [ConditionalFact]
    public void Can_round_trip_bit_string_as_string()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 1, BitString = "10101", Bits = new BitArray([true, false, true]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 1);

        Assert.Equal("10101", entity.BitString);
    }

    [ConditionalFact]
    public void Can_round_trip_bit_string_as_BitArray()
    {
        using var context = CreateContext();

        var bits = new BitArray([true, false, false, true, true, false]);

        context.Entities.Add(new BitStringEntity { Id = 2, BitString = "1", Bits = bits });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 2);

        Assert.Equal(bits.Length, entity.Bits.Length);
        Assert.Equal(bits.Cast<bool>(), entity.Bits.Cast<bool>());
    }

    [ConditionalFact]
    public void Can_round_trip_null_bit_string()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 3, BitString = "0", Bits = new BitArray(1), NullableBits = null });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 3);

        Assert.Null(entity.NullableBits);
    }

    [ConditionalFact]
    public void Preserves_leading_zeros()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 4, BitString = "000000101011", Bits = new BitArray(1) });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 4);

        Assert.Equal("000000101011", entity.BitString);
    }

    [ConditionalFact]
    public void Can_filter_by_bit_string_parameter()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 5, BitString = "1100", Bits = new BitArray(1) });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var value = "1100";
        var entity = context.Entities.Single(e => e.BitString == value);

        Assert.Equal(5, entity.Id);
    }

    [ConditionalFact]
    public void Can_filter_by_bit_string_constant()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 6, BitString = "111000", Bits = new BitArray(1) });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.BitString == "111000");

        Assert.Equal(6, entity.Id);

        Assert.Contains("'111000'", Fixture.TestSqlLoggerFactory.SqlStatements[^1]);
    }

    [ConditionalFact]
    public void Can_update_bit_string()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 7, BitString = "0000", Bits = new BitArray(1) });
        context.SaveChanges();

        var tracked = context.Entities.Single(e => e.Id == 7);
        tracked.BitString = "1111";
        tracked.Bits = new BitArray([false, true]);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 7);

        Assert.Equal("1111", entity.BitString);
        Assert.Equal(new BitArray([false, true]).Cast<bool>(), entity.Bits.Cast<bool>());
    }

    [ConditionalFact]
    public void Explicit_store_type_is_not_overridden_for_BitArray()
    {
        var options = new DbContextOptionsBuilder<IncompatibleStoreTypeContext>()
            .UseInternalServiceProvider(Fixture.ServiceProvider)
            .UseDuckDB(Fixture.Connection)
            .Options;

        using var context = new IncompatibleStoreTypeContext(options);

        Assert.Throws<InvalidOperationException>(() => context.Model);
    }

    private BitStringContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<BitStringContext>()
            .UseInternalServiceProvider(Fixture.ServiceProvider)
            .UseDuckDB(Fixture.Connection)
            .Options;

        var context = new BitStringContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    private sealed class BitStringContext(DbContextOptions<BitStringContext> options) : DbContext(options)
    {
        public DbSet<BitStringEntity> Entities => Set<BitStringEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitStringEntity>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedNever();
                b.Property(e => e.BitString).HasColumnType("BIT");
            });
        }
    }

    private sealed class IncompatibleStoreTypeContext(DbContextOptions<IncompatibleStoreTypeContext> options) : DbContext(options)
    {
        public DbSet<BitStringEntity> Entities => Set<BitStringEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitStringEntity>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedNever();
                b.Property(e => e.Bits).HasColumnType("TIMESTAMP");
            });
        }
    }

    private sealed class BitStringEntity    {
        public int Id { get; set; }
        public string BitString { get; set; } = null!;
        public BitArray Bits { get; set; } = null!;
        public BitArray? NullableBits { get; set; }
    }

    public sealed class BitStringFixture : ServiceProviderFixtureBase, ITestSqlLoggerFactory, IDisposable
    {
        public BitStringFixture()
        {
            Connection = new DuckDBConnection("DataSource=:memory:");
            Connection.Open();
        }

        public DuckDBConnection Connection { get; }

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory => (TestSqlLoggerFactory)ListLoggerFactory;

        public void Dispose()
            => Connection.Dispose();
    }
}
