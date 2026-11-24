using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.OmbrevixGateway;

/// <summary>
/// The inputs of the RequestAccessToken operation.
/// </summary>
public sealed record RequestAccessTokenRequest
{
    public required OmbrevixGatewayOAuthTokenRequest Body { get; init; }
}
