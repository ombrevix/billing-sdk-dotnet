namespace OmbrevixBilling.Requests.SubscriptionNotes;

/// <summary>
/// The inputs of the ReadSubscriptionNote operation.
/// </summary>
public sealed record ReadSubscriptionNoteRequest
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
