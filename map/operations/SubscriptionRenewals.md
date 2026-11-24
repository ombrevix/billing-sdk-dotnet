<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionRenewals — operations

Accessor: `client.SubscriptionRenewals` · Source: `src/OmbrevixBilling/Api/SubscriptionRenewals.cs` · 11 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelScheduledRenewalConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CancelScheduledRenewalConfiguration(CancelScheduledRenewalConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<CancelScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/CancelScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `CancelScheduledRenewalConfigurationError` | `src/OmbrevixBilling/Errors/CancelScheduledRenewalConfigurationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateScheduledRenewalConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateScheduledRenewalConfiguration(CreateScheduledRenewalConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<CreateScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/CreateScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `CreateScheduledRenewalConfigurationError` | `src/OmbrevixBilling/Errors/CreateScheduledRenewalConfigurationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreateScheduledRenewalConfigurationItem

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateScheduledRenewalConfigurationItem(CreateScheduledRenewalConfigurationItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `ScheduledRenewalsConfigurationId`
- **Returns**: `ScheduledRenewalConfigurationItemResponse`
- **Error**: `ApiException<CreateScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateScheduledRenewalConfigurationItemRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/CreateScheduledRenewalConfigurationItemRequest.cs` |
| `ScheduledRenewalConfigurationItemRequest` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationItemRequest.cs` |
| `ScheduledRenewalConfigurationItemResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationItemResponse.cs` |
| `CreateScheduledRenewalConfigurationItemError` | `src/OmbrevixBilling/Errors/CreateScheduledRenewalConfigurationItemError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeleteScheduledRenewalConfigurationItem

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteScheduledRenewalConfigurationItem(DeleteScheduledRenewalConfigurationItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `ScheduledRenewalsConfigurationId`, `Id`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteScheduledRenewalConfigurationItemRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/DeleteScheduledRenewalConfigurationItemRequest.cs` |
| `DeleteScheduledRenewalConfigurationItemError` | `src/OmbrevixBilling/Errors/DeleteScheduledRenewalConfigurationItemError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListScheduledRenewalConfigurations

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListScheduledRenewalConfigurations(ListScheduledRenewalConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `status` ← `Status`
- **Returns**: `ScheduledRenewalConfigurationsResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListScheduledRenewalConfigurationsRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/ListScheduledRenewalConfigurationsRequest.cs` |
| `Status` | `src/OmbrevixBilling/Models/Enums/Status.cs` |
| `ScheduledRenewalConfigurationsResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationsResponse.cs` |

### LockInScheduledRenewalImmediately

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `LockInScheduledRenewalImmediately(LockInScheduledRenewalImmediatelyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<LockInScheduledRenewalImmediatelyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `LockInScheduledRenewalImmediatelyRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/LockInScheduledRenewalImmediatelyRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `LockInScheduledRenewalImmediatelyError` | `src/OmbrevixBilling/Errors/LockInScheduledRenewalImmediatelyError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadScheduledRenewalConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadScheduledRenewalConfiguration(ReadScheduledRenewalConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/ReadScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |

### ScheduleScheduledRenewalLockIn

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ScheduleScheduledRenewalLockIn(ScheduleScheduledRenewalLockInRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<ScheduleScheduledRenewalLockInError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ScheduleScheduledRenewalLockInRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/ScheduleScheduledRenewalLockInRequest.cs` |
| `ScheduledRenewalLockInRequest` | `src/OmbrevixBilling/Models/ScheduledRenewalLockInRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `ScheduleScheduledRenewalLockInError` | `src/OmbrevixBilling/Errors/ScheduleScheduledRenewalLockInError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UnpublishScheduledRenewalConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UnpublishScheduledRenewalConfiguration(UnpublishScheduledRenewalConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<UnpublishScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UnpublishScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/UnpublishScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `UnpublishScheduledRenewalConfigurationError` | `src/OmbrevixBilling/Errors/UnpublishScheduledRenewalConfigurationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateScheduledRenewalConfiguration

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateScheduledRenewalConfiguration(UpdateScheduledRenewalConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `ApiException<UpdateScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/UpdateScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationRequest` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationRequest.cs` |
| `ScheduledRenewalConfigurationResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationResponse.cs` |
| `UpdateScheduledRenewalConfigurationError` | `src/OmbrevixBilling/Errors/UpdateScheduledRenewalConfigurationError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdateScheduledRenewalConfigurationItem

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateScheduledRenewalConfigurationItem(UpdateScheduledRenewalConfigurationItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `ScheduledRenewalsConfigurationId`, `Id`
- **Returns**: `ScheduledRenewalConfigurationItemResponse`
- **Error**: `ApiException<UpdateScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateScheduledRenewalConfigurationItemRequest` | `src/OmbrevixBilling/Requests/SubscriptionRenewals/UpdateScheduledRenewalConfigurationItemRequest.cs` |
| `ScheduledRenewalUpdateRequest` | `src/OmbrevixBilling/Models/ScheduledRenewalUpdateRequest.cs` |
| `ScheduledRenewalConfigurationItemResponse` | `src/OmbrevixBilling/Models/ScheduledRenewalConfigurationItemResponse.cs` |
| `UpdateScheduledRenewalConfigurationItemError` | `src/OmbrevixBilling/Errors/UpdateScheduledRenewalConfigurationItemError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

