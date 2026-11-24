<!-- Generated file — do not edit; regenerated with the SDK. -->

# Customers — operations

Accessor: `client.Customers` · Source: `src/OmbrevixBilling/Api/Customers.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateCustomer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateCustomer(CreateCustomerOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `CustomerResponse`
- **Error**: `ApiException<CreateCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetCustomerErrorResponse([NotNullWhen(true)] out CustomerErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCustomerOperationRequest` | `src/OmbrevixBilling/Requests/Customers/CreateCustomerOperationRequest.cs` |
| `CreateCustomerRequest` | `src/OmbrevixBilling/Models/CreateCustomerRequest.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |
| `CreateCustomerError` | `src/OmbrevixBilling/Errors/CreateCustomerError.cs` |
| `CustomerErrorResponse` | `src/OmbrevixBilling/Models/CustomerErrorResponse.cs` |

### DeleteCustomer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteCustomer(DeleteCustomerRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteCustomerRequest` | `src/OmbrevixBilling/Requests/Customers/DeleteCustomerRequest.cs` |

### ListCustomerSubscriptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCustomerSubscriptions(ListCustomerSubscriptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CustomerId`
- **Returns**: `IReadOnlyList<SubscriptionResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCustomerSubscriptionsRequest` | `src/OmbrevixBilling/Requests/Customers/ListCustomerSubscriptionsRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |

### ListCustomers

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCustomers(ListCustomersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `direction` ← `Direction`, `page` ← `Page`, `per_page` ← `PerPage`, `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `q` ← `Q`
- **Returns**: `IReadOnlyList<CustomerResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCustomersRequest` | `src/OmbrevixBilling/Requests/Customers/ListCustomersRequest.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |

### ReadCustomer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadCustomer(ReadCustomerRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Returns**: `CustomerResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadCustomerRequest` | `src/OmbrevixBilling/Requests/Customers/ReadCustomerRequest.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |

### ReadCustomerByReference

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadCustomerByReference(ReadCustomerByReferenceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Reference`
- **Query params (wire ← C#)**: `reference` ← `Reference`
- **Returns**: `CustomerResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadCustomerByReferenceRequest` | `src/OmbrevixBilling/Requests/Customers/ReadCustomerByReferenceRequest.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |

### UpdateCustomer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateCustomer(UpdateCustomerOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Returns**: `CustomerResponse`
- **Error**: `ApiException<UpdateCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetCustomerErrorResponse([NotNullWhen(true)] out CustomerErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateCustomerOperationRequest` | `src/OmbrevixBilling/Requests/Customers/UpdateCustomerOperationRequest.cs` |
| `UpdateCustomerRequest` | `src/OmbrevixBilling/Models/UpdateCustomerRequest.cs` |
| `CustomerResponse` | `src/OmbrevixBilling/Models/CustomerResponse.cs` |
| `UpdateCustomerError` | `src/OmbrevixBilling/Errors/UpdateCustomerError.cs` |
| `CustomerErrorResponse` | `src/OmbrevixBilling/Models/CustomerErrorResponse.cs` |

