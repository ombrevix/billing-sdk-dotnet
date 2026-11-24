using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ValidateAffiliateCodeError : ApiError
{
    private readonly Optional<SingleStringErrorResponse> _singleStringErrorResponseValue;

    private ValidateAffiliateCodeError(Optional<SingleStringErrorResponse> singleStringErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _singleStringErrorResponseValue = singleStringErrorResponseValue;
    }

    private static ValidateAffiliateCodeError AsSingleStringErrorResponse(SingleStringErrorResponse value) =>
        new(Optional<SingleStringErrorResponse>.Some(value), default);

    private static ValidateAffiliateCodeError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetSingleStringErrorResponse([NotNullWhen(true)] out SingleStringErrorResponse? value) =>
        _singleStringErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SingleStringErrorResponse, TResult> onSingleStringErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSingleStringErrorResponse(
                out var singleStringErrorResponseValue) => onSingleStringErrorResponse(singleStringErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ValidateAffiliateCodeError)} holds no value.")
        };

    public void Match(Action<SingleStringErrorResponse> onSingleStringErrorResponse, Action<RawError> otherwise)
    {
        if (TryGetSingleStringErrorResponse(out var singleStringErrorResponseValue)) onSingleStringErrorResponse(
            singleStringErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ValidateAffiliateCodeError)} holds no value.");
    }

    private static Task<ValidateAffiliateCodeError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<SingleStringErrorResponse>().As(AsSingleStringErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ValidateAffiliateCodeError> Response { get; } = new(Create);
}
