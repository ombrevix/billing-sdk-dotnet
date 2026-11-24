using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdateEndpointError : ApiError
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<RawError> _noContentValue;

    private UpdateEndpointError(Optional<ErrorListResponse> errorListResponseValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorListResponseValue = errorListResponseValue;
        _noContentValue = noContentValue;
    }

    private static UpdateEndpointError AsErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    private static UpdateEndpointError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static UpdateEndpointError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdateEndpointError)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdateEndpointError)} holds no value.");
    }

    private static Task<UpdateEndpointError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<ErrorListResponse>().As(AsErrorListResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateEndpointError> Response { get; } = new(Create);
}
