<!-- Generated file — do not edit; regenerated with the SDK. -->

# AddonPriceOptions — operations

Accessor: `client.AddonPriceOptions` · Source: `src/OmbrevixBilling/Api/AddonPriceOptions.cs` · 12 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveAddonPriceOption(ArchiveAddonPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `AddonPriceOptionResponse`
- **Error**: `ApiException<ArchiveAddonPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ArchiveAddonPriceOptionRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/ArchiveAddonPriceOptionRequest.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `AddonPriceOptionResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionResponse.cs` |
| `ArchiveAddonPriceOptionError` | `src/OmbrevixBilling/Errors/ArchiveAddonPriceOptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### BulkCreateAddonPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkCreateAddonPriceOptions(BulkCreateAddonPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`
- **Returns**: `AddonPriceOptionsResponse`
- **Error**: `ApiException<BulkCreateAddonPriceOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BulkCreateAddonPriceOptionsRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/BulkCreateAddonPriceOptionsRequest.cs` |
| `CreateAddonPriceOptionsRequest` | `src/OmbrevixBilling/Models/CreateAddonPriceOptionsRequest.cs` |
| `AddonPriceOptionsResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionsResponse.cs` |
| `BulkCreateAddonPriceOptionsError` | `src/OmbrevixBilling/Errors/BulkCreateAddonPriceOptionsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CloneAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CloneAddonPriceOption(CloneAddonPriceOptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `AddonPriceOptionCurrencyOverageResponse`
- **Error**: `ApiException<CloneAddonPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CloneAddonPriceOptionOperationRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/CloneAddonPriceOptionOperationRequest.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `CloneAddonPriceOptionRequest` | `src/OmbrevixBilling/Models/CloneAddonPriceOptionRequest.cs` |
| `AddonPriceOptionCurrencyOverageResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionCurrencyOverageResponse.cs` |
| `CloneAddonPriceOptionError` | `src/OmbrevixBilling/Errors/CloneAddonPriceOptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateAddonPriceOption(CreateAddonPriceOptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`
- **Returns**: `AddonPriceOptionResponse`
- **Error**: `ApiException<CreateAddonPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateAddonPriceOptionOperationRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/CreateAddonPriceOptionOperationRequest.cs` |
| `CreateAddonPriceOptionRequest` | `src/OmbrevixBilling/Models/CreateAddonPriceOptionRequest.cs` |
| `AddonPriceOptionResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionResponse.cs` |
| `CreateAddonPriceOptionError` | `src/OmbrevixBilling/Errors/CreateAddonPriceOptionError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### CreateCurrencyPrices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateCurrencyPrices(CreateCurrencyPricesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PriceOptionId`
- **Returns**: `AddonCurrencyPricesResponse`
- **Error**: `ApiException<CreateCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCurrencyPricesOperationRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/CreateCurrencyPricesOperationRequest.cs` |
| `CreateCurrencyPricesRequest` | `src/OmbrevixBilling/Models/CreateCurrencyPricesRequest.cs` |
| `AddonCurrencyPricesResponse` | `src/OmbrevixBilling/Models/AddonCurrencyPricesResponse.cs` |
| `CreateCurrencyPricesError` | `src/OmbrevixBilling/Errors/CreateCurrencyPricesError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### ListAddonPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListAddonPriceOptions(ListAddonPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`
- **Query params (wire ← C#)**: `currency_prices` ← `CurrencyPrices`, `page` ← `Page`, `per_page` ← `PerPage`, `filter[type]` ← `FilterType` (comma-separated)
- **Returns**: `AddonPriceOptionsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListAddonPriceOptionsRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/ListAddonPriceOptionsRequest.cs` |
| `PriceOptionType` | `src/OmbrevixBilling/Models/Enums/PriceOptionType.cs` |
| `AddonPriceOptionsResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionsResponse.cs` |

### ListAllAddonPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListAllAddonPriceOptions(ListAllAddonPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `include` ← `Include`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`, `filter` ← `Filter`
- **Returns**: `ListAddonsPriceOptionsResponse`
- **Error**: `ApiException<ListAllAddonPriceOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAllAddonPriceOptionsRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/ListAllAddonPriceOptionsRequest.cs` |
| `ListAddonsPriceOptionsInclude` | `src/OmbrevixBilling/Models/Enums/ListAddonsPriceOptionsInclude.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListPriceOptionsFilter` | `src/OmbrevixBilling/Models/ListPriceOptionsFilter.cs` |
| `ListAddonsPriceOptionsResponse` | `src/OmbrevixBilling/Models/ListAddonsPriceOptionsResponse.cs` |
| `ListAllAddonPriceOptionsError` | `src/OmbrevixBilling/Errors/ListAllAddonPriceOptionsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### PromoteAddonPriceOptionToDefault

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PromoteAddonPriceOptionToDefault(PromoteAddonPriceOptionToDefaultRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `PromoteAddonPriceOptionToDefaultRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/PromoteAddonPriceOptionToDefaultRequest.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |

### ReadAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadAddonPriceOption(ReadAddonPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Query params (wire ← C#)**: `currency_prices` ← `CurrencyPrices`
- **Returns**: `AddonPriceOptionCurrencyOverageResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadAddonPriceOptionRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/ReadAddonPriceOptionRequest.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `AddonPriceOptionCurrencyOverageResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionCurrencyOverageResponse.cs` |

### UnarchiveAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UnarchiveAddonPriceOption(UnarchiveAddonPriceOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `AddonPriceOptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UnarchiveAddonPriceOptionRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/UnarchiveAddonPriceOptionRequest.cs` |
| `AddonPriceOptionResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionResponse.cs` |

### UpdateAddonPriceOption

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateAddonPriceOption(UpdateAddonPriceOptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`, `PriceOptionId`
- **Returns**: `AddonPriceOptionResponse`
- **Error**: `ApiException<UpdateAddonPriceOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateAddonPriceOptionOperationRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/UpdateAddonPriceOptionOperationRequest.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `PriceOptionIdModel` | `src/OmbrevixBilling/Models/AnyOf/PriceOptionIdModel.cs` |
| `UpdateAddonPriceOptionRequest` | `src/OmbrevixBilling/Models/UpdateAddonPriceOptionRequest.cs` |
| `AddonPriceOptionResponse` | `src/OmbrevixBilling/Models/AddonPriceOptionResponse.cs` |
| `UpdateAddonPriceOptionError` | `src/OmbrevixBilling/Errors/UpdateAddonPriceOptionError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### UpdateCurrencyPrices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateCurrencyPrices(UpdateCurrencyPricesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PriceOptionId`
- **Returns**: `AddonCurrencyPricesResponse`
- **Error**: `ApiException<UpdateCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateCurrencyPricesOperationRequest` | `src/OmbrevixBilling/Requests/AddonPriceOptions/UpdateCurrencyPricesOperationRequest.cs` |
| `UpdateCurrencyPricesRequest` | `src/OmbrevixBilling/Models/UpdateCurrencyPricesRequest.cs` |
| `AddonCurrencyPricesResponse` | `src/OmbrevixBilling/Models/AddonCurrencyPricesResponse.cs` |
| `UpdateCurrencyPricesError` | `src/OmbrevixBilling/Errors/UpdateCurrencyPricesError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

