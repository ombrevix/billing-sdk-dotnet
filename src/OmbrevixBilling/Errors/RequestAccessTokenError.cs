using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class RequestAccessTokenError : ApiError
{
    private readonly Optional<OmbrevixGatewayOAuthError> _ombrevixGatewayOAuthErrorValue;

    private RequestAccessTokenError(Optional<OmbrevixGatewayOAuthError> ombrevixGatewayOAuthErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _ombrevixGatewayOAuthErrorValue = ombrevixGatewayOAuthErrorValue;
    }

    private static RequestAccessTokenError AsOmbrevixGatewayOAuthError(OmbrevixGatewayOAuthError value) =>
        new(Optional<OmbrevixGatewayOAuthError>.Some(value), default);

    private static RequestAccessTokenError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetOmbrevixGatewayOAuthError([NotNullWhen(true)] out OmbrevixGatewayOAuthError? value) =>
        _ombrevixGatewayOAuthErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<OmbrevixGatewayOAuthError, TResult> onOmbrevixGatewayOAuthError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetOmbrevixGatewayOAuthError(
                out var ombrevixGatewayOAuthErrorValue) => onOmbrevixGatewayOAuthError(ombrevixGatewayOAuthErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(RequestAccessTokenError)} holds no value.")
        };

    public void Match(Action<OmbrevixGatewayOAuthError> onOmbrevixGatewayOAuthError, Action<RawError> otherwise)
    {
        if (TryGetOmbrevixGatewayOAuthError(out var ombrevixGatewayOAuthErrorValue)) onOmbrevixGatewayOAuthError(
            ombrevixGatewayOAuthErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(RequestAccessTokenError)} holds no value.");
    }

    private static Task<RequestAccessTokenError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 => response.Json<OmbrevixGatewayOAuthError>().As(AsOmbrevixGatewayOAuthError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<RequestAccessTokenError> Response { get; } = new(Create);
}
