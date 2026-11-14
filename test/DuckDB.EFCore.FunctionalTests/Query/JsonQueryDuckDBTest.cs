using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class JsonQueryDuckDBTest : JsonQueryRelationalTestBase<JsonQueryDuckDBFixture>
{
    public JsonQueryDuckDBTest(JsonQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(true)]
    [InlineData(false)]
    public override async Task Bad_json_properties_null_navigations(bool noTracking)
    {
        await base.Bad_json_properties_null_navigations(noTracking);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Entity_splitting_with_owned_json()
    {
        await base.Entity_splitting_with_owned_json();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Filter_on_complex_json_collection_on_entity_mapped_to_view()
    {
        await base.Filter_on_complex_json_collection_on_entity_mapped_to_view();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task HasJsonPropertyName()
    {
        await base.HasJsonPropertyName();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Project_entity_with_optional_json_entity_owned_by_required_json()
    {
        await base.Project_entity_with_optional_json_entity_owned_by_required_json();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_missing_required_navigation(bool async)
    {
        await base.Project_missing_required_navigation(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), InlineData(true), InlineData(false)]
    public override async Task Bad_json_properties_duplicated_navigations(bool noTracking)
    {
        await base.Bad_json_properties_duplicated_navigations(noTracking);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), InlineData(true), InlineData(false)]
    public override async Task Bad_json_properties_duplicated_scalars(bool noTracking)
    {
        await base.Bad_json_properties_duplicated_scalars(noTracking);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), InlineData(true), InlineData(false)]
    public override async Task Bad_json_properties_empty_navigations(bool noTracking)
    {
        await base.Bad_json_properties_empty_navigations(noTracking);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), InlineData(true), InlineData(false)]
    public override async Task Bad_json_properties_empty_scalars(bool noTracking)
    {
        await base.Bad_json_properties_empty_scalars(noTracking);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), InlineData(true), InlineData(false)]
    public override async Task Bad_json_properties_null_scalars(bool noTracking)
    {
        await base.Bad_json_properties_null_scalars(noTracking);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Custom_naming_projection_everything(bool async)
    {
        await base.Custom_naming_projection_everything(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Custom_naming_projection_owned_scalar(bool async)
    {
        await base.Custom_naming_projection_owned_scalar(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_all_types_entity_projection(bool async)
    {
        await base.Json_all_types_entity_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_all_types_projection_individual_properties(bool async)
    {
        await base.Json_all_types_projection_individual_properties(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_boolean_predicate(bool async)
    {
        await base.Json_boolean_predicate(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_boolean_predicate_negated(bool async)
    {
        await base.Json_boolean_predicate_negated(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_filter_in_projection(bool async)
    {
        await base.Json_collection_filter_in_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_in_projection_with_anonymous_projection_of_scalars(bool async)
    {
        await base.Json_collection_in_projection_with_anonymous_projection_of_scalars(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_index_in_projection_using_untranslatable_client_method(bool async)
    {
        await base.Json_collection_index_in_projection_using_untranslatable_client_method(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_index_in_projection_using_untranslatable_client_method2(bool async)
    {
        await base.Json_collection_index_in_projection_using_untranslatable_client_method2(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_leaf_filter_in_projection(bool async)
    {
        await base.Json_collection_leaf_filter_in_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_skip_take_in_projection(bool async)
    {
        await base.Json_collection_skip_take_in_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_skip_take_in_projection_project_into_anonymous_type(bool async)
    {
        await base.Json_collection_skip_take_in_projection_project_into_anonymous_type(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(bool async)
    {
        await base.Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_multiple_collection_projections(bool async)
    {
        await base.Json_multiple_collection_projections(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_nested_collection_anonymous_projection_in_projection(bool async)
    {
        await base.Json_nested_collection_anonymous_projection_in_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(async);
    }

    protected override async Task Seed30028(DbContext ctx)
    {
        // complete
        await ctx.Database.ExecuteSqlAsync(
            $$$$"""
                INSERT INTO "Entities" ("Id", "Json")
                VALUES(
                1,
                '{"RootName":"e1","Collection":[{"BranchName":"e1 c1","Nested":{"LeafName":"e1 c1 l"}},{"BranchName":"e1 c2","Nested":{"LeafName":"e1 c2 l"}}],"OptionalReference":{"BranchName":"e1 or","Nested":{"LeafName":"e1 or l"}},"RequiredReference":{"BranchName":"e1 rr","Nested":{"LeafName":"e1 rr l"}}}')
                """);

        // missing collection
        await ctx.Database.ExecuteSqlAsync(
            $$$$"""
                INSERT INTO "Entities" ("Id", "Json")
                VALUES(
                2,
                '{"RootName":"e2","OptionalReference":{"BranchName":"e2 or","Nested":{"LeafName":"e2 or l"}},"RequiredReference":{"BranchName":"e2 rr","Nested":{"LeafName":"e2 rr l"}}}')
                """);

        // missing optional reference
        await ctx.Database.ExecuteSqlAsync(
            $$$$"""
                INSERT INTO "Entities" ("Id", "Json")
                VALUES(
                3,
                '{"RootName":"e3","Collection":[{"BranchName":"e3 c1","Nested":{"LeafName":"e3 c1 l"}},{"BranchName":"e3 c2","Nested":{"LeafName":"e3 c2 l"}}],"RequiredReference":{"BranchName":"e3 rr","Nested":{"LeafName":"e3 rr l"}}}')
                """);

        // missing required reference
        await ctx.Database.ExecuteSqlAsync(
            $$$$"""
                INSERT INTO "Entities" ("Id", "Json")
                VALUES(
                4,
                '{"RootName":"e4","Collection":[{"BranchName":"e4 c1","Nested":{"LeafName":"e4 c1 l"}},{"BranchName":"e4 c2","Nested":{"LeafName":"e4 c2 l"}}],"OptionalReference":{"BranchName":"e4 or","Nested":{"LeafName":"e4 or l"}}}')
                """);
    }

    protected override async Task Seed33046(DbContext ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$"""
              INSERT INTO "Reviews" ("Rounds", "Id")
              VALUES('[{"RoundNumber":11,"SubRounds":[{"SubRoundNumber":111},{"SubRoundNumber":112}]}]', 1)
              """);
    }

    protected override async Task SeedJunkInJson(DbContext ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$$"""
               INSERT INTO "Entities" ("Collection", "CollectionWithCtor", "Reference", "ReferenceWithCtor", "Id")
               VALUES(
               '[{"JunkReference":{"Something":"SomeValue" },"Name":"c11","JunkProperty1":50,"Number":11.5,"JunkCollection1":[],"JunkCollection2":[{"Foo":"junk value"}],"NestedCollection":[{"DoB":"2002-04-01T00:00:00","DummyProp":"Dummy value"},{"DoB":"2002-04-02T00:00:00","DummyReference":{"Foo":5}}],"NestedReference":{"DoB":"2002-03-01T00:00:00"}},{"Name":"c12","Number":12.5,"NestedCollection":[{"DoB":"2002-06-01T00:00:00"},{"DoB":"2002-06-02T00:00:00"}],"NestedDummy":59,"NestedReference":{"DoB":"2002-05-01T00:00:00"}}]',
               '[{"MyBool":true,"Name":"c11 ctor","JunkReference":{"Something":"SomeValue","JunkCollection":[{"Foo":"junk value"}]},"NestedCollection":[{"DoB":"2002-08-01T00:00:00"},{"DoB":"2002-08-02T00:00:00"}],"NestedReference":{"DoB":"2002-07-01T00:00:00"}},{"MyBool":false,"Name":"c12 ctor","NestedCollection":[{"DoB":"2002-10-01T00:00:00"},{"DoB":"2002-10-02T00:00:00"}],"JunkCollection":[{"Foo":"junk value"}],"NestedReference":{"DoB":"2002-09-01T00:00:00"}}]',
               '{"Name":"r1","JunkCollection":[{"Foo":"junk value"}],"JunkReference":{"Something":"SomeValue" },"Number":1.5,"NestedCollection":[{"DoB":"2000-02-01T00:00:00","JunkReference":{"Something":"SomeValue"}},{"DoB":"2000-02-02T00:00:00"}],"NestedReference":{"DoB":"2000-01-01T00:00:00"}}',
               '{"MyBool":true,"JunkCollection":[{"Foo":"junk value"}],"Name":"r1 ctor","JunkReference":{"Something":"SomeValue" },"NestedCollection":[{"DoB":"2001-02-01T00:00:00"},{"DoB":"2001-02-02T00:00:00"}],"NestedReference":{"JunkCollection":[{"Foo":"junk value"}],"DoB":"2001-01-01T00:00:00"}}',
               1)
               """);
    }

    protected override async Task SeedTrickyBuffering(DbContext ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$$"""
               INSERT INTO "Entities" ("Reference", "Id")
               VALUES(
               '{"Name": "r1", "Number": 7, "JunkReference":{"Something": "SomeValue" }, "JunkCollection": [{"Foo": "junk value"}], "NestedReference": {"DoB": "2000-01-01T00:00:00"}, "NestedCollection": [{"DoB": "2000-02-01T00:00:00", "JunkReference": {"Something": "SomeValue"}}, {"DoB": "2000-02-02T00:00:00"}]}',1)
               """);
    }

    protected override async Task SeedShadowProperties(DbContext ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$"""
              INSERT INTO "Entities" ("Collection", "CollectionWithCtor", "Reference", "ReferenceWithCtor", "Id", "Name")
              VALUES(
              '[{"Name":"e1_c1","ShadowDouble":5.5},{"ShadowDouble":20.5,"Name":"e1_c2"}]',
              '[{"Name":"e1_c1 ctor","ShadowNullableByte":6},{"ShadowNullableByte":null,"Name":"e1_c2 ctor"}]',
              '{"Name":"e1_r", "ShadowString":"Foo"}',
              '{"ShadowInt":143,"Name":"e1_r ctor"}',
              1,
              'e1')
              """);
    }

    protected override async Task SeedNotICollection(DbContext ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$"""
              INSERT INTO "Entities" ("Json", "Id")
              VALUES(
              '{"Collection":[{"Bar":11,"Foo":"c11"},{"Bar":12,"Foo":"c12"},{"Bar":13,"Foo":"c13"}]}',
              1)
              """);

        await ctx.Database.ExecuteSqlAsync(
            $$"""
              INSERT INTO "Entities" ("Json", "Id")
              VALUES(
              '{"Collection":[{"Bar":21,"Foo":"c21"},{"Bar":22,"Foo":"c22"}]}',
              2)
              """);
    }

    protected override async Task SeedBadJsonProperties(ContextBadJsonProperties ctx)
    {
        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
1,
'baseline',
'{"NestedOptional": { "Text":"or no" }, "NestedRequired": { "Text":"or nr" }, "NestedCollection": [ { "Text":"or nc 1" }, { "Text":"or nc 2" } ] }',
'{"NestedOptional": { "Text":"rr no" }, "NestedRequired": { "Text":"rr nr" }, "NestedCollection": [ { "Text":"rr nc 1" }, { "Text":"rr nc 2" } ] }',
'[
{"NestedOptional": { "Text":"c 1 no" }, "NestedRequired": { "Text":"c 1 nr" }, "NestedCollection": [ { "Text":"c 1 nc 1" }, { "Text":"c 1 nc 2" } ] },
{"NestedOptional": { "Text":"c 2 no" }, "NestedRequired": { "Text":"c 2 nr" }, "NestedCollection": [ { "Text":"c 2 nc 1" }, { "Text":"c 2 nc 2" } ] }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
2,
'duplicated navigations',
'{"NestedOptional": { "Text":"or no" }, "NestedOptional": { "Text":"or no dupnav" }, "NestedRequired": { "Text":"or nr" }, "NestedCollection": [ { "Text":"or nc 1" }, { "Text":"or nc 2" } ], "NestedCollection": [ { "Text":"or nc 1 dupnav" }, { "Text":"or nc 2 dupnav" } ], "NestedRequired": { "Text":"or nr dupnav" } }',
'{"NestedOptional": { "Text":"rr no" }, "NestedOptional": { "Text":"rr no dupnav" }, "NestedRequired": { "Text":"rr nr" }, "NestedCollection": [ { "Text":"rr nc 1" }, { "Text":"rr nc 2" } ], "NestedCollection": [ { "Text":"rr nc 1 dupnav" }, { "Text":"rr nc 2 dupnav" } ], "NestedRequired": { "Text":"rr nr dupnav" } }',
'[
{"NestedOptional": { "Text":"c 1 no" }, "NestedOptional": { "Text":"c 1 no dupnav" }, "NestedRequired": { "Text":"c 1 nr" }, "NestedCollection": [ { "Text":"c 1 nc 1" }, { "Text":"c 1 nc 2" } ], "NestedCollection": [ { "Text":"c 1 nc 1 dupnav" }, { "Text":"c 1 nc 2 dupnav" } ], "NestedRequired": { "Text":"c 1 nr dupnav" } },
{"NestedOptional": { "Text":"c 2 no" }, "NestedOptional": { "Text":"c 2 no dupnav" }, "NestedRequired": { "Text":"c 2 nr" }, "NestedCollection": [ { "Text":"c 2 nc 1" }, { "Text":"c 2 nc 2" } ], "NestedCollection": [ { "Text":"c 2 nc 1 dupnav" }, { "Text":"c 2 nc 2 dupnav" } ], "NestedRequired": { "Text":"c 2 nr dupnav" } }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
3,
'duplicated scalars',
'{"NestedOptional": { "Text":"or no", "Text":"or no dupprop" }, "NestedRequired": { "Text":"or nr", "Text":"or nr dupprop" }, "NestedCollection": [ { "Text":"or nc 1", "Text":"or nc 1 dupprop" }, { "Text":"or nc 2", "Text":"or nc 2 dupprop" } ] }',
'{"NestedOptional": { "Text":"rr no", "Text":"rr no dupprop" }, "NestedRequired": { "Text":"rr nr", "Text":"rr nr dupprop" }, "NestedCollection": [ { "Text":"rr nc 1", "Text":"rr nc 1 dupprop" }, { "Text":"rr nc 2", "Text":"rr nc 2 dupprop" } ] }',
'[
{"NestedOptional": { "Text":"c 1 no", "Text":"c 1 no dupprop" }, "NestedRequired": { "Text":"c 1 nr", "Text":"c 1 nr dupprop" }, "NestedCollection": [ { "Text":"c 1 nc 1", "Text":"c 1 nc 1 dupprop" }, { "Text":"c 1 nc 2", "Text":"c 1 nc 2 dupprop" } ] },
{"NestedOptional": { "Text":"c 2 no", "Text":"c 2 no dupprop" }, "NestedRequired": { "Text":"c 2 nr", "Text":"c 2 nr dupprop" }, "NestedCollection": [ { "Text":"c 2 nc 1", "Text":"c 2 nc 1 dupprop" }, { "Text":"c 2 nc 2", "Text":"c 2 nc 2 dupprop" } ] }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
4,
'empty navigation property names',
'{"": { "Text":"or no" }, "": { "Text":"or nr" }, "": [ { "Text":"or nc 1" }, { "Text":"or nc 2" } ] }',
'{"": { "Text":"rr no" }, "": { "Text":"rr nr" }, "": [ { "Text":"rr nc 1" }, { "Text":"rr nc 2" } ] }',
'[
{"": { "Text":"c 1 no" }, "": { "Text":"c 1 nr" }, "": [ { "Text":"c 1 nc 1" }, { "Text":"c 1 nc 2" } ] },
{"": { "Text":"c 2 no" }, "": { "Text":"c 2 nr" }, "": [ { "Text":"c 2 nc 1" }, { "Text":"c 2 nc 2" } ] }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
5,
'empty scalar property names',
'{"NestedOptional": { "":"or no" }, "NestedRequired": { "":"or nr" }, "NestedCollection": [ { "":"or nc 1" }, { "":"or nc 2" } ] }',
'{"NestedOptional": { "":"rr no" }, "NestedRequired": { "":"rr nr" }, "NestedCollection": [ { "":"rr nc 1" }, { "":"rr nc 2" } ] }',
'[
{"NestedOptional": { "":"c 1 no" }, "NestedRequired": { "":"c 1 nr" }, "NestedCollection": [ { "":"c 1 nc 1" }, { "":"c 1 nc 2" } ] },
{"NestedOptional": { "":"c 2 no" }, "NestedRequired": { "":"c 2 nr" }, "NestedCollection": [ { "":"c 2 nc 1" }, { "":"c 2 nc 2" } ] }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
10,
'null navigation property names',
'{null: { "Text":"or no" }, null: { "Text":"or nr" }, null: [ { "Text":"or nc 1" }, { "Text":"or nc 2" } ] }',
'{null: { "Text":"rr no" }, null: { "Text":"rr nr" }, null: [ { "Text":"rr nc 1" }, { "Text":"rr nc 2" } ] }',
'[
{null: { "Text":"c 1 no" }, null: { "Text":"c 1 nr" }, null: [ { "Text":"c 1 nc 1" }, { "Text":"c 1 nc 2" } ] },
{null: { "Text":"c 2 no" }, null: { "Text":"c 2 nr" }, null: [ { "Text":"c 2 nc 1" }, { "Text":"c 2 nc 2" } ] }
]')
""");

        await ctx.Database.ExecuteSqlAsync(
            $$"""
INSERT INTO Entities (Id, Scenario, OptionalReference, RequiredReference, Collection)
VALUES(
11,
'null scalar property names',
'{"NestedOptional": { null:"or no", "Text":"or no nonnull" }, "NestedRequired": { null:"or nr", "Text":"or nr nonnull" }, "NestedCollection": [ { null:"or nc 1", "Text":"or nc 1 nonnull" }, { null:"or nc 2", "Text":"or nc 2 nonnull" } ] }',
'{"NestedOptional": { null:"rr no", "Text":"rr no nonnull" }, "NestedRequired": { null:"rr nr", "Text":"rr nr nonnull" }, "NestedCollection": [ { null:"rr nc 1", "Text":"rr nc 1 nonnull" }, { null:"rr nc 2", "Text":"rr nc 2 nonnull" } ] }',
'[
{"NestedOptional": { null:"c 1 no", "Text":"c 1 no nonnull" }, "NestedRequired": { null:"c 1 nr", "Text":"c 1 nr nonnull" }, "NestedCollection": [ { null:"c 1 nc 1", "Text":"c 1 nc 1 nonnull" }, { null:"c 1 nc 2", "Text":"c 1 nc 2 nonnull" } ] },
{"NestedOptional": { null:"c 2 no", "Text":"c 2 no nonnull" }, "NestedRequired": { null:"c 2 nr", "Text":"c 2 nr nonnull" }, "NestedCollection": [ { null:"c 2 nc 1", "Text":"c 2 nc 1 nonnull" }, { null:"c 2 nc 2", "Text":"c 2 nc 2 nonnull" } ] }
]')
""");
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_nested_collection_filter_in_projection(bool async)
    {
        await base.Json_nested_collection_filter_in_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_bool_converted_to_string_True_False(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_string_True_False(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_byte(bool async)
    {
        await base.Json_predicate_on_byte(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_byte_array(bool async)
    {
        await base.Json_predicate_on_byte_array(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_character(bool async)
    {
        await base.Json_predicate_on_character(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_dateonly(bool async)
    {
        await base.Json_predicate_on_dateonly(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_datetime(bool async)
    {
        await base.Json_predicate_on_datetime(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_datetimeoffset(bool async)
    {
        await base.Json_predicate_on_datetimeoffset(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_decimal(bool async)
    {
        await base.Json_predicate_on_decimal(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_default_string(bool async)
    {
        await base.Json_predicate_on_default_string(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_double(bool async)
    {
        await base.Json_predicate_on_double(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_enum(bool async)
    {
        await base.Json_predicate_on_enum(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_enumwithintconverter(bool async)
    {
        await base.Json_predicate_on_enumwithintconverter(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_guid(bool async)
    {
        await base.Json_predicate_on_guid(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_int16(bool async)
    {
        await base.Json_predicate_on_int16(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_int32(bool async)
    {
        await base.Json_predicate_on_int32(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_int64(bool async)
    {
        await base.Json_predicate_on_int64(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_max_length_string(bool async)
    {
        await base.Json_predicate_on_max_length_string(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableenum1(bool async)
    {
        await base.Json_predicate_on_nullableenum1(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableenum2(bool async)
    {
        await base.Json_predicate_on_nullableenum2(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableenumwithconverter1(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverter1(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableenumwithconverter2(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverter2(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableenumwithconverterthathandlesnulls1(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverterthathandlesnulls1(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableint321(bool async)
    {
        await base.Json_predicate_on_nullableint321(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_nullableint322(bool async)
    {
        await base.Json_predicate_on_nullableint322(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_signedbyte(bool async)
    {
        await base.Json_predicate_on_signedbyte(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_single(bool async)
    {
        await base.Json_predicate_on_single(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_string_condition(bool async)
    {
        await base.Json_predicate_on_string_condition(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_timeonly(bool async)
    {
        await base.Json_predicate_on_timeonly(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_timespan(bool async)
    {
        await base.Json_predicate_on_timespan(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_unisgnedint16(bool async)
    {
        await base.Json_predicate_on_unisgnedint16(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_unsignedint32(bool async)
    {
        await base.Json_predicate_on_unsignedint32(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_predicate_on_unsignedint64(bool async)
    {
        await base.Json_predicate_on_unsignedint64(async);
    }

    public override async Task Json_scalar_length(bool async)
    {
        await base.Json_scalar_length(async);

        AssertSql(
            """
            SELECT j."Name"
            FROM "JsonEntitiesBasic" AS j
            WHERE length(j."OwnedReferenceRoot" ->> 'Name') > 2
            """);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_null_required_navigation(bool async)
    {
        await base.Project_null_required_navigation(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_top_level_entity_with_null_value_required_scalars(bool async)
    {
        await base.Project_top_level_entity_with_null_value_required_scalars(async);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Try_project_collection_but_JSON_is_entity()
    {
        await base.Try_project_collection_but_JSON_is_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Try_project_reference_but_JSON_is_collection()
    {
        await base.Try_project_reference_but_JSON_is_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_project_nullable_json_property_when_the_element_in_json_is_not_present()
    {
        await base.Can_project_nullable_json_property_when_the_element_in_json_is_not_present();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_json_properties_materialized_as_null_when_the_element_in_json_is_not_present()
    {
        await base.Optional_json_properties_materialized_as_null_when_the_element_in_json_is_not_present();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_missing_required_scalar(bool async)
    {
        await base.Project_missing_required_scalar(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_nested_json_entity_with_missing_scalars(bool async)
    {
        await base.Project_nested_json_entity_with_missing_scalars(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_null_required_scalar(bool async)
    {
        await base.Project_null_required_scalar(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_root_entity_with_missing_required_navigation(bool async)
    {
        await base.Project_root_entity_with_missing_required_navigation(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_root_entity_with_null_required_navigation(bool async)
    {
        await base.Project_root_entity_with_null_required_navigation(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_root_with_missing_scalars(bool async)
    {
        await base.Project_root_with_missing_scalars(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Project_top_level_json_entity_with_missing_scalars(bool async)
    {
        await base.Project_top_level_json_entity_with_missing_scalars(async);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
