using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ExportInvoicesError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private readonly Optional<SingleErrorResponse> _singleErrorResponseValue;

    private ExportInvoicesError(Optional<RawError> noContentValue,
        Optional<SingleErrorResponse> singleErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
        _singleErrorResponseValue = singleErrorResponseValue;
    }

    private static ExportInvoicesError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default, default);

    private static ExportInvoicesError AsSingleErrorResponse(SingleErrorResponse value) =>
        new(default, Optional<SingleErrorResponse>.Some(value), default);

    private static ExportInvoicesError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public bool TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value) =>
        _singleErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<RawError, TResult> onNoContent,
        Func<SingleErrorResponse, TResult> onSingleErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetSingleErrorResponse(out var singleErrorResponseValue) => onSingleErrorResponse(
                singleErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ExportInvoicesError)} holds no value.")
        };

    public void Match(Action<RawError> onNoContent,
        Action<SingleErrorResponse> onSingleErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetSingleErrorResponse(out var singleErrorResponseValue)) onSingleErrorResponse(
            singleErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ExportInvoicesError)} holds no value.");
    }

    private static Task<ExportInvoicesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            409 => response.Json<SingleErrorResponse>().As(AsSingleErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ExportInvoicesError> Response { get; } = new(Create);
}
