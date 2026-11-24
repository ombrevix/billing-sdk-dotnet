using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundleInvoiceAccount;

/// <summary>
/// The inputs of the CreateSubscriptionBundlePrepayment operation.
/// </summary>
public sealed record CreateSubscriptionBundlePrepaymentRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    public SubscriptionBundlePrepaymentRequest? Body { get; init; }
}
