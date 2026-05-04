namespace DuckDB.EFCore.Metadata;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ParquetAttribute : Attribute
{
    public ParquetAttribute(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Parquet path cannot be null or whitespace.", nameof(path));
        }

        Path = path;
    }

    public string Path { get; }
}
