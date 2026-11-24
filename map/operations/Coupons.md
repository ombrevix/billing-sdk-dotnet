<!-- Generated file — do not edit; regenerated with the SDK. -->

# Coupons — operations

Accessor: `client.Coupons` · Source: `src/OmbrevixBilling/Api/Coupons.cs` · 14 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveCoupon(ArchiveCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `CouponId`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ArchiveCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/ArchiveCouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |

### CreateCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateCoupon(CreateCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<CreateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/CreateCouponRequest.cs` |
| `CouponRequest` | `src/OmbrevixBilling/Models/CouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |
| `CreateCouponError` | `src/OmbrevixBilling/Errors/CreateCouponError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateCouponVariants

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateCouponVariants(CreateCouponVariantsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CouponId`
- **Returns**: `CouponVariantsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `CreateCouponVariantsRequest` | `src/OmbrevixBilling/Requests/Coupons/CreateCouponVariantsRequest.cs` |
| `CouponVariants` | `src/OmbrevixBilling/Models/CouponVariants.cs` |
| `CouponVariantsResponse` | `src/OmbrevixBilling/Models/CouponVariantsResponse.cs` |

### CreateOrUpdateCouponCurrencyPrices

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateOrUpdateCouponCurrencyPrices(CreateOrUpdateCouponCurrencyPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CouponId`
- **Returns**: `CouponCurrencyResponse`
- **Error**: `ApiException<CreateOrUpdateCouponCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateOrUpdateCouponCurrencyPricesRequest` | `src/OmbrevixBilling/Requests/Coupons/CreateOrUpdateCouponCurrencyPricesRequest.cs` |
| `CouponCurrencyRequest` | `src/OmbrevixBilling/Models/CouponCurrencyRequest.cs` |
| `CouponCurrencyResponse` | `src/OmbrevixBilling/Models/CouponCurrencyResponse.cs` |
| `CreateOrUpdateCouponCurrencyPricesError` | `src/OmbrevixBilling/Errors/CreateOrUpdateCouponCurrencyPricesError.cs` |
| `ErrorStringMapResponse` | `src/OmbrevixBilling/Models/ErrorStringMapResponse.cs` |

### DeleteCouponVariant

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteCouponVariant(DeleteCouponVariantRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CouponId`, `Variant`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteCouponVariantError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteCouponVariantRequest` | `src/OmbrevixBilling/Requests/Coupons/DeleteCouponVariantRequest.cs` |
| `DeleteCouponVariantError` | `src/OmbrevixBilling/Errors/DeleteCouponVariantError.cs` |

### FindCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `FindCoupon(FindCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `product_lineup_id` ← `ProductLineupId`, `code` ← `Code`, `currency_prices` ← `CurrencyPrices`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `FindCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/FindCouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |

### ListCouponVariants

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCouponVariants(ListCouponVariantsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CouponId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `CouponVariants`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCouponVariantsRequest` | `src/OmbrevixBilling/Requests/Coupons/ListCouponVariantsRequest.cs` |
| `CouponVariants` | `src/OmbrevixBilling/Models/CouponVariants.cs` |

### ListCoupons

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCoupons(ListCouponsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`, `currency_prices` ← `CurrencyPrices`
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCouponsRequest` | `src/OmbrevixBilling/Requests/Coupons/ListCouponsRequest.cs` |
| `ListCouponsFilter` | `src/OmbrevixBilling/Models/ListCouponsFilter.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |

### ListCouponsForProductLineup

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListCouponsForProductLineup(ListCouponsForProductLineupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`, `currency_prices` ← `CurrencyPrices`
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListCouponsForProductLineupRequest` | `src/OmbrevixBilling/Requests/Coupons/ListCouponsForProductLineupRequest.cs` |
| `ListCouponsFilter` | `src/OmbrevixBilling/Models/ListCouponsFilter.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |

### ReadCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadCoupon(ReadCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `CouponId`
- **Query params (wire ← C#)**: `currency_prices` ← `CurrencyPrices`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/ReadCouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |

### ReadCouponUsage

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadCouponUsage(ReadCouponUsageRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `CouponId`
- **Returns**: `IReadOnlyList<CouponUsage>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadCouponUsageRequest` | `src/OmbrevixBilling/Requests/Coupons/ReadCouponUsageRequest.cs` |
| `CouponUsage` | `src/OmbrevixBilling/Models/CouponUsage.cs` |

### UpdateCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateCoupon(UpdateCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `CouponId`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<UpdateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/UpdateCouponRequest.cs` |
| `CouponRequest` | `src/OmbrevixBilling/Models/CouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |
| `UpdateCouponError` | `src/OmbrevixBilling/Errors/UpdateCouponError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateCouponVariants

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateCouponVariants(UpdateCouponVariantsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CouponId`
- **Returns**: `CouponVariantsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateCouponVariantsRequest` | `src/OmbrevixBilling/Requests/Coupons/UpdateCouponVariantsRequest.cs` |
| `CouponVariants` | `src/OmbrevixBilling/Models/CouponVariants.cs` |
| `CouponVariantsResponse` | `src/OmbrevixBilling/Models/CouponVariantsResponse.cs` |

### ValidateCoupon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ValidateCoupon(ValidateCouponRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Code`
- **Query params (wire ← C#)**: `code` ← `Code`, `product_lineup_id` ← `ProductLineupId`
- **Returns**: `CouponResponse`
- **Error**: `ApiException<ValidateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleStringErrorResponse([NotNullWhen(true)] out SingleStringErrorResponse? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ValidateCouponRequest` | `src/OmbrevixBilling/Requests/Coupons/ValidateCouponRequest.cs` |
| `CouponResponse` | `src/OmbrevixBilling/Models/CouponResponse.cs` |
| `ValidateCouponError` | `src/OmbrevixBilling/Errors/ValidateCouponError.cs` |
| `SingleStringErrorResponse` | `src/OmbrevixBilling/Models/SingleStringErrorResponse.cs` |

