using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the CreateCouponVariants operation.
/// </summary>
public sealed record CreateCouponVariantsRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the coupon
    /// </summary>
    public required int CouponId { get; init; }

    public CouponVariants? Body { get; init; }
}
