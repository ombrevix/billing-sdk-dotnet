using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the RecordEvent operation.
/// </summary>
public sealed record RecordEventRequest
{
    /// <summary>
    /// Identifies the Stream for which the event should be published.
    /// </summary>
    public required string ApiSlug { get; init; }

    /// <summary>
    /// If you've attached your own Keen project as an Ombrevix Billing event data-store, use this parameter to indicate the data-store.
    /// </summary>
    public string? StoreUid { get; init; }

    public EubEvent? Body { get; init; }
}
