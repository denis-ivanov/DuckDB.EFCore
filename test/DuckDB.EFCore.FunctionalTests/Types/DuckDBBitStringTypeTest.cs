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

        context.Entities.Add(new BitStringEntity { Id = 5, BitString = "110000000001", Bits = new BitArray(1) });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var value = "110000000001";
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

    [ConditionalFact]
    public void Can_translate_bit_length_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 10, BitString = "101", Bits = new BitArray([true, false, true, false, true, true, false, false, true]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entity = context.Entities.Single(e => e.Bits.Length == 9);

        Assert.Equal(10, entity.Id);
        AssertSql(
            """
            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE bit_length(e."Bits") = 9
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_bit_length_for_string_mapped_to_bit()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 11, BitString = "1010111", Bits = new BitArray(1) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entity = context.Entities.Single(e => e.BitString.Length == 7);

        Assert.Equal(11, entity.Id);
        AssertSql(
            """
            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE bit_length(e."BitString") = 7
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_project_bit_length()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 12, BitString = "11001", Bits = new BitArray([true, false, false, true]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var lengths = context.Entities
            .Where(e => e.Id == 12)
            .Select(e => new
            {
                BitStringLength = e.BitString.Length,
                BitsLength = e.Bits.Length
            })
            .Single();

        Assert.Equal(5, lengths.BitStringLength);
        Assert.Equal(4, lengths.BitsLength);
        AssertSql(
            """
            SELECT bit_length(e."BitString") AS "BitStringLength", bit_length(e."Bits") AS "BitsLength"
            FROM "Entities" AS e
            WHERE e."Id" = 12
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_And_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 20, BitString = "10101", Bits = new BitArray([true, false, true, false, true]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([true, true, false, false, true]);
        var expected = new BitArray([true, false, false, false, true]);
        var entity = context.Entities.Single(e => e.Bits.And(otherBits) == expected);

        Assert.Equal(20, entity.Id);
        AssertSql(
            """
            otherBits='?'
            expected='?'

            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE (e."Bits" & $otherBits) = $expected
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_project_And_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 21, BitString = "1100", Bits = new BitArray([true, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([true, false, true, false]);
        var result = context.Entities
            .Where(e => e.Id == 21)
            .Select(e => new
            {
                Result = e.Bits.And(otherBits)
            })
            .Single();

        Assert.Equal(new BitArray([true, false, false, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            otherBits='?'

            SELECT e."Bits" & $otherBits AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 21
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_And_between_columns_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity
        {
            Id = 22,
            BitString = "1111",
            Bits = new BitArray([true, true, true, false]),
            NullableBits = new BitArray([true, false, true, false])
        });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var result = context.Entities
            .Where(e => e.Id == 22)
            .Select(e => new
            {
                Result = e.Bits.And(e.NullableBits!)
            })
            .Single();

        Assert.Equal(new BitArray([true, false, true, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            SELECT e."Bits" & e."NullableBits" AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 22
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_Or_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 30, BitString = "10100", Bits = new BitArray([true, false, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([true, true, false, false, true]);
        var expected = new BitArray([true, true, true, false, true]);
        var entity = context.Entities.Where(e => e.Id == 30).Single(e => e.Bits.Or(otherBits) == expected);

        Assert.Equal(30, entity.Id);
        AssertSql(
            """
            otherBits='?'
            expected='?'

            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE e."Id" = 30 AND (e."Bits" | $otherBits) = $expected
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_project_Or_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 31, BitString = "1100", Bits = new BitArray([true, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([false, true, true, false]);
        var result = context.Entities
            .Where(e => e.Id == 31)
            .Select(e => new
            {
                Result = e.Bits.Or(otherBits)
            })
            .Single();

        Assert.Equal(new BitArray([true, true, true, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            otherBits='?'

            SELECT e."Bits" | $otherBits AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 31
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_Or_between_columns_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity
        {
            Id = 32,
            BitString = "1010",
            Bits = new BitArray([true, false, true, false]),
            NullableBits = new BitArray([false, true, true, false])
        });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var result = context.Entities
            .Where(e => e.Id == 32)
            .Select(e => new
            {
                Result = e.Bits.Or(e.NullableBits!)
            })
            .Single();

        Assert.Equal(new BitArray([true, true, true, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            SELECT e."Bits" | e."NullableBits" AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 32
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_Xor_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 40, BitString = "10100", Bits = new BitArray([true, false, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([true, true, false, false, true]);
        var expected = new BitArray([false, true, true, false, true]);
        var entity = context.Entities.Where(e => e.Id == 40).Single(e => e.Bits.Xor(otherBits) == expected);

        Assert.Equal(40, entity.Id);
        AssertSql(
            """
            otherBits='?'
            expected='?'

            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE e."Id" = 40 AND xor(e."Bits", $otherBits) = $expected
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_project_Xor_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 41, BitString = "1100", Bits = new BitArray([true, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var otherBits = new BitArray([false, true, true, false]);
        var result = context.Entities
            .Where(e => e.Id == 41)
            .Select(e => new
            {
                Result = e.Bits.Xor(otherBits)
            })
            .Single();

        Assert.Equal(new BitArray([true, false, true, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            otherBits='?'

            SELECT xor(e."Bits", $otherBits) AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 41
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_Xor_between_columns_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity
        {
            Id = 42,
            BitString = "1010",
            Bits = new BitArray([true, false, true, false]),
            NullableBits = new BitArray([false, true, true, false])
        });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var result = context.Entities
            .Where(e => e.Id == 42)
            .Select(e => new
            {
                Result = e.Bits.Xor(e.NullableBits!)
            })
            .Single();

        Assert.Equal(new BitArray([true, true, false, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            SELECT xor(e."Bits", e."NullableBits") AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 42
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_translate_Not_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 50, BitString = "10100", Bits = new BitArray([true, false, true, false, false]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var expected = new BitArray([false, true, false, true, true]);
        var entity = context.Entities.Where(e => e.Id == 50).Single(e => e.Bits.Not() == expected);

        Assert.Equal(50, entity.Id);
        AssertSql(
            """
            expected='?'

            SELECT e."Id", e."BitString", e."Bits", e."NullableBits"
            FROM "Entities" AS e
            WHERE e."Id" = 50 AND ~e."Bits" = $expected
            LIMIT 2
            """
        );
    }

    [ConditionalFact]
    public void Can_project_Not_for_BitArray()
    {
        using var context = CreateContext();

        context.Entities.Add(new BitStringEntity { Id = 51, BitString = "101", Bits = new BitArray([true, false, true]) });
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var result = context.Entities
            .Where(e => e.Id == 51)
            .Select(e => new
            {
                Result = e.Bits.Not()
            })
            .Single();

        Assert.Equal(new BitArray([false, true, false]).Cast<bool>(), result.Result.Cast<bool>());
        AssertSql(
            """
            SELECT ~e."Bits" AS "Result"
            FROM "Entities" AS e
            WHERE e."Id" = 51
            LIMIT 2
            """
        );
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

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
