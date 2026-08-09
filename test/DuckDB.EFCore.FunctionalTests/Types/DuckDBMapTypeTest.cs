using DuckDB.EFCore.Extensions;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Types;

public class DuckDBMapTypeTest : IClassFixture<DuckDBMapTypeTest.MapFixture>
{
    public DuckDBMapTypeTest(MapFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    private MapFixture Fixture { get; }

    [ConditionalFact]
    public void Map_columns_are_created_with_MAP_store_type()
    {
        using var context = CreateContext();

        var entityType = context.Model.FindEntityType(typeof(MapEntity))!;

        Assert.Equal(
            "MAP(VARCHAR, INTEGER)",
            entityType.FindProperty(nameof(MapEntity.Counters))!.GetColumnType());
        Assert.Equal(
            "MAP(VARCHAR, VARCHAR)",
            entityType.FindProperty(nameof(MapEntity.Labels))!.GetColumnType());
        Assert.Equal(
            "MAP(INTEGER, DOUBLE)",
            entityType.FindProperty(nameof(MapEntity.Measurements))!.GetColumnType());
    }

    [ConditionalFact]
    public void Can_round_trip_map()
    {
        using var context = CreateContext();

        var entity1 = NewEntity(1, new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 });
        entity1.Labels = new Dictionary<string, string> { ["x"] = "one" };
        entity1.Measurements = new Dictionary<int, double> { [7] = 1.5 };

        context.Entities.Add(entity1);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 1);

        Assert.Equal(new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 }, entity.Counters);
        Assert.Equal(new Dictionary<string, string> { ["x"] = "one" }, entity.Labels);
        Assert.Equal(new Dictionary<int, double> { [7] = 1.5 }, entity.Measurements);
    }

    [ConditionalFact]
    public void Can_round_trip_empty_map()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(2, new Dictionary<string, int>()));
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 2);

        Assert.Empty(entity.Counters);
    }

    [ConditionalFact]
    public void Can_round_trip_null_map()
    {
        using var context = CreateContext();

        var entity = NewEntity(3, new Dictionary<string, int> { ["a"] = 1 });
        entity.OptionalCounters = null;
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        Assert.Null(context.Entities.Single(e => e.Id == 3).OptionalCounters);
    }

    [ConditionalFact]
    public void Can_round_trip_map_with_null_values()
    {
        using var context = CreateContext();

        context.Entities.Add(
            NewEntity(4, new Dictionary<string, int> { ["a"] = 1 }, new Dictionary<string, int?> { ["a"] = null, ["b"] = 2 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var entity = context.Entities.Single(e => e.Id == 4);

        Assert.Equal(new Dictionary<string, int?> { ["a"] = null, ["b"] = 2 }, entity.NullableValues);
    }

    [ConditionalFact]
    public void Can_round_trip_keys_and_values_needing_escaping()
    {
        using var context = CreateContext();

        var labels = new Dictionary<string, string>
        {
            ["a'b"] = "c'd",
            ["with, comma"] = "with = equals",
            [@"back\slash"] = "{braces}",
            ["empty"] = ""
        };

        var entity = NewEntity(5, new Dictionary<string, int> { ["a"] = 1 });
        entity.Labels = labels;
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        Assert.Equal(labels, context.Entities.Single(e => e.Id == 5).Labels);
    }

    [ConditionalFact]
    public void Can_update_map()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(6, new Dictionary<string, int> { ["a"] = 1 }));
        context.SaveChanges();

        var tracked = context.Entities.Single(e => e.Id == 6);
        tracked.Counters["b"] = 2;
        context.SaveChanges();
        context.ChangeTracker.Clear();

        Assert.Equal(new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 }, context.Entities.Single(e => e.Id == 6).Counters);
    }

    [ConditionalFact]
    public void Mutating_a_map_is_detected_by_change_tracking()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(7, new Dictionary<string, int> { ["a"] = 1 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var tracked = context.Entities.Single(e => e.Id == 7);
        tracked.Counters["a"] = 99;

        context.ChangeTracker.DetectChanges();

        Assert.Equal(EntityState.Modified, context.Entry(tracked).State);
    }

    [ConditionalFact]
    public void Can_filter_by_map_parameter()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(8, new Dictionary<string, int> { ["k"] = 5 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var filter = new Dictionary<string, int> { ["k"] = 5 };
        var entity = context.Entities.Single(e => e.Counters == filter);

        Assert.Equal(8, entity.Id);
    }

    [ConditionalFact]
    public void Generates_map_sql_literal()
    {
        using var context = CreateContext();

        var typeMapping = context.Model
            .FindEntityType(typeof(MapEntity))!
            .FindProperty(nameof(MapEntity.Counters))!
            .GetRelationalTypeMapping();

        Assert.Equal(
            "MAP {'a': 1, 'b''s': 2}::MAP(VARCHAR, INTEGER)",
            typeMapping.GenerateSqlLiteral(new Dictionary<string, int> { ["a"] = 1, ["b's"] = 2 }));

        Assert.Equal("MAP {}::MAP(VARCHAR, INTEGER)", typeMapping.GenerateSqlLiteral(new Dictionary<string, int>()));
        Assert.Equal("NULL", typeMapping.GenerateSqlLiteral(null));
    }

    [ConditionalFact]
    public void Generated_map_sql_literal_is_valid_duckdb_sql()
    {
        using var context = CreateContext();

        var typeMapping = context.Model
            .FindEntityType(typeof(MapEntity))!
            .FindProperty(nameof(MapEntity.Counters))!
            .GetRelationalTypeMapping();

        var expected = new Dictionary<string, int> { ["a"] = 1, ["b's"] = 2, [@"c\d"] = 3 };

        using var command = Fixture.Connection.CreateCommand();
        command.CommandText = "SELECT " + typeMapping.GenerateSqlLiteral(expected);

        using var reader = command.ExecuteReader();

        Assert.True(reader.Read());
        Assert.Equal(expected, reader.GetFieldValue<Dictionary<string, int>>(0));
    }

    [ConditionalFact]
    public void Explicit_store_type_is_used_for_map()
    {
        using var context = CreateContext();

        var entityType = context.Model.FindEntityType(typeof(MapEntity))!;

        Assert.Equal(
            "MAP(VARCHAR, BIGINT)",
            entityType.FindProperty(nameof(MapEntity.ExplicitlyTyped))!.GetColumnType());
    }

    [ConditionalFact]
    public void Can_round_trip_map_with_explicit_store_type()
    {
        using var context = CreateContext();

        var entity = NewEntity(9, new Dictionary<string, int> { ["a"] = 1 });
        entity.ExplicitlyTyped = new Dictionary<string, long> { ["big"] = 9_000_000_000L };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        Assert.Equal(
            new Dictionary<string, long> { ["big"] = 9_000_000_000L },
            context.Entities.Single(e => e.Id == 9).ExplicitlyTyped);
    }

    [ConditionalFact]
    public void Can_round_trip_map_with_non_string_element_types()
    {
        using var context = CreateContext();

        var timestamps = new Dictionary<Guid, DateTime>
        {
            [new Guid("11111111-1111-1111-1111-111111111111")] = new DateTime(2024, 5, 17, 13, 45, 30, DateTimeKind.Unspecified)
        };
        var flags = new Dictionary<string, bool> { ["on"] = true, ["off"] = false };
        var amounts = new Dictionary<string, decimal> { ["total"] = 12.34m };

        var entity = NewEntity(10, new Dictionary<string, int> { ["a"] = 1 });
        entity.Timestamps = timestamps;
        entity.Flags = flags;
        entity.Amounts = amounts;
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        var loaded = context.Entities.Single(e => e.Id == 10);

        Assert.Equal(timestamps, loaded.Timestamps);
        Assert.Equal(flags, loaded.Flags);
        Assert.Equal(amounts, loaded.Amounts);
    }

    private static MapEntity NewEntity(
        int id,
        Dictionary<string, int> counters,
        Dictionary<string, int?>? nullableValues = null)
        => new()
        {
            Id = id,
            Counters = counters,
            Labels = new Dictionary<string, string>(),
            Measurements = new Dictionary<int, double>(),
            OptionalCounters = new Dictionary<string, int>(),
            NullableValues = nullableValues ?? new Dictionary<string, int?>(),
            ExplicitlyTyped = new Dictionary<string, long>(),
            Timestamps = new Dictionary<Guid, DateTime>(),
            Flags = new Dictionary<string, bool>(),
            Amounts = new Dictionary<string, decimal>()
        };

    private MapContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MapContext>()
            .UseInternalServiceProvider(Fixture.ServiceProvider)
            .UseDuckDB(Fixture.Connection)
            .Options;

        var context = new MapContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    private sealed class MapContext(DbContextOptions<MapContext> options) : DbContext(options)
    {
        public DbSet<MapEntity> Entities => Set<MapEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MapEntity>(b =>
            {
                b.Property(e => e.Id).ValueGeneratedNever();
                b.Property(e => e.ExplicitlyTyped).HasColumnType("MAP(VARCHAR, BIGINT)");
            });
        }
    }

    private sealed class MapEntity
    {
        public int Id { get; set; }
        public Dictionary<string, int> Counters { get; set; } = null!;
        public Dictionary<string, string> Labels { get; set; } = null!;
        public Dictionary<int, double> Measurements { get; set; } = null!;
        public Dictionary<string, int>? OptionalCounters { get; set; }
        public Dictionary<string, int?> NullableValues { get; set; } = null!;
        public Dictionary<string, long> ExplicitlyTyped { get; set; } = null!;
        public Dictionary<Guid, DateTime> Timestamps { get; set; } = null!;
        public Dictionary<string, bool> Flags { get; set; } = null!;
        public Dictionary<string, decimal> Amounts { get; set; } = null!;
    }

    public sealed class MapFixture : ServiceProviderFixtureBase, ITestSqlLoggerFactory, IDisposable
    {
        public MapFixture()
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
