using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class PreviewSignupEstimateInvoiceError : ApiError
{
    private readonly Optional<ErrorArrayMapResponse> _errorArrayMapResponseValue;

    private readonly Optional<EstimateBadRequestErrorResponse> _estimateBadRequestErrorResponseValue;

    private PreviewSignupEstimateInvoiceError(Optional<ErrorArrayMapResponse> errorArrayMapResponseValue,
        Optional<EstimateBadRequestErrorResponse> estimateBadRequestErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorArrayMapResponseValue = errorArrayMapResponseValue;
        _estimateBadRequestErrorResponseValue = estimateBadRequestErrorResponseValue;
    }

    private static PreviewSignupEstimateInvoiceError AsErrorArrayMapResponse(ErrorArrayMapResponse value) =>
        new(Optional<ErrorArrayMapResponse>.Some(value), default, default);

    private static PreviewSignupEstimateInvoiceError AsEstimateBadRequestErrorResponse(EstimateBadRequestErrorResponse value) =>
        new(default, Optional<EstimateBadRequestErrorResponse>.Some(value), default);

    private static PreviewSignupEstimateInvoiceError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value) =>
        _errorArrayMapResponseValue.TryGetValue(out value);

    public bool TryGetEstimateBadRequestErrorResponse([NotNullWhen(true)] out EstimateBadRequestErrorResponse? value) =>
        _estimateBadRequestErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorArrayMapResponse, TResult> onErrorArrayMapResponse,
        Func<EstimateBadRequestErrorResponse, TResult> onEstimateBadRequestErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue) => onErrorArrayMapResponse(
                errorArrayMapResponseValue),
            _ when TryGetEstimateBadRequestErrorResponse(
                out var estimateBadRequestErrorResponseValue) => onEstimateBadRequestErrorResponse(
                estimateBadRequestErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(PreviewSignupEstimateInvoiceError)} holds no value.")
        };

    public void Match(Action<ErrorArrayMapResponse> onErrorArrayMapResponse,
        Action<EstimateBadRequestErrorResponse> onEstimateBadRequestErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue)) onErrorArrayMapResponse(
            errorArrayMapResponseValue);
        else if (TryGetEstimateBadRequestErrorResponse(
            out var estimateBadRequestErrorResponseValue)) onEstimateBadRequestErrorResponse(
            estimateBadRequestErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(PreviewSignupEstimateInvoiceError)} holds no value.");
    }

    private static Task<PreviewSignupEstimateInvoiceError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<EstimateBadRequestErrorResponse>().As(AsEstimateBadRequestErrorResponse),
            422 => response.Json<ErrorArrayMapResponse>().As(AsErrorArrayMapResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<PreviewSignupEstimateInvoiceError> Response { get; } = new(Create);
}
