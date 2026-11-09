using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace DuckDB.EFCore.NTS.Diagnostics.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBSpatialCommandInterceptor : DbCommandInterceptor
{
    private const string Option = "geometry_always_xy";
    private const string OptionValue = "true";

    private static readonly string[] AlwaysXyFunctions =
    [
        "ST_Area_Spheroid",
        "ST_Distance_Sphere",
        "ST_DWithin_Spheroid"
    ];

    /// <summary>
    ///     Called immediately after a <see cref="DbCommand" /> has been initialized.
    /// </summary>
    /// <param name="eventData">Contextual information about the command initialization.</param>
    /// <param name="result">The command that was initialized.</param>
    /// <returns>The command to use, which may be modified.</returns>
    public override DbCommand CommandInitialized(CommandEndEventData eventData, DbCommand result)
    {
        var command = base.CommandInitialized(eventData, result);

        if (!string.IsNullOrWhiteSpace(command.CommandText))
        {
            foreach (var function in AlwaysXyFunctions)
            {
                if (command.CommandText.Contains(function) && !command.CommandText.Contains(Option))
                {
                    command.CommandText = $"SET {Option} = {OptionValue};" + Environment.NewLine + command.CommandText;
                    break;
                }
            }
        }

        return command;
    }
}
