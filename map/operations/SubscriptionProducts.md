<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionProducts — operations

Accessor: `client.SubscriptionProducts` · Source: `src/OmbrevixBilling/Api/SubscriptionProducts.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### PreviewSubscriptionProductTransition

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewSubscriptionProductTransition(PreviewSubscriptionProductTransitionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionTransitionPreviewResponse`
- **Error**: `ApiException<PreviewSubscriptionProductTransitionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewSubscriptionProductTransitionRequest` | `src/OmbrevixBilling/Requests/SubscriptionProducts/PreviewSubscriptionProductTransitionRequest.cs` |
| `SubscriptionTransitionPreviewRequest` | `src/OmbrevixBilling/Models/SubscriptionTransitionPreviewRequest.cs` |
| `SubscriptionTransitionPreviewResponse` | `src/OmbrevixBilling/Models/SubscriptionTransitionPreviewResponse.cs` |
| `PreviewSubscriptionProductTransitionError` | `src/OmbrevixBilling/Errors/PreviewSubscriptionProductTransitionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### TransitionSubscriptionProduct

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `TransitionSubscriptionProduct(TransitionSubscriptionProductRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<TransitionSubscriptionProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `TransitionSubscriptionProductRequest` | `src/OmbrevixBilling/Requests/SubscriptionProducts/TransitionSubscriptionProductRequest.cs` |
| `SubscriptionProductTransitionRequest` | `src/OmbrevixBilling/Models/SubscriptionProductTransitionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `TransitionSubscriptionProductError` | `src/OmbrevixBilling/Errors/TransitionSubscriptionProductError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

