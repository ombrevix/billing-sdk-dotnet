<!-- Generated file — do not edit; regenerated with the SDK. -->

# EstimateInvoices — operations

Accessor: `client.EstimateInvoices` · Source: `src/OmbrevixBilling/Api/EstimateInvoices.cs` · 10 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateConsolidatedEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateConsolidatedEstimateInvoice(CreateConsolidatedEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CreateConsolidatedEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateConsolidatedEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/CreateConsolidatedEstimateInvoiceRequest.cs` |
| `CreateConsolidatedEstimateInvoiceError` | `src/OmbrevixBilling/Errors/CreateConsolidatedEstimateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateEstimateInvoice(CreateEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<CreateEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/CreateEstimateInvoiceRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `CreateEstimateInvoiceError` | `src/OmbrevixBilling/Errors/CreateEstimateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateSignupEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSignupEstimateInvoice(CreateSignupEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<CreateSignupEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetEstimateBadRequestErrorResponse([NotNullWhen(true)] out EstimateBadRequestErrorResponse? value)` [400] · `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSignupEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/CreateSignupEstimateInvoiceRequest.cs` |
| `CreateSubscriptionRequest` | `src/OmbrevixBilling/Models/CreateSubscriptionRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `CreateSignupEstimateInvoiceError` | `src/OmbrevixBilling/Errors/CreateSignupEstimateInvoiceError.cs` |
| `EstimateBadRequestErrorResponse` | `src/OmbrevixBilling/Models/EstimateBadRequestErrorResponse.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### DeliverEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeliverEstimateInvoice(DeliverEstimateInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `EstimateInvoiceUid`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<DeliverEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeliverEstimateInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/DeliverEstimateInvoiceOperationRequest.cs` |
| `DeliverEstimateInvoiceRequest` | `src/OmbrevixBilling/Models/DeliverEstimateInvoiceRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `DeliverEstimateInvoiceError` | `src/OmbrevixBilling/Errors/DeliverEstimateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListEstimateInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListEstimateInvoices(ListEstimateInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `status` ← `Status`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`, `line_items` ← `LineItems`, `discounts` ← `Discounts`, `taxes` ← `Taxes`, `credits` ← `Credits`, `payments` ← `Payments`, `custom_fields` ← `CustomFields`
- **Returns**: `ListEstimateInvoicesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListEstimateInvoicesRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/ListEstimateInvoicesRequest.cs` |
| `EstimateInvoiceStatus` | `src/OmbrevixBilling/Models/Enums/EstimateInvoiceStatus.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `ListEstimateInvoicesResponse` | `src/OmbrevixBilling/Models/ListEstimateInvoicesResponse.cs` |

### ListSubscriptionBundleEstimateInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionBundleEstimateInvoices(ListSubscriptionBundleEstimateInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Query params (wire ← C#)**: `line_items` ← `LineItems`, `discounts` ← `Discounts`, `taxes` ← `Taxes`, `credits` ← `Credits`, `payments` ← `Payments`, `custom_fields` ← `CustomFields`
- **Returns**: `ListEstimateInvoicesResponse`
- **Error**: `ApiException<ListSubscriptionBundleEstimateInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSubscriptionBundleEstimateInvoicesRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/ListSubscriptionBundleEstimateInvoicesRequest.cs` |
| `ListEstimateInvoicesResponse` | `src/OmbrevixBilling/Models/ListEstimateInvoicesResponse.cs` |
| `ListSubscriptionBundleEstimateInvoicesError` | `src/OmbrevixBilling/Errors/ListSubscriptionBundleEstimateInvoicesError.cs` |

### PreviewEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewEstimateInvoice(PreviewEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<PreviewEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/PreviewEstimateInvoiceRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `PreviewEstimateInvoiceError` | `src/OmbrevixBilling/Errors/PreviewEstimateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### PreviewSignupEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewSignupEstimateInvoice(PreviewSignupEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `include` ← `Include`
- **Returns**: `SignupEstimatePreviewResponse`
- **Error**: `ApiException<PreviewSignupEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetEstimateBadRequestErrorResponse([NotNullWhen(true)] out EstimateBadRequestErrorResponse? value)` [400] · `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewSignupEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/PreviewSignupEstimateInvoiceRequest.cs` |
| `CreateSignupEstimatePreviewInclude` | `src/OmbrevixBilling/Models/Enums/CreateSignupEstimatePreviewInclude.cs` |
| `CreateSubscriptionRequest` | `src/OmbrevixBilling/Models/CreateSubscriptionRequest.cs` |
| `SignupEstimatePreviewResponse` | `src/OmbrevixBilling/Models/SignupEstimatePreviewResponse.cs` |
| `PreviewSignupEstimateInvoiceError` | `src/OmbrevixBilling/Errors/PreviewSignupEstimateInvoiceError.cs` |
| `EstimateBadRequestErrorResponse` | `src/OmbrevixBilling/Models/EstimateBadRequestErrorResponse.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### ReadEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadEstimateInvoice(ReadEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `EstimateInvoiceUid`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<ReadEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/ReadEstimateInvoiceRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `ReadEstimateInvoiceError` | `src/OmbrevixBilling/Errors/ReadEstimateInvoiceError.cs` |

### VoidEstimateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `VoidEstimateInvoice(VoidEstimateInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `EstimateInvoiceUid`
- **Returns**: `EstimateInvoice`
- **Error**: `ApiException<VoidEstimateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `VoidEstimateInvoiceRequest` | `src/OmbrevixBilling/Requests/EstimateInvoices/VoidEstimateInvoiceRequest.cs` |
| `VoidInvoiceRequest` | `src/OmbrevixBilling/Models/VoidInvoiceRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `VoidEstimateInvoiceError` | `src/OmbrevixBilling/Errors/VoidEstimateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

