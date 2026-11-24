<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionAddons — operations

Accessor: `client.SubscriptionAddons` · Source: `src/OmbrevixBilling/Api/SubscriptionAddons.cs` · 17 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ActivateEventBasedAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ActivateEventBasedAddon(ActivateEventBasedAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ActivateEventBasedAddonRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ActivateEventBasedAddonRequest.cs` |
| `ActivateEventBasedAddon` | `src/OmbrevixBilling/Models/ActivateEventBasedAddon.cs` |

### BulkRecordEvents

- **Server group**: `Ebb`
- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkRecordEvents(BulkRecordEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ApiSlug`
- **Query params (wire ← C#)**: `store_uid` ← `StoreUid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `BulkRecordEventsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/BulkRecordEventsRequest.cs` |
| `EubEvent` | `src/OmbrevixBilling/Models/EubEvent.cs` |

### BulkResetSubscriptionAddonsPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkResetSubscriptionAddonsPriceOptions(BulkResetSubscriptionAddonsPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `BulkResetSubscriptionAddonsPriceOptionsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/BulkResetSubscriptionAddonsPriceOptionsRequest.cs` |
| `SubscriptionResponse` | `src/OmbrevixBilling/Models/SubscriptionResponse.cs` |

### BulkUpdateSubscriptionAddonsPriceOptions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `BulkUpdateSubscriptionAddonsPriceOptions(BulkUpdateSubscriptionAddonsPriceOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `BulkAddonsPriceOptionAssignment`
- **Error**: `ApiException<BulkUpdateSubscriptionAddonsPriceOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetAddonPriceOptionError([NotNullWhen(true)] out AddonPriceOptionError? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `BulkUpdateSubscriptionAddonsPriceOptionsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/BulkUpdateSubscriptionAddonsPriceOptionsRequest.cs` |
| `BulkAddonsPriceOptionAssignment` | `src/OmbrevixBilling/Models/BulkAddonsPriceOptionAssignment.cs` |
| `BulkUpdateSubscriptionAddonsPriceOptionsError` | `src/OmbrevixBilling/Errors/BulkUpdateSubscriptionAddonsPriceOptionsError.cs` |
| `AddonPriceOptionError` | `src/OmbrevixBilling/Models/AddonPriceOptionError.cs` |

### CreateUsage

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateUsage(CreateUsageOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionIdOrReference`, `AddonId`
- **Returns**: `UsageResponse`
- **Error**: `ApiException<CreateUsageError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateUsageOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/CreateUsageOperationRequest.cs` |
| `SubscriptionIdOrReference` | `src/OmbrevixBilling/Models/AnyOf/SubscriptionIdOrReference.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `CreateUsageRequest` | `src/OmbrevixBilling/Models/CreateUsageRequest.cs` |
| `UsageResponse` | `src/OmbrevixBilling/Models/UsageResponse.cs` |
| `CreateUsageError` | `src/OmbrevixBilling/Errors/CreateUsageError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeactivateEventBasedAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeactivateEventBasedAddon(DeactivateEventBasedAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeactivateEventBasedAddonRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/DeactivateEventBasedAddonRequest.cs` |

### DeletePrepaidUsageProvision

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeletePrepaidUsageProvision(DeletePrepaidUsageProvisionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`, `ProvisionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeletePrepaidUsageProvisionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetSubscriptionAddonProvisionError([NotNullWhen(true)] out SubscriptionAddonProvisionError? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeletePrepaidUsageProvisionRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/DeletePrepaidUsageProvisionRequest.cs` |
| `CreditSchemeRequest` | `src/OmbrevixBilling/Models/CreditSchemeRequest.cs` |
| `DeletePrepaidUsageProvisionError` | `src/OmbrevixBilling/Errors/DeletePrepaidUsageProvisionError.cs` |
| `SubscriptionAddonProvisionError` | `src/OmbrevixBilling/Models/SubscriptionAddonProvisionError.cs` |

### ListProvisions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListProvisions(ListProvisionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`
- **Query params (wire ← C#)**: `page` ← `Page`
- **Returns**: `IReadOnlyList<ProvisionResponse>`
- **Error**: `ApiException<ListProvisionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListProvisionsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ListProvisionsRequest.cs` |
| `ProvisionResponse` | `src/OmbrevixBilling/Models/ProvisionResponse.cs` |
| `ListProvisionsError` | `src/OmbrevixBilling/Errors/ListProvisionsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListSubscriptionAddons

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionAddons(ListSubscriptionAddonsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `date_field` ← `DateField`, `direction` ← `Direction`, `filter` ← `Filter`, `end_date` ← `EndDate`, `end_datetime` ← `EndDatetime`, `price_option_ids` ← `PriceOptionIds`, `product_lineup_ids` ← `ProductLineupIds` (comma-separated), `sort` ← `Sort`, `start_date` ← `StartDate`, `start_datetime` ← `StartDatetime`, `include` ← `Include` (comma-separated), `in_use` ← `InUse`
- **Returns**: `IReadOnlyList<SubscriptionAddonResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSubscriptionAddonsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ListSubscriptionAddonsRequest.cs` |
| `SubscriptionListDateField` | `src/OmbrevixBilling/Models/Enums/SubscriptionListDateField.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListSubscriptionAddonsFilter` | `src/OmbrevixBilling/Models/ListSubscriptionAddonsFilter.cs` |
| `IncludeNotNull` | `src/OmbrevixBilling/Models/Enums/IncludeNotNull.cs` |
| `ListSubscriptionAddonsSort` | `src/OmbrevixBilling/Models/Enums/ListSubscriptionAddonsSort.cs` |
| `ListSubscriptionAddonsInclude` | `src/OmbrevixBilling/Models/Enums/ListSubscriptionAddonsInclude.cs` |
| `SubscriptionAddonResponse` | `src/OmbrevixBilling/Models/SubscriptionAddonResponse.cs` |

### ListSubscriptionAddonsForWorkspace

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionAddonsForWorkspace(ListSubscriptionAddonsForWorkspaceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `sort` ← `Sort`, `direction` ← `Direction`, `filter` ← `Filter`, `date_field` ← `DateField`, `start_date` ← `StartDate`, `start_datetime` ← `StartDatetime`, `end_date` ← `EndDate`, `end_datetime` ← `EndDatetime`, `subscription_ids` ← `SubscriptionIds` (comma-separated), `price_option_ids` ← `PriceOptionIds`, `product_lineup_ids` ← `ProductLineupIds` (comma-separated), `include` ← `Include`
- **Returns**: `ListSubscriptionAddonsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSubscriptionAddonsForWorkspaceRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ListSubscriptionAddonsForWorkspaceRequest.cs` |
| `ListSubscriptionAddonsSort` | `src/OmbrevixBilling/Models/Enums/ListSubscriptionAddonsSort.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListSubscriptionAddonsForWorkspaceFilter` | `src/OmbrevixBilling/Models/ListSubscriptionAddonsForWorkspaceFilter.cs` |
| `SubscriptionListDateField` | `src/OmbrevixBilling/Models/Enums/SubscriptionListDateField.cs` |
| `IncludeNotNull` | `src/OmbrevixBilling/Models/Enums/IncludeNotNull.cs` |
| `ListSubscriptionAddonsInclude` | `src/OmbrevixBilling/Models/Enums/ListSubscriptionAddonsInclude.cs` |
| `ListSubscriptionAddonsResponse` | `src/OmbrevixBilling/Models/ListSubscriptionAddonsResponse.cs` |

### ListUsages

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListUsages(ListUsagesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionIdOrReference`, `AddonId`
- **Query params (wire ← C#)**: `since_id` ← `SinceId`, `max_id` ← `MaxId`, `since_date` ← `SinceDate`, `until_date` ← `UntilDate`, `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `IReadOnlyList<UsageResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListUsagesRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ListUsagesRequest.cs` |
| `SubscriptionIdOrReference` | `src/OmbrevixBilling/Models/AnyOf/SubscriptionIdOrReference.cs` |
| `AddonIdModel` | `src/OmbrevixBilling/Models/AnyOf/AddonIdModel.cs` |
| `UsageResponse` | `src/OmbrevixBilling/Models/UsageResponse.cs` |

### PreviewProvisions

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `PreviewProvisions(PreviewProvisionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `ProvisionPreviewResponse`
- **Error**: `ApiException<PreviewProvisionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetAddonProvisionError([NotNullWhen(true)] out AddonProvisionError? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PreviewProvisionsOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/PreviewProvisionsOperationRequest.cs` |
| `PreviewProvisionsRequest` | `src/OmbrevixBilling/Models/PreviewProvisionsRequest.cs` |
| `ProvisionPreviewResponse` | `src/OmbrevixBilling/Models/ProvisionPreviewResponse.cs` |
| `PreviewProvisionsError` | `src/OmbrevixBilling/Errors/PreviewProvisionsError.cs` |
| `AddonProvisionError` | `src/OmbrevixBilling/Models/AddonProvisionError.cs` |

### ProvisionAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ProvisionAddon(ProvisionAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`
- **Returns**: `ProvisionResponse`
- **Error**: `ApiException<ProvisionAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ProvisionAddonRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ProvisionAddonRequest.cs` |
| `CreateProvisionRequest` | `src/OmbrevixBilling/Models/CreateProvisionRequest.cs` |
| `ProvisionResponse` | `src/OmbrevixBilling/Models/ProvisionResponse.cs` |
| `ProvisionAddonError` | `src/OmbrevixBilling/Errors/ProvisionAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ProvisionAddons

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ProvisionAddons(ProvisionAddonsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `IReadOnlyList<ProvisionResponse>`
- **Error**: `ApiException<ProvisionAddonsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ProvisionAddonsRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ProvisionAddonsRequest.cs` |
| `ProvisionAddons` | `src/OmbrevixBilling/Models/ProvisionAddons.cs` |
| `ProvisionResponse` | `src/OmbrevixBilling/Models/ProvisionResponse.cs` |
| `ProvisionAddonsError` | `src/OmbrevixBilling/Errors/ProvisionAddonsError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadSubscriptionAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSubscriptionAddon(ReadSubscriptionAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`
- **Returns**: `SubscriptionAddonResponse`
- **Error**: `ApiException<ReadSubscriptionAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadSubscriptionAddonRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/ReadSubscriptionAddonRequest.cs` |
| `SubscriptionAddonResponse` | `src/OmbrevixBilling/Models/SubscriptionAddonResponse.cs` |
| `ReadSubscriptionAddonError` | `src/OmbrevixBilling/Errors/ReadSubscriptionAddonError.cs` |

### RecordEvent

- **Server group**: `Ebb`
- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `RecordEvent(RecordEventRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ApiSlug`
- **Query params (wire ← C#)**: `store_uid` ← `StoreUid`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `RecordEventRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/RecordEventRequest.cs` |
| `EubEvent` | `src/OmbrevixBilling/Models/EubEvent.cs` |

### UpdatePrepaidUsageProvisionExpirationDate

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdatePrepaidUsageProvisionExpirationDate(UpdatePrepaidUsageProvisionExpirationDateRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `AddonId`, `ProvisionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<UpdatePrepaidUsageProvisionExpirationDateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetSubscriptionAddonProvisionError([NotNullWhen(true)] out SubscriptionAddonProvisionError? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePrepaidUsageProvisionExpirationDateRequest` | `src/OmbrevixBilling/Requests/SubscriptionAddons/UpdatePrepaidUsageProvisionExpirationDateRequest.cs` |
| `UpdateProvisionExpirationDate` | `src/OmbrevixBilling/Models/UpdateProvisionExpirationDate.cs` |
| `UpdatePrepaidUsageProvisionExpirationDateError` | `src/OmbrevixBilling/Errors/UpdatePrepaidUsageProvisionExpirationDateError.cs` |
| `SubscriptionAddonProvisionError` | `src/OmbrevixBilling/Models/SubscriptionAddonProvisionError.cs` |

