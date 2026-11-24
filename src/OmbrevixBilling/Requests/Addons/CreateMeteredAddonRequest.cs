using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the CreateMeteredAddon operation.
/// </summary>
public sealed record CreateMeteredAddonRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreateMeteredAddon? Body { get; init; }
}
