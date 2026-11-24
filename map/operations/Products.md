<!-- Generated file — do not edit; regenerated with the SDK. -->

# Products — operations

Accessor: `client.Products` · Source: `src/OmbrevixBilling/Api/Products.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveProduct

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveProduct(ArchiveProductRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<ArchiveProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ArchiveProductRequest` | `src/OmbrevixBilling/Requests/Products/ArchiveProductRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |
| `ArchiveProductError` | `src/OmbrevixBilling/Errors/ArchiveProductError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateProduct

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateProduct(CreateProductRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<CreateProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductRequest` | `src/OmbrevixBilling/Requests/Products/CreateProductRequest.cs` |
| `CreateOrUpdateProductRequest` | `src/OmbrevixBilling/Models/CreateOrUpdateProductRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |
| `CreateProductError` | `src/OmbrevixBilling/Errors/CreateProductError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListProducts

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListProducts(ListProductsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `date_field` ← `DateField`, `filter` ← `Filter`, `end_date` ← `EndDate`, `end_datetime` ← `EndDatetime`, `start_date` ← `StartDate`, `start_datetime` ← `StartDatetime`, `page` ← `Page`, `per_page` ← `PerPage`, `include_archived` ← `IncludeArchived`, `include` ← `Include`
- **Returns**: `IReadOnlyList<ProductResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListProductsRequest` | `src/OmbrevixBilling/Requests/Products/ListProductsRequest.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `ListProductsFilter` | `src/OmbrevixBilling/Models/ListProductsFilter.cs` |
| `ListProductsInclude` | `src/OmbrevixBilling/Models/Enums/ListProductsInclude.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |

### ReadProduct

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadProduct(ReadProductRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadProductRequest` | `src/OmbrevixBilling/Requests/Products/ReadProductRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |

### ReadProductBySlug

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadProductBySlug(ReadProductBySlugRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ApiSlug`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadProductBySlugRequest` | `src/OmbrevixBilling/Requests/Products/ReadProductBySlugRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |

### UpdateProduct

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateProduct(UpdateProductRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<UpdateProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateProductRequest` | `src/OmbrevixBilling/Requests/Products/UpdateProductRequest.cs` |
| `CreateOrUpdateProductRequest` | `src/OmbrevixBilling/Models/CreateOrUpdateProductRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |
| `UpdateProductError` | `src/OmbrevixBilling/Errors/UpdateProductError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

