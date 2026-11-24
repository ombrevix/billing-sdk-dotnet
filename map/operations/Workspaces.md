<!-- Generated file — do not edit; regenerated with the SDK. -->

# Workspaces — operations

Accessor: `client.Workspaces` · Source: `src/OmbrevixBilling/Api/Workspaces.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ClearWorkspace

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ClearWorkspace(ClearWorkspaceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `cleanup_scope` ← `CleanupScope`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ClearWorkspaceRequest` | `src/OmbrevixBilling/Requests/Workspaces/ClearWorkspaceRequest.cs` |
| `CleanupScope` | `src/OmbrevixBilling/Models/Enums/CleanupScope.cs` |

### ListPlatformJsPublicKeys

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListPlatformJsPublicKeys(ListPlatformJsPublicKeysRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `ListPublicKeysResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListPlatformJsPublicKeysRequest` | `src/OmbrevixBilling/Requests/Workspaces/ListPlatformJsPublicKeysRequest.cs` |
| `ListPublicKeysResponse` | `src/OmbrevixBilling/Models/ListPublicKeysResponse.cs` |

### ReadWorkspace

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadWorkspace(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `WorkspaceResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `WorkspaceResponse` | `src/OmbrevixBilling/Models/WorkspaceResponse.cs` |

