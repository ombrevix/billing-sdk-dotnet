namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the DeactivateEventBasedAddon operation.
/// </summary>
public sealed record DeactivateEventBasedAddonRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the subscription
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the addon
    /// </summary>
    public required int AddonId { get; init; }
}
