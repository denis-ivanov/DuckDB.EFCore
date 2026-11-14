using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.NTS.Extensions;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class BadDataJsonDeserializationDuckDBTest : BadDataJsonDeserializationTestBase
{
    [
        Theory(Skip = DuckDBSkipReasons.Tbd),
        InlineData("""{"Prop":[-128,[0,127]]}"""),
        InlineData("""{"Prop":[-128,{"P":127}]}"""),
        InlineData("""{"Prop":[-128,],23]}"""),
        InlineData("""{"Prop":[-128,},23]}"""),
        InlineData("""{"Prop":[-128,,23]}""")
    ]
    public override void Throws_for_bad_collection_of_nullable_long_JSON_values(string json)
    {
        base.Throws_for_bad_collection_of_nullable_long_JSON_values(json);
    }

    [
        Theory(Skip = DuckDBSkipReasons.Tbd),
        InlineData("""{"Prop":[-128,[0,127]]}"""),
        InlineData("""{"Prop":[-128,{"P":127}]}"""),
        InlineData("""{"Prop":[-128,],23]}"""),
        InlineData("""{"Prop":[-128,},23]}"""),
        InlineData("""{"Prop":[-128,,23]}""")]
    public override void Throws_for_bad_collection_of_sbyte_JSON_values(string json)
    {
        base.Throws_for_bad_collection_of_sbyte_JSON_values(json);
    }

    [
        Theory(Skip = DuckDBSkipReasons.Tbd),
        InlineData("""{"Prop"}"""),
        InlineData("""{"Prop"}:127}"""),
        InlineData("""{"Prop":"X"}"""),
        InlineData("""{"Prop":}""")
    ]
    public override void Throws_for_bad_nullable_long_JSON_values(string json)
    {
        base.Throws_for_bad_nullable_long_JSON_values(json);
    }

    [
        Theory(Skip = DuckDBSkipReasons.Tbd),
        InlineData("""{"Prop":{"type""Point","coordinates":[2.0,4.0]}}"""),
        InlineData("""{"Prop":{"type":["Point","coordinates":[2.0,4.0]}}"""),
        InlineData("""{"Prop":{"type":"Point","coordinates":[2.0,,4.0]}}"""),
        InlineData("""{"Prop":[{"type":"Point","coordinates":[2.0,4.0]}]}"""),
        InlineData("""{"Prop":1}"""),
        InlineData("""{"Prop":true}"""),
        InlineData("""{"Prop":false}"""),
        InlineData("""{"Prop":"X"}""")
    ]
    public override void Throws_for_bad_point_as_GeoJson(string json)
    {
        base.Throws_for_bad_point_as_GeoJson(json);
    }

    [
        Theory(Skip = DuckDBSkipReasons.Tbd),
        InlineData("""{"Prop"}"""),
        InlineData("""{"Prop"}:127}"""),
        InlineData("""{"Prop":"X"}"""),
        InlineData("""{"Prop":}""")
    ]
    public override void Throws_for_bad_sbyte_JSON_values(string json)
    {
        base.Throws_for_bad_sbyte_JSON_values(json);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(optionsBuilder.UseDuckDB(b => b.UseNetTopologySuite()));
}
