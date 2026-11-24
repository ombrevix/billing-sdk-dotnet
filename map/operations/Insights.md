<!-- Generated file — do not edit; regenerated with the SDK. -->

# Insights — operations

Accessor: `client.Insights` · Source: `src/OmbrevixBilling/Api/Insights.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListMrrPerSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListMrrPerSubscription(ListMrrPerSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `filter` ← `Filter`, `at_time` ← `AtTime`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`
- **Returns**: `SubscriptionMrrResponse`
- **Error**: `ApiException<ListMrrPerSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionsMrrErrorResponse([NotNullWhen(true)] out SubscriptionsMrrErrorResponse? value)` [400] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListMrrPerSubscriptionRequest` | `src/OmbrevixBilling/Requests/Insights/ListMrrPerSubscriptionRequest.cs` |
| `ListMrrFilter` | `src/OmbrevixBilling/Models/ListMrrFilter.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `SubscriptionMrrResponse` | `src/OmbrevixBilling/Models/SubscriptionMrrResponse.cs` |
| `ListMrrPerSubscriptionError` | `src/OmbrevixBilling/Errors/ListMrrPerSubscriptionError.cs` |
| `SubscriptionsMrrErrorResponse` | `src/OmbrevixBilling/Models/SubscriptionsMrrErrorResponse.cs` |

### ListMrrShifts

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListMrrShifts(ListMrrShiftsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `subscription_id` ← `SubscriptionId`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`
- **Returns**: `ListMrrResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListMrrShiftsRequest` | `src/OmbrevixBilling/Requests/Insights/ListMrrShiftsRequest.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListMrrResponse` | `src/OmbrevixBilling/Models/ListMrrResponse.cs` |

### ReadMrr

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadMrr(ReadMrrRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `at_time` ← `AtTime`, `subscription_id` ← `SubscriptionId`
- **Returns**: `MrrResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadMrrRequest` | `src/OmbrevixBilling/Requests/Insights/ReadMrrRequest.cs` |
| `MrrResponse` | `src/OmbrevixBilling/Models/MrrResponse.cs` |

### ReadWorkspaceStats

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadWorkspaceStats(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `WorkspaceSummary`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `WorkspaceSummary` | `src/OmbrevixBilling/Models/WorkspaceSummary.cs` |

