<!-- Generated file — do not edit; regenerated with the SDK. -->

# BillingPortal — operations

Accessor: `client.BillingPortal` · Source: `src/OmbrevixBilling/Api/BillingPortal.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### EnableBillingPortalForCustomer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `EnableBillingPortalForCustomer(EnableBillingPortalForCustomerRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CustomerId`
- **Query params (wire ← C#)**: `auto_invite` ← `AutoInvite`
- **Returns**: `CustomerResponse`
- **Error**: `ApiException<EnableBillingPortalForCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `EnableBillingPortalForCustomerRequest` | `src/OmbrevixBilling/Requests/BillingPortal/EnableBillingPortalForCustomerRequest.cs` |
| `AutoInvite` | `src/OmbrevixBilling/Models/Enums/AutoInvite.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |
| `EnableBillingPortalForCustomerError` | `src/OmbrevixBilling/Errors/EnableBillingPortalForCustomerError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadBillingPortalLink

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadBillingPortalLink(ReadBillingPortalLinkRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CustomerId`
- **Returns**: `PortalManagementLink`
- **Error**: `ApiException<ReadBillingPortalLinkError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetTooManyManagementLinkRequestsError([NotNullWhen(true)] out TooManyManagementLinkRequestsError? value)` [429] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadBillingPortalLinkRequest` | `src/OmbrevixBilling/Requests/BillingPortal/ReadBillingPortalLinkRequest.cs` |
| `PortalManagementLink` | `src/OmbrevixBilling/Models/PortalManagementLink.cs` |
| `ReadBillingPortalLinkError` | `src/OmbrevixBilling/Errors/ReadBillingPortalLinkError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |
| `TooManyManagementLinkRequestsError` | `src/OmbrevixBilling/Models/TooManyManagementLinkRequestsError.cs` |

### ResendBillingPortalInvitation

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ResendBillingPortalInvitation(ResendBillingPortalInvitationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CustomerId`
- **Returns**: `ResentInvitation`
- **Error**: `ApiException<ResendBillingPortalInvitationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ResendBillingPortalInvitationRequest` | `src/OmbrevixBilling/Requests/BillingPortal/ResendBillingPortalInvitationRequest.cs` |
| `ResentInvitation` | `src/OmbrevixBilling/Models/ResentInvitation.cs` |
| `ResendBillingPortalInvitationError` | `src/OmbrevixBilling/Errors/ResendBillingPortalInvitationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### RevokeBillingPortalAccess

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RevokeBillingPortalAccess(RevokeBillingPortalAccessRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CustomerId`
- **Returns**: `RevokedInvitation`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `RevokeBillingPortalAccessRequest` | `src/OmbrevixBilling/Requests/BillingPortal/RevokeBillingPortalAccessRequest.cs` |
| `RevokedInvitation` | `src/OmbrevixBilling/Models/RevokedInvitation.cs` |

