namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the DeleteCouponVariant operation.
/// </summary>
public sealed record DeleteCouponVariantRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the coupon to which the variant belongs
    /// </summary>
    public required int CouponId { get; init; }

    /// <summary>
    /// The variant of the coupon
    /// </summary>
    public required string Variant { get; init; }
}
