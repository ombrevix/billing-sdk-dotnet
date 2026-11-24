using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ListReasonCodesError : ApiError
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private ListReasonCodesError(Optional<ErrorListResponse> errorListResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorListResponseValue = errorListResponseValue;
    }

    private static ListReasonCodesError AsErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default);

    private static ListReasonCodesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ListReasonCodesError)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse, Action<RawError> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ListReasonCodesError)} holds no value.");
    }

    private static Task<ListReasonCodesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<ErrorListResponse>().As(AsErrorListResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListReasonCodesError> Response { get; } = new(Create);
}
