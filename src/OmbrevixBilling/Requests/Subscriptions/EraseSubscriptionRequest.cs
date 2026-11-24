using System.Collections.Generic;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the EraseSubscription operation.
/// </summary>
public sealed record EraseSubscriptionRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// id of the customer.
    /// </summary>
    public required int Ack { get; init; }

    /// <summary>
    /// Options are "customer" or "payment_profile".
    /// Use in query: <c>cascade[]=customer&amp;cascade[]=payment_profile</c>.
    /// </summary>
    public IReadOnlyList<SubscriptionEraseType>? Cascade { get; init; }
}
