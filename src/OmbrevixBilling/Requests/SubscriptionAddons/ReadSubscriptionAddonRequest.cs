namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the ReadSubscriptionAddon operation.
/// </summary>
public sealed record ReadSubscriptionAddonRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the addon. Alternatively, the addon's slug prefixed by <c>slug:</c>
    /// </summary>
    public required int AddonId { get; init; }
}
