namespace OmbrevixBilling.Requests.ReasonCodes;

/// <summary>
/// The inputs of the DeleteReasonCode operation.
/// </summary>
public sealed record DeleteReasonCodeRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the reason code
    /// </summary>
    public required int ReasonCodeId { get; init; }
}
