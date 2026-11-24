using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the ActivateEventBasedAddon operation.
/// </summary>
public sealed record ActivateEventBasedAddonRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the subscription
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the addon
    /// </summary>
    public required int AddonId { get; init; }

    public ActivateEventBasedAddon? Body { get; init; }
}
