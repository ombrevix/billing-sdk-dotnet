using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Errors;

public sealed class RefundPrepaymentError : ApiError
{
    private readonly Optional<RefundPrepaymentBaseErrorsResponse> _refundPrepaymentBaseErrorsResponseValue;

    private readonly Optional<RefundPrepaymentErrorResponse> _refundPrepaymentErrorResponseValue;

    private readonly Optional<string> _stringValue;

    private RefundPrepaymentError(Optional<RefundPrepaymentBaseErrorsResponse> refundPrepaymentBaseErrorsResponseValue,
        Optional<RefundPrepaymentErrorResponse> refundPrepaymentErrorResponseValue,
        Optional<string> stringValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _refundPrepaymentBaseErrorsResponseValue = refundPrepaymentBaseErrorsResponseValue;
        _refundPrepaymentErrorResponseValue = refundPrepaymentErrorResponseValue;
        _stringValue = stringValue;
    }

    private static RefundPrepaymentError AsRefundPrepaymentBaseErrorsResponse(RefundPrepaymentBaseErrorsResponse value) =>
        new(Optional<RefundPrepaymentBaseErrorsResponse>.Some(value), default, default, default);

    private static RefundPrepaymentError AsRefundPrepaymentErrorResponse(RefundPrepaymentErrorResponse value) =>
        new(default, Optional<RefundPrepaymentErrorResponse>.Some(value), default, default);

    private static RefundPrepaymentError AsString(string value) =>
        new(default, default, Optional<string>.Some(value), default);

    private static RefundPrepaymentError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetRefundPrepaymentBaseErrorsResponse([NotNullWhen(true)] out RefundPrepaymentBaseErrorsResponse? value) =>
        _refundPrepaymentBaseErrorsResponseValue.TryGetValue(out value);

    public bool TryGetRefundPrepaymentErrorResponse([NotNullWhen(true)] out RefundPrepaymentErrorResponse? value) =>
        _refundPrepaymentErrorResponseValue.TryGetValue(out value);

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<RefundPrepaymentBaseErrorsResponse, TResult> onRefundPrepaymentBaseErrorsResponse,
        Func<RefundPrepaymentErrorResponse, TResult> onRefundPrepaymentErrorResponse,
        Func<string, TResult> onString,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetRefundPrepaymentBaseErrorsResponse(
                out var refundPrepaymentBaseErrorsResponseValue) => onRefundPrepaymentBaseErrorsResponse(
                refundPrepaymentBaseErrorsResponseValue),
            _ when TryGetRefundPrepaymentErrorResponse(
                out var refundPrepaymentErrorResponseValue) => onRefundPrepaymentErrorResponse(
                refundPrepaymentErrorResponseValue),
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(RefundPrepaymentError)} holds no value.")
        };

    public void Match(Action<RefundPrepaymentBaseErrorsResponse> onRefundPrepaymentBaseErrorsResponse,
        Action<RefundPrepaymentErrorResponse> onRefundPrepaymentErrorResponse,
        Action<string> onString,
        Action<RawError> otherwise)
    {
        if (TryGetRefundPrepaymentBaseErrorsResponse(
            out var refundPrepaymentBaseErrorsResponseValue)) onRefundPrepaymentBaseErrorsResponse(
            refundPrepaymentBaseErrorsResponseValue);
        else if (TryGetRefundPrepaymentErrorResponse(
            out var refundPrepaymentErrorResponseValue)) onRefundPrepaymentErrorResponse(
            refundPrepaymentErrorResponseValue);
        else if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(RefundPrepaymentError)} holds no value.");
    }

    private static Task<RefundPrepaymentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<RefundPrepaymentBaseErrorsResponse>().As(AsRefundPrepaymentBaseErrorsResponse),
            404 => response.Json<string>().As(AsString),
            422 => response.Json<RefundPrepaymentErrorResponse>().As(AsRefundPrepaymentErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<RefundPrepaymentError> Response { get; } = new(Create);
}
