using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the BulkCreateAddonPriceOptions operation.
/// </summary>
public sealed record BulkCreateAddonPriceOptionsRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the addon for which you want to fetch price options.
    /// </summary>
    public required string AddonId { get; init; }

    public CreateAddonPriceOptionsRequest? Body { get; init; }
}
