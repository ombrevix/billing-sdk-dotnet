<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionBundleInvoiceAccount — operations

Accessor: `client.SubscriptionBundleInvoiceAccount` · Source: `src/OmbrevixBilling/Api/SubscriptionBundleInvoiceAccount.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateSubscriptionBundlePrepayment

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSubscriptionBundlePrepayment(CreateSubscriptionBundlePrepaymentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `SubscriptionBundlePrepaymentResponse`
- **Error**: `ApiException<CreateSubscriptionBundlePrepaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionBundlePrepaymentRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleInvoiceAccount/CreateSubscriptionBundlePrepaymentRequest.cs` |
| `SubscriptionBundlePrepaymentRequest` | `src/OmbrevixBilling/Models/SubscriptionBundlePrepaymentRequest.cs` |
| `SubscriptionBundlePrepaymentResponse` | `src/OmbrevixBilling/Models/SubscriptionBundlePrepaymentResponse.cs` |
| `CreateSubscriptionBundlePrepaymentError` | `src/OmbrevixBilling/Errors/CreateSubscriptionBundlePrepaymentError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeductSubscriptionBundleServiceCredit

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeductSubscriptionBundleServiceCredit(DeductSubscriptionBundleServiceCreditRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `ServiceCredit`
- **Error**: `ApiException<DeductSubscriptionBundleServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeductSubscriptionBundleServiceCreditRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleInvoiceAccount/DeductSubscriptionBundleServiceCreditRequest.cs` |
| `DeductServiceCreditRequest` | `src/OmbrevixBilling/Models/DeductServiceCreditRequest.cs` |
| `ServiceCredit` | `src/OmbrevixBilling/Models/ServiceCredit.cs` |
| `DeductSubscriptionBundleServiceCreditError` | `src/OmbrevixBilling/Errors/DeductSubscriptionBundleServiceCreditError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### IssueSubscriptionBundleServiceCredit

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `IssueSubscriptionBundleServiceCredit(IssueSubscriptionBundleServiceCreditRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Returns**: `ServiceCreditResponse`
- **Error**: `ApiException<IssueSubscriptionBundleServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `IssueSubscriptionBundleServiceCreditRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleInvoiceAccount/IssueSubscriptionBundleServiceCreditRequest.cs` |
| `IssueServiceCreditRequest` | `src/OmbrevixBilling/Models/IssueServiceCreditRequest.cs` |
| `ServiceCreditResponse` | `src/OmbrevixBilling/Models/ServiceCreditResponse.cs` |
| `IssueSubscriptionBundleServiceCreditError` | `src/OmbrevixBilling/Errors/IssueSubscriptionBundleServiceCreditError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListPrepaymentsForSubscriptionBundle

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListPrepaymentsForSubscriptionBundle(ListPrepaymentsForSubscriptionBundleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`
- **Returns**: `ListSubscriptionBundlePrepaymentResponse`
- **Error**: `ApiException<ListPrepaymentsForSubscriptionBundleError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPrepaymentsForSubscriptionBundleRequest` | `src/OmbrevixBilling/Requests/SubscriptionBundleInvoiceAccount/ListPrepaymentsForSubscriptionBundleRequest.cs` |
| `ListPrepaymentsFilter` | `src/OmbrevixBilling/Models/ListPrepaymentsFilter.cs` |
| `ListSubscriptionBundlePrepaymentResponse` | `src/OmbrevixBilling/Models/ListSubscriptionBundlePrepaymentResponse.cs` |
| `ListPrepaymentsForSubscriptionBundleError` | `src/OmbrevixBilling/Errors/ListPrepaymentsForSubscriptionBundleError.cs` |

