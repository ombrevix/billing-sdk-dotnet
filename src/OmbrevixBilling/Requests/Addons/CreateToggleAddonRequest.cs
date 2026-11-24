using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the CreateToggleAddon operation.
/// </summary>
public sealed record CreateToggleAddonRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreateToggleAddon? Body { get; init; }
}
