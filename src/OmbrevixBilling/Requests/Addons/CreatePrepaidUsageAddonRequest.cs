using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the CreatePrepaidUsageAddon operation.
/// </summary>
public sealed record CreatePrepaidUsageAddonRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreatePrepaidAddon? Body { get; init; }
}
