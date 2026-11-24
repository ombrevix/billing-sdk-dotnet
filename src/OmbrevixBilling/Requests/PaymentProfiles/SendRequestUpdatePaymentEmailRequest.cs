namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the SendRequestUpdatePaymentEmail operation.
/// </summary>
public sealed record SendRequestUpdatePaymentEmailRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
