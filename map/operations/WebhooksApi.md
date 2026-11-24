<!-- Generated file — do not edit; regenerated with the SDK. -->

# WebhooksApi — operations

Accessor: `client.WebhooksApi` · Source: `src/OmbrevixBilling/Api/WebhooksApi.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateEndpoint

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateEndpoint(CreateEndpointRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `EndpointResponse`
- **Error**: `ApiException<CreateEndpointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateEndpointRequest` | `src/OmbrevixBilling/Requests/WebhooksApi/CreateEndpointRequest.cs` |
| `CreateOrUpdateEndpointRequest` | `src/OmbrevixBilling/Models/CreateOrUpdateEndpointRequest.cs` |
| `EndpointResponse` | `src/OmbrevixBilling/Models/EndpointResponse.cs` |
| `CreateEndpointError` | `src/OmbrevixBilling/Errors/CreateEndpointError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### EnableWebhooks

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `EnableWebhooks(EnableWebhooksOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `EnableWebhooksResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `EnableWebhooksOperationRequest` | `src/OmbrevixBilling/Requests/WebhooksApi/EnableWebhooksOperationRequest.cs` |
| `EnableWebhooksRequest` | `src/OmbrevixBilling/Models/EnableWebhooksRequest.cs` |
| `EnableWebhooksResponse` | `src/OmbrevixBilling/Models/EnableWebhooksResponse.cs` |

### ListEndpoints

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListEndpoints(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `IReadOnlyList<Endpoint>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `Endpoint` | `src/OmbrevixBilling/Models/Endpoint.cs` |

### ListWebhooks

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListWebhooks(ListWebhooksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `status` ← `Status`, `since_date` ← `SinceDate`, `until_date` ← `UntilDate`, `page` ← `Page`, `per_page` ← `PerPage`, `order` ← `Order`, `subscription` ← `Subscription`
- **Returns**: `IReadOnlyList<WebhookResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListWebhooksRequest` | `src/OmbrevixBilling/Requests/WebhooksApi/ListWebhooksRequest.cs` |
| `WebhookStatus` | `src/OmbrevixBilling/Models/Enums/WebhookStatus.cs` |
| `WebhookOrder` | `src/OmbrevixBilling/Models/Enums/WebhookOrder.cs` |
| `WebhookResponse` | `src/OmbrevixBilling/Models/WebhookResponse.cs` |

### ReplayWebhooks

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReplayWebhooks(ReplayWebhooksOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `ReplayWebhooksResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReplayWebhooksOperationRequest` | `src/OmbrevixBilling/Requests/WebhooksApi/ReplayWebhooksOperationRequest.cs` |
| `ReplayWebhooksRequest` | `src/OmbrevixBilling/Models/ReplayWebhooksRequest.cs` |
| `ReplayWebhooksResponse` | `src/OmbrevixBilling/Models/ReplayWebhooksResponse.cs` |

### UpdateEndpoint

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateEndpoint(UpdateEndpointRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `EndpointId`
- **Returns**: `EndpointResponse`
- **Error**: `ApiException<UpdateEndpointError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateEndpointRequest` | `src/OmbrevixBilling/Requests/WebhooksApi/UpdateEndpointRequest.cs` |
| `CreateOrUpdateEndpointRequest` | `src/OmbrevixBilling/Models/CreateOrUpdateEndpointRequest.cs` |
| `EndpointResponse` | `src/OmbrevixBilling/Models/EndpointResponse.cs` |
| `UpdateEndpointError` | `src/OmbrevixBilling/Errors/UpdateEndpointError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

