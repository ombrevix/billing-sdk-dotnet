using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdatePaymentProfileError : ApiError
{
    private readonly Optional<ErrorStringMapResponse> _errorStringMapResponseValue;

    private readonly Optional<RawError> _noContentValue;

    private UpdatePaymentProfileError(Optional<ErrorStringMapResponse> errorStringMapResponseValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorStringMapResponseValue = errorStringMapResponseValue;
        _noContentValue = noContentValue;
    }

    private static UpdatePaymentProfileError AsErrorStringMapResponse(ErrorStringMapResponse value) =>
        new(Optional<ErrorStringMapResponse>.Some(value), default, default);

    private static UpdatePaymentProfileError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static UpdatePaymentProfileError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value) =>
        _errorStringMapResponseValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorStringMapResponse, TResult> onErrorStringMapResponse,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorStringMapResponse(out var errorStringMapResponseValue) => onErrorStringMapResponse(
                errorStringMapResponseValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdatePaymentProfileError)} holds no value.")
        };

    public void Match(Action<ErrorStringMapResponse> onErrorStringMapResponse,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetErrorStringMapResponse(out var errorStringMapResponseValue)) onErrorStringMapResponse(
            errorStringMapResponseValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdatePaymentProfileError)} holds no value.");
    }

    private static Task<UpdatePaymentProfileError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<ErrorStringMapResponse>().As(AsErrorStringMapResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdatePaymentProfileError> Response { get; } = new(Create);
}
