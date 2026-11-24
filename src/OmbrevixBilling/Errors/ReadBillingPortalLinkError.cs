using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ReadBillingPortalLinkError : ApiError
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<TooManyManagementLinkRequestsError> _tooManyManagementLinkRequestsErrorValue;

    private ReadBillingPortalLinkError(Optional<ErrorListResponse> errorListResponseValue,
        Optional<TooManyManagementLinkRequestsError> tooManyManagementLinkRequestsErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorListResponseValue = errorListResponseValue;
        _tooManyManagementLinkRequestsErrorValue = tooManyManagementLinkRequestsErrorValue;
    }

    private static ReadBillingPortalLinkError AsErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    private static ReadBillingPortalLinkError AsTooManyManagementLinkRequestsError(TooManyManagementLinkRequestsError value) =>
        new(default, Optional<TooManyManagementLinkRequestsError>.Some(value), default);

    private static ReadBillingPortalLinkError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetTooManyManagementLinkRequestsError([NotNullWhen(true)] out TooManyManagementLinkRequestsError? value) =>
        _tooManyManagementLinkRequestsErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<TooManyManagementLinkRequestsError, TResult> onTooManyManagementLinkRequestsError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetTooManyManagementLinkRequestsError(
                out var tooManyManagementLinkRequestsErrorValue) => onTooManyManagementLinkRequestsError(
                tooManyManagementLinkRequestsErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ReadBillingPortalLinkError)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<TooManyManagementLinkRequestsError> onTooManyManagementLinkRequestsError,
        Action<RawError> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetTooManyManagementLinkRequestsError(
            out var tooManyManagementLinkRequestsErrorValue)) onTooManyManagementLinkRequestsError(
            tooManyManagementLinkRequestsErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ReadBillingPortalLinkError)} holds no value.");
    }

    private static Task<ReadBillingPortalLinkError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<ErrorListResponse>().As(AsErrorListResponse),
            429 => response.Json<TooManyManagementLinkRequestsError>().As(AsTooManyManagementLinkRequestsError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ReadBillingPortalLinkError> Response { get; } = new(Create);
}
