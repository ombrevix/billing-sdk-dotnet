using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ReopenInvoiceError : ApiError
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<object?> _objectValue;

    private ReopenInvoiceError(Optional<ErrorListResponse> errorListResponseValue,
        Optional<object?> objectValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorListResponseValue = errorListResponseValue;
        _objectValue = objectValue;
    }

    private static ReopenInvoiceError AsErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    private static ReopenInvoiceError AsObject(object? value) => new(default, Optional<object?>.Some(value), default);

    private static ReopenInvoiceError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetObject(out object? value) => _objectValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<object?, TResult> onObject,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetObject(out var objectValue) => onObject(objectValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ReopenInvoiceError)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<object?> onObject,
        Action<RawError> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetObject(out var objectValue)) onObject(objectValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ReopenInvoiceError)} holds no value.");
    }

    private static Task<ReopenInvoiceError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<object?>().As(AsObject),
            422 => response.Json<ErrorListResponse>().As(AsErrorListResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ReopenInvoiceError> Response { get; } = new(Create);
}
