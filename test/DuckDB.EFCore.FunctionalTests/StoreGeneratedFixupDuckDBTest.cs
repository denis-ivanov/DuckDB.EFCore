using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class StoreGeneratedFixupDuckDBTest : StoreGeneratedFixupRelationalTestBase<
    StoreGeneratedFixupDuckDBTest.StoreGeneratedFixupDuckDBFixture>
{
    public StoreGeneratedFixupDuckDBTest(StoreGeneratedFixupDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_set_both_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_not_set_both_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_set_both_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_not_set_both_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_many_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_many_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_many_no_navs_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_many_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_many_no_navs_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_many_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_set_both_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_not_set_both_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_set_both_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_not_set_both_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_then_principal_one_to_one_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_then_dependent_one_to_one_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_then_principal_one_to_one_no_navs_FK_set_no_navs_set()
    {
        await base.Add_dependent_then_principal_one_to_one_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_then_dependent_one_to_one_no_navs_FK_set_no_navs_set()
    {
        await base.Add_principal_then_dependent_one_to_one_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_set_both_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_not_set_both_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_set_both_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_not_set_both_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_many_no_navs_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_many_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_many_no_navs_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_many_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_set_both_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_not_set_both_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_set_both_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_not_set_both_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_not_set_both_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_prin_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_prin_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_prin_uni_FK_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_prin_uni_FK_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_prin_uni_FK_not_set_principal_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_prin_uni_FK_not_set_principal_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_dep_uni_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_dep_uni_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_dep_uni_FK_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_dep_uni_FK_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_dep_uni_FK_not_set_dependent_nav_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_dep_uni_FK_not_set_dependent_nav_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_dependent_but_not_principal_one_to_one_no_navs_FK_set_no_navs_set()
    {
        await base.Add_dependent_but_not_principal_one_to_one_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_principal_but_not_dependent_one_to_one_no_navs_FK_set_no_navs_set()
    {
        await base.Add_principal_but_not_dependent_one_to_one_no_navs_FK_set_no_navs_set();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_overlapping_graph_from_level()
    {
        await base.Add_overlapping_graph_from_level();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_overlapping_graph_from_game()
    {
        await base.Add_overlapping_graph_from_game();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Add_overlapping_graph_from_item()
    {
        await base.Add_overlapping_graph_from_item();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Temporary_value_equals_database_generated_value()
    {
        base.Temporary_value_equals_database_generated_value();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Remove_overlapping_principal()
    {
        base.Remove_overlapping_principal();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Multi_level_add_replace_and_save()
    {
        await base.Multi_level_add_replace_and_save();
    }

    protected override bool EnforcesFKs
        => true;

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class StoreGeneratedFixupDuckDBFixture : StoreGeneratedFixupRelationalFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
