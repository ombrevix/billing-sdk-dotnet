namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the ValidateCoupon operation.
/// </summary>
public sealed record ValidateCouponRequest
{
    /// <summary>
    /// The code of the coupon
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the coupon belongs
    /// </summary>
    public int? ProductLineupId { get; init; }
}
