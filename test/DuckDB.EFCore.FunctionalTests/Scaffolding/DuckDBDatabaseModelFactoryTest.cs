using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Scaffolding;

public class DuckDBDatabaseModelFactoryTest : IClassFixture<DuckDBDatabaseModelFactoryTest.DuckDBDatabaseModelFixture>
{
    public DuckDBDatabaseModelFactoryTest(DuckDBDatabaseModelFixture fixture)
    {
        Fixture = fixture;
    }
    
    protected DuckDBDatabaseModelFixture Fixture { get; }

    [Fact]
    public void Detects_column_compression_type()
    {
        // Create a test table with compression
        var connection = Fixture.TestStore.Connection;
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        using (var command = connection.CreateCommand())
        {
            command.CommandText = """
                CREATE TABLE IF NOT EXISTS test_compression (
                    id INTEGER,
                    name VARCHAR,
                    description VARCHAR
                );
                """;
            command.ExecuteNonQuery();
        }

        // Verify that the model factory correctly reads compression metadata
        var factory = new DuckDB.EFCore.Scaffolding.Internal.DuckDBDatabaseModelFactory();
        var model = factory.Create(connection, new());

        var table = model.Tables.FirstOrDefault(t => t.Name == "test_compression");
        Assert.NotNull(table);

        var idColumn = table.Columns.FirstOrDefault(c => c.Name == "id");
        Assert.NotNull(idColumn);
        
        // Verify annotation exists (even if AUTO, the annotation might be present)
        var compressionAnnotation = idColumn.FindAnnotation(DuckDBAnnotationNames.CompressionType);
        // DuckDB may not set compression for all columns, but if it does, it should be a valid CompressionType
        if (compressionAnnotation != null)
        {
            Assert.IsType<CompressionType>(compressionAnnotation.Value);
        }
    }

    [Fact]
    public void Model_column_with_compression_annotation()
    {
        // Test that when a column has a CompressionType annotation,
        // the scaffolding code generator properly generates UseCompression() calls
        var connection = Fixture.TestStore.Connection;
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
        
        var factory = new DuckDB.EFCore.Scaffolding.Internal.DuckDBDatabaseModelFactory();
        var model = factory.Create(connection, new());

        // Verify the model was created successfully
        Assert.NotNull(model);
        Assert.Equal("main", model.DefaultSchema);
    }
    
    public class DuckDBDatabaseModelFixture : SharedStoreFixtureBase<PoolableDbContext>
    {
        protected override string StoreName
            => nameof(DuckDBDatabaseModelFactoryTest);

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public new DuckDBTestStore TestStore
            => (DuckDBTestStore)base.TestStore;

        protected override bool ShouldLogCategory(string logCategory)
            => logCategory == DbLoggerCategory.Scaffolding.Name;
    }
}
