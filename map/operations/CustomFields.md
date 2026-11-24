<!-- Generated file — do not edit; regenerated with the SDK. -->

# CustomFields — operations

Accessor: `client.CustomFields` · Source: `src/OmbrevixBilling/Api/CustomFields.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateDatafields

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateDatafields(CreateDatafieldsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`
- **Returns**: `IReadOnlyList<Datafield>`
- **Error**: `ApiException<CreateDatafieldsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateDatafieldsOperationRequest` | `src/OmbrevixBilling/Requests/CustomFields/CreateDatafieldsOperationRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `CreateDatafieldsRequest` | `src/OmbrevixBilling/Models/CreateDatafieldsRequest.cs` |
| `Datafield` | `src/OmbrevixBilling/Models/Datafield.cs` |
| `CreateDatafieldsError` | `src/OmbrevixBilling/Errors/CreateDatafieldsError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### CreateMetadata

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateMetadata(CreateMetadataOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`, `ResourceId`
- **Returns**: `IReadOnlyList<Metadata>`
- **Error**: `ApiException<CreateMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMetadataOperationRequest` | `src/OmbrevixBilling/Requests/CustomFields/CreateMetadataOperationRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `CreateMetadataRequest` | `src/OmbrevixBilling/Models/CreateMetadataRequest.cs` |
| `Metadata` | `src/OmbrevixBilling/Models/Metadata.cs` |
| `CreateMetadataError` | `src/OmbrevixBilling/Errors/CreateMetadataError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### DeleteDatafield

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteDatafield(DeleteDatafieldRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`
- **Query params (wire ← C#)**: `name` ← `Name`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteDatafieldError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteDatafieldRequest` | `src/OmbrevixBilling/Requests/CustomFields/DeleteDatafieldRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `DeleteDatafieldError` | `src/OmbrevixBilling/Errors/DeleteDatafieldError.cs` |

### DeleteMetadata

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteMetadata(DeleteMetadataRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`, `ResourceId`
- **Query params (wire ← C#)**: `name` ← `Name`, `names` ← `Names`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteMetadataRequest` | `src/OmbrevixBilling/Requests/CustomFields/DeleteMetadataRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `DeleteMetadataError` | `src/OmbrevixBilling/Errors/DeleteMetadataError.cs` |

### ListDatafields

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListDatafields(ListDatafieldsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`
- **Query params (wire ← C#)**: `name` ← `Name`, `page` ← `Page`, `per_page` ← `PerPage`, `direction` ← `Direction`
- **Returns**: `ListDatafieldsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListDatafieldsRequest` | `src/OmbrevixBilling/Requests/CustomFields/ListDatafieldsRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `ListDatafieldsResponse` | `src/OmbrevixBilling/Models/ListDatafieldsResponse.cs` |

### ListMetadata

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListMetadata(ListMetadataRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`, `ResourceId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `PaginatedMetadata`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListMetadataRequest` | `src/OmbrevixBilling/Requests/CustomFields/ListMetadataRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `PaginatedMetadata` | `src/OmbrevixBilling/Models/PaginatedMetadata.cs` |

### ListMetadataForResourceType

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListMetadataForResourceType(ListMetadataForResourceTypeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`, `with_deleted` ← `WithDeleted`, `resource_ids` ← `ResourceIds`, `direction` ← `Direction`
- **Returns**: `PaginatedMetadata`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListMetadataForResourceTypeRequest` | `src/OmbrevixBilling/Requests/CustomFields/ListMetadataForResourceTypeRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `BasicDateField` | `src/OmbrevixBilling/Models/Enums/BasicDateField.cs` |
| `SortingDirection` | `src/OmbrevixBilling/Models/Enums/SortingDirection.cs` |
| `PaginatedMetadata` | `src/OmbrevixBilling/Models/PaginatedMetadata.cs` |

### UpdateDatafield

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateDatafield(UpdateDatafieldRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`
- **Returns**: `IReadOnlyList<Datafield>`
- **Error**: `ApiException<UpdateDatafieldError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateDatafieldRequest` | `src/OmbrevixBilling/Requests/CustomFields/UpdateDatafieldRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `UpdateDatafieldsRequest` | `src/OmbrevixBilling/Models/UpdateDatafieldsRequest.cs` |
| `Datafield` | `src/OmbrevixBilling/Models/Datafield.cs` |
| `UpdateDatafieldError` | `src/OmbrevixBilling/Errors/UpdateDatafieldError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

### UpdateMetadata

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateMetadata(UpdateMetadataOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResourceType`, `ResourceId`
- **Returns**: `IReadOnlyList<Metadata>`
- **Error**: `ApiException<UpdateMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateMetadataOperationRequest` | `src/OmbrevixBilling/Requests/CustomFields/UpdateMetadataOperationRequest.cs` |
| `ResourceType` | `src/OmbrevixBilling/Models/Enums/ResourceType.cs` |
| `UpdateMetadataRequest` | `src/OmbrevixBilling/Models/UpdateMetadataRequest.cs` |
| `Metadata` | `src/OmbrevixBilling/Models/Metadata.cs` |
| `UpdateMetadataError` | `src/OmbrevixBilling/Errors/UpdateMetadataError.cs` |
| `SingleErrorResponse` | `src/OmbrevixBilling/Models/SingleErrorResponse.cs` |

