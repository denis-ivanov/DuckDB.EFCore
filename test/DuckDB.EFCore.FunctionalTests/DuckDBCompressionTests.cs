using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Integration tests for USING COMPRESSION feature
/// </summary>
public class DuckDBCompressionTests : IClassFixture<DuckDBCompressionTests.CompressionTestFixture>
{
    public DuckDBCompressionTests(CompressionTestFixture fixture)
    {
        Fixture = fixture;
    }

    protected CompressionTestFixture Fixture { get; }

    [Fact]
    public void Can_create_model_with_compression_configured()
    {
        var modelBuilder = new ModelBuilder(new ConventionSet());
        
        var entityBuilder = modelBuilder.Entity("Employee");
        entityBuilder.Property<int>("Id").ValueGeneratedOnAdd();
        entityBuilder.Property<string>("Name").UseCompression(CompressionType.DICTIONARY);
        entityBuilder.Property<string>("Description").UseCompression(CompressionType.FSST);
        entityBuilder.Property<decimal>("Salary").UseCompression(CompressionType.ALP);
        
        entityBuilder.HasKey("Id");

        var model = modelBuilder.Model;
        var entity = model.FindEntityType("Employee");
        
        Assert.NotNull(entity);
        
        var nameProperty = entity.FindProperty("Name");
        Assert.NotNull(nameProperty);
        Assert.Equal(CompressionType.DICTIONARY, nameProperty.GetCompressionType());

        var descriptionProperty = entity.FindProperty("Description");
        Assert.NotNull(descriptionProperty);
        Assert.Equal(CompressionType.FSST, descriptionProperty.GetCompressionType());

        var salaryProperty = entity.FindProperty("Salary");
        Assert.NotNull(salaryProperty);
        Assert.Equal(CompressionType.ALP, salaryProperty.GetCompressionType());
    }

    [Fact]
    public void UseCompression_returns_property_builder_for_method_chaining()
    {
        var modelBuilder = new ModelBuilder(new ConventionSet());
        
        var entityBuilder = modelBuilder.Entity("Employee");
        var propertyBuilder = entityBuilder.Property<string>("Name");
        
        var result = propertyBuilder.UseCompression(CompressionType.DICTIONARY);
        
        // Should return the same property builder for chaining
        Assert.Same(propertyBuilder, result);
    }

    [Theory]
    [InlineData(CompressionType.AUTO)]
    [InlineData(CompressionType.UNCOMPRESSED)]
    [InlineData(CompressionType.CONSTANT)]
    [InlineData(CompressionType.RLE)]
    [InlineData(CompressionType.DICTIONARY)]
    [InlineData(CompressionType.PFOR_DELTA)]
    [InlineData(CompressionType.BITPACKING)]
    [InlineData(CompressionType.FSST)]
    [InlineData(CompressionType.CHIMP)]
    [InlineData(CompressionType.PATAS)]
    [InlineData(CompressionType.ALP)]
    [InlineData(CompressionType.ALPRD)]
    [InlineData(CompressionType.ZSDT)]
    [InlineData(CompressionType.ROARING)]
    [InlineData(CompressionType.EMPTY)]
    [InlineData(CompressionType.DICT_FSST)]
    public void Can_set_all_compression_types(CompressionType compressionType)
    {
        var modelBuilder = new ModelBuilder(new ConventionSet());
        
        var entityBuilder = modelBuilder.Entity("TestEntity");
        entityBuilder.Property<int>("Id").ValueGeneratedOnAdd();
        entityBuilder.Property<string>("Data").UseCompression(compressionType);
        entityBuilder.HasKey("Id");

        var model = modelBuilder.Model;
        var entity = model.FindEntityType("TestEntity");
        var property = entity.FindProperty("Data");
        
        Assert.Equal(compressionType, property.GetCompressionType());
    }

    [Fact]
    public void Compression_type_persists_through_model_metadata()
    {
        var modelBuilder = new ModelBuilder(new ConventionSet());
        
        var entityBuilder = modelBuilder.Entity("Product");
        entityBuilder.Property<int>("Id").ValueGeneratedOnAdd();
        entityBuilder.Property<string>("Name").UseCompression(CompressionType.DICTIONARY);
        entityBuilder.HasKey("Id");

        var model = modelBuilder.Model;
        var productEntity = model.FindEntityType("Product");
        var nameProperty = productEntity.FindProperty("Name");
        
        // Get the annotation and verify it persists
        var annotation = nameProperty.GetAnnotation(DuckDBAnnotationNames.CompressionType);
        Assert.NotNull(annotation);
        Assert.Equal(CompressionType.DICTIONARY, (CompressionType)annotation.Value!);
    }

    [Fact]
    public void Property_with_no_compression_type_returns_null()
    {
        var modelBuilder = new ModelBuilder(new ConventionSet());
        
        var entityBuilder = modelBuilder.Entity("Customer");
        entityBuilder.Property<int>("Id").ValueGeneratedOnAdd();
        entityBuilder.Property<string>("Name"); // No compression specified
        entityBuilder.HasKey("Id");

        var model = modelBuilder.Model;
        var entity = model.FindEntityType("Customer");
        var property = entity.FindProperty("Name");
        
        var compressionType = property.GetCompressionType();
        
        // Should return null or default when not set
        Assert.Null(compressionType);
    }

    public class CompressionTestFixture : SharedStoreFixtureBase<PoolableDbContext>
    {
        protected override string StoreName
            => nameof(DuckDBCompressionTests);

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public new DuckDBTestStore TestStore
            => (DuckDBTestStore)base.TestStore;
    }
}

