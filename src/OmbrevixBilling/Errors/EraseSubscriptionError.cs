using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class EraseSubscriptionError : ApiError
{
    private readonly Optional<SubscriptionResponse> _subscriptionResponseValue;

    private EraseSubscriptionError(Optional<SubscriptionResponse> subscriptionResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionResponseValue = subscriptionResponseValue;
    }

    private static EraseSubscriptionError AsSubscriptionResponse(SubscriptionResponse value) =>
        new(Optional<SubscriptionResponse>.Some(value), default);

    private static EraseSubscriptionError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionResponse([NotNullWhen(true)] out SubscriptionResponse? value) =>
        _subscriptionResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionResponse, TResult> onSubscriptionResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionResponse(out var subscriptionResponseValue) => onSubscriptionResponse(
                subscriptionResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(EraseSubscriptionError)} holds no value.")
        };

    public void Match(Action<SubscriptionResponse> onSubscriptionResponse, Action<RawError> otherwise)
    {
        if (TryGetSubscriptionResponse(out var subscriptionResponseValue)) onSubscriptionResponse(
            subscriptionResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(EraseSubscriptionError)} holds no value.");
    }

    private static Task<EraseSubscriptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<SubscriptionResponse>().As(AsSubscriptionResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<EraseSubscriptionError> Response { get; } = new(Create);
}
