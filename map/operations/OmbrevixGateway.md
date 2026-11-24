<!-- Generated file — do not edit; regenerated with the SDK. -->

# OmbrevixGateway — operations

Accessor: `client.OmbrevixGateway` · Source: `src/OmbrevixBilling/Api/OmbrevixGateway.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### RequestAccessToken

- **Server group**: `Oauth`
- **Signature**: `RequestAccessToken(RequestAccessTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `OmbrevixGatewayOAuthAccessToken`
- **Error**: `ApiException<RequestAccessTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetOmbrevixGatewayOAuthError([NotNullWhen(true)] out OmbrevixGatewayOAuthError? value)` [400, 401] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RequestAccessTokenRequest` | `src/OmbrevixBilling/Requests/OmbrevixGateway/RequestAccessTokenRequest.cs` |
| `OmbrevixGatewayOAuthTokenRequest` | `src/OmbrevixBilling/Models/OmbrevixGatewayOAuthTokenRequest.cs` |
| `OmbrevixGatewayOAuthAccessToken` | `src/OmbrevixBilling/Models/OmbrevixGatewayOAuthAccessToken.cs` |
| `RequestAccessTokenError` | `src/OmbrevixBilling/Errors/RequestAccessTokenError.cs` |
| `OmbrevixGatewayOAuthError` | `src/OmbrevixBilling/Models/OmbrevixGatewayOAuthError.cs` |

