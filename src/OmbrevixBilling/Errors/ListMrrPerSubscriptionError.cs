using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ListMrrPerSubscriptionError : ApiError
{
    private readonly Optional<SubscriptionsMrrErrorResponse> _subscriptionsMrrErrorResponseValue;

    private ListMrrPerSubscriptionError(Optional<SubscriptionsMrrErrorResponse> subscriptionsMrrErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionsMrrErrorResponseValue = subscriptionsMrrErrorResponseValue;
    }

    private static ListMrrPerSubscriptionError AsSubscriptionsMrrErrorResponse(SubscriptionsMrrErrorResponse value) =>
        new(Optional<SubscriptionsMrrErrorResponse>.Some(value), default);

    private static ListMrrPerSubscriptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionsMrrErrorResponse([NotNullWhen(true)] out SubscriptionsMrrErrorResponse? value) =>
        _subscriptionsMrrErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionsMrrErrorResponse, TResult> onSubscriptionsMrrErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionsMrrErrorResponse(
                out var subscriptionsMrrErrorResponseValue) => onSubscriptionsMrrErrorResponse(
                subscriptionsMrrErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ListMrrPerSubscriptionError)} holds no value.")
        };

    public void Match(Action<SubscriptionsMrrErrorResponse> onSubscriptionsMrrErrorResponse, Action<RawError> otherwise)
    {
        if (TryGetSubscriptionsMrrErrorResponse(
            out var subscriptionsMrrErrorResponseValue)) onSubscriptionsMrrErrorResponse(
            subscriptionsMrrErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ListMrrPerSubscriptionError)} holds no value.");
    }

    private static Task<ListMrrPerSubscriptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<SubscriptionsMrrErrorResponse>().As(AsSubscriptionsMrrErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListMrrPerSubscriptionError> Response { get; } = new(Create);
}
