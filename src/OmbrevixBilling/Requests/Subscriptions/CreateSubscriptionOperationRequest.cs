using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the CreateSubscription operation.
/// </summary>
public sealed record CreateSubscriptionOperationRequest
{
    public CreateSubscriptionRequest? Body { get; init; }
}
