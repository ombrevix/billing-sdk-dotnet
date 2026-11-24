<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionBundleStatus — operations

Accessor: `client.SubscriptionBundleStatus` · Source: `src/OmbrevixBilling/Api/SubscriptionBundleStatus.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelDeferredCancellationForBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelDeferredCancellationForBundle(CancelDeferredCancellationForBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelDeferredCancellationForBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelDeferredCancellationForBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleStatus/CancelDeferredCancellationForBundleRequest.cs` |
| `CancelDeferredCancellationForBundleError` | `src/OmbrevixBilling/Errors/CancelDeferredCancellationForBundleError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CancelSubscriptionsInBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelSubscriptionsInBundle(CancelSubscriptionsInBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelSubscriptionsInBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelSubscriptionsInBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleStatus/CancelSubscriptionsInBundleRequest.cs` |
| `CancelGroupedSubscriptionsRequest` | `src/OmbrevixBilling/Models/CancelGroupedSubscriptionsRequest.cs` |
| `CancelSubscriptionsInBundleError` | `src/OmbrevixBilling/Errors/CancelSubscriptionsInBundleError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### InitiateDeferredCancellationForBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `InitiateDeferredCancellationForBundle(InitiateDeferredCancellationForBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<InitiateDeferredCancellationForBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `InitiateDeferredCancellationForBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleStatus/InitiateDeferredCancellationForBundleRequest.cs` |
| `InitiateDeferredCancellationForBundleError` | `src/OmbrevixBilling/Errors/InitiateDeferredCancellationForBundleError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReactivateSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReactivateSubscriptionBundle(ReactivateSubscriptionBundleOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `ReactivateSubscriptionBundleResponse`
- **Error**: `ApiException<ReactivateSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReactivateSubscriptionBundleOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleStatus/ReactivateSubscriptionBundleOperationRequest.cs` |
| `ReactivateSubscriptionBundleRequest` | `src/OmbrevixBilling/Models/ReactivateSubscriptionBundleRequest.cs` |
| `ReactivateSubscriptionBundleResponse` | `src/OmbrevixBilling/Models/ReactivateSubscriptionBundleResponse.cs` |
| `ReactivateSubscriptionBundleError` | `src/OmbrevixBilling/Errors/ReactivateSubscriptionBundleError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

