using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the UpdateCouponVariants operation.
/// </summary>
public sealed record UpdateCouponVariantsRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the coupon
    /// </summary>
    public required int CouponId { get; init; }

    public CouponVariants? Body { get; init; }
}
