using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionNotes;

/// <summary>
/// The inputs of the CreateSubscriptionNote operation.
/// </summary>
public sealed record CreateSubscriptionNoteRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public UpdateSubscriptionNoteRequest? Body { get; init; }
}
