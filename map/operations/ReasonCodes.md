<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReasonCodes — operations

Accessor: `client.ReasonCodes` · Source: `src/OmbrevixBilling/Api/ReasonCodes.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateReasonCode

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateReasonCode(CreateReasonCodeOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `ReasonCodeResponse`
- **Error**: `ApiException<CreateReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReasonCodeOperationRequest` | `src/OmbrevixBilling/Requests/ReasonCodes/CreateReasonCodeOperationRequest.cs` |
| `CreateReasonCodeRequest` | `src/OmbrevixBilling/Models/CreateReasonCodeRequest.cs` |
| `ReasonCodeResponse` | `src/OmbrevixBilling/Models/ReasonCodeResponse.cs` |
| `CreateReasonCodeError` | `src/OmbrevixBilling/Errors/CreateReasonCodeError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeleteReasonCode

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteReasonCode(DeleteReasonCodeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReasonCodeId`
- **Returns**: `OkResponse`
- **Error**: `ApiException<DeleteReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteReasonCodeRequest` | `src/OmbrevixBilling/Requests/ReasonCodes/DeleteReasonCodeRequest.cs` |
| `OkResponse` | `src/OmbrevixBilling/Models/OkResponse.cs` |
| `DeleteReasonCodeError` | `src/OmbrevixBilling/Errors/DeleteReasonCodeError.cs` |

### ListReasonCodes

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListReasonCodes(ListReasonCodesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `IReadOnlyList<ReasonCodeResponse>`
- **Error**: `ApiException<ListReasonCodesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListReasonCodesRequest` | `src/OmbrevixBilling/Requests/ReasonCodes/ListReasonCodesRequest.cs` |
| `ReasonCodeResponse` | `src/OmbrevixBilling/Models/ReasonCodeResponse.cs` |
| `ListReasonCodesError` | `src/OmbrevixBilling/Errors/ListReasonCodesError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadReasonCode

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadReasonCode(ReadReasonCodeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReasonCodeId`
- **Returns**: `ReasonCodeResponse`
- **Error**: `ApiException<ReadReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadReasonCodeRequest` | `src/OmbrevixBilling/Requests/ReasonCodes/ReadReasonCodeRequest.cs` |
| `ReasonCodeResponse` | `src/OmbrevixBilling/Models/ReasonCodeResponse.cs` |
| `ReadReasonCodeError` | `src/OmbrevixBilling/Errors/ReadReasonCodeError.cs` |

### UpdateReasonCode

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateReasonCode(UpdateReasonCodeOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReasonCodeId`
- **Returns**: `ReasonCodeResponse`
- **Error**: `ApiException<UpdateReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateReasonCodeOperationRequest` | `src/OmbrevixBilling/Requests/ReasonCodes/UpdateReasonCodeOperationRequest.cs` |
| `UpdateReasonCodeRequest` | `src/OmbrevixBilling/Models/UpdateReasonCodeRequest.cs` |
| `ReasonCodeResponse` | `src/OmbrevixBilling/Models/ReasonCodeResponse.cs` |
| `UpdateReasonCodeError` | `src/OmbrevixBilling/Errors/UpdateReasonCodeError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

