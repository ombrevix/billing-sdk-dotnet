<!-- Generated file — do not edit; regenerated with the SDK. -->

# AdvanceInvoice — operations

Accessor: `client.AdvanceInvoice` · Source: `src/OmbrevixBilling/Api/AdvanceInvoice.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### IssueAdvanceInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `IssueAdvanceInvoice(IssueAdvanceInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `Invoice`
- **Error**: `ApiException<IssueAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `IssueAdvanceInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/AdvanceInvoice/IssueAdvanceInvoiceOperationRequest.cs` |
| `IssueAdvanceInvoiceRequest` | `src/OmbrevixBilling/Models/IssueAdvanceInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `IssueAdvanceInvoiceError` | `src/OmbrevixBilling/Errors/IssueAdvanceInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadAdvanceInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadAdvanceInvoice(ReadAdvanceInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `Invoice`
- **Error**: `ApiException<ReadAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadAdvanceInvoiceRequest` | `src/OmbrevixBilling/Requests/AdvanceInvoice/ReadAdvanceInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `ReadAdvanceInvoiceError` | `src/OmbrevixBilling/Errors/ReadAdvanceInvoiceError.cs` |

### VoidAdvanceInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `VoidAdvanceInvoice(VoidAdvanceInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `Invoice`
- **Error**: `ApiException<VoidAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `VoidAdvanceInvoiceRequest` | `src/OmbrevixBilling/Requests/AdvanceInvoice/VoidAdvanceInvoiceRequest.cs` |
| `VoidInvoiceRequest` | `src/OmbrevixBilling/Models/VoidInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `VoidAdvanceInvoiceError` | `src/OmbrevixBilling/Errors/VoidAdvanceInvoiceError.cs` |

