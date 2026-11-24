using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundleInvoiceAccount;

/// <summary>
/// The inputs of the DeductSubscriptionBundleServiceCredit operation.
/// </summary>
public sealed record DeductSubscriptionBundleServiceCreditRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    public DeductServiceCreditRequest? Body { get; init; }
}
