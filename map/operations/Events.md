<!-- Generated file — do not edit; regenerated with the SDK. -->

# Events — operations

Accessor: `client.Events` · Source: `src/OmbrevixBilling/Api/Events.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListEvents

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListEvents(ListEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `since_id` ← `SinceId`, `max_id` ← `MaxId`, `direction` ← `Direction`, `filter` ← `Filter` (comma-separated), `date_field` ← `DateField`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `start_datetime` ← `StartDatetime`, `end_datetime` ← `EndDatetime`
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListEventsRequest` | `src/OmbrevixBilling/Requests/Events/ListEventsRequest.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `EventKey` | `src/OmbrevixBilling/Models/Enums/EventKey.cs` |
| `ListEventsDateField` | `src/OmbrevixBilling/Models/Enums/ListEventsDateField.cs` |
| `EventResponse` | `src/OmbrevixBilling/Models/EventResponse.cs` |

### ListSubscriptionEvents

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionEvents(ListSubscriptionEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `since_id` ← `SinceId`, `max_id` ← `MaxId`, `direction` ← `Direction`, `filter` ← `Filter` (comma-separated)
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSubscriptionEventsRequest` | `src/OmbrevixBilling/Requests/Events/ListSubscriptionEventsRequest.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `EventKey` | `src/OmbrevixBilling/Models/Enums/EventKey.cs` |
| `EventResponse` | `src/OmbrevixBilling/Models/EventResponse.cs` |

### ReadEventsCount

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadEventsCount(ReadEventsCountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `since_id` ← `SinceId`, `max_id` ← `MaxId`, `direction` ← `Direction`, `filter` ← `Filter` (comma-separated)
- **Returns**: `CountResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadEventsCountRequest` | `src/OmbrevixBilling/Requests/Events/ReadEventsCountRequest.cs` |
| `Direction` | `src/OmbrevixBilling/Models/Enums/Direction.cs` |
| `EventKey` | `src/OmbrevixBilling/Models/Enums/EventKey.cs` |
| `CountResponse` | `src/OmbrevixBilling/Models/CountResponse.cs` |

