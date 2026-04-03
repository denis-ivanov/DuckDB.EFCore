using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class ConferencePlannerDuckDBTest : ConferencePlannerTestBase<ConferencePlannerDuckDBTest.ConferencePlannerDuckDBFixture>
{
    public ConferencePlannerDuckDBTest(ConferencePlannerDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_AddSession()
    {
        await base.AttendeesController_AddSession();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_AddSession_bad_attendee()
    {
        await base.AttendeesController_AddSession_bad_attendee();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_AddSession_bad_session()
    {
        await base.AttendeesController_AddSession_bad_session();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_Get()
    {
        await base.AttendeesController_Get();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_GetSessions()
    {
        await base.AttendeesController_GetSessions();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_Post_with_existing_attendee()
    {
        await base.AttendeesController_Post_with_existing_attendee();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_Post_with_new_attendee()
    {
        await base.AttendeesController_Post_with_new_attendee();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_RemoveSession()
    {
        await base.AttendeesController_RemoveSession();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_RemoveSession_bad_attendee()
    {
        await base.AttendeesController_RemoveSession_bad_attendee();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task AttendeesController_RemoveSession_bad_session()
    {
        await base.AttendeesController_RemoveSession_bad_session();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SearchController_Search(string searchTerm, int totalCount, int sessionCount)
    {
        await base.SearchController_Search(searchTerm, totalCount, sessionCount);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Delete()
    {
        await base.SessionsController_Delete();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Delete_with_bad_ID()
    {
        await base.SessionsController_Delete_with_bad_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Get()
    {
        await base.SessionsController_Get();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Get_with_bad_ID()
    {
        await base.SessionsController_Get_with_bad_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Get_with_ID()
    {
        await base.SessionsController_Get_with_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Post()
    {
        await base.SessionsController_Post();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Put()
    {
        await base.SessionsController_Put();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SessionsController_Put_with_bad_ID()
    {
        await base.SessionsController_Put_with_bad_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SpeakersController_GetSpeaker_with_bad_ID()
    {
        await base.SpeakersController_GetSpeaker_with_bad_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SpeakersController_GetSpeaker_with_ID()
    {
        await base.SpeakersController_GetSpeaker_with_ID();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SpeakersController_GetSpeakers()
    {
        await base.SpeakersController_GetSpeakers();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class ConferencePlannerDuckDBFixture : ConferencePlannerFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
