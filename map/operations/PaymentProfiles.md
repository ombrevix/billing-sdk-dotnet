<!-- Generated file — do not edit; regenerated with the SDK. -->

# PaymentProfiles — operations

Accessor: `client.PaymentProfiles` · Source: `src/OmbrevixBilling/Api/PaymentProfiles.cs` · 12 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ChangeSubscriptionBundleDefaultPaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ChangeSubscriptionBundleDefaultPaymentProfile(ChangeSubscriptionBundleDefaultPaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`, `PaymentProfileId`
- **Returns**: `PaymentProfileResponse`
- **Error**: `ApiException<ChangeSubscriptionBundleDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ChangeSubscriptionBundleDefaultPaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/ChangeSubscriptionBundleDefaultPaymentProfileRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |
| `ChangeSubscriptionBundleDefaultPaymentProfileError` | `src/OmbrevixBilling/Errors/ChangeSubscriptionBundleDefaultPaymentProfileError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ChangeSubscriptionDefaultPaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ChangeSubscriptionDefaultPaymentProfile(ChangeSubscriptionDefaultPaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `PaymentProfileId`
- **Returns**: `PaymentProfileResponse`
- **Error**: `ApiException<ChangeSubscriptionDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ChangeSubscriptionDefaultPaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/ChangeSubscriptionDefaultPaymentProfileRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |
| `ChangeSubscriptionDefaultPaymentProfileError` | `src/OmbrevixBilling/Errors/ChangeSubscriptionDefaultPaymentProfileError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### CreatePaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `CreatePaymentProfile(CreatePaymentProfileOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `ApiException<CreatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePaymentProfileOperationRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/CreatePaymentProfileOperationRequest.cs` |
| `CreatePaymentProfileRequest` | `src/OmbrevixBilling/Models/CreatePaymentProfileRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |
| `CreatePaymentProfileError` | `src/OmbrevixBilling/Errors/CreatePaymentProfileError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### DeleteSubscriptionBundlePaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteSubscriptionBundlePaymentProfile(DeleteSubscriptionBundlePaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Uid`, `PaymentProfileId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteSubscriptionBundlePaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/DeleteSubscriptionBundlePaymentProfileRequest.cs` |

### DeleteSubscriptionsPaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteSubscriptionsPaymentProfile(DeleteSubscriptionsPaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`, `PaymentProfileId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteSubscriptionsPaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/DeleteSubscriptionsPaymentProfileRequest.cs` |

### DeleteUnusedPaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `DeleteUnusedPaymentProfile(DeleteUnusedPaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PaymentProfileId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteUnusedPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteUnusedPaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/DeleteUnusedPaymentProfileRequest.cs` |
| `DeleteUnusedPaymentProfileError` | `src/OmbrevixBilling/Errors/DeleteUnusedPaymentProfileError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ListPaymentProfiles

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ListPaymentProfiles(ListPaymentProfilesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `page` ← `Page`, `per_page` ← `PerPage`, `customer_id` ← `CustomerId`
- **Returns**: `IReadOnlyList<PaymentProfileResponse>`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `ListPaymentProfilesRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/ListPaymentProfilesRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |

### ReadOneTimeToken

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadOneTimeToken(ReadOneTimeTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PlatformToken`
- **Returns**: `GetOneTimeTokenRequest`
- **Error**: `ApiException<ReadOneTimeTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadOneTimeTokenRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/ReadOneTimeTokenRequest.cs` |
| `GetOneTimeTokenRequest` | `src/OmbrevixBilling/Models/GetOneTimeTokenRequest.cs` |
| `ReadOneTimeTokenError` | `src/OmbrevixBilling/Errors/ReadOneTimeTokenError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### ReadPaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `ReadPaymentProfile(ReadPaymentProfileRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PaymentProfileId`
- **Returns**: `PaymentProfileResponse`
- **Error**: `ApiException<ReadPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ReadPaymentProfileRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/ReadPaymentProfileRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |
| `ReadPaymentProfileError` | `src/OmbrevixBilling/Errors/ReadPaymentProfileError.cs` |

### SendRequestUpdatePaymentEmail

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `SendRequestUpdatePaymentEmail(SendRequestUpdatePaymentEmailRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SubscriptionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<SendRequestUpdatePaymentEmailError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `SendRequestUpdatePaymentEmailRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/SendRequestUpdatePaymentEmailRequest.cs` |
| `SendRequestUpdatePaymentEmailError` | `src/OmbrevixBilling/Errors/SendRequestUpdatePaymentEmailError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

### UpdatePaymentProfile

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `UpdatePaymentProfile(UpdatePaymentProfileOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PaymentProfileId`
- **Returns**: `PaymentProfileResponse`
- **Error**: `ApiException<UpdatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePaymentProfileOperationRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/UpdatePaymentProfileOperationRequest.cs` |
| `UpdatePaymentProfileRequest` | `src/OmbrevixBilling/Models/UpdatePaymentProfileRequest.cs` |
| `PaymentProfileResponse` | `src/OmbrevixBilling/Models/PaymentProfileResponse.cs` |
| `UpdatePaymentProfileError` | `src/OmbrevixBilling/Errors/UpdatePaymentProfileError.cs` |
| `ErrorStringMapResponse` | `src/OmbrevixBilling/Models/ErrorStringMapResponse.cs` |

### VerifyBankAccount

- **Auth**: `options.BasicAuth` OR `options.BearerAuth`
- **Signature**: `VerifyBankAccount(VerifyBankAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BankAccountId`
- **Returns**: `BankAccountResponse`
- **Error**: `ApiException<VerifyBankAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [404] · `TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value)` [422] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `VerifyBankAccountRequest` | `src/OmbrevixBilling/Requests/PaymentProfiles/VerifyBankAccountRequest.cs` |
| `BankAccountVerificationRequest` | `src/OmbrevixBilling/Models/BankAccountVerificationRequest.cs` |
| `BankAccountResponse` | `src/OmbrevixBilling/Models/BankAccountResponse.cs` |
| `VerifyBankAccountError` | `src/OmbrevixBilling/Errors/VerifyBankAccountError.cs` |
| `ErrorListResponse` | `src/OmbrevixBilling/Models/ErrorListResponse.cs` |

