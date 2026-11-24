using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionNotes;

/// <summary>
/// The inputs of the UpdateSubscriptionNote operation.
/// </summary>
public sealed record UpdateSubscriptionNoteOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the note
    /// </summary>
    public required int NoteId { get; init; }

    public UpdateSubscriptionNoteRequest? Body { get; init; }
}
