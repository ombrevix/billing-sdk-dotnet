<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionInvoiceAccount — operations

Accessor: `client.SubscriptionInvoiceAccount` · Source: `src/OmbrevixBilling/Api/SubscriptionInvoiceAccount.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreatePrepayment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreatePrepayment(CreatePrepaymentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `CreatePrepaymentResponse`
- **Error**: `ApiException<CreatePrepaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreatePrepaymentErrorResponse([NotNullWhen(true)] out CreatePrepaymentErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePrepaymentOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/CreatePrepaymentOperationRequest.cs` |
| `CreatePrepaymentRequest` | `src/OmbrevixBilling/Models/CreatePrepaymentRequest.cs` |
| `CreatePrepaymentResponse` | `src/OmbrevixBilling/Models/CreatePrepaymentResponse.cs` |
| `CreatePrepaymentError` | `src/OmbrevixBilling/Errors/CreatePrepaymentError.cs` |
| `CreatePrepaymentErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/CreatePrepaymentErrorResponse.cs` |

### DeductServiceCredit

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeductServiceCredit(DeductServiceCreditOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeductServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeductServiceCreditErrorResponse([NotNullWhen(true)] out DeductServiceCreditErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeductServiceCreditOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/DeductServiceCreditOperationRequest.cs` |
| `DeductServiceCreditRequest` | `src/OmbrevixBilling/Models/DeductServiceCreditRequest.cs` |
| `DeductServiceCreditError` | `src/OmbrevixBilling/Errors/DeductServiceCreditError.cs` |
| `DeductServiceCreditErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/DeductServiceCreditErrorResponse.cs` |

### IssueServiceCredit

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `IssueServiceCredit(IssueServiceCreditOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `ServiceCredit`
- **Error**: `ApiException<IssueServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetIssueServiceCreditErrorResponse([NotNullWhen(true)] out IssueServiceCreditErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `IssueServiceCreditOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/IssueServiceCreditOperationRequest.cs` |
| `IssueServiceCreditRequest` | `src/OmbrevixBilling/Models/IssueServiceCreditRequest.cs` |
| `ServiceCredit` | `src/OmbrevixBilling/Models/ServiceCredit.cs` |
| `IssueServiceCreditError` | `src/OmbrevixBilling/Errors/IssueServiceCreditError.cs` |
| `IssueServiceCreditErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/IssueServiceCreditErrorResponse.cs` |

### ListPrepayments

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListPrepayments(ListPrepaymentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`
- **Returns**: `PrepaymentsResponse`
- **Error**: `ApiException<ListPrepaymentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPrepaymentsRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/ListPrepaymentsRequest.cs` |
| `ListPrepaymentsFilter` | `src/OmbrevixBilling/Models/ListPrepaymentsFilter.cs` |
| `PrepaymentsResponse` | `src/OmbrevixBilling/Models/PrepaymentsResponse.cs` |
| `ListPrepaymentsError` | `src/OmbrevixBilling/Errors/ListPrepaymentsError.cs` |

### ListServiceCredits

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListServiceCredits(ListServiceCreditsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`
- **Returns**: `ListServiceCreditsResponse`
- **Error**: `ApiException<ListServiceCreditsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListServiceCreditsRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/ListServiceCreditsRequest.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListServiceCreditsResponse` | `src/OmbrevixBilling/Models/ListServiceCreditsResponse.cs` |
| `ListServiceCreditsError` | `src/OmbrevixBilling/Errors/ListServiceCreditsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadAccountBalances

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadAccountBalances(ReadAccountBalancesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `AccountBalances`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadAccountBalancesRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/ReadAccountBalancesRequest.cs` |
| `AccountBalances` | `src/OmbrevixBilling/Models/AccountBalances.cs` |

### RefundPrepayment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RefundPrepayment(RefundPrepaymentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `PrepaymentId`
- **Returns**: `PrepaymentResponse`
- **Error**: `ApiException<RefundPrepaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetRefundPrepaymentBaseErrorsResponse([NotNullWhen(true)] out RefundPrepaymentBaseErrorsResponse? value)` [400] · `TryGetString([NotNullWhen(true)] out string? value)` [404] · `TryGetRefundPrepaymentErrorResponse([NotNullWhen(true)] out RefundPrepaymentErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RefundPrepaymentOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionInvoiceAccount/RefundPrepaymentOperationRequest.cs` |
| `RefundPrepaymentRequest` | `src/OmbrevixBilling/Models/RefundPrepaymentRequest.cs` |
| `PrepaymentResponse` | `src/OmbrevixBilling/Models/PrepaymentResponse.cs` |
| `RefundPrepaymentError` | `src/OmbrevixBilling/Errors/RefundPrepaymentError.cs` |
| `RefundPrepaymentBaseErrorsResponse` | `src/OmbrevixBilling/Models/RefundPrepaymentBaseErrorsResponse.cs` |
| `RefundPrepaymentErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/RefundPrepaymentErrorResponse.cs` |

