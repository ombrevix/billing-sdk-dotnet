using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the CreateOrUpdateCouponCurrencyPrices operation.
/// </summary>
public sealed record CreateOrUpdateCouponCurrencyPricesRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the coupon
    /// </summary>
    public required int CouponId { get; init; }

    public CouponCurrencyRequest? Body { get; init; }
}
