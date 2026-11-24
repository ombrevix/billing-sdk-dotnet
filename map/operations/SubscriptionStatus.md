<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionStatus — operations

Accessor: `client.SubscriptionStatus` · Source: `src/OmbrevixBilling/Api/SubscriptionStatus.cs` · 10 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelDeferredCancellation

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelDeferredCancellation(CancelDeferredCancellationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `DeferredCancellationResponse`
- **Error**: `ApiException<CancelDeferredCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelDeferredCancellationRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/CancelDeferredCancellationRequest.cs` |
| `DeferredCancellationResponse` | `src/OmbrevixBilling/Models/DeferredCancellationResponse.cs` |
| `CancelDeferredCancellationError` | `src/OmbrevixBilling/Errors/CancelDeferredCancellationError.cs` |

### CancelRecovery

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelRecovery(CancelRecoveryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<CancelRecoveryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelRecoveryRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/CancelRecoveryRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `CancelRecoveryError` | `src/OmbrevixBilling/Errors/CancelRecoveryError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CancelSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelSubscription(CancelSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<CancelSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetCancelSubscriptionErrorResponse([NotNullWhen(true)] out CancelSubscriptionErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelSubscriptionRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/CancelSubscriptionRequest.cs` |
| `CancellationRequest` | `src/OmbrevixBilling/Models/CancellationRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `CancelSubscriptionError` | `src/OmbrevixBilling/Errors/CancelSubscriptionError.cs` |
| `CancelSubscriptionErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/CancelSubscriptionErrorResponse.cs` |

### InitiateDeferredCancellation

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `InitiateDeferredCancellation(InitiateDeferredCancellationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `DeferredCancellationResponse`
- **Error**: `ApiException<InitiateDeferredCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `InitiateDeferredCancellationRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/InitiateDeferredCancellationRequest.cs` |
| `CancellationRequest` | `src/OmbrevixBilling/Models/CancellationRequest.cs` |
| `DeferredCancellationResponse` | `src/OmbrevixBilling/Models/DeferredCancellationResponse.cs` |
| `InitiateDeferredCancellationError` | `src/OmbrevixBilling/Errors/InitiateDeferredCancellationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### PauseSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PauseSubscription(PauseSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<PauseSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PauseSubscriptionRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/PauseSubscriptionRequest.cs` |
| `PauseRequest` | `src/OmbrevixBilling/Models/PauseRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `PauseSubscriptionError` | `src/OmbrevixBilling/Errors/PauseSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### PreviewRenewal

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewRenewal(PreviewRenewalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `RenewalPreviewResponse`
- **Error**: `ApiException<PreviewRenewalError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewRenewalRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/PreviewRenewalRequest.cs` |
| `RenewalPreviewRequest` | `src/OmbrevixBilling/Models/RenewalPreviewRequest.cs` |
| `RenewalPreviewResponse` | `src/OmbrevixBilling/Models/RenewalPreviewResponse.cs` |
| `PreviewRenewalError` | `src/OmbrevixBilling/Errors/PreviewRenewalError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReactivateSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReactivateSubscription(ReactivateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<ReactivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReactivateSubscriptionOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/ReactivateSubscriptionOperationRequest.cs` |
| `ReactivateSubscriptionRequest` | `src/OmbrevixBilling/Models/ReactivateSubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `ReactivateSubscriptionError` | `src/OmbrevixBilling/Errors/ReactivateSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ResumeSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ResumeSubscription(ResumeSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `calendar_billing['resumption_charge']` ← `CalendarBillingResumptionCharge`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<ResumeSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ResumeSubscriptionRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/ResumeSubscriptionRequest.cs` |
| `ResumptionCharge` | `src/OmbrevixBilling/Models/Enums/ResumptionCharge.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `ResumeSubscriptionError` | `src/OmbrevixBilling/Errors/ResumeSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### RetrySubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RetrySubscription(RetrySubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<RetrySubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrySubscriptionRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/RetrySubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `RetrySubscriptionError` | `src/OmbrevixBilling/Errors/RetrySubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateAutomaticSubscriptionResumption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateAutomaticSubscriptionResumption(UpdateAutomaticSubscriptionResumptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<UpdateAutomaticSubscriptionResumptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateAutomaticSubscriptionResumptionRequest` | `src/OmbrevixBilling/Requests/SubscriptionStatus/UpdateAutomaticSubscriptionResumptionRequest.cs` |
| `PauseRequest` | `src/OmbrevixBilling/Models/PauseRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `UpdateAutomaticSubscriptionResumptionError` | `src/OmbrevixBilling/Errors/UpdateAutomaticSubscriptionResumptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

