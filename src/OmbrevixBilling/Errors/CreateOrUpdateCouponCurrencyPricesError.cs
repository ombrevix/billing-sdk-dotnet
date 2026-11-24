using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateOrUpdateCouponCurrencyPricesError : ApiError
{
    private readonly Optional<ErrorStringMapResponse> _errorStringMapResponseValue;

    private CreateOrUpdateCouponCurrencyPricesError(Optional<ErrorStringMapResponse> errorStringMapResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorStringMapResponseValue = errorStringMapResponseValue;
    }

    private static CreateOrUpdateCouponCurrencyPricesError AsErrorStringMapResponse(ErrorStringMapResponse value) =>
        new(Optional<ErrorStringMapResponse>.Some(value), default);

    private static CreateOrUpdateCouponCurrencyPricesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value) =>
        _errorStringMapResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorStringMapResponse, TResult> onErrorStringMapResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorStringMapResponse(out var errorStringMapResponseValue) => onErrorStringMapResponse(
                errorStringMapResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException(
                $"{nameof(CreateOrUpdateCouponCurrencyPricesError)} holds no value.")
        };

    public void Match(Action<ErrorStringMapResponse> onErrorStringMapResponse, Action<RawError> otherwise)
    {
        if (TryGetErrorStringMapResponse(out var errorStringMapResponseValue)) onErrorStringMapResponse(
            errorStringMapResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateOrUpdateCouponCurrencyPricesError)} holds no value.");
    }

    private static Task<CreateOrUpdateCouponCurrencyPricesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<ErrorStringMapResponse>().As(AsErrorStringMapResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateOrUpdateCouponCurrencyPricesError> Response { get; } = new(Create);
}
