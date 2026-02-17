using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DuckDB.EFCore.Storage.ValueConverters;

public class DuckDBTimeSpanToTimeOnlyValueConverter : ValueConverter<TimeSpan, TimeOnly>
{
    public static readonly DuckDBTimeSpanToTimeOnlyValueConverter Instance = new();

    public DuckDBTimeSpanToTimeOnlyValueConverter()
        : base(
            timeSpan => TimeOnly.FromTimeSpan(timeSpan),
            timeOnly => timeOnly.ToTimeSpan())
    {
    }
}
