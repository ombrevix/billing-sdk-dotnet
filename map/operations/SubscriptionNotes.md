<!-- Generated file — do not edit; regenerated with the SDK. -->

# SubscriptionNotes — operations

Accessor: `client.SubscriptionNotes` · Source: `src/OmbrevixBilling/Api/SubscriptionNotes.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateSubscriptionNote

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateSubscriptionNote(CreateSubscriptionNoteRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `ApiException<CreateSubscriptionNoteError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSubscriptionNoteRequest` | `src/OmbrevixBilling/Requests/SubscriptionNotes/CreateSubscriptionNoteRequest.cs` |
| `UpdateSubscriptionNoteRequest` | `src/OmbrevixBilling/Models/UpdateSubscriptionNoteRequest.cs` |
| `SubscriptionNoteResponse` | `src/OmbrevixBilling/Models/SubscriptionNoteResponse.cs` |
| `CreateSubscriptionNoteError` | `src/OmbrevixBilling/Errors/CreateSubscriptionNoteError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeleteSubscriptionNote

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteSubscriptionNote(DeleteSubscriptionNoteRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `NoteId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteSubscriptionNoteRequest` | `src/OmbrevixBilling/Requests/SubscriptionNotes/DeleteSubscriptionNoteRequest.cs` |

### ListSubscriptionNotes

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSubscriptionNotes(ListSubscriptionNotesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `IReadOnlyList<SubscriptionNoteResponse>`
- **Error**: `ApiException<ListSubscriptionNotesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSubscriptionNotesRequest` | `src/OmbrevixBilling/Requests/SubscriptionNotes/ListSubscriptionNotesRequest.cs` |
| `SubscriptionNoteResponse` | `src/OmbrevixBilling/Models/SubscriptionNoteResponse.cs` |
| `ListSubscriptionNotesError` | `src/OmbrevixBilling/Errors/ListSubscriptionNotesError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadSubscriptionNote

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSubscriptionNote(ReadSubscriptionNoteRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `NoteId`
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadSubscriptionNoteRequest` | `src/OmbrevixBilling/Requests/SubscriptionNotes/ReadSubscriptionNoteRequest.cs` |
| `SubscriptionNoteResponse` | `src/OmbrevixBilling/Models/SubscriptionNoteResponse.cs` |

### UpdateSubscriptionNote

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdateSubscriptionNote(UpdateSubscriptionNoteOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `NoteId`
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `ApiException<UpdateSubscriptionNoteError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSubscriptionNoteOperationRequest` | `src/OmbrevixBilling/Requests/SubscriptionNotes/UpdateSubscriptionNoteOperationRequest.cs` |
| `UpdateSubscriptionNoteRequest` | `src/OmbrevixBilling/Models/UpdateSubscriptionNoteRequest.cs` |
| `SubscriptionNoteResponse` | `src/OmbrevixBilling/Models/SubscriptionNoteResponse.cs` |
| `UpdateSubscriptionNoteError` | `src/OmbrevixBilling/Errors/UpdateSubscriptionNoteError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

