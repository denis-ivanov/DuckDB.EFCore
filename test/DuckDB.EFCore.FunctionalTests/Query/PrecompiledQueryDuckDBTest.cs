using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class PrecompiledQueryDuckDBTest : PrecompiledQueryRelationalTestBase, IClassFixture<PrecompiledQueryDuckDBTest.PrecompiledQueryDuckDBFixture>
{
    public PrecompiledQueryDuckDBTest(PrecompiledQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    public class PrecompiledQueryDuckDBFixture : PrecompiledQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override async Task SeedAsync(PrecompiledQueryContext context)
        {
            var blog1 = new Blog { Id = 8, Name = "Blog1", Json = [] };
            var blog2 = new Blog
            {
                Id = 9,
                Name = "Blog2",
                Json =
                [
                    new JsonRoot { Number = 1, Text = "One", Inner = new JsonBranch { Date = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc) } },
                    new JsonRoot { Number = 2, Text = "Two", Inner = new JsonBranch { Date = new DateTime(2002, 2, 2, 0, 0, 0, DateTimeKind.Utc) } },
                ]
            };

            context.Blogs.AddRange(blog1, blog2);

            var post11 = new Post { Id = 11, Title = "Post11", Blog = blog1 };
            var post12 = new Post { Id = 12, Title = "Post12", Blog = blog1 };
            var post21 = new Post { Id = 21, Title = "Post21", Blog = blog2 };
            var post22 = new Post { Id = 22, Title = "Post22", Blog = blog2 };
            var post23 = new Post { Id = 23, Title = "Post23", Blog = blog2 };

            context.Posts.AddRange(post11, post12, post21, post22, post23);

            // Native arrays use SQL NULL rather than the JSON null token seeded by the base fixture.
            context.EntitiesWithPrimitiveCollection.AddRange(
                new EntityWithPrimitiveCollection { Id = 1, Tags = ["a", "b"] },
                new EntityWithPrimitiveCollection { Id = 2, Tags = null });

            await context.SaveChangesAsync();
        }

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => DuckDBPrecompiledQueryTestHelpers.Instance;
    }
}
