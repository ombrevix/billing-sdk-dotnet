using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateOfferError : ApiError
{
    private readonly Optional<ErrorArrayMapResponse> _errorArrayMapResponseValue;

    private CreateOfferError(Optional<ErrorArrayMapResponse> errorArrayMapResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorArrayMapResponseValue = errorArrayMapResponseValue;
    }

    private static CreateOfferError AsErrorArrayMapResponse(ErrorArrayMapResponse value) =>
        new(Optional<ErrorArrayMapResponse>.Some(value), default);

    private static CreateOfferError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value) =>
        _errorArrayMapResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorArrayMapResponse, TResult> onErrorArrayMapResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue) => onErrorArrayMapResponse(
                errorArrayMapResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(CreateOfferError)} holds no value.")
        };

    public void Match(Action<ErrorArrayMapResponse> onErrorArrayMapResponse, Action<RawError> otherwise)
    {
        if (TryGetErrorArrayMapResponse(out var errorArrayMapResponseValue)) onErrorArrayMapResponse(
            errorArrayMapResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateOfferError)} holds no value.");
    }

    private static Task<CreateOfferError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<ErrorArrayMapResponse>().As(AsErrorArrayMapResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateOfferError> Response { get; } = new(Create);
}
