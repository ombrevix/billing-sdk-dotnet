namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the DeleteSubscriptionBundlePaymentProfile operation.
/// </summary>
public sealed record DeleteSubscriptionBundlePaymentProfileRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    /// <summary>
    /// The Ombrevix id of the payment profile
    /// </summary>
    public required int PaymentProfileId { get; init; }
}
