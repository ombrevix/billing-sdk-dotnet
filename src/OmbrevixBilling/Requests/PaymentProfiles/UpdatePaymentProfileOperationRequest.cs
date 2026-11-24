using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the UpdatePaymentProfile operation.
/// </summary>
public sealed record UpdatePaymentProfileOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the payment profile
    /// </summary>
    public required int PaymentProfileId { get; init; }

    public UpdatePaymentProfileRequest? Body { get; init; }
}
