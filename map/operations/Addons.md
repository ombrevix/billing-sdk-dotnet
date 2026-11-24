<!-- Generated file — do not edit; regenerated with the SDK. -->

# Addons — operations

Accessor: `client.Addons` · Source: `src/OmbrevixBilling/Api/Addons.cs` · 12 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveAddon(ArchiveAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `AddonId`
- **Returns**: `Addon`
- **Error**: `ApiException<ArchiveAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ArchiveAddonRequest` | `src/OmbrevixBilling/Requests/Addons/ArchiveAddonRequest.cs` |
| `Addon` | `src/OmbrevixBilling/Models/Addon.cs` |
| `ArchiveAddonError` | `src/OmbrevixBilling/Errors/ArchiveAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateEventBasedAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateEventBasedAddon(CreateEventBasedAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<CreateEventBasedAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateEventBasedAddonRequest` | `src/OmbrevixBilling/Requests/Addons/CreateEventBasedAddonRequest.cs` |
| `CreateEubAddon` | `src/OmbrevixBilling/Models/CreateEubAddon.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `CreateEventBasedAddonError` | `src/OmbrevixBilling/Errors/CreateEventBasedAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateMeteredAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateMeteredAddon(CreateMeteredAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<CreateMeteredAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMeteredAddonRequest` | `src/OmbrevixBilling/Requests/Addons/CreateMeteredAddonRequest.cs` |
| `CreateMeteredAddon` | `src/OmbrevixBilling/Models/CreateMeteredAddon.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `CreateMeteredAddonError` | `src/OmbrevixBilling/Errors/CreateMeteredAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreatePrepaidUsageAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreatePrepaidUsageAddon(CreatePrepaidUsageAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<CreatePrepaidUsageAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePrepaidUsageAddonRequest` | `src/OmbrevixBilling/Requests/Addons/CreatePrepaidUsageAddonRequest.cs` |
| `CreatePrepaidAddon` | `src/OmbrevixBilling/Models/CreatePrepaidAddon.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `CreatePrepaidUsageAddonError` | `src/OmbrevixBilling/Errors/CreatePrepaidUsageAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateSeatBasedAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSeatBasedAddon(CreateSeatBasedAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<CreateSeatBasedAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSeatBasedAddonRequest` | `src/OmbrevixBilling/Requests/Addons/CreateSeatBasedAddonRequest.cs` |
| `CreateSeatBasedAddon` | `src/OmbrevixBilling/Models/CreateSeatBasedAddon.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `CreateSeatBasedAddonError` | `src/OmbrevixBilling/Errors/CreateSeatBasedAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateToggleAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateToggleAddon(CreateToggleAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<CreateToggleAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateToggleAddonRequest` | `src/OmbrevixBilling/Requests/Addons/CreateToggleAddonRequest.cs` |
| `CreateToggleAddon` | `src/OmbrevixBilling/Models/CreateToggleAddon.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `CreateToggleAddonError` | `src/OmbrevixBilling/Errors/CreateToggleAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### FindAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `FindAddon(FindAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Slug`
- **Query params (wire ← C#)**: `slug` ← `Slug`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `FindAddonRequest` | `src/OmbrevixBilling/Requests/Addons/FindAddonRequest.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |

### ListAddons

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListAddons(ListAddonsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `include_archived` ← `IncludeArchived`, `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`
- **Returns**: `IReadOnlyList<AddonResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListAddonsRequest` | `src/OmbrevixBilling/Requests/Addons/ListAddonsRequest.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `ListAddonsFilter` | `src/OmbrevixBilling/Models/ListAddonsFilter.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |

### ListAddonsForProductLineup

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListAddonsForProductLineup(ListAddonsForProductLineupRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`
- **Query params (wire ← C#)**: `include_archived` ← `IncludeArchived`, `page` ← `Page`, `per_page` ← `PerPage`, `filter` ← `Filter`, `date_field` ← `DateField`, `end_date` ← `EndDate`, `end_datetime` ← `EndDatetime`, `start_date` ← `StartDate`, `start_datetime` ← `StartDatetime`
- **Returns**: `IReadOnlyList<AddonResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListAddonsForProductLineupRequest` | `src/OmbrevixBilling/Requests/Addons/ListAddonsForProductLineupRequest.cs` |
| `ListAddonsFilter` | `src/OmbrevixBilling/Models/ListAddonsFilter.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |

### ReadAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadAddon(ReadAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `AddonId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadAddonRequest` | `src/OmbrevixBilling/Requests/Addons/ReadAddonRequest.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |

### UpdateAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateAddon(UpdateAddonOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AddonId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<UpdateAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateAddonOperationRequest` | `src/OmbrevixBilling/Requests/Addons/UpdateAddonOperationRequest.cs` |
| `UpdateAddonRequest` | `src/OmbrevixBilling/Models/UpdateAddonRequest.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `UpdateAddonError` | `src/OmbrevixBilling/Errors/UpdateAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateProductLineupAddon

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateProductLineupAddon(UpdateProductLineupAddonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ProductLineupId`, `AddonId`
- **Returns**: `AddonResponse`
- **Error**: `ApiException<UpdateProductLineupAddonError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateProductLineupAddonRequest` | `src/OmbrevixBilling/Requests/Addons/UpdateProductLineupAddonRequest.cs` |
| `UpdateAddonRequest` | `src/OmbrevixBilling/Models/UpdateAddonRequest.cs` |
| `AddonResponse` | `src/OmbrevixBilling/Models/AddonResponse.cs` |
| `UpdateProductLineupAddonError` | `src/OmbrevixBilling/Errors/UpdateProductLineupAddonError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

