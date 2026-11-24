<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductLineups — operations

Accessor: `client.ProductLineups` · Source: `src/OmbrevixBilling/Api/ProductLineups.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateProductLineup

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateProductLineup(CreateProductLineupOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `ProductLineupResponse`
- **Error**: `ApiException<CreateProductLineupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductLineupOperationRequest` | `src/OmbrevixBilling/Requests/ProductLineups/CreateProductLineupOperationRequest.cs` |
| `CreateProductLineupRequest` | `src/OmbrevixBilling/Models/CreateProductLineupRequest.cs` |
| `ProductLineupResponse` | `src/OmbrevixBilling/Models/ProductLineupResponse.cs` |
| `CreateProductLineupError` | `src/OmbrevixBilling/Errors/CreateProductLineupError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListProductLineups

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListProductLineups(ListProductLineupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`
- **Returns**: `IReadOnlyList<ProductLineupResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListProductLineupsRequest` | `src/OmbrevixBilling/Requests/ProductLineups/ListProductLineupsRequest.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `ProductLineupResponse` | `src/OmbrevixBilling/Models/ProductLineupResponse.cs` |

### ListProductsForProductLineup

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListProductsForProductLineup(ListProductsForProductLineupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `date_field` ← `DateField`, `filter` ← `Filter`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `include_archived` ← `IncludeArchived`, `include` ← `Include`
- **Returns**: `IReadOnlyList<ProductResponse>`
- **Error**: `ApiException<ListProductsForProductLineupError>` — **Case A (typed)**
- **Error accessors**: `TryGetString([NotNullWhen(true)] out string? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListProductsForProductLineupRequest` | `src/OmbrevixBilling/Requests/ProductLineups/ListProductsForProductLineupRequest.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `ListProductsFilter` | `src/OmbrevixBilling/Models/ListProductsFilter.cs` |
| `ListProductsInclude` | `src/OmbrevixBilling/Models/Enums/ListProductsInclude.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |
| `ListProductsForProductLineupError` | `src/OmbrevixBilling/Errors/ListProductsForProductLineupError.cs` |

### ReadProductLineup

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadProductLineup(ReadProductLineupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Returns**: `ProductLineupResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadProductLineupRequest` | `src/OmbrevixBilling/Requests/ProductLineups/ReadProductLineupRequest.cs` |
| `ProductLineupResponse` | `src/OmbrevixBilling/Models/ProductLineupResponse.cs` |

