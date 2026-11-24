using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateSubscriptionBundleError : ApiError
{
    private readonly Optional<SubscriptionBundleCreateErrorResponse> _subscriptionBundleCreateErrorResponseValue;

    private CreateSubscriptionBundleError(Optional<SubscriptionBundleCreateErrorResponse> subscriptionBundleCreateErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionBundleCreateErrorResponseValue = subscriptionBundleCreateErrorResponseValue;
    }

    private static CreateSubscriptionBundleError AsSubscriptionBundleCreateErrorResponse(SubscriptionBundleCreateErrorResponse value) =>
        new(Optional<SubscriptionBundleCreateErrorResponse>.Some(value), default);

    private static CreateSubscriptionBundleError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionBundleCreateErrorResponse([NotNullWhen(true)] out SubscriptionBundleCreateErrorResponse? value) =>
        _subscriptionBundleCreateErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionBundleCreateErrorResponse, TResult> onSubscriptionBundleCreateErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionBundleCreateErrorResponse(
                out var subscriptionBundleCreateErrorResponseValue) => onSubscriptionBundleCreateErrorResponse(
                subscriptionBundleCreateErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(CreateSubscriptionBundleError)} holds no value.")
        };

    public void Match(Action<SubscriptionBundleCreateErrorResponse> onSubscriptionBundleCreateErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetSubscriptionBundleCreateErrorResponse(
            out var subscriptionBundleCreateErrorResponseValue)) onSubscriptionBundleCreateErrorResponse(
            subscriptionBundleCreateErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateSubscriptionBundleError)} holds no value.");
    }

    private static Task<CreateSubscriptionBundleError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SubscriptionBundleCreateErrorResponse>().As(AsSubscriptionBundleCreateErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateSubscriptionBundleError> Response { get; } = new(Create);
}
