namespace OmbrevixBilling.Requests.PaymentProfiles;

/// <summary>
/// The inputs of the ReadOneTimeToken operation.
/// </summary>
public sealed record ReadOneTimeTokenRequest
{
    /// <summary>
    /// Ombrevix Billing Token
    /// </summary>
    public required string PlatformToken { get; init; }
}
