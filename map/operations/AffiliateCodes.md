<!-- Generated file — do not edit; regenerated with the SDK. -->

# AffiliateCodes — operations

Accessor: `client.AffiliateCodes` · Source: `src/OmbrevixBilling/Api/AffiliateCodes.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ValidateAffiliateCode

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ValidateAffiliateCode(ValidateAffiliateCodeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Code`
- **Query params (wire ← C#)**: `code` ← `Code`
- **Returns**: `AffiliateValidationResponse`
- **Error**: `ApiException<ValidateAffiliateCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleStringErrorResponse([NotNullWhen(true)] out SingleStringErrorResponse? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ValidateAffiliateCodeRequest` | `src/OmbrevixBilling/Requests/AffiliateCodes/ValidateAffiliateCodeRequest.cs` |
| `AffiliateValidationResponse` | `src/OmbrevixBilling/Models/AffiliateValidationResponse.cs` |
| `ValidateAffiliateCodeError` | `src/OmbrevixBilling/Errors/ValidateAffiliateCodeError.cs` |
| `SingleStringErrorResponse` | `src/OmbrevixBilling/Models/SingleStringErrorResponse.cs` |

