using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the CreateCoupon operation.
/// </summary>
public sealed record CreateCouponRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the coupon belongs
    /// </summary>
    public required int ProductLineupId { get; init; }

    public CouponRequest? Body { get; init; }
}
