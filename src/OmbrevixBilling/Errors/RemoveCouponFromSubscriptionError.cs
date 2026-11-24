using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class RemoveCouponFromSubscriptionError : ApiError
{
    private readonly Optional<SubscriptionRemoveCouponErrors> _subscriptionRemoveCouponErrorsValue;

    private RemoveCouponFromSubscriptionError(Optional<SubscriptionRemoveCouponErrors> subscriptionRemoveCouponErrorsValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionRemoveCouponErrorsValue = subscriptionRemoveCouponErrorsValue;
    }

    private static RemoveCouponFromSubscriptionError AsSubscriptionRemoveCouponErrors(SubscriptionRemoveCouponErrors value) =>
        new(Optional<SubscriptionRemoveCouponErrors>.Some(value), default);

    private static RemoveCouponFromSubscriptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionRemoveCouponErrors([NotNullWhen(true)] out SubscriptionRemoveCouponErrors? value) =>
        _subscriptionRemoveCouponErrorsValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionRemoveCouponErrors, TResult> onSubscriptionRemoveCouponErrors,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionRemoveCouponErrors(
                out var subscriptionRemoveCouponErrorsValue) => onSubscriptionRemoveCouponErrors(
                subscriptionRemoveCouponErrorsValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(RemoveCouponFromSubscriptionError)} holds no value.")
        };

    public void Match(Action<SubscriptionRemoveCouponErrors> onSubscriptionRemoveCouponErrors,
        Action<RawError> otherwise)
    {
        if (TryGetSubscriptionRemoveCouponErrors(
            out var subscriptionRemoveCouponErrorsValue)) onSubscriptionRemoveCouponErrors(
            subscriptionRemoveCouponErrorsValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(RemoveCouponFromSubscriptionError)} holds no value.");
    }

    private static Task<RemoveCouponFromSubscriptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SubscriptionRemoveCouponErrors>().As(AsSubscriptionRemoveCouponErrors),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<RemoveCouponFromSubscriptionError> Response { get; } = new(Create);
}
