namespace OmbrevixBilling.Requests.BillingPortal;

/// <summary>
/// The inputs of the RevokeBillingPortalAccess operation.
/// </summary>
public sealed record RevokeBillingPortalAccessRequest
{
    /// <summary>
    /// The Ombrevix id of the customer
    /// </summary>
    public required int CustomerId { get; init; }
}
