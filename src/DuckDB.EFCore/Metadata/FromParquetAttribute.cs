namespace DuckDB.EFCore.Metadata;

/// <summary>
///     Maps an entity type to a parquet file path or glob pattern.
/// </summary>
/// <remarks>
///     When applied, DuckDB query SQL generation translates table references for the annotated entity type to
///     DuckDB <c>read_parquet(...)</c> using the supplied path. The path should be a DuckDB-compatible parquet
///     path or glob pattern and any embedded quotes are escaped during SQL generation.
/// </remarks>
[AttributeUsage(AttributeTargets.Class)]
public sealed class FromParquetAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FromParquetAttribute" /> class.
    /// </summary>
    /// <param name="path">The parquet file path or glob pattern used for DuckDB <c>read_parquet(...)</c>.</param>
    public FromParquetAttribute(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Parquet path cannot be null or whitespace.", nameof(path));
        }

        Path = path;
    }

    /// <summary>
    ///     The parquet file path or glob pattern.
    /// </summary>
    public string Path { get; }
}
