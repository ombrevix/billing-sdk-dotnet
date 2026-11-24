<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductPriceOptions — operations

Accessor: `client.ProductPriceOptions` · Source: `src/OmbrevixBilling/Api/ProductPriceOptions.cs` · 11 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveProductPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveProductPriceOption(ArchiveProductPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`, `PriceOptionId`
- **Returns**: `ProductPriceOptionResponse`
- **Error**: `ApiException<ArchiveProductPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ArchiveProductPriceOptionRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/ArchiveProductPriceOptionRequest.cs` |
| `ProductIdModel` | `src/OmbrevixBilling/Models/AnyOf/ProductIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `ProductPriceOptionResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionResponse.cs` |
| `ArchiveProductPriceOptionError` | `src/OmbrevixBilling/Errors/ArchiveProductPriceOptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### BulkCreateProductPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkCreateProductPriceOptions(BulkCreateProductPriceOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Returns**: `BulkCreateProductPriceOptionsResponse`
- **Error**: `ApiException<BulkCreateProductPriceOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetMapOfJsonElement([NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BulkCreateProductPriceOptionsOperationRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/BulkCreateProductPriceOptionsOperationRequest.cs` |
| `BulkCreateProductPriceOptionsRequest` | `src/OmbrevixBilling/Models/BulkCreateProductPriceOptionsRequest.cs` |
| `BulkCreateProductPriceOptionsResponse` | `src/OmbrevixBilling/Models/BulkCreateProductPriceOptionsResponse.cs` |
| `BulkCreateProductPriceOptionsError` | `src/OmbrevixBilling/Errors/BulkCreateProductPriceOptionsError.cs` |

### CreateProductCurrencyPrices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateProductCurrencyPrices(CreateProductCurrencyPricesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductPriceOptionId`
- **Returns**: `CurrencyPricesResponse`
- **Error**: `ApiException<CreateProductCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductCurrencyPricesOperationRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/CreateProductCurrencyPricesOperationRequest.cs` |
| `CreateProductCurrencyPricesRequest` | `src/OmbrevixBilling/Models/CreateProductCurrencyPricesRequest.cs` |
| `CurrencyPricesResponse` | `src/OmbrevixBilling/Models/CurrencyPricesResponse.cs` |
| `CreateProductCurrencyPricesError` | `src/OmbrevixBilling/Errors/CreateProductCurrencyPricesError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### CreateProductPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateProductPriceOption(CreateProductPriceOptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Returns**: `ProductPriceOptionResponse`
- **Error**: `ApiException<CreateProductPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetProductPriceOptionErrorResponse([NotNullWhen(true)] out ProductPriceOptionErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductPriceOptionOperationRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/CreateProductPriceOptionOperationRequest.cs` |
| `ProductIdModel` | `src/OmbrevixBilling/Models/AnyOf/ProductIdModel.cs` |
| `CreateProductPriceOptionRequest` | `src/OmbrevixBilling/Models/CreateProductPriceOptionRequest.cs` |
| `ProductPriceOptionResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionResponse.cs` |
| `CreateProductPriceOptionError` | `src/OmbrevixBilling/Errors/CreateProductPriceOptionError.cs` |
| `ProductPriceOptionErrorResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionErrorResponse.cs` |

### ListAllProductPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListAllProductPriceOptions(ListAllProductPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `direction` ← `Direction`, `filter` ← `Filter`, `include` ← `Include`, `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `ListProductPriceOptionsResponse`
- **Error**: `ApiException<ListAllProductPriceOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAllProductPriceOptionsRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/ListAllProductPriceOptionsRequest.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListPriceOptionsFilter` | `src/OmbrevixBilling/Models/ListPriceOptionsFilter.cs` |
| `ListProductsPriceOptionsInclude` | `src/OmbrevixBilling/Models/Enums/ListProductsPriceOptionsInclude.cs` |
| `ListProductPriceOptionsResponse` | `src/OmbrevixBilling/Models/ListProductPriceOptionsResponse.cs` |
| `ListAllProductPriceOptionsError` | `src/OmbrevixBilling/Errors/ListAllProductPriceOptionsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListProductPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListProductPriceOptions(ListProductPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `currency_prices` ← `CurrencyPrices`, `filter[type]` ← `FilterType` (comma-separated), `archived` ← `Archived`
- **Returns**: `ListProductPriceOptionsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListProductPriceOptionsRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/ListProductPriceOptionsRequest.cs` |
| `ProductIdModel` | `src/OmbrevixBilling/Models/AnyOf/ProductIdModel.cs` |
| `PriceOptionType` | `src/OmbrevixBilling/Models/Enums/PriceOptionType.cs` |
| `ListProductPriceOptionsResponse` | `src/OmbrevixBilling/Models/ListProductPriceOptionsResponse.cs` |

### PromoteProductPriceOptionToDefault

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PromoteProductPriceOptionToDefault(PromoteProductPriceOptionToDefaultRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`, `PriceOptionId`
- **Returns**: `ProductResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `PromoteProductPriceOptionToDefaultRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/PromoteProductPriceOptionToDefaultRequest.cs` |
| `ProductResponse` | `src/OmbrevixBilling/Models/ProductResponse.cs` |

### ReadProductPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadProductPriceOption(ReadProductPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`, `PriceOptionId`
- **Query params (wire ← C#)**: `currency_prices` ← `CurrencyPrices`
- **Returns**: `ProductPriceOptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadProductPriceOptionRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/ReadProductPriceOptionRequest.cs` |
| `ProductIdModel` | `src/OmbrevixBilling/Models/AnyOf/ProductIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `ProductPriceOptionResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionResponse.cs` |

### UnarchiveProductPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UnarchiveProductPriceOption(UnarchiveProductPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`, `PriceOptionId`
- **Returns**: `ProductPriceOptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UnarchiveProductPriceOptionRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/UnarchiveProductPriceOptionRequest.cs` |
| `ProductPriceOptionResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionResponse.cs` |

### UpdateProductCurrencyPrices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateProductCurrencyPrices(UpdateProductCurrencyPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductPriceOptionId`
- **Returns**: `CurrencyPricesResponse`
- **Error**: `ApiException<UpdateProductCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateProductCurrencyPricesRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/UpdateProductCurrencyPricesRequest.cs` |
| `UpdateCurrencyPricesRequest` | `src/OmbrevixBilling/Models/UpdateCurrencyPricesRequest.cs` |
| `CurrencyPricesResponse` | `src/OmbrevixBilling/Models/CurrencyPricesResponse.cs` |
| `UpdateProductCurrencyPricesError` | `src/OmbrevixBilling/Errors/UpdateProductCurrencyPricesError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### UpdateProductPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateProductPriceOption(UpdateProductPriceOptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductId`, `PriceOptionId`
- **Returns**: `ProductPriceOptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateProductPriceOptionOperationRequest` | `src/OmbrevixBilling/Requests/ProductPriceOptions/UpdateProductPriceOptionOperationRequest.cs` |
| `ProductIdModel` | `src/OmbrevixBilling/Models/AnyOf/ProductIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `UpdateProductPriceOptionRequest` | `src/OmbrevixBilling/Models/UpdateProductPriceOptionRequest.cs` |
| `ProductPriceOptionResponse` | `src/OmbrevixBilling/Models/ProductPriceOptionResponse.cs` |

