using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdateSubscriptionBundleMembersError : ApiError
{
    private readonly Optional<SubscriptionBundleUpdateErrorResponse> _subscriptionBundleUpdateErrorResponseValue;

    private UpdateSubscriptionBundleMembersError(Optional<SubscriptionBundleUpdateErrorResponse> subscriptionBundleUpdateErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _subscriptionBundleUpdateErrorResponseValue = subscriptionBundleUpdateErrorResponseValue;
    }

    private static UpdateSubscriptionBundleMembersError AsSubscriptionBundleUpdateErrorResponse(SubscriptionBundleUpdateErrorResponse value) =>
        new(Optional<SubscriptionBundleUpdateErrorResponse>.Some(value), default);

    private static UpdateSubscriptionBundleMembersError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSubscriptionBundleUpdateErrorResponse([NotNullWhen(true)] out SubscriptionBundleUpdateErrorResponse? value) =>
        _subscriptionBundleUpdateErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SubscriptionBundleUpdateErrorResponse, TResult> onSubscriptionBundleUpdateErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionBundleUpdateErrorResponse(
                out var subscriptionBundleUpdateErrorResponseValue) => onSubscriptionBundleUpdateErrorResponse(
                subscriptionBundleUpdateErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdateSubscriptionBundleMembersError)} holds no value.")
        };

    public void Match(Action<SubscriptionBundleUpdateErrorResponse> onSubscriptionBundleUpdateErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetSubscriptionBundleUpdateErrorResponse(
            out var subscriptionBundleUpdateErrorResponseValue)) onSubscriptionBundleUpdateErrorResponse(
            subscriptionBundleUpdateErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdateSubscriptionBundleMembersError)} holds no value.");
    }

    private static Task<UpdateSubscriptionBundleMembersError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SubscriptionBundleUpdateErrorResponse>().As(AsSubscriptionBundleUpdateErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateSubscriptionBundleMembersError> Response { get; } = new(Create);
}
