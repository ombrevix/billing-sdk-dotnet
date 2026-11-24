using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the BulkUpdateSubscriptionAddonsPriceOptions operation.
/// </summary>
public sealed record BulkUpdateSubscriptionAddonsPriceOptionsRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public BulkAddonsPriceOptionAssignment? Body { get; init; }
}
