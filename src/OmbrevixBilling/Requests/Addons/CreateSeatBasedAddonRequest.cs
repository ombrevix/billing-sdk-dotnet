using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the CreateSeatBasedAddon operation.
/// </summary>
public sealed record CreateSeatBasedAddonRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreateSeatBasedAddon? Body { get; init; }
}
