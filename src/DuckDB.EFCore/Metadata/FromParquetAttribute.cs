namespace DuckDB.EFCore.Metadata;

[AttributeUsage(AttributeTargets.Class)]
public sealed class FromParquetAttribute : Attribute
{
    public FromParquetAttribute(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Parquet path cannot be null or whitespace.", nameof(path));
        }

        Path = path;
    }

    public string Path { get; }
}
