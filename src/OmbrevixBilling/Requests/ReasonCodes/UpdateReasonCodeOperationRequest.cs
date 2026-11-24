using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.ReasonCodes;

/// <summary>
/// The inputs of the UpdateReasonCode operation.
/// </summary>
public sealed record UpdateReasonCodeOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the reason code
    /// </summary>
    public required int ReasonCodeId { get; init; }

    public UpdateReasonCodeRequest? Body { get; init; }
}
