namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the ChangeSubscriptionDefaultPaymentProfile operation.
/// </summary>
public sealed record ChangeSubscriptionDefaultPaymentProfileRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix id of the payment profile
    /// </summary>
    public required int PaymentProfileId { get; init; }
}
