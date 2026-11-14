using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Scaffolding;

public class CompiledModelDuckDBTest : CompiledModelRelationalTestBase
{
    public CompiledModelDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Owned_entity_sharing_table_with_owner_that_has_an_index()
    {
        await base.Owned_entity_sharing_table_with_owner_that_has_an_index();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task BigModel_with_JSON_columns()
    {
        return base.BigModel_with_JSON_columns();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task CheckConstraints()
    {
        return base.CheckConstraints();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ComplexTypes()
    {
        return base.ComplexTypes();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Custom_function_parameter_type_mapping()
    {
        return base.Custom_function_parameter_type_mapping();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Custom_function_type_mapping()
    {
        return base.Custom_function_type_mapping();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DbFunctions()
    {
        return base.DbFunctions();
    }

    [Fact(Skip = "Stored procedures are not supported in DuckDB")]
    public override Task Tpc_Sprocs()
    {
        return base.Tpc_Sprocs();
    }

    [Fact(Skip = "duckdb_triggers function available only in v2")]
    public override Task Triggers()
    {
        return base.Triggers();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task BigModel()
    {
        return base.BigModel();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task No_NativeAOT()
    {
        return base.No_NativeAOT();
    }

    protected override BuildSource AddReferences(BuildSource build, string filePath = "")
    {
        base.AddReferences(build, filePath);
        build.References.Add(BuildReference.ByName("DuckDB.EFCore"));
        build.References.Add(BuildReference.ByName("DuckDB.EFCore.NTS"));
        return build;
    }

    protected override TestHelpers TestHelpers
        => DuckDBTestHelpers.Instance;

    protected override ITestStoreFactory NonSharedTestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
