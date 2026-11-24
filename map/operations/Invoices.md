<!-- Generated file — do not edit; regenerated with the SDK. -->

# Invoices — operations

Accessor: `client.Invoices` · Source: `src/OmbrevixBilling/Api/Invoices.cs` · 19 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateInvoice(CreateInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `InvoiceResponse`
- **Error**: `ApiException<CreateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/CreateInvoiceOperationRequest.cs` |
| `CreateInvoiceRequest` | `src/OmbrevixBilling/Models/CreateInvoiceRequest.cs` |
| `InvoiceResponse` | `src/OmbrevixBilling/Models/InvoiceResponse.cs` |
| `CreateInvoiceError` | `src/OmbrevixBilling/Errors/CreateInvoiceError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### DeleteInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteInvoice(DeleteInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [404, 422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteInvoiceRequest` | `src/OmbrevixBilling/Requests/Invoices/DeleteInvoiceRequest.cs` |
| `DeleteInvoiceError` | `src/OmbrevixBilling/Errors/DeleteInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### IssueInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `IssueInvoice(IssueInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<IssueInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `IssueInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/IssueInvoiceOperationRequest.cs` |
| `IssueInvoiceRequest` | `src/OmbrevixBilling/Models/IssueInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `IssueInvoiceError` | `src/OmbrevixBilling/Errors/IssueInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListConsolidatedInvoiceSegments

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListConsolidatedInvoiceSegments(ListConsolidatedInvoiceSegmentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InvoiceUid`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`
- **Returns**: `ConsolidatedInvoice`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListConsolidatedInvoiceSegmentsRequest` | `src/OmbrevixBilling/Requests/Invoices/ListConsolidatedInvoiceSegmentsRequest.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `ConsolidatedInvoice` | `src/OmbrevixBilling/Models/ConsolidatedInvoice.cs` |

### ListCreditNotes

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCreditNotes(ListCreditNotesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `subscription_id` ← `SubscriptionId`, `page` ← `Page`, `per_page` ← `PerPage`, `line_items` ← `LineItems`, `discounts` ← `Discounts`, `taxes` ← `Taxes`, `refunds` ← `Refunds`, `applications` ← `Applications`
- **Returns**: `ListCreditNotesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCreditNotesRequest` | `src/OmbrevixBilling/Requests/Invoices/ListCreditNotesRequest.cs` |
| `ListCreditNotesResponse` | `src/OmbrevixBilling/Models/ListCreditNotesResponse.cs` |

### ListInvoiceEvents

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListInvoiceEvents(ListInvoiceEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `since_date` ← `SinceDate`, `since_id` ← `SinceId`, `page` ← `Page`, `per_page` ← `PerPage`, `invoice_uid` ← `InvoiceUid`, `with_change_invoice_status` ← `WithChangeInvoiceStatus`, `event_types` ← `EventTypes` (comma-separated)
- **Returns**: `ListInvoiceEventsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListInvoiceEventsRequest` | `src/OmbrevixBilling/Requests/Invoices/ListInvoiceEventsRequest.cs` |
| `InvoiceEventType` | `src/OmbrevixBilling/Models/Enums/InvoiceEventType.cs` |
| `ListInvoiceEventsResponse` | `src/OmbrevixBilling/Models/ListInvoiceEventsResponse.cs` |

### ListInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListInvoices(ListInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `status` ← `Status`, `subscription_id` ← `SubscriptionId`, `subscription_bundle_uid` ← `SubscriptionBundleUid`, `consolidation_level` ← `ConsolidationLevel`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`, `line_items` ← `LineItems`, `discounts` ← `Discounts`, `taxes` ← `Taxes`, `credits` ← `Credits`, `payments` ← `Payments`, `custom_fields` ← `CustomFields`, `refunds` ← `Refunds`, `date_field` ← `DateField`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `customer_ids` ← `CustomerIds` (comma-separated), `number` ← `Number` (comma-separated), `product_ids` ← `ProductIds` (comma-separated), `sort` ← `Sort`
- **Returns**: `ListInvoicesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListInvoicesRequest` | `src/OmbrevixBilling/Requests/Invoices/ListInvoicesRequest.cs` |
| `InvoiceStatus` | `src/OmbrevixBilling/Models/Enums/InvoiceStatus.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `InvoiceDateField` | `src/OmbrevixBilling/Models/Enums/InvoiceDateField.cs` |
| `InvoiceSortField` | `src/OmbrevixBilling/Models/Enums/InvoiceSortField.cs` |
| `ListInvoicesResponse` | `src/OmbrevixBilling/Models/ListInvoicesResponse.cs` |

### PreviewCustomerInformationChanges

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewCustomerInformationChanges(PreviewCustomerInformationChangesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `CustomerChangesPreviewResponse`
- **Error**: `ApiException<PreviewCustomerInformationChangesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [404, 422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewCustomerInformationChangesRequest` | `src/OmbrevixBilling/Requests/Invoices/PreviewCustomerInformationChangesRequest.cs` |
| `CustomerChangesPreviewResponse` | `src/OmbrevixBilling/Models/CustomerChangesPreviewResponse.cs` |
| `PreviewCustomerInformationChangesError` | `src/OmbrevixBilling/Errors/PreviewCustomerInformationChangesError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadCreditNote

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadCreditNote(ReadCreditNoteRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `CreditNote`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadCreditNoteRequest` | `src/OmbrevixBilling/Requests/Invoices/ReadCreditNoteRequest.cs` |
| `CreditNote` | `src/OmbrevixBilling/Models/CreditNote.cs` |

### ReadInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadInvoice(ReadInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadInvoiceRequest` | `src/OmbrevixBilling/Requests/Invoices/ReadInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |

### RecordPaymentForInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RecordPaymentForInvoice(RecordPaymentForInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<RecordPaymentForInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RecordPaymentForInvoiceRequest` | `src/OmbrevixBilling/Requests/Invoices/RecordPaymentForInvoiceRequest.cs` |
| `CreateInvoicePaymentRequest` | `src/OmbrevixBilling/Models/CreateInvoicePaymentRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `RecordPaymentForInvoiceError` | `src/OmbrevixBilling/Errors/RecordPaymentForInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### RecordPaymentForMultipleInvoices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RecordPaymentForMultipleInvoices(RecordPaymentForMultipleInvoicesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `MultiInvoicePaymentResponse`
- **Error**: `ApiException<RecordPaymentForMultipleInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RecordPaymentForMultipleInvoicesRequest` | `src/OmbrevixBilling/Requests/Invoices/RecordPaymentForMultipleInvoicesRequest.cs` |
| `CreateMultiInvoicePaymentRequest` | `src/OmbrevixBilling/Models/CreateMultiInvoicePaymentRequest.cs` |
| `MultiInvoicePaymentResponse` | `src/OmbrevixBilling/Models/MultiInvoicePaymentResponse.cs` |
| `RecordPaymentForMultipleInvoicesError` | `src/OmbrevixBilling/Errors/RecordPaymentForMultipleInvoicesError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### RecordPaymentForSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RecordPaymentForSubscription(RecordPaymentForSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `RecordPaymentResponse`
- **Error**: `ApiException<RecordPaymentForSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RecordPaymentForSubscriptionRequest` | `src/OmbrevixBilling/Requests/Invoices/RecordPaymentForSubscriptionRequest.cs` |
| `RecordPaymentRequest` | `src/OmbrevixBilling/Models/RecordPaymentRequest.cs` |
| `RecordPaymentResponse` | `src/OmbrevixBilling/Models/RecordPaymentResponse.cs` |
| `RecordPaymentForSubscriptionError` | `src/OmbrevixBilling/Errors/RecordPaymentForSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### RefundInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RefundInvoice(RefundInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<RefundInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RefundInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/RefundInvoiceOperationRequest.cs` |
| `RefundInvoiceRequest` | `src/OmbrevixBilling/Models/RefundInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `RefundInvoiceError` | `src/OmbrevixBilling/Errors/RefundInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReopenInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReopenInvoice(ReopenInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<ReopenInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReopenInvoiceRequest` | `src/OmbrevixBilling/Requests/Invoices/ReopenInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `ReopenInvoiceError` | `src/OmbrevixBilling/Errors/ReopenInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### SendInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `SendInvoice(SendInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<SendInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `SendInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/SendInvoiceOperationRequest.cs` |
| `SendInvoiceRequest` | `src/OmbrevixBilling/Models/SendInvoiceRequest.cs` |
| `SendInvoiceError` | `src/OmbrevixBilling/Errors/SendInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateCustomerInformation

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateCustomerInformation(UpdateCustomerInformationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<UpdateCustomerInformationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [404, 422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateCustomerInformationRequest` | `src/OmbrevixBilling/Requests/Invoices/UpdateCustomerInformationRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `UpdateCustomerInformationError` | `src/OmbrevixBilling/Errors/UpdateCustomerInformationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateInvoice(UpdateInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Uid`
- **Returns**: `InvoiceResponse`
- **Error**: `ApiException<UpdateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [404] · `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/UpdateInvoiceOperationRequest.cs` |
| `UpdateInvoiceRequest` | `src/OmbrevixBilling/Models/UpdateInvoiceRequest.cs` |
| `InvoiceResponse` | `src/OmbrevixBilling/Models/InvoiceResponse.cs` |
| `UpdateInvoiceError` | `src/OmbrevixBilling/Errors/UpdateInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### VoidInvoice

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `VoidInvoice(VoidInvoiceOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `Invoice`
- **Error**: `ApiException<VoidInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `VoidInvoiceOperationRequest` | `src/OmbrevixBilling/Requests/Invoices/VoidInvoiceOperationRequest.cs` |
| `VoidInvoiceRequest` | `src/OmbrevixBilling/Models/VoidInvoiceRequest.cs` |
| `Invoice` | `src/OmbrevixBilling/Models/Invoice.cs` |
| `VoidInvoiceError` | `src/OmbrevixBilling/Errors/VoidInvoiceError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

