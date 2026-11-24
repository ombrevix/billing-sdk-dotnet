<!-- Generated file — do not edit; regenerated with the SDK. -->

# Subscriptions — operations

Accessor: `client.Subscriptions` · Source: `src/OmbrevixBilling/Api/Subscriptions.cs` · 12 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ActivateSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ActivateSubscription(ActivateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<ActivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [400] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ActivateSubscriptionOperationRequest` | `src/OmbrevixBilling/Requests/Subscriptions/ActivateSubscriptionOperationRequest.cs` |
| `ActivateSubscriptionRequest` | `src/OmbrevixBilling/Models/ActivateSubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `ActivateSubscriptionError` | `src/OmbrevixBilling/Errors/ActivateSubscriptionError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### ApplyCouponsToSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ApplyCouponsToSubscription(ApplyCouponsToSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `code` ← `Code`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<ApplyCouponsToSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionAddCouponError([NotNullWhen(true)] out SubscriptionAddCouponError? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ApplyCouponsToSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/ApplyCouponsToSubscriptionRequest.cs` |
| `AddCouponsRequest` | `src/OmbrevixBilling/Models/AddCouponsRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `ApplyCouponsToSubscriptionError` | `src/OmbrevixBilling/Errors/ApplyCouponsToSubscriptionError.cs` |
| `SubscriptionAddCouponError` | `src/OmbrevixBilling/Models/SubscriptionAddCouponError.cs` |

### CreateSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSubscription(CreateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionOperationRequest` | `src/OmbrevixBilling/Requests/Subscriptions/CreateSubscriptionOperationRequest.cs` |
| `CreateSubscriptionRequest` | `src/OmbrevixBilling/Models/CreateSubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `CreateSubscriptionError` | `src/OmbrevixBilling/Errors/CreateSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### EraseSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `EraseSubscription(EraseSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Ack`
- **Query params (wire ← C#)**: `ack` ← `Ack`, `cascade` ← `Cascade`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<EraseSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionResponse([NotNullWhen(true)] out SubscriptionResponse? value)` [400] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `EraseSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/EraseSubscriptionRequest.cs` |
| `SubscriptionEraseType` | `src/OmbrevixBilling/Models/Enums/SubscriptionEraseType.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `EraseSubscriptionError` | `src/OmbrevixBilling/Errors/EraseSubscriptionError.cs` |

### FindSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `FindSubscription(FindSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `reference` ← `Reference`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<FindSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `FindSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/FindSubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `FindSubscriptionError` | `src/OmbrevixBilling/Errors/FindSubscriptionError.cs` |

### ListSubscriptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptions(ListSubscriptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `state` ← `State`, `product` ← `Product`, `product_price_option_id` ← `ProductPriceOptionId`, `coupon` ← `Coupon`, `coupon_code` ← `CouponCode`, `branding_theme_id` ← `BrandingThemeId`, `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `metadata` ← `Metadata`, `direction` ← `Direction`, `sort` ← `Sort`, `include` ← `Include`
- **Returns**: `IReadOnlyList<SubscriptionResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSubscriptionsRequest` | `src/OmbrevixBilling/Requests/Subscriptions/ListSubscriptionsRequest.cs` |
| `SubscriptionStateFilter` | `src/OmbrevixBilling/Models/Enums/SubscriptionStateFilter.cs` |
| `SubscriptionDateField` | `src/OmbrevixBilling/Models/Enums/SubscriptionDateField.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `SubscriptionSort` | `src/OmbrevixBilling/Models/Enums/SubscriptionSort.cs` |
| `SubscriptionListInclude` | `src/OmbrevixBilling/Models/Enums/SubscriptionListInclude.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |

### OverrideSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `OverrideSubscription(OverrideSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<OverrideSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `OverrideSubscriptionOperationRequest` | `src/OmbrevixBilling/Requests/Subscriptions/OverrideSubscriptionOperationRequest.cs` |
| `OverrideSubscriptionRequest` | `src/OmbrevixBilling/Models/OverrideSubscriptionRequest.cs` |
| `OverrideSubscriptionError` | `src/OmbrevixBilling/Errors/OverrideSubscriptionError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### PreviewSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewSubscription(PreviewSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `SubscriptionPreviewResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `PreviewSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/PreviewSubscriptionRequest.cs` |
| `CreateSubscriptionRequest` | `src/OmbrevixBilling/Models/CreateSubscriptionRequest.cs` |
| `SubscriptionPreviewResponse` | `src/OmbrevixBilling/Models/SubscriptionPreviewResponse.cs` |

### ReadSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSubscription(ReadSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `include` ← `Include`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/ReadSubscriptionRequest.cs` |
| `SubscriptionInclude` | `src/OmbrevixBilling/Models/Enums/SubscriptionInclude.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |

### RemoveCouponFromSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RemoveCouponFromSubscription(RemoveCouponFromSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `coupon_code` ← `CouponCode`
- **Returns**: `string`
- **Error**: `ApiException<RemoveCouponFromSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionRemoveCouponErrors([NotNullWhen(true)] out SubscriptionRemoveCouponErrors? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RemoveCouponFromSubscriptionRequest` | `src/OmbrevixBilling/Requests/Subscriptions/RemoveCouponFromSubscriptionRequest.cs` |
| `RemoveCouponFromSubscriptionError` | `src/OmbrevixBilling/Errors/RemoveCouponFromSubscriptionError.cs` |
| `SubscriptionRemoveCouponErrors` | `src/OmbrevixBilling/Models/SubscriptionRemoveCouponErrors.cs` |

### UpdatePrepaidSubscriptionConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdatePrepaidSubscriptionConfiguration(UpdatePrepaidSubscriptionConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `PrepaidConfigurationResponse`
- **Error**: `ApiException<UpdatePrepaidSubscriptionConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetPrepaidConfigurationErrorResponse([NotNullWhen(true)] out PrepaidConfigurationErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePrepaidSubscriptionConfigurationRequest` | `src/OmbrevixBilling/Requests/Subscriptions/UpdatePrepaidSubscriptionConfigurationRequest.cs` |
| `UpsertPrepaidConfigurationRequest` | `src/OmbrevixBilling/Models/UpsertPrepaidConfigurationRequest.cs` |
| `PrepaidConfigurationResponse` | `src/OmbrevixBilling/Models/PrepaidConfigurationResponse.cs` |
| `UpdatePrepaidSubscriptionConfigurationError` | `src/OmbrevixBilling/Errors/UpdatePrepaidSubscriptionConfigurationError.cs` |
| `PrepaidConfigurationErrorResponse` | `src/OmbrevixBilling/Models/AnyOf/PrepaidConfigurationErrorResponse.cs` |

### UpdateSubscription

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateSubscription(UpdateSubscriptionOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<UpdateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSubscriptionOperationRequest` | `src/OmbrevixBilling/Requests/Subscriptions/UpdateSubscriptionOperationRequest.cs` |
| `UpdateSubscriptionRequest` | `src/OmbrevixBilling/Models/UpdateSubscriptionRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |
| `UpdateSubscriptionError` | `src/OmbrevixBilling/Errors/UpdateSubscriptionError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

