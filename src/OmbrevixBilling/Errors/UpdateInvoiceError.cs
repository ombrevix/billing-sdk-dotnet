using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdateInvoiceError : ApiError
{
    private readonly Optional<ErrorArrayMapResponse> _errorArrayMapResponseValue;

    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private UpdateInvoiceError(Optional<ErrorArrayMapResponse> errorArrayMapResponseValue,
        Optional<ErrorListResponse> errorListResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorArrayMapResponseValue = errorArrayMapResponseValue;
        _errorListResponseValue = errorListResponseValue;
    }

    private static UpdateInvoiceError AsErrorArrayMapResponse(ErrorArrayMapResponse value) =>
        new(Optional<ErrorArrayMapResponse>.Some(value), default, default);

    private static UpdateInvoiceError AsErrorListResponse(ErrorListResponse value) =>
        new(default, Optional<ErrorListResponse>.Some(value), default);

    private static UpdateInvoiceError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value) =>
        _errorArrayMapResponseValue.TryGetValue(out value);

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorArrayMapResponse, TResult> onErrorArrayMapResponse,
        Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue) => onErrorArrayMapResponse(
                errorArrayMapResponseValue),
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdateInvoiceError)} holds no value.")
        };

    public void Match(Action<ErrorArrayMapResponse> onErrorArrayMapResponse,
        Action<ErrorListResponse> onErrorListResponse,
        Action<RawError> otherwise)
    {
        if (TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue)) onErrorArrayMapResponse(
            errorArrayMapResponseValue);
        else if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdateInvoiceError)} holds no value.");
    }

    private static Task<UpdateInvoiceError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<ErrorListResponse>().As(AsErrorListResponse),
            422 => response.Json<ErrorArrayMapResponse>().As(AsErrorArrayMapResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateInvoiceError> Response { get; } = new(Create);
}
