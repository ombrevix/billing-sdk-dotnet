namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the RemoveCouponFromSubscription operation.
/// </summary>
public sealed record RemoveCouponFromSubscriptionRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The coupon code
    /// </summary>
    public string? CouponCode { get; init; }
}
