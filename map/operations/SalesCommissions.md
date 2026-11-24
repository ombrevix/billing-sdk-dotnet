<!-- Generated file — do not edit; regenerated with the SDK. -->

# SalesCommissions — operations

Accessor: `client.SalesCommissions` · Source: `src/OmbrevixBilling/Api/SalesCommissions.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListSalesCommissionSettings

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSalesCommissionSettings(ListSalesCommissionSettingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`
- **Query params (wire ← C#)**: `live_mode` ← `LiveMode`, `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `IReadOnlyList<SaleRepSettings>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSalesCommissionSettingsRequest` | `src/OmbrevixBilling/Requests/SalesCommissions/ListSalesCommissionSettingsRequest.cs` |
| `SaleRepSettings` | `src/OmbrevixBilling/Models/SaleRepSettings.cs` |

### ListSalesReps

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListSalesReps(ListSalesRepsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`
- **Query params (wire ← C#)**: `live_mode` ← `LiveMode`, `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `IReadOnlyList<ListSaleRepItem>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListSalesRepsRequest` | `src/OmbrevixBilling/Requests/SalesCommissions/ListSalesRepsRequest.cs` |
| `ListSaleRepItem` | `src/OmbrevixBilling/Models/ListSaleRepItem.cs` |

### ReadSalesRep

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadSalesRep(ReadSalesRepRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `SalesRepId`
- **Query params (wire ← C#)**: `live_mode` ← `LiveMode`, `page` ← `Page`, `per_page` ← `PerPage`
- **Returns**: `SaleRep`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadSalesRepRequest` | `src/OmbrevixBilling/Requests/SalesCommissions/ReadSalesRepRequest.cs` |
| `SaleRep` | `src/OmbrevixBilling/Models/SaleRep.cs` |

