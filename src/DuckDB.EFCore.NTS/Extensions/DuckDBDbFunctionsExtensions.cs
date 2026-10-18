using Microsoft.EntityFrameworkCore.Diagnostics;
using NetTopologySuite.Geometries;
using System.Text.Json;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class DuckDBDbFunctionsExtensions
{
    /// <summary>
    /// Applies an affine transformation to a geometry.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <param name="e"></param>
    /// <param name="f"></param>
    /// <param name="g"></param>
    /// <param name="h"></param>
    /// <param name="i"></param>
    /// <param name="xoff"></param>
    /// <param name="yoff"></param>
    /// <param name="zoff"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Geometry? Affine(
        this DbFunctions _,
        Geometry? geometry,
        double a,
        double b,
        double c,
        double d,
        double e,
        double f,
        double g,
        double h,
        double i,
        double xoff,
        double yoff,
        double zoff)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Affine)));

    /// <summary>
    /// Applies an affine transformation to a geometry.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="d"></param>
    /// <param name="e"></param>
    /// <param name="xoff"></param>
    /// <param name="yoff"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Geometry? Affine(
        this DbFunctions _,
        Geometry? geometry,
        double a,
        double b,
        double d,
        double e,
        double xoff,
        double yoff)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Affine)));

    /// <summary>
    /// Returns the area of a geometry in meters, using an ellipsoidal model of the earth
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? AreaSpheroid(this DbFunctions _, Geometry? geometry)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AreaSpheroid)));

    /// <summary>
    /// Returns the area of a geometry in meters, using an ellipsoidal model of the earth
    /// </summary>
    /// <param name="_"></param>
    /// <param name="polygon"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? AreaSpheroid(this DbFunctions _, Polygon? polygon)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AreaSpheroid)));

    /// <summary>
    /// Returns the geometry as a GeoJSON fragment.
    ///
    /// This does not return a complete GeoJSON document, only the geometry fragment. To construct a complete
    /// GeoJSON document or feature, look into using the DuckDB JSON extension in conjunction with this function.
    /// This function supports geometries with Z values, but not M values. M values are ignored.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static JsonElement? AsGeoJson(this DbFunctions _, Geometry? geometry)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsGeoJson)));

    /// <summary>
    /// Returns the geometry as a HEXWKB string
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string? AsHexWkb(this DbFunctions _, Geometry? geometry)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsHexWkb)));

    /// <summary>
    /// Transform and clip geometry to a tile boundary
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <param name="bounds"></param>
    /// <param name="extent"></param>
    /// <param name="buffer"></param>
    /// <param name="clipGeom"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Geometry? AsMvtGeom(this DbFunctions _, Geometry? geom, Envelope? bounds, long extent, long buffer, bool clipGeom)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsMvtGeom)));

    /// <summary>
    /// Transform and clip geometry to a tile boundary
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <param name="bounds"></param>
    /// <param name="extent"></param>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static Geometry? AsMvtGeom(this DbFunctions _, Geometry? geom, Envelope? bounds, long extent, long buffer)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsMvtGeom)));

    /// <summary>
    /// Transform and clip geometry to a tile boundary
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <param name="bounds"></param>
    /// <param name="extent"></param>
    /// <returns></returns>
    public static Geometry? AsMvtGeom(this DbFunctions _, Geometry? geom, Envelope? bounds, long extent)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsMvtGeom)));

    /// <summary>
    /// Transform and clip geometry to a tile boundary
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static Geometry? AsMvtGeom(this DbFunctions _, Geometry? geom, Envelope? bounds)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsMvtGeom)));

    /// <summary>
    /// Convert the geometry into a SVG fragment or path
    /// The SVG fragment is returned as a string. The fragment is a path element that can be used in an SVG document.
    /// The second boolean argument specifies whether the path should be relative or absolute.
    /// The third argument specifies the maximum number of digits to use for the coordinates.
    /// Points are formatted as cx/cy using absolute coordinates or x/y using relative coordinates.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <param name="relative"></param>
    /// <param name="precision"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string? AsSvg(this DbFunctions _, Geometry? geometry, bool relative, int precision)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AsSvg)));

    /// <summary>
    /// Returns the azimuth (a clockwise angle measured from north) of two points in radian.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? Azimuth(this DbFunctions _, Geometry? origin, Geometry? target)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Azimuth)));

    /// <summary>
    /// Returns the azimuth (a clockwise angle measured from north) of two points in radian.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? Azimuth(this DbFunctions _, Geometry? origin, Point? target)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Azimuth)));

    /// <summary>
    /// Creates a polygonal geometry by attempting to "fill in" the input geometry.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geometry"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Geometry? BuildArea(this DbFunctions _, Geometry? geometry)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BuildArea)));

    /// <summary>
    /// Returns the 'concave' hull of the input geometry, containing all of the source input's points,
    /// and which can be used to create polygons from points. The ratio parameter dictates the level
    /// of concavity; 1.0 returns the convex hull; and 0 indicates to return the most concave hull
    /// possible. Set allowHoles to a non-zero value to allow output containing holes.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <param name="ratio"></param>
    /// <param name="allowHoles"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Geometry? ConcaveHull(this DbFunctions _, Geometry? geom, double ratio, bool allowHoles)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ConcaveHull)));

    /// <summary>
    /// Returns true if the first geometry "properly" contains the second geometry.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom1"></param>
    /// <param name="geom2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool? ContainsProperly(this DbFunctions _, Geometry? geom1, Geometry? geom2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ContainsProperly)));

    /// <summary>
    /// Returns if two POINT_2D's are within a target distance in meters, using an ellipsoidal model of the earths surface
    /// </summary>
    /// <param name="_"></param>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool? DWithinSpheroid(this DbFunctions _, Point? point1, Point? point2, double distance)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DWithinSpheroid)));

    /// <summary>
    /// Returns the planar distance between two geometries.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom1"></param>
    /// <param name="geom2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? DistanceGeos(this DbFunctions _, Geometry? geom1, Geometry? geom2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DistanceGeos)));

    /// <summary>
    /// Returns the planar distance between two geometries
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom1"></param>
    /// <param name="geom2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? DistanceSphere(this DbFunctions _, Geometry? geom1, Geometry? geom2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DistanceSphere)));

    /// <summary>
    /// Returns the planar distance between two points.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? DistanceSphere(this DbFunctions _, Point? point1, Point? point2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DistanceSphere)));

    /// <summary>
    /// Returns the distance between two geometries in meters using an ellipsoidal model of the earths surface
    /// </summary>
    /// <param name="_"></param>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double? DistanceSpheroid(this DbFunctions _, Point? point1, Point? point2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DistanceSpheroid)));

    /// <summary>
    /// Returns the minimal bounding box enclosing the input geometry.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="geom"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Envelope? Extent(this DbFunctions _, Geometry? geom)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Extent)));
}
