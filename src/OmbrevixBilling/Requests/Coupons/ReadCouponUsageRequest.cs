namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the ReadCouponUsage operation.
/// </summary>
public sealed record ReadCouponUsageRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the coupon belongs.
    /// </summary>
    public required int ProductLineupId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the coupon.
    /// </summary>
    public required int CouponId { get; init; }
}
