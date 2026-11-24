using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the CreateEventBasedAddon operation.
/// </summary>
public sealed record CreateEventBasedAddonRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreateEubAddon? Body { get; init; }
}
