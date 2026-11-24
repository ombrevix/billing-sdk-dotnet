namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the DeleteUnusedPaymentProfile operation.
/// </summary>
public sealed record DeleteUnusedPaymentProfileRequest
{
    /// <summary>
    /// The Ombrevix id of the payment profile
    /// </summary>
    public required int PaymentProfileId { get; init; }
}
