namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the BulkResetSubscriptionAddonsPriceOptions operation.
/// </summary>
public sealed record BulkResetSubscriptionAddonsPriceOptionsRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
