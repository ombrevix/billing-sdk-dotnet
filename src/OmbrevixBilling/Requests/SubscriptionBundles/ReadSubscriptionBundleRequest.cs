using System.Collections.Generic;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the ReadSubscriptionBundle operation.
/// </summary>
public sealed record ReadSubscriptionBundleRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    /// <summary>
    /// Allows including additional data in the response. Use in query: <c>include[]=current_billing_amount_minor</c>.
    /// </summary>
    public IReadOnlyList<SubscriptionBundleInclude>? Include { get; init; }
}
