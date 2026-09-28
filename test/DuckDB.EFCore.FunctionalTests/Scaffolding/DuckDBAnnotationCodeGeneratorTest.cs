using DuckDB.EFCore.Design.Internal;
using DuckDB.EFCore.Metadata;
using DuckDB.EFCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Scaffolding.Internal;

public class DuckDBAnnotationCodeGeneratorTest
{
    private readonly AnnotationCodeGeneratorDependencies _dependencies;

    public DuckDBAnnotationCodeGeneratorTest()
    {
        var typeMappingSource = DuckDBTestHelpers.Instance.CreateContextServices().GetRequiredService<IRelationalTypeMappingSource>();
        _dependencies = new AnnotationCodeGeneratorDependencies(typeMappingSource);
    }

    [Fact]
    public void GenerateFluentApiCalls_with_compression_type_dictionary()
    {
        var generator = new DuckDBAnnotationCodeGenerator(_dependencies);
        
        var annotations = new Dictionary<string, IAnnotation>
        {
            { 
                DuckDBAnnotationNames.CompressionType,
                new Annotation(DuckDBAnnotationNames.CompressionType, CompressionType.DICTIONARY)
            }
        };

        var property = CreateMockProperty();
        var calls = generator.GenerateFluentApiCalls(property, annotations);

        Assert.NotEmpty(calls);
        var lastCall = calls.Last();
        Assert.NotNull(lastCall);
        // The method should be UseCompression
        Assert.Contains("UseCompression", lastCall.Method);
    }

    [Fact]
    public void GenerateFluentApiCalls_with_compression_type_auto_should_not_generate()
    {
        var generator = new DuckDBAnnotationCodeGenerator(_dependencies);
        
        var annotations = new Dictionary<string, IAnnotation>
        {
            { 
                DuckDBAnnotationNames.CompressionType,
                new Annotation(DuckDBAnnotationNames.CompressionType, CompressionType.AUTO)
            }
        };

        var property = CreateMockProperty();
        var calls = generator.GenerateFluentApiCalls(property, annotations);

        // AUTO is the default, so no call should be generated
        // The annotation should be removed from the dictionary as handled by convention
        Assert.DoesNotContain(calls, c => c.Method.Contains("UseCompression"));
    }

    [Theory]
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
    public void GenerateFluentApiCalls_with_all_compression_types(CompressionType compressionType)
    {
        var generator = new DuckDBAnnotationCodeGenerator(_dependencies);
        
        var annotations = new Dictionary<string, IAnnotation>
        {
            { 
                DuckDBAnnotationNames.CompressionType,
                new Annotation(DuckDBAnnotationNames.CompressionType, compressionType)
            }
        };

        var property = CreateMockProperty();
        var calls = generator.GenerateFluentApiCalls(property, annotations);

        if (compressionType == CompressionType.AUTO)
        {
            // AUTO is handled by convention, no call should be generated
            Assert.DoesNotContain(calls, c => c.Method.Contains("UseCompression"));
        }
        else
        {
            // Non-AUTO compression types should generate UseCompression calls
            Assert.Single(calls);
            Assert.Contains("UseCompression", calls.First().Method);
        }
    }

    [Fact]
    public void IsHandledByConvention_returns_true_for_auto_compression()
    {
        var generator = new TestDuckDBAnnotationCodeGenerator(_dependencies);
        
        var property = CreateMockProperty();
        var annotation = new Annotation(DuckDBAnnotationNames.CompressionType, CompressionType.AUTO);

        var isHandled = generator.IsHandledByConvention(property, annotation);

        Assert.True(isHandled);
    }

    [Fact]
    public void IsHandledByConvention_returns_false_for_non_auto_compression()
    {
        var generator = new TestDuckDBAnnotationCodeGenerator(_dependencies);
        
        var property = CreateMockProperty();
        var annotation = new Annotation(DuckDBAnnotationNames.CompressionType, CompressionType.DICTIONARY);

        var isHandled = generator.IsHandledByConvention(property, annotation);

        Assert.False(isHandled);
    }

    private IProperty CreateMockProperty()
    {
        var builder = DuckDBTestHelpers.Instance.CreateConventionBuilder();
        var entityBuilder = builder.Entity("TestEntity");
        var propertyBuilder = entityBuilder.Property<string>("TestProperty");
        return (IProperty)propertyBuilder.Metadata;
    }

    private class TestDuckDBAnnotationCodeGenerator : DuckDBAnnotationCodeGenerator
    {
        public TestDuckDBAnnotationCodeGenerator(AnnotationCodeGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }

        public new bool IsHandledByConvention(IProperty property, IAnnotation annotation)
            => base.IsHandledByConvention(property, annotation);
    }
}

