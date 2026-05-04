using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class SpatialQueryDuckDBTest : SpatialQueryRelationalTestBase<SpatialQueryDuckDBFixture>
{
    public SpatialQueryDuckDBTest(SpatialQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Area(bool async)
    {
        return base.Area(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AsBinary(bool async)
    {
        return base.AsBinary(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AsBinary_with_null_check(bool async)
    {
        return base.AsBinary_with_null_check(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AsText(bool async)
    {
        return base.AsText(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Boundary(bool async)
    {
        return base.Boundary(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Buffer(bool async)
    {
        return base.Buffer(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Buffer_quadrantSegments(bool async)
    {
        return base.Buffer_quadrantSegments(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Centroid(bool async)
    {
        return base.Centroid(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Combine_aggregate(bool async)
    {
        return base.Combine_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Contains(bool async)
    {
        return base.Contains(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ConvexHull(bool async)
    {
        return base.ConvexHull(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ConvexHull_aggregate(bool async)
    {
        return base.ConvexHull_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task CoveredBy(bool async)
    {
        return base.CoveredBy(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Covers(bool async)
    {
        return base.Covers(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Crosses(bool async)
    {
        return base.Crosses(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Difference(bool async)
    {
        return base.Difference(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Dimension(bool async)
    {
        return base.Dimension(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Disjoint_with_cast_to_nullable(bool async)
    {
        return base.Disjoint_with_cast_to_nullable(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Disjoint_with_null_check(bool async)
    {
        return base.Disjoint_with_null_check(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_constant(bool async)
    {
        return base.Distance_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_constant_lhs(bool async)
    {
        return base.Distance_constant_lhs(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_constant_srid_4326(bool async)
    {
        return base.Distance_constant_srid_4326(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_geometry(bool async)
    {
        return base.Distance_geometry(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_on_converted_geometry_type(bool async)
    {
        return base.Distance_on_converted_geometry_type(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_on_converted_geometry_type_constant(bool async)
    {
        return base.Distance_on_converted_geometry_type_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_on_converted_geometry_type_constant_lhs(bool async)
    {
        return base.Distance_on_converted_geometry_type_constant_lhs(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_on_converted_geometry_type_lhs(bool async)
    {
        return base.Distance_on_converted_geometry_type_lhs(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_with_cast_to_nullable(bool async)
    {
        return base.Distance_with_cast_to_nullable(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distance_with_null_check(bool async)
    {
        return base.Distance_with_null_check(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task EndPoint(bool async)
    {
        return base.EndPoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Envelope(bool async)
    {
        return base.Envelope(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task EnvelopeCombine_aggregate(bool async)
    {
        return base.EnvelopeCombine_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task EqualsTopologically(bool async)
    {
        return base.EqualsTopologically(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ExteriorRing(bool async)
    {
        return base.ExteriorRing(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GeometryType(bool async)
    {
        return base.GeometryType(async);
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
    public override Task GetInteriorRingN(bool async)
    {
        return base.GetInteriorRingN(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GetPointN(bool async)
    {
        return base.GetPointN(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ICurve_IsClosed(bool async)
    {
        return base.ICurve_IsClosed(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IGeometryCollection_Count(bool async)
    {
        return base.IGeometryCollection_Count(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IMultiCurve_IsClosed(bool async)
    {
        return base.IMultiCurve_IsClosed(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task InteriorPoint(bool async)
    {
        return base.InteriorPoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intersection(bool async)
    {
        return base.Intersection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intersects(bool async)
    {
        return base.Intersects(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsEmpty(bool async)
    {
        return base.IsEmpty(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsEmpty_equal_to_null(bool async)
    {
        return base.IsEmpty_equal_to_null(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsEmpty_not_equal_to_null(bool async)
    {
        return base.IsEmpty_not_equal_to_null(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsRing(bool async)
    {
        return base.IsRing(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsSimple(bool async)
    {
        return base.IsSimple(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsValid(bool async)
    {
        return base.IsValid(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task IsWithinDistance(bool async)
    {
        return base.IsWithinDistance(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Item(bool async)
    {
        return base.Item(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Length(bool async)
    {
        return base.Length(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task LineString_Count(bool async)
    {
        return base.LineString_Count(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task M(bool async)
    {
        return base.M(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Normalized(bool async)
    {
        return base.Normalized(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NumGeometries(bool async)
    {
        return base.NumGeometries(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intersects_equal_to_null(bool async)
    {
        return base.Intersects_equal_to_null(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intersects_not_equal_to_null(bool async)
    {
        return base.Intersects_not_equal_to_null(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NumInteriorRings(bool async)
    {
        return base.NumInteriorRings(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task NumPoints(bool async)
    {
        return base.NumPoints(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task OgcGeometryType(bool async)
    {
        return base.OgcGeometryType(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Overlaps(bool async)
    {
        return base.Overlaps(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task PointOnSurface(bool async)
    {
        return base.PointOnSurface(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Relate(bool async)
    {
        return base.Relate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Reverse(bool async)
    {
        return base.Reverse(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SimpleSelect(bool async)
    {
        return base.SimpleSelect(async);
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
    public override Task SymmetricDifference(bool async)
    {
        return base.SymmetricDifference(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToBinary(bool async)
    {
        return base.ToBinary(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ToText(bool async)
    {
        return base.ToText(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Touches(bool async)
    {
        return base.Touches(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Union(bool async)
    {
        return base.Union(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Union_aggregate(bool async)
    {
        return base.Union_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Union_void(bool async)
    {
        return base.Union_void(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task WithConversion(bool async)
    {
        return base.WithConversion(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Within(bool async)
    {
        return base.Within(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task X(bool async)
    {
        return base.X(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task XY_with_collection_join(bool async)
    {
        return base.XY_with_collection_join(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Y(bool async)
    {
        return base.Y(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Z(bool async)
    {
        return base.Z(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task StartPoint(bool async)
    {
        return base.StartPoint(async);
    }
}