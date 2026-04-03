using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class MusicStoreDuckDBTest : MusicStoreTestBase<MusicStoreDuckDBTest.MusicStoreDuckDBFixture>
{
    public MusicStoreDuckDBTest(MusicStoreDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AddressAndPayment_RedirectToCompleteWhenSuccessful()
    {
        await base.AddressAndPayment_RedirectToCompleteWhenSuccessful();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Browse_ReturnsViewWithGenre()
    {
        await base.Browse_ReturnsViewWithGenre();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_add_items_to_cart()
    {
        await base.Can_add_items_to_cart();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Cart_has_items_once_they_have_been_added()
    {
        await base.Cart_has_items_once_they_have_been_added();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task CartSummaryComponent_returns_items()
    {
        await base.CartSummaryComponent_returns_items();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Complete_ReturnsErrorIfInvalidOrder()
    {
        await base.Complete_ReturnsErrorIfInvalidOrder();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Details_ReturnsAlbumDetail()
    {
        await base.Details_ReturnsAlbumDetail();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Complete_ReturnsOrderIdIfValid()
    {
        await base.Complete_ReturnsOrderIdIfValid();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task GenreMenuComponent_Returns_NineGenres()
    {
        await base.GenreMenuComponent_Returns_NineGenres();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Index_CreatesViewWithGenres()
    {
        await base.Index_CreatesViewWithGenres();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Index_GetsSixTopAlbums()
    {
        await base.Index_GetsSixTopAlbums();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Music_store_project_to_mapped_entity()
    {
        await base.Music_store_project_to_mapped_entity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task RemoveFromCart_removes_items_from_cart()
    {
        await base.RemoveFromCart_removes_items_from_cart();
    }

    public class MusicStoreDuckDBFixture : MusicStoreFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
