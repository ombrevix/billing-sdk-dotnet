using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ValidateCouponError : ApiError
{
    private readonly Optional<SingleStringErrorResponse> _singleStringErrorResponseValue;

    private ValidateCouponError(Optional<SingleStringErrorResponse> singleStringErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _singleStringErrorResponseValue = singleStringErrorResponseValue;
    }

    private static ValidateCouponError AsSingleStringErrorResponse(SingleStringErrorResponse value) =>
        new(Optional<SingleStringErrorResponse>.Some(value), default);

    private static ValidateCouponError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetSingleStringErrorResponse([NotNullWhen(true)] out SingleStringErrorResponse? value) =>
        _singleStringErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SingleStringErrorResponse, TResult> onSingleStringErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSingleStringErrorResponse(
                out var singleStringErrorResponseValue) => onSingleStringErrorResponse(singleStringErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ValidateCouponError)} holds no value.")
        };

    public void Match(Action<SingleStringErrorResponse> onSingleStringErrorResponse, Action<RawError> otherwise)
    {
        if (TryGetSingleStringErrorResponse(out var singleStringErrorResponseValue)) onSingleStringErrorResponse(
            singleStringErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ValidateCouponError)} holds no value.");
    }

    private static Task<ValidateCouponError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<SingleStringErrorResponse>().As(AsSingleStringErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ValidateCouponError> Response { get; } = new(Create);
}
