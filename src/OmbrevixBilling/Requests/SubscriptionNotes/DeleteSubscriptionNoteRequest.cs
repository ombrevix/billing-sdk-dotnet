namespace OmbrevixBilling.Requests.SubscriptionNotes;

/// <summary>
/// The inputs of the DeleteSubscriptionNote operation.
/// </summary>
public sealed record DeleteSubscriptionNoteRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the note
    /// </summary>
    public required int NoteId { get; init; }
}
