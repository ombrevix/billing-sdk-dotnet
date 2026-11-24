<!-- Generated file — do not edit; regenerated with the SDK. -->

# ApiExports — operations

Accessor: `client.ApiExports` · Source: `src/OmbrevixBilling/Api/ApiExports.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ExportEstimateInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ExportEstimateInvoices(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ExportEstimateInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [409] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ExportEstimateInvoicesError` | `src/OmbrevixBilling/Errors/ExportEstimateInvoicesError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### ExportInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ExportInvoices(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ExportInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [409] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ExportInvoicesError` | `src/OmbrevixBilling/Errors/ExportInvoicesError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### ExportSubscriptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ExportSubscriptions(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ExportSubscriptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [409] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ExportSubscriptionsError` | `src/OmbrevixBilling/Errors/ExportSubscriptionsError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### ListExportedEstimateInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListExportedEstimateInvoices(ListExportedEstimateInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Query params (wire ← C#)**: `per_page` ← `PerPage`, `page` ← `Page`
- **Returns**: `IReadOnlyList<EstimateInvoice>`
- **Error**: `ApiException<ListExportedEstimateInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListExportedEstimateInvoicesRequest` | `src/OmbrevixBilling/Requests/ApiExports/ListExportedEstimateInvoicesRequest.cs` |
| `EstimateInvoice` | `src/OmbrevixBilling/Models/EstimateInvoice.cs` |
| `ListExportedEstimateInvoicesError` | `src/OmbrevixBilling/Errors/ListExportedEstimateInvoicesError.cs` |

### ListExportedInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListExportedInvoices(ListExportedInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Query params (wire ← C#)**: `per_page` ← `PerPage`, `page` ← `Page`
- **Returns**: `IReadOnlyList<Invoice>`
- **Error**: `ApiException<ListExportedInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListExportedInvoicesRequest` | `src/OmbrevixBilling/Requests/ApiExports/ListExportedInvoicesRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `ListExportedInvoicesError` | `src/OmbrevixBilling/Errors/ListExportedInvoicesError.cs` |

### ListExportedSubscriptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListExportedSubscriptions(ListExportedSubscriptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Query params (wire ← C#)**: `per_page` ← `PerPage`, `page` ← `Page`
- **Returns**: `IReadOnlyList<Subscription>`
- **Error**: `ApiException<ListExportedSubscriptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListExportedSubscriptionsRequest` | `src/OmbrevixBilling/Requests/ApiExports/ListExportedSubscriptionsRequest.cs` |
| `Subscription` | `src/OmbrevixBilling/Models/Subscription.cs` |
| `ListExportedSubscriptionsError` | `src/OmbrevixBilling/Errors/ListExportedSubscriptionsError.cs` |

### ReadEstimateInvoicesExport

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadEstimateInvoicesExport(ReadEstimateInvoicesExportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ReadEstimateInvoicesExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadEstimateInvoicesExportRequest` | `src/OmbrevixBilling/Requests/ApiExports/ReadEstimateInvoicesExportRequest.cs` |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ReadEstimateInvoicesExportError` | `src/OmbrevixBilling/Errors/ReadEstimateInvoicesExportError.cs` |

### ReadInvoicesExport

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadInvoicesExport(ReadInvoicesExportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ReadInvoicesExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadInvoicesExportRequest` | `src/OmbrevixBilling/Requests/ApiExports/ReadInvoicesExportRequest.cs` |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ReadInvoicesExportError` | `src/OmbrevixBilling/Errors/ReadInvoicesExportError.cs` |

### ReadSubscriptionsExport

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSubscriptionsExport(ReadSubscriptionsExportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BatchId`
- **Returns**: `BatchJobResponse`
- **Error**: `ApiException<ReadSubscriptionsExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadSubscriptionsExportRequest` | `src/OmbrevixBilling/Requests/ApiExports/ReadSubscriptionsExportRequest.cs` |
| `BatchJobResponse` | `src/OmbrevixBilling/Models/BatchJobResponse.cs` |
| `ReadSubscriptionsExportError` | `src/OmbrevixBilling/Errors/ReadSubscriptionsExportError.cs` |

