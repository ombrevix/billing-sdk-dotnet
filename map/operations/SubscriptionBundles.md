<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionBundles — operations

Accessor: `client.SubscriptionBundles` · Source: `src/OmbrevixBilling/Api/SubscriptionBundles.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AddSubscriptionToBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `AddSubscriptionToBundle(AddSubscriptionToBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionBundleResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `AddSubscriptionToBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/AddSubscriptionToBundleRequest.cs` |
| `AddSubscriptionToABundle` | `src/OmbrevixBilling/Models/AddSubscriptionToABundle.cs` |
| `SubscriptionBundleResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleResponse.cs` |

### CreateSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSubscriptionBundle(CreateSubscriptionBundleOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `SubscriptionBundleResponse`
- **Error**: `ApiException<CreateSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionBundleCreateErrorResponse([NotNullWhen(true)] out SubscriptionBundleCreateErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionBundleOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/CreateSubscriptionBundleOperationRequest.cs` |
| `CreateSubscriptionBundleRequest` | `src/OmbrevixBilling/Models/CreateSubscriptionBundleRequest.cs` |
| `SubscriptionBundleResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleResponse.cs` |
| `CreateSubscriptionBundleError` | `src/OmbrevixBilling/Errors/CreateSubscriptionBundleError.cs` |
| `SubscriptionBundleCreateErrorResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleCreateErrorResponse.cs` |

### DeleteSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteSubscriptionBundle(DeleteSubscriptionBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `DeleteSubscriptionBundleResponse`
- **Error**: `ApiException<DeleteSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSubscriptionBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/DeleteSubscriptionBundleRequest.cs` |
| `DeleteSubscriptionBundleResponse` | `src/OmbrevixBilling/Models/DeleteSubscriptionBundleResponse.cs` |
| `DeleteSubscriptionBundleError` | `src/OmbrevixBilling/Errors/DeleteSubscriptionBundleError.cs` |

### FindSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `FindSubscriptionBundle(FindSubscriptionBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `subscription_id` ← `SubscriptionId`
- **Returns**: `FullSubscriptionBundleResponse`
- **Error**: `ApiException<FindSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `FindSubscriptionBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/FindSubscriptionBundleRequest.cs` |
| `FullSubscriptionBundleResponse` | `src/OmbrevixBilling/Models/FullSubscriptionBundleResponse.cs` |
| `FindSubscriptionBundleError` | `src/OmbrevixBilling/Errors/FindSubscriptionBundleError.cs` |

### ListSubscriptionBundles

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionBundles(ListSubscriptionBundlesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `include` ← `Include`
- **Returns**: `ListSubscriptionBundlesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSubscriptionBundlesRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/ListSubscriptionBundlesRequest.cs` |
| `SubscriptionBundlesListInclude` | `src/OmbrevixBilling/Models/Enums/SubscriptionBundlesListInclude.cs` |
| `ListSubscriptionBundlesResponse` | `src/OmbrevixBilling/Models/ListSubscriptionBundlesResponse.cs` |

### ReadSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSubscriptionBundle(ReadSubscriptionBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Query params (wire ← C#)**: `include` ← `Include`
- **Returns**: `FullSubscriptionBundleResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadSubscriptionBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/ReadSubscriptionBundleRequest.cs` |
| `SubscriptionBundleInclude` | `src/OmbrevixBilling/Models/Enums/SubscriptionBundleInclude.cs` |
| `FullSubscriptionBundleResponse` | `src/OmbrevixBilling/Models/FullSubscriptionBundleResponse.cs` |

### RemoveSubscriptionFromBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RemoveSubscriptionFromBundle(RemoveSubscriptionFromBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RemoveSubscriptionFromBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RemoveSubscriptionFromBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/RemoveSubscriptionFromBundleRequest.cs` |
| `RemoveSubscriptionFromBundleError` | `src/OmbrevixBilling/Errors/RemoveSubscriptionFromBundleError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### SignupWithSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `SignupWithSubscriptionBundle(SignupWithSubscriptionBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `SubscriptionBundleSignupResponse`
- **Error**: `ApiException<SignupWithSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionBundleSignupErrorResponse([NotNullWhen(true)] out SubscriptionBundleSignupErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `SignupWithSubscriptionBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/SignupWithSubscriptionBundleRequest.cs` |
| `SubscriptionBundleSignupRequest` | `src/OmbrevixBilling/Models/SubscriptionBundleSignupRequest.cs` |
| `SubscriptionBundleSignupResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleSignupResponse.cs` |
| `SignupWithSubscriptionBundleError` | `src/OmbrevixBilling/Errors/SignupWithSubscriptionBundleError.cs` |
| `SubscriptionBundleSignupErrorResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleSignupErrorResponse.cs` |

### UpdateSubscriptionBundleMembers

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateSubscriptionBundleMembers(UpdateSubscriptionBundleMembersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `SubscriptionBundleResponse`
- **Error**: `ApiException<UpdateSubscriptionBundleMembersError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionBundleUpdateErrorResponse([NotNullWhen(true)] out SubscriptionBundleUpdateErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSubscriptionBundleMembersRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundles/UpdateSubscriptionBundleMembersRequest.cs` |
| `UpdateSubscriptionBundleRequest` | `src/OmbrevixBilling/Models/UpdateSubscriptionBundleRequest.cs` |
| `SubscriptionBundleResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleResponse.cs` |
| `UpdateSubscriptionBundleMembersError` | `src/OmbrevixBilling/Errors/UpdateSubscriptionBundleMembersError.cs` |
| `SubscriptionBundleUpdateErrorResponse` | `src/OmbrevixBilling/Models/SubscriptionBundleUpdateErrorResponse.cs` |

