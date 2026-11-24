<!-- Generated file — do not edit; regenerated with the SDK. -->

# SDK map — Ombrevix Billing (.NET)

> A generated table of contents for this SDK. Consult this map and its sub-pages to learn signatures, error types, and server/auth wiring **by lookup**. Model shapes and enum values are *not* duplicated here — the map names the file declaring each type; read the shape there. The compiler is the backstop: a wrong name fails to build.

|  |  |
| --- | --- |
| SDK display name | Ombrevix Billing |
| Root namespace | `OmbrevixBilling` |
| Target framework | `netstandard2.0` (C# `LangVersion 14`, `Nullable enable`) |
| API spec version | `1.0` |
| Generator | APIMatic |

Staleness check: the API spec version above changes when the SDK is regenerated from a new spec. If a lookup here fails to compile, trust the compiler and re-read the source file named in the row.

All `Source` paths on this map and its sub-pages are relative to the **SDK root** — the directory holding this file — never to the page that carries them; the project file is `src/OmbrevixBilling/OmbrevixBilling.csproj`. Open them as-is from the SDK root, from any page; if the SDK sits under a subdirectory of a larger repo, prefix that subdirectory.

---

## Getting a client

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options = new OmbrevixBillingClientOptions
{
    BasicAuth = new BasicAuthCredentials { Username = "YOUR_USERNAME", Password = "YOUR_PASSWORD" },
    BearerAuth = "YOUR_BEARER_TOKEN",
    Environment = ServerEnvironment.Us,
};
var client = new OmbrevixBillingClient(httpClient, options);
```

DI alternative (`services.AddOmbrevixBillingClient`):

```csharp
services.AddOmbrevixBillingClient(options =>
{
    options.BasicAuth = new BasicAuthCredentials { Username = "YOUR_USERNAME", Password = "YOUR_PASSWORD" };
    options.BearerAuth = "YOUR_BEARER_TOKEN";
    options.Environment = ServerEnvironment.Us;
    // TODO: configure more client options here
});
```

Every API group is a property on the client (e.g. `client.ApiExports`). Source: `src/OmbrevixBilling/OmbrevixBillingClient.cs`. The only constructor is `OmbrevixBillingClient(HttpClient httpClient, OmbrevixBillingClientOptions options)`.

All `OmbrevixBillingClientOptions` properties (source: `src/OmbrevixBilling/OmbrevixBillingClientOptions.cs`):

| Property | Type |
| --- | --- |
| `Environment` | `ServerEnvironment` |
| `Retry` | `RetryOptions` |
| `Logging` | `LoggingOptions` |
| `TimeProvider` | `TimeProvider` |
| `Server` | `ServerOptions` |
| `StreamReadTimeout` | `TimeSpan?` |
| `Hooks` | `IReadOnlyList<SdkHook>` |
| `BasicAuth` | `BasicAuthCredentials?` |
| `BasicAuthProvider` | `CredentialProvider<BasicAuthCredentials>?` |
| `BearerAuth` | `string?` |
| `BearerAuthProvider` | `CredentialProvider<string>?` |

`ServerEnvironment` (source: `src/OmbrevixBilling/Servers/ServerEnvironment.cs`, namespace `OmbrevixBilling.Servers`)
`BasicAuthCredentials` (source: `src/OmbrevixBilling/Core/Authentication/Basic/BasicAuthCredentials.cs`, namespace `OmbrevixBilling.Core.Authentication.Basic`)

`RetryOptions` members (namespace `OmbrevixBilling.Core.Configuration` — add `using OmbrevixBilling.Core.Configuration;`; source: `src/OmbrevixBilling/Core/Configuration/RetryOptions.cs`; all members are `required`, so build a full instance or start from `RetryOptions.Default()`):

| Member | Type |
| --- | --- |
| `StatusCodesToRetry` | `IReadOnlyList<HttpStatusCode>` |
| `HttpMethodsToRetry` | `IReadOnlyList<HttpMethod>` |
| `MaxRetries` | `int` |
| `Delay` | `TimeSpan` |
| `Timeout` | `TimeSpan?` |
| `BackOffFactor` | `int` |
| `UseExponentialBackoff` | `bool` |
| `MaxJitter` | `TimeSpan` |
| `OnRetry` | `Action<RetryAttempt>?` |

---

## Error-handling model (read once — applies to every operation)

Operations are **throw-based**. On an error status the SDK throws `ApiException<TError>` (`src/OmbrevixBilling/Core/Exceptions/ApiException.cs`, namespace `OmbrevixBilling.Core.Exceptions`) exposing `.Error` of type `TError` beside the `StatusCode`, `Headers` and `ContentType` of the response. There are two cases:

- **Case A — typed error.** `TError` is a generated `…Error : ApiError` class (namespace `OmbrevixBilling.Errors`) with status-specific `TryGet…(out …)` accessors (each returns `true` when that shape is present) plus the inherited `TryGetRawError([NotNullWhen(true)] out RawError? error)` fallback, and an exhaustive `Match` pair — `Match<TResult>(Func<T, TResult> on{Arm}…, Func<RawError, TResult> otherwise)` and its `Action` twin — with one `on…` arm per accessor, in the ordinal order of their names, and a required `otherwise` that receives the `RawError` of a status the operation does not declare. The operation blocks name the exact `TryGet…` methods and the HTTP status each maps to.
- **Case B — raw error.** `TError` is `RawError` (`src/OmbrevixBilling/Core/ErrorResponse/RawError.cs`, namespace `OmbrevixBilling.Core.ErrorResponse`): `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`.

⚠ Each of the three lives in its own namespace. `src/OmbrevixBilling/Core/` holds several namespaces, so a catch block naming `ApiException<T>`, a typed `{Operation}Error` and `RawError` together needs a `using` for each.

`ApiException<TError>` is one leaf of the `SdkException` family (`src/OmbrevixBilling/Core/Exceptions/SdkException.cs`): a request that produced no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match its declared type as `ResponseDeserializationException`, and a required credential that is not configured, or one that could not be applied, as `AuthSchemeException`. Every one of them names the failed call. The full table is in [README → Error Handling](README.md#error-handling).

Core error types (`src/OmbrevixBilling/Core/ErrorResponse/`) — public members with their **declared types**, verbatim from source:

| Type | Public members | Source |
| --- | --- | --- |
| `ApiError` — abstract base of the 166 typed error classes in `src/OmbrevixBilling/Errors/` | `TryGetRawError([NotNullWhen(true)] out RawError? error): bool` | `src/OmbrevixBilling/Core/ErrorResponse/ApiError.cs` |
| `RawError` | `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | `src/OmbrevixBilling/Core/ErrorResponse/RawError.cs` |

Every accessor over a reference-type payload, on a typed error and on a `OneOf`/`AnyOf` union alike, is `[NotNullWhen(true)] out T?`: read the value inside the `if`, where the compiler has narrowed it; a value-type payload (`long`, `JsonElement`) stays a bare `out`.

Typed-error payload shapes (the `out` types in each operation page's error-accessor cells) are ordinary records/unions — no special handling. The operation's **Type sources** table gives the file that declares each one; read field names, declared types, and JSON wire names there, as for any other model.

```csharp
try
{
    var response = await client.ApiExports.ExportEstimateInvoices();
}
catch (ApiException<ExportEstimateInvoicesError> ex)
{
    // Case A — typed error
    if (ex.Error.TryGetNoContent(out var error))
    {
        // Handle 404
    }
    else if (ex.Error.TryGetRawError(out var raw))
    {
        // Any other error status
    }
}
catch (ApiException<RawError> ex)
{
    // Case B — raw error
    // ex.Error.StatusCode, ex.Error.ReadAsString(), ex.Error.ReadAsJson<T>()
}
```

**No-throw (`…Result`) variants: absent across this SDK** — every operation is throw-only. Of **250 operations**, **166 are Case A (typed)** and **84 are Case B (raw)**.

---

## Operations — by controller (34 groups, 250 operations)

Each links to a sub-page with one row per operation: signature, the request record's required members, query-param wire names (with the serialization style where the spec declares one), return type, error Case A/B, and Case A's typed accessors with their statuses. Each operation also carries a **Type sources** table — every type it names, with the file that declares it — so resolving a body, return, or error payload to its source is a lookup, never a search. `RawError` is excluded there (its members and path are above); an operation with no table names nothing but primitives and `RawError`.

**Each row states what is specific to its operation. Everything below holds for EVERY operation unless that operation's row says otherwise, so a row silent on one of these points is telling you the default here applies — take it and move on rather than opening the source to confirm it.**

| Applies to every operation | Stated where | A row appears only when |
| --- | --- | --- |
| **Throw-only** — no `…Result`/no-throw variant exists anywhere in this SDK | this page, Error-handling model | a no-throw sibling exists (none do at this SDK version) |
| **No pagination** — the operation returns a single response, not a `Pageable` | here | pagination is offered — the block carries a **Pagination** bullet naming the posture (page-, offset-, cursor- or link-based, or the `page`-without-page-size case) |
| **Case B error accessors are always these four** — `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | the `RawError` row above | never — a `Case B` label always implies exactly these four; Case A rows list their own typed accessors |
| **Server group `Production`** — base URL per Servers & auth below | here | the operation is on another group — its block carries a **Server group** bullet |
| **Inputs are one request record** — an operation that takes input takes a single request record as its first parameter; build it with an object initializer, using the property names in the record's source (its file is in the operation's **Type sources**). A member the row does not list as required is optional or already carries the spec's default | here | never — it always holds |

**The HTTP verb and route live on the operation itself**, in the source file named at the top of its operations page. This map is method-first: the C# method is the interface you call. When something wire-level needs the route — reproducing a raw request, pointing the client at a mock, reading a provider-side log — read it from that file; do not reconstruct it from memory or infer it from the method name.

**The endpoint's behavioural prose lives there too**, as the XML `<remarks>` on the method. Rows here give you the contract — names, types, shapes, errors. Where an operation's *semantics* decide what you must pass — a parameter whose value changes server-side behaviour, an ordering or exclusivity rule between fields — that is what `<remarks>` settles; read it there rather than filling it in from memory.

| Controller (`client.X`) | Ops | Page |
| --- | --- | --- |
| `ApiExports` | 9 | [map/operations/ApiExports.md](map/operations/ApiExports.md) |
| `AddonPriceOptions` | 12 | [map/operations/AddonPriceOptions.md](map/operations/AddonPriceOptions.md) |
| `Addons` | 12 | [map/operations/Addons.md](map/operations/Addons.md) |
| `AdvanceInvoice` | 3 | [map/operations/AdvanceInvoice.md](map/operations/AdvanceInvoice.md) |
| `AffiliateCodes` | 1 | [map/operations/AffiliateCodes.md](map/operations/AffiliateCodes.md) |
| `BillingPortal` | 4 | [map/operations/BillingPortal.md](map/operations/BillingPortal.md) |
| `Coupons` | 14 | [map/operations/Coupons.md](map/operations/Coupons.md) |
| `CustomFields` | 9 | [map/operations/CustomFields.md](map/operations/CustomFields.md) |
| `Customers` | 7 | [map/operations/Customers.md](map/operations/Customers.md) |
| `EstimateInvoices` | 10 | [map/operations/EstimateInvoices.md](map/operations/EstimateInvoices.md) |
| `Events` | 3 | [map/operations/Events.md](map/operations/Events.md) |
| `EventsUsageBillingSegments` | 6 | [map/operations/EventsUsageBillingSegments.md](map/operations/EventsUsageBillingSegments.md) |
| `Insights` | 4 | [map/operations/Insights.md](map/operations/Insights.md) |
| `Invoices` | 19 | [map/operations/Invoices.md](map/operations/Invoices.md) |
| `Offers` | 5 | [map/operations/Offers.md](map/operations/Offers.md) |
| `OmbrevixGateway` | 1 | [map/operations/OmbrevixGateway.md](map/operations/OmbrevixGateway.md) |
| `PaymentProfiles` | 12 | [map/operations/PaymentProfiles.md](map/operations/PaymentProfiles.md) |
| `ProductLineups` | 4 | [map/operations/ProductLineups.md](map/operations/ProductLineups.md) |
| `ProductPriceOptions` | 11 | [map/operations/ProductPriceOptions.md](map/operations/ProductPriceOptions.md) |
| `Products` | 6 | [map/operations/Products.md](map/operations/Products.md) |
| `ReasonCodes` | 5 | [map/operations/ReasonCodes.md](map/operations/ReasonCodes.md) |
| `SalesCommissions` | 3 | [map/operations/SalesCommissions.md](map/operations/SalesCommissions.md) |
| `SubscriptionAddons` | 17 | [map/operations/SubscriptionAddons.md](map/operations/SubscriptionAddons.md) |
| `SubscriptionBundleInvoiceAccount` | 4 | [map/operations/SubscriptionBundleInvoiceAccount.md](map/operations/SubscriptionBundleInvoiceAccount.md) |
| `SubscriptionBundleStatus` | 4 | [map/operations/SubscriptionBundleStatus.md](map/operations/SubscriptionBundleStatus.md) |
| `SubscriptionBundles` | 9 | [map/operations/SubscriptionBundles.md](map/operations/SubscriptionBundles.md) |
| `SubscriptionInvoiceAccount` | 7 | [map/operations/SubscriptionInvoiceAccount.md](map/operations/SubscriptionInvoiceAccount.md) |
| `SubscriptionNotes` | 5 | [map/operations/SubscriptionNotes.md](map/operations/SubscriptionNotes.md) |
| `SubscriptionProducts` | 2 | [map/operations/SubscriptionProducts.md](map/operations/SubscriptionProducts.md) |
| `SubscriptionRenewals` | 11 | [map/operations/SubscriptionRenewals.md](map/operations/SubscriptionRenewals.md) |
| `SubscriptionStatus` | 10 | [map/operations/SubscriptionStatus.md](map/operations/SubscriptionStatus.md) |
| `Subscriptions` | 12 | [map/operations/Subscriptions.md](map/operations/Subscriptions.md) |
| `WebhooksApi` | 6 | [map/operations/WebhooksApi.md](map/operations/WebhooksApi.md) |
| `Workspaces` | 3 | [map/operations/Workspaces.md](map/operations/Workspaces.md) |

---

## Models — where they live, how to build them

**Shapes live only in the source.** Every file under `src/OmbrevixBilling/Models/`, `src/OmbrevixBilling/Errors/` and `src/OmbrevixBilling/Requests/` declares exactly one public type, named after the file, and no two share a name — so a type name *is* its path. Take it from the operation's **Type sources** table, or build it from the kind's directory below. Never grep for a type.

| Group | Count | Directory (file = `<TypeName>.cs`) |
| --- | --- | --- |
| Records (plain `record` data models) | 564 | `src/OmbrevixBilling/Models/` |
| Unions (`OneOf`) — variant factories + `TryGet…` + `Match` | 4 | `src/OmbrevixBilling/Models/OneOf/` |
| Unions (`AnyOf`) — variant factories + `TryGet…` + `Match` | 83 | `src/OmbrevixBilling/Models/AnyOf/` |
| Enums (`OpenStringEnum<T>` / `OpenIntEnum<T>`) — C# member names + wire values | 98 | `src/OmbrevixBilling/Models/Enums/` |
| Typed error classes (`: ApiError`, one per Case A operation) | 166 | `src/OmbrevixBilling/Errors/` |
| Request records (one per operation that takes input; never serialized) | 244 | `src/OmbrevixBilling/Requests/` — a controller's records sit in a folder named after it (an operation with several tags is filed under the first tag it declares) |

Conventions: records are immutable, `init`-only; `required` properties must be set in the object initializer; `T?` is optional. A field's wire name is its `[JsonPropertyName]` and often differs from the C# name (`AmountMinor` ↔ `amount_minor`) — read it off the property, don't derive it. `OneOf`/`AnyOf` unions wrap `Optional<T>` variants — build via static factory or implicit conversion, read one variant via `TryGet…(out …)` or branch over all of them with the generated `Match`, which takes one `on{Variant}` handler per variant in declaration order and then `otherwise`, which receives the raw `JsonElement` of a value the SDK could not place: unions are open on read, so an unrecognised discriminator value or a body no variant accepts lands in `TryGetUnknown(out JsonElement)` and re-serializes verbatim; pass handlers by name, and treat an added or moved variant as a breaking change; `AllOf` compositions are not unions — every constituent is a `required` property, so set them all, and those constituent properties carry no `[JsonPropertyName]` and have no wire name of their own, because the generated converter flattens each constituent's own fields directly into the one parent JSON object. Enums are **not** C# enums — use the static members, whose names are PascalCase even when the wire value isn't (`CollectionMethod.Invoice`, not `.invoice`); there is no public factory, so resolve a raw value with `TryGetKnownValue` and branch with the generated `Match`, whose `otherwise` arm receives any value the SDK does not declare.

Namespaces by content type (add `using` accordingly):

| Contents | Namespace |
| --- | --- |
| Client & options (root) | `OmbrevixBilling` |
| Operation controllers (`src/OmbrevixBilling/Api/`) | `OmbrevixBilling.Api` |
| Records (`src/OmbrevixBilling/Models/`) | `OmbrevixBilling.Models` |
| Enums (`src/OmbrevixBilling/Models/Enums/`) | `OmbrevixBilling.Models.Enums` |
| OneOf unions (`src/OmbrevixBilling/Models/OneOf/`) | `OmbrevixBilling.Models.OneOf` |
| AnyOf unions (`src/OmbrevixBilling/Models/AnyOf/`) | `OmbrevixBilling.Models.AnyOf` |
| Error classes (`src/OmbrevixBilling/Errors/`) | `OmbrevixBilling.Errors` |
| Request records (`src/OmbrevixBilling/Requests/`) | `OmbrevixBilling.Requests` — plus `.<Controller>` for a controller's records (an operation with several tags is filed under the first tag it declares) |

---

## Servers & auth

**Basic auth.** Set `options.BasicAuth = new BasicAuthCredentials { Username = …, Password = … }`, or `options.BasicAuthProvider` to a delegate asked on every request. The `username` is a Ombrevix Ombrevix API key and the `password` is `x`. Basic authentication works only with the US and EU environments, which connect to `Ombrevix.com` directly. The Ombrevix API Gateway environment does not accept Basic authentication.

**Bearer token.** Set `options.BearerAuth = "<token>"`, or `options.BearerAuthProvider` to a delegate asked on every request. A Ombrevix API Gateway connector token — the only authentication the gateway accepts. Use it with the Ombrevix API Gateway environment. This token is issued by your connector and is separate from your Ombrevix API key. Depending on how the connector was created, it is either a static connector API token you copy from your connector settings (long-lived, valid until you rotate it) or an access token you obtain by exchanging OAuth2 client credentials at `https://<connector>.api.ombrevix.example/oauth/token`.

Operation blocks name their credential in an **Auth** bullet; an operation whose spec declares no scheme carries no such bullet.

- `AND` — every credential listed must be configured; the call fails before anything is sent, naming each one that is not.
- `OR` — the first configured credential that applies is sent, in the order listed; a configured one that fails falls through to the next; when none is configured the call fails before anything is sent, naming all of them.
- `OR anonymous` — the operation accepts anonymous callers: it is authenticated when a whole alternative listed before it is configured (every credential in an AND group), and sent without credentials otherwise.
- `(scopes: …)` — the OAuth2 scopes the operation's token is requested with; a client-credentials scheme mints one token per scope set.

A required credential you never configured fails the call with `AuthSchemeException` before anything is sent, so a `401` on an operation that requires a credential means the server rejected the one that was sent. A credential option left `null` is read from an environment variable when the client is constructed; the README's **Credentials from environment variables** table names them. A value set in code always wins, including the placeholder assignments in the **Getting a client** sample; delete the line for any credential you supply through an environment variable.

**Environments.** `options.Environment` selects the target environment (`src/OmbrevixBilling/Servers/ServerEnvironment.cs`):

| Environment | Value | Hosting |
| --- | --- | --- |
| `ServerEnvironment.Us` *(default)* | `US` | Default Ombrevix Billing environment hosted in US. Valid for the majority of our customers. |
| `ServerEnvironment.Eu` | `EU` | Ombrevix Billing environment hosted in EU. Use only when you requested EU hosting for your AB account. |
| `ServerEnvironment.OmbrevixApiGateway` | `Ombrevix API Gateway` | Access Ombrevix Billing through a Ombrevix API Gateway connector. Authenticate with your connector Bearer token instead of Basic auth. Events-Usage Billing ingestion does not go through the gateway and keeps its direct URL. |

**3 server groups.** Base-URL templates and override points (`options.Server.…`):

| Group | `Us` base URL | `Eu` base URL | `OmbrevixApiGateway` base URL | Override point |
| --- | --- | --- | --- | --- |
| `Production` | `https://{workspace}.ombrevix.example` | `https://{workspace}.eu.ombrevix.example` | `https://{connector}.api.ombrevix.example/api/v1/billing` | `options.Server.Production.Us.BaseUrl` (and the other environments) |
| `Ebb` | `https://events.ombrevix.example/{workspace}` | `https://events.ombrevix.example/{workspace}` | `https://events.ombrevix.example/{workspace}` | `options.Server.Ebb.Us.BaseUrl` (and the other environments) |
| `Oauth` | `https://{connector}.api.ombrevix.example` | `https://{connector}.api.ombrevix.example` | `https://{connector}.api.ombrevix.example` | `options.Server.Oauth.Us.BaseUrl` (and the other environments) |

`Production` · `Us` template variables: `{workspace}` defaults to `"subdomain"` — override `options.Server.Production.Us.Workspace`.

`Production` · `Eu` template variables: `{workspace}` defaults to `"subdomain"` — override `options.Server.Production.Eu.Workspace`.

`Production` · `OmbrevixApiGateway` template variables: `{connector}` defaults to `"connector"` — override `options.Server.Production.OmbrevixApiGateway.Connector`.

`Ebb` · `Us` template variables: `{workspace}` defaults to `"subdomain"` — override `options.Server.Ebb.Us.Workspace`.

`Ebb` · `Eu` template variables: `{workspace}` defaults to `"subdomain"` — override `options.Server.Ebb.Eu.Workspace`.

`Ebb` · `OmbrevixApiGateway` template variables: `{workspace}` defaults to `"subdomain"` — override `options.Server.Ebb.OmbrevixApiGateway.Workspace`.

`Oauth` · `Us` template variables: `{connector}` defaults to `"connector"` — override `options.Server.Oauth.Us.Connector`.

`Oauth` · `Eu` template variables: `{connector}` defaults to `"connector"` — override `options.Server.Oauth.Eu.Connector`.

`Oauth` · `OmbrevixApiGateway` template variables: `{connector}` defaults to `"connector"` — override `options.Server.Oauth.OmbrevixApiGateway.Connector`.

Retry/resilience is configurable via `options.Retry` (`RetryOptions`, backed by Polly).

