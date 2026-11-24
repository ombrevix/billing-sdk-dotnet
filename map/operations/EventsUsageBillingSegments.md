<!-- Generated file — do not edit; regenerated with the SDK. -->

# EventsUsageBillingSegments — operations

Accessor: `client.EventsUsageBillingSegments` · Source: `src/OmbrevixBilling/Api/EventsUsageBillingSegments.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BulkCreateSegments

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkCreateSegments(BulkCreateSegmentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `ListSegmentsResponse`
- **Error**: `ApiException<BulkCreateSegmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetEventBasedBillingSegment([NotNullWhen(true)] out EventBasedBillingSegment? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BulkCreateSegmentsRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/BulkCreateSegmentsRequest.cs` |
| `BulkCreateSegments` | `src/OmbrevixBilling/Models/BulkCreateSegments.cs` |
| `ListSegmentsResponse` | `src/OmbrevixBilling/Models/ListSegmentsResponse.cs` |
| `BulkCreateSegmentsError` | `src/OmbrevixBilling/Errors/BulkCreateSegmentsError.cs` |
| `EventBasedBillingSegment` | `src/OmbrevixBilling/Models/EventBasedBillingSegment.cs` |

### BulkUpdateSegments

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkUpdateSegments(BulkUpdateSegmentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `ListSegmentsResponse`
- **Error**: `ApiException<BulkUpdateSegmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetEventBasedBillingSegment([NotNullWhen(true)] out EventBasedBillingSegment? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BulkUpdateSegmentsRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/BulkUpdateSegmentsRequest.cs` |
| `BulkUpdateSegments` | `src/OmbrevixBilling/Models/BulkUpdateSegments.cs` |
| `ListSegmentsResponse` | `src/OmbrevixBilling/Models/ListSegmentsResponse.cs` |
| `BulkUpdateSegmentsError` | `src/OmbrevixBilling/Errors/BulkUpdateSegmentsError.cs` |
| `EventBasedBillingSegment` | `src/OmbrevixBilling/Models/EventBasedBillingSegment.cs` |

### CreateSegment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSegment(CreateSegmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `SegmentResponse`
- **Error**: `ApiException<CreateSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetEventBasedBillingSegmentErrors([NotNullWhen(true)] out EventBasedBillingSegmentErrors? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSegmentOperationRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/CreateSegmentOperationRequest.cs` |
| `CreateSegmentRequest` | `src/OmbrevixBilling/Models/CreateSegmentRequest.cs` |
| `SegmentResponse` | `src/OmbrevixBilling/Models/SegmentResponse.cs` |
| `CreateSegmentError` | `src/OmbrevixBilling/Errors/CreateSegmentError.cs` |
| `EventBasedBillingSegmentErrors` | `src/OmbrevixBilling/Models/EventBasedBillingSegmentErrors.cs` |

### DeleteSegment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteSegment(DeleteSegmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`, `Id`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404, 422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSegmentRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/DeleteSegmentRequest.cs` |
| `DeleteSegmentError` | `src/OmbrevixBilling/Errors/DeleteSegmentError.cs` |

### ListSegmentsForPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSegmentsForPriceOption(ListSegmentsForPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`
- **Returns**: `ListSegmentsResponse`
- **Error**: `ApiException<ListSegmentsForPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetEventBasedBillingListSegmentsErrors([NotNullWhen(true)] out EventBasedBillingListSegmentsErrors? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSegmentsForPriceOptionRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/ListSegmentsForPriceOptionRequest.cs` |
| `ListSegmentsFilter` | `src/OmbrevixBilling/Models/ListSegmentsFilter.cs` |
| `ListSegmentsResponse` | `src/OmbrevixBilling/Models/ListSegmentsResponse.cs` |
| `ListSegmentsForPriceOptionError` | `src/OmbrevixBilling/Errors/ListSegmentsForPriceOptionError.cs` |
| `EventBasedBillingListSegmentsErrors` | `src/OmbrevixBilling/Models/EventBasedBillingListSegmentsErrors.cs` |

### UpdateSegment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateSegment(UpdateSegmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`, `Id`
- **Returns**: `SegmentResponse`
- **Error**: `ApiException<UpdateSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetEventBasedBillingSegmentErrors([NotNullWhen(true)] out EventBasedBillingSegmentErrors? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSegmentOperationRequest` | `src/OmbrevixBilling/Requests/EventsUsageBillingSegments/UpdateSegmentOperationRequest.cs` |
| `UpdateSegmentRequest` | `src/OmbrevixBilling/Models/UpdateSegmentRequest.cs` |
| `SegmentResponse` | `src/OmbrevixBilling/Models/SegmentResponse.cs` |
| `UpdateSegmentError` | `src/OmbrevixBilling/Errors/UpdateSegmentError.cs` |
| `EventBasedBillingSegmentErrors` | `src/OmbrevixBilling/Models/EventBasedBillingSegmentErrors.cs` |

