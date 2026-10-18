using Microsoft.EntityFrameworkCore.TestModels.SpatialModel;
using NetTopologySuite.Geometries;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class SpatialQueryDuckDBTest : SpatialQueryRelationalTestBase<SpatialQueryDuckDBFixture>
{
    public SpatialQueryDuckDBTest(SpatialQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Affine(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Affine = EF.Functions.Affine(e.Point, 1, 0, 0, 1, 2, 3) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.Affine is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_Affine(p."Point", CAST(1.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(1.0 AS DOUBLE), CAST(2.0 AS DOUBLE), CAST(3.0 AS DOUBLE))) AS "Affine"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Affine_3d(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Affine = EF.Functions.Affine(e.PointZ, 1, 0, 0, 0, 1, 0, 0, 0, 1, 2, 3, 4) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.Affine is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_Affine(p."PointZ", CAST(1.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(1.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(0.0 AS DOUBLE), CAST(1.0 AS DOUBLE), CAST(2.0 AS DOUBLE), CAST(3.0 AS DOUBLE), CAST(4.0 AS DOUBLE))) AS "Affine"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AreaSpheroid_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, Area = EF.Functions.AreaSpheroid((Geometry?)e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.Area is > 0);

        AssertSql(
            """
            SELECT p."Id", ST_Area_Spheroid(CAST(p."Polygon" AS GEOMETRY)) AS "Area"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AreaSpheroid_polygon(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, Area = EF.Functions.AreaSpheroid(e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.Area is > 0);

        AssertSql(
            """
            SELECT p."Id", ST_Area_Spheroid(p."Polygon") AS "Area"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task BuildArea(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, BuildArea = EF.Functions.BuildArea(e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.BuildArea is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_BuildArea(p."Polygon")) AS "BuildArea"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task BuildArea_lineString(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<LineStringEntity>()
            .Select(e => new { e.Id, BuildArea = EF.Functions.BuildArea(e.LineString) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT l."Id", ST_AsWKT(ST_BuildArea(l."LineString")) AS "BuildArea"
            FROM "LineStringEntity" AS l
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task BuildArea_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, BuildArea = EF.Functions.BuildArea((Geometry?)e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.BuildArea is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_BuildArea(CAST(p."Polygon" AS GEOMETRY))) AS "BuildArea"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task ConcaveHull(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, ConcaveHull = EF.Functions.ConcaveHull(e.Polygon, 0.5, true) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.ConcaveHull is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_ConcaveHull(p."Polygon", 0.5, true)) AS "ConcaveHull"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task ConcaveHull_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, ConcaveHull = EF.Functions.ConcaveHull((Geometry?)e.Polygon, 0.5, true) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.ConcaveHull is not null);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_ConcaveHull(CAST(p."Polygon" AS GEOMETRY), 0.5, true)) AS "ConcaveHull"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task ContainsProperly(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, ContainsProperly = EF.Functions.ContainsProperly(e.Polygon, e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_ContainsProperly(p."Polygon", p."Polygon") AS "ContainsProperly"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task ContainsProperly_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PolygonEntity>()
            .Select(e => new { e.Id, ContainsProperly = EF.Functions.ContainsProperly((Geometry?)e.Polygon, (Geometry?)e.Polygon) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_ContainsProperly(CAST(p."Polygon" AS GEOMETRY), CAST(p."Polygon" AS GEOMETRY)) AS "ContainsProperly"
            FROM "PolygonEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DistanceGeos(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Distance = EF.Functions.DistanceGeos(e.Point, e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Distance_GEOS(p."Point", p."Point") AS "Distance"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DistanceGeos_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Distance = EF.Functions.DistanceGeos((Geometry?)e.Point, (Geometry?)e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Distance_GEOS(CAST(p."Point" AS GEOMETRY), CAST(p."Point" AS GEOMETRY)) AS "Distance"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DistanceSphere(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Distance = EF.Functions.DistanceSphere(e.Point, e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Distance_Sphere(p."Point", p."Point") AS "Distance"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DistanceSphere_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Distance = EF.Functions.DistanceSphere((Geometry?)e.Point, (Geometry?)e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Distance_Sphere(CAST(p."Point" AS GEOMETRY), CAST(p."Point" AS GEOMETRY)) AS "Distance"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DistanceSpheroid(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Distance = EF.Functions.DistanceSpheroid(e.Point, e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Distance_Spheroid(p."Point", p."Point") AS "Distance"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Extent(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Extent = EF.Functions.Extent(e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Extent(p."Point") AS "Extent"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Extent_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Extent = EF.Functions.Extent((Geometry?)e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Extent(CAST(p."Point" AS GEOMETRY)) AS "Extent"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AsGeoJson(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, GeoJson = EF.Functions.AsGeoJson(e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(
            results,
            r => r.GeoJson is { ValueKind: JsonValueKind.Object } geoJson
                 && geoJson.GetProperty("type").GetString() == "Point");

        AssertSql(
            """
            SELECT p."Id", ST_AsGeoJSON(p."Point") AS "GeoJson"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AsHexWkb(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, HexWkb = EF.Functions.AsHexWkb(e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.HexWkb is { Length: > 0 } hexWkb && hexWkb.All(char.IsAsciiHexDigit));

        AssertSql(
            """
            SELECT p."Id", ST_AsHEXWKB(p."Point") AS "HexWkb"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AsSvg(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Svg = EF.Functions.AsSvg(e.Point, true, 3) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => !string.IsNullOrWhiteSpace(r.Svg));

        AssertSql(
            """
            SELECT p."Id", ST_AsSVG(p."Point", true, 3) AS "Svg"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Azimuth_geometry(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Azimuth = EF.Functions.Azimuth((Geometry?)e.Point, (Geometry?)e.PointZ) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Azimuth(CAST(p."Point" AS GEOMETRY), CAST(p."PointZ" AS GEOMETRY)) AS "Azimuth"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task Azimuth_point(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, Azimuth = EF.Functions.Azimuth((Geometry?)e.Point, e.Point) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_Azimuth(CAST(p."Point" AS GEOMETRY), p."Point") AS "Azimuth"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task DWithinSpheroid(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, DWithin = EF.Functions.DWithinSpheroid(e.Point, e.Point, 1000.0) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_DWithin_Spheroid(p."Point", p."Point", 1000.0) AS "DWithin"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public async Task AsMvtGeom(bool async)
    {
        using var context = Fixture.CreateContext();

        var query = context.Set<PointEntity>()
            .Select(e => new { e.Id, MvtGeom = EF.Functions.AsMvtGeom(e.Point, null, 4096, 256, true) });

        var results = async
            ? await query.ToListAsync()
            : query.ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT p."Id", ST_AsWKT(ST_AsMVTGeom(p."Point", NULL, 4096, 256, true)) AS "MvtGeom"
            FROM "PointEntity" AS p
            """);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Buffer_quadrantSegments(bool async)
    {
        return base.Buffer_quadrantSegments(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_constant_srid_4326(bool async)
    {
        return base.Distance_constant_srid_4326(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GetGeometryN(bool async)
    {
        return base.GetGeometryN(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GetGeometryN_with_null_argument(bool async)
    {
        return base.GetGeometryN_with_null_argument(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Item(bool async)
    {
        return base.Item(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Relate(bool async)
    {
        return base.Relate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SRID(bool async)
    {
        return base.SRID(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SRID_geometry(bool async)
    {
        return base.SRID_geometry(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Union_void(bool async)
    {
        return base.Union_void(async);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
