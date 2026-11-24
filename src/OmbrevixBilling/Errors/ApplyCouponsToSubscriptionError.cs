using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ApplyCouponsToSubscriptionError : ApiError
{
    private readonly Optional<SubscriptionAddCouponError> _subscriptionAddCouponErrorValue;

    private ApplyCouponsToSubscriptionError(Optional<SubscriptionAddCouponError> subscriptionAddCouponErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionAddCouponErrorValue = subscriptionAddCouponErrorValue;
    }

    private static ApplyCouponsToSubscriptionError AsSubscriptionAddCouponError(SubscriptionAddCouponError value) =>
        new(Optional<SubscriptionAddCouponError>.Some(value), default);

    private static ApplyCouponsToSubscriptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionAddCouponError([NotNullWhen(true)] out SubscriptionAddCouponError? value) =>
        _subscriptionAddCouponErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionAddCouponError, TResult> onSubscriptionAddCouponError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionAddCouponError(
                out var subscriptionAddCouponErrorValue) => onSubscriptionAddCouponError(
                subscriptionAddCouponErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ApplyCouponsToSubscriptionError)} holds no value.")
        };

    public void Match(Action<SubscriptionAddCouponError> onSubscriptionAddCouponError, Action<RawError> otherwise)
    {
        if (TryGetSubscriptionAddCouponError(out var subscriptionAddCouponErrorValue)) onSubscriptionAddCouponError(
            subscriptionAddCouponErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ApplyCouponsToSubscriptionError)} holds no value.");
    }

    private static Task<ApplyCouponsToSubscriptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SubscriptionAddCouponError>().As(AsSubscriptionAddCouponError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ApplyCouponsToSubscriptionError> Response { get; } = new(Create);
}
