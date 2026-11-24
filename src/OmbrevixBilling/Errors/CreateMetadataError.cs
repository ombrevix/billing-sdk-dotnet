using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateMetadataError : ApiError
{
    private readonly Optional<SingleErrorResponse> _singleErrorResponseValue;

    private CreateMetadataError(Optional<SingleErrorResponse> singleErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _singleErrorResponseValue = singleErrorResponseValue;
    }

    private static CreateMetadataError AsSingleErrorResponse(SingleErrorResponse value) =>
        new(Optional<SingleErrorResponse>.Some(value), default);

    private static CreateMetadataError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value) =>
        _singleErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<SingleErrorResponse, TResult> onSingleErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSingleErrorResponse(out var singleErrorResponseValue) => onSingleErrorResponse(
                singleErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(CreateMetadataError)} holds no value.")
        };

    public void Match(Action<SingleErrorResponse> onSingleErrorResponse, Action<RawError> otherwise)
    {
        if (TryGetSingleErrorResponse(out var singleErrorResponseValue)) onSingleErrorResponse(
            singleErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateMetadataError)} holds no value.");
    }

    private static Task<CreateMetadataError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<SingleErrorResponse>().As(AsSingleErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateMetadataError> Response { get; } = new(Create);
}
