<!-- Generated file — do not edit; regenerated with the SDK. -->

# Offers — operations

Accessor: `client.Offers` · Source: `src/OmbrevixBilling/Api/Offers.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ArchiveOffer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ArchiveOffer(ArchiveOfferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OfferId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ArchiveOfferRequest` | `src/OmbrevixBilling/Requests/Offers/ArchiveOfferRequest.cs` |

### CreateOffer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreateOffer(CreateOfferOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `OfferResponse`
- **Error**: `ApiException<CreateOfferError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse([NotNullWhen(true)] out ErrorArrayMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateOfferOperationRequest` | `src/OmbrevixBilling/Requests/Offers/CreateOfferOperationRequest.cs` |
| `CreateOfferRequest` | `src/OmbrevixBilling/Models/CreateOfferRequest.cs` |
| `OfferResponse` | `src/OmbrevixBilling/Models/OfferResponse.cs` |
| `CreateOfferError` | `src/OmbrevixBilling/Errors/CreateOfferError.cs` |
| `ErrorArrayMapResponse` | `src/OmbrevixBilling/Models/ErrorArrayMapResponse.cs` |

### ListOffers

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListOffers(ListOffersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `include_archived` ← `IncludeArchived`
- **Returns**: `ListOffersResponse`
- **Error**: `ApiException<ListOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListOffersRequest` | `src/OmbrevixBilling/Requests/Offers/ListOffersRequest.cs` |
| `ListOffersResponse` | `src/OmbrevixBilling/Models/ListOffersResponse.cs` |
| `ListOffersError` | `src/OmbrevixBilling/Errors/ListOffersError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadOffer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadOffer(ReadOfferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OfferId`
- **Returns**: `OfferResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ReadOfferRequest` | `src/OmbrevixBilling/Requests/Offers/ReadOfferRequest.cs` |
| `OfferResponse` | `src/OmbrevixBilling/Models/OfferResponse.cs` |

### UnarchiveOffer

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UnarchiveOffer(UnarchiveOfferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OfferId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UnarchiveOfferRequest` | `src/OmbrevixBilling/Requests/Offers/UnarchiveOfferRequest.cs` |

