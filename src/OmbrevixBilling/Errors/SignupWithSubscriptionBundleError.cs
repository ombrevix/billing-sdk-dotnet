using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class SignupWithSubscriptionBundleError : ApiError
{
    private readonly Optional<SubscriptionBundleSignupErrorResponse> _subscriptionBundleSignupErrorResponseValue;

    private SignupWithSubscriptionBundleError(Optional<SubscriptionBundleSignupErrorResponse> subscriptionBundleSignupErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionBundleSignupErrorResponseValue = subscriptionBundleSignupErrorResponseValue;
    }

    private static SignupWithSubscriptionBundleError AsSubscriptionBundleSignupErrorResponse(SubscriptionBundleSignupErrorResponse value) =>
        new(Optional<SubscriptionBundleSignupErrorResponse>.Some(value), default);

    private static SignupWithSubscriptionBundleError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionBundleSignupErrorResponse([NotNullWhen(true)] out SubscriptionBundleSignupErrorResponse? value) =>
        _subscriptionBundleSignupErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionBundleSignupErrorResponse, TResult> onSubscriptionBundleSignupErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionBundleSignupErrorResponse(
                out var subscriptionBundleSignupErrorResponseValue) => onSubscriptionBundleSignupErrorResponse(
                subscriptionBundleSignupErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(SignupWithSubscriptionBundleError)} holds no value.")
        };

    public void Match(Action<SubscriptionBundleSignupErrorResponse> onSubscriptionBundleSignupErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetSubscriptionBundleSignupErrorResponse(
            out var subscriptionBundleSignupErrorResponseValue)) onSubscriptionBundleSignupErrorResponse(
            subscriptionBundleSignupErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(SignupWithSubscriptionBundleError)} holds no value.");
    }

    private static Task<SignupWithSubscriptionBundleError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SubscriptionBundleSignupErrorResponse>().As(AsSubscriptionBundleSignupErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<SignupWithSubscriptionBundleError> Response { get; } = new(Create);
}
