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

    [ConditionalFact]
    public void Can_filter_by_map_count()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(11, new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 }));
        context.Entities.Add(NewEntity(12, new Dictionary<string, int> { ["a"] = 1 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entities = context.Entities.Where(e => e.Counters.Count == 2).ToList();

        Assert.Single(entities);
        Assert.Equal(11, entities[0].Id);

        AssertSql(
            """
            SELECT e."Id", e."Amounts", e."Counters", e."ExplicitlyTyped", e."Flags", e."Labels", e."Measurements", e."NullableValues", e."OptionalCounters", e."Timestamps"
            FROM "Entities" AS e
            WHERE cardinality(e."Counters") = 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_count()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(13, new Dictionary<string, int> { ["x"] = 10, ["y"] = 20, ["z"] = 30 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var count = context.Entities.Where(e => e.Id == 13).Select(e => e.Counters.Count).Single();

        Assert.Equal(3, count);

        AssertSql(
            """
            SELECT cardinality(e."Counters")
            FROM "Entities" AS e
            WHERE e."Id" = 13
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_filter_by_map_contains_key()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(14, new Dictionary<string, int> { ["target_filter"] = 100 }));
        context.Entities.Add(NewEntity(15, new Dictionary<string, int> { ["other"] = 200 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entities = context.Entities.Where(e => e.Counters.ContainsKey("target_filter")).ToList();

        Assert.Single(entities);
        Assert.Equal(14, entities[0].Id);

        AssertSql(
            """
            SELECT e."Id", e."Amounts", e."Counters", e."ExplicitlyTyped", e."Flags", e."Labels", e."Measurements", e."NullableValues", e."OptionalCounters", e."Timestamps"
            FROM "Entities" AS e
            WHERE map_contains(e."Counters", 'target_filter')
            """);
    }

    [ConditionalFact]
    public void Can_project_map_contains_key()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(16, new Dictionary<string, int> { ["target_project"] = 100 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var contains = context.Entities.Where(e => e.Id == 16).Select(e => e.Counters.ContainsKey("target_project")).Single();

        Assert.True(contains);

        AssertSql(
            """
            SELECT map_contains(e."Counters", 'target_project')
            FROM "Entities" AS e
            WHERE e."Id" = 16
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_filter_by_map_contains_value()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(17, new Dictionary<string, int> { ["k1"] = 555 }));
        context.Entities.Add(NewEntity(18, new Dictionary<string, int> { ["k2"] = 777 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entities = context.Entities.Where(e => e.Counters.ContainsValue(555)).ToList();

        Assert.Single(entities);
        Assert.Equal(17, entities[0].Id);

        AssertSql(
            """
            SELECT e."Id", e."Amounts", e."Counters", e."ExplicitlyTyped", e."Flags", e."Labels", e."Measurements", e."NullableValues", e."OptionalCounters", e."Timestamps"
            FROM "Entities" AS e
            WHERE map_contains_value(e."Counters", 555)
            """);
    }

    [ConditionalFact]
    public void Can_project_map_contains_value()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(19, new Dictionary<string, int> { ["k1"] = 888 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var contains = context.Entities.Where(e => e.Id == 19).Select(e => e.Counters.ContainsValue(888)).Single();

        Assert.True(contains);

        AssertSql(
            """
            SELECT map_contains_value(e."Counters", 888)
            FROM "Entities" AS e
            WHERE e."Id" = 19
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_filter_by_map_indexer()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(20, new Dictionary<string, int> { ["k1"] = 42, ["k2"] = 99 }));
        context.Entities.Add(NewEntity(21, new Dictionary<string, int> { ["k1"] = 100 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var entities = context.Entities.Where(e => e.Counters["k1"] == 42).ToList();

        Assert.Single(entities);
        Assert.Equal(20, entities[0].Id);

        AssertSql(
            """
            SELECT e."Id", e."Amounts", e."Counters", e."ExplicitlyTyped", e."Flags", e."Labels", e."Measurements", e."NullableValues", e."OptionalCounters", e."Timestamps"
            FROM "Entities" AS e
            WHERE map_extract_value(e."Counters", 'k1') = 42
            """);
    }

    [ConditionalFact]
    public void Can_project_map_indexer()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(22, new Dictionary<string, int> { ["my_key"] = 321 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var val = context.Entities.Where(e => e.Id == 22).Select(e => e.Counters["my_key"]).Single();

        Assert.Equal(321, val);

        AssertSql(
            """
            SELECT map_extract_value(e."Counters", 'my_key')
            FROM "Entities" AS e
            WHERE e."Id" = 22
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_filter_and_project_map_indexer_non_string_key()
    {
        using var context = CreateContext();

        var entity = NewEntity(23, new Dictionary<string, int>());
        entity.Measurements = new Dictionary<int, double> { [10] = 3.14, [20] = 2.71 };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var val = context.Entities.Where(e => e.Measurements[10] > 3.0).Select(e => e.Measurements[10]).Single();

        Assert.Equal(3.14, val);

        AssertSql(
            """
            SELECT map_extract_value(e."Measurements", 10)
            FROM "Entities" AS e
            WHERE map_extract_value(e."Measurements", 10) > 3.0
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_keys_to_array()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(24, new Dictionary<string, int> { ["k1"] = 1, ["k2"] = 2, ["k3"] = 3 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var keys = context.Entities.Where(e => e.Id == 24).Select(e => e.Counters.Keys.ToArray()).Single();

        Assert.Equal(["k1", "k2", "k3"], keys);

        AssertSql(
            """
            SELECT map_keys(e."Counters")
            FROM "Entities" AS e
            WHERE e."Id" = 24
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_keys_to_list()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(25, new Dictionary<string, int> { ["k1"] = 10 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var keys = context.Entities.Where(e => e.Id == 25).Select(e => e.Counters.Keys.ToList()).Single();

        Assert.Equal(new List<string> { "k1" }, keys);

        AssertSql(
            """
            SELECT map_keys(e."Counters")
            FROM "Entities" AS e
            WHERE e."Id" = 25
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_keys_to_array_non_string()
    {
        using var context = CreateContext();

        var entity = NewEntity(26, new Dictionary<string, int>());
        entity.Measurements = new Dictionary<int, double> { [100] = 3.14, [200] = 2.71 };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var keys = context.Entities.Where(e => e.Id == 26).Select(e => e.Measurements.Keys.ToArray()).Single();

        Assert.Equal([100, 200], keys);

        AssertSql(
            """
            SELECT map_keys(e."Measurements")
            FROM "Entities" AS e
            WHERE e."Id" = 26
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_keys_to_list_non_string()
    {
        using var context = CreateContext();

        var entity = NewEntity(27, new Dictionary<string, int>());
        entity.Measurements = new Dictionary<int, double> { [300] = 1.11, [400] = 2.22 };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var keys = context.Entities.Where(e => e.Id == 27).Select(e => e.Measurements.Keys.ToList()).Single();

        Assert.Equal(new List<int> { 300, 400 }, keys);

        AssertSql(
            """
            SELECT map_keys(e."Measurements")
            FROM "Entities" AS e
            WHERE e."Id" = 27
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_values_to_array()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(28, new Dictionary<string, int> { ["k1"] = 1, ["k2"] = 2, ["k3"] = 3 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var values = context.Entities.Where(e => e.Id == 28).Select(e => e.Counters.Values.ToArray()).Single();

        Assert.Equal([1, 2, 3], values);

        AssertSql(
            """
            SELECT map_values(e."Counters")
            FROM "Entities" AS e
            WHERE e."Id" = 28
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_values_to_list()
    {
        using var context = CreateContext();

        context.Entities.Add(NewEntity(29, new Dictionary<string, int> { ["k1"] = 10 }));
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var values = context.Entities.Where(e => e.Id == 29).Select(e => e.Counters.Values.ToList()).Single();

        Assert.Equal(new List<int> { 10 }, values);

        AssertSql(
            """
            SELECT map_values(e."Counters")
            FROM "Entities" AS e
            WHERE e."Id" = 29
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_values_to_array_non_string()
    {
        using var context = CreateContext();

        var entity = NewEntity(30, new Dictionary<string, int>());
        entity.Measurements = new Dictionary<int, double> { [100] = 3.14, [200] = 2.71 };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var values = context.Entities.Where(e => e.Id == 30).Select(e => e.Measurements.Values.ToArray()).Single();

        Assert.Equal([3.14, 2.71], values);

        AssertSql(
            """
            SELECT map_values(e."Measurements")
            FROM "Entities" AS e
            WHERE e."Id" = 30
            LIMIT 2
            """);
    }

    [ConditionalFact]
    public void Can_project_map_values_to_list_non_string()
    {
        using var context = CreateContext();

        var entity = NewEntity(31, new Dictionary<string, int>());
        entity.Measurements = new Dictionary<int, double> { [300] = 1.11, [400] = 2.22 };
        context.Entities.Add(entity);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        Fixture.TestSqlLoggerFactory.Clear();

        var values = context.Entities.Where(e => e.Id == 31).Select(e => e.Measurements.Values.ToList()).Single();

        Assert.Equal(new List<double> { 1.11, 2.22 }, values);

        AssertSql(
            """
            SELECT map_values(e."Measurements")
            FROM "Entities" AS e
            WHERE e."Id" = 31
            LIMIT 2
            """);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

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
