namespace OmbrevixBilling.Requests.AffiliateCodes;

/// <summary>
/// The inputs of the ValidateAffiliateCode operation.
/// </summary>
public sealed record ValidateAffiliateCodeRequest
{
    /// <summary>
    /// The affiliate code you are trying to validate
    /// </summary>
    public required string Code { get; init; }
}
