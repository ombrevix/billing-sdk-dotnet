using System.Net.Http;
using OmbrevixBilling.Api;
using OmbrevixBilling.Core;
using OmbrevixBilling.Core.Configuration;
using OmbrevixBilling.Core.Logging;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling;

/// <summary>
/// Ombrevix Billing provides an HTTP-based API that conforms to the principles of REST.
/// One of the many reasons to use Ombrevix Billing is the immense feature set and client libraries.
/// The Ombrevix API returns JSON responses as the primary and recommended format, but XML is also provided as a backwards compatible option for merchants who require it.
/// <para>
/// ## Steps to make your first Ombrevix Billing API call
/// </para>
/// <list type="number">
///   <item><description>Sign-up or log-in to your test workspace account.</description></item>
///   <item><description>Setup authentication credentials.</description></item>
///   <item><description>Submit an API request and verify the response.</description></item>
///   <item><description>Test the Ombrevix Billing integrations.</description></item>
/// </list>
/// <para>
/// Next, you can explore authentication methods, basic concepts for interacting with Ombrevix Billing via the API, and the entire set of application-based documentation to aid in your discovery of the product.
/// </para>
/// <para>
/// ### Request Example
/// </para>
/// <para>
/// The following example uses the curl command-line tool to make an API request.
/// </para>
/// <para>
/// <b>Request</b>
/// </para>
/// <para>
///     curl -u &lt;api_key&gt;:x -H Accept:application/json -H Content-Type:application/json https://acme.ombrevix.example/subscriptions
/// </para>
/// </summary>
public sealed class OmbrevixBillingClient
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    public OmbrevixBillingClient(HttpClient httpClient, OmbrevixBillingClientOptions options)
    {
        _server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory = new HeadersFactory([
            new HeaderParam("User-Agent", "OmbrevixBillingClient/1.0 CSharp"),
            new HeaderParam("X-APIMatic-Lang", "CSharp"),
            new HeaderParam("X-APIMatic-Package-Version", "1.0"),
            new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
            new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
            new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime),
        ]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry, options.TimeProvider);
        var httpLogger = new HttpLogger(
            options.Logging.WithEnvironmentDefaults("OMBREVIX_BILLING_LOG"),
            "OmbrevixBillingClient",
            options.TimeProvider);
        var responseContexts = new ResponseContextFactory(options.TimeProvider, options.StreamReadTimeout);
        _rawClient =
            new RawClient(
                httpClient,
                urlFactory,
                httpStatusPolicy,
                headersFactory,
                resiliencePipelineFactory,
                httpLogger,
                options.Hooks,
                responseContexts);
        _auth = new AuthSchemes(options);
    }

    public ApiExports ApiExports => field ??= new ApiExports(_rawClient, _server, _auth);

    public AddonPriceOptions AddonPriceOptions => field ??= new AddonPriceOptions(_rawClient, _server, _auth);

    public Addons Addons => field ??= new Addons(_rawClient, _server, _auth);

    public AdvanceInvoice AdvanceInvoice => field ??= new AdvanceInvoice(_rawClient, _server, _auth);

    public AffiliateCodes AffiliateCodes => field ??= new AffiliateCodes(_rawClient, _server, _auth);

    public BillingPortal BillingPortal => field ??= new BillingPortal(_rawClient, _server, _auth);

    public Coupons Coupons => field ??= new Coupons(_rawClient, _server, _auth);

    public CustomFields CustomFields => field ??= new CustomFields(_rawClient, _server, _auth);

    public Customers Customers => field ??= new Customers(_rawClient, _server, _auth);

    public EstimateInvoices EstimateInvoices => field ??= new EstimateInvoices(_rawClient, _server, _auth);

    public Events Events => field ??= new Events(_rawClient, _server, _auth);

    public EventsUsageBillingSegments EventsUsageBillingSegments =>
        field ??= new EventsUsageBillingSegments(_rawClient, _server, _auth);

    public Insights Insights => field ??= new Insights(_rawClient, _server, _auth);

    public Invoices Invoices => field ??= new Invoices(_rawClient, _server, _auth);

    public Offers Offers => field ??= new Offers(_rawClient, _server, _auth);

    /// <summary>
    /// Obtain an OAuth 2.0 access token for the Ombrevix API Gateway.
    /// </summary>
    public OmbrevixGateway OmbrevixGateway => field ??= new OmbrevixGateway(_rawClient, _server);

    public PaymentProfiles PaymentProfiles => field ??= new PaymentProfiles(_rawClient, _server, _auth);

    public ProductLineups ProductLineups => field ??= new ProductLineups(_rawClient, _server, _auth);

    public ProductPriceOptions ProductPriceOptions => field ??= new ProductPriceOptions(_rawClient, _server, _auth);

    public Products Products => field ??= new Products(_rawClient, _server, _auth);

    public ReasonCodes ReasonCodes => field ??= new ReasonCodes(_rawClient, _server, _auth);

    public SalesCommissions SalesCommissions => field ??= new SalesCommissions(_rawClient, _server, _auth);

    public SubscriptionAddons SubscriptionAddons => field ??= new SubscriptionAddons(_rawClient, _server, _auth);

    public SubscriptionBundleInvoiceAccount SubscriptionBundleInvoiceAccount =>
        field ??= new SubscriptionBundleInvoiceAccount(_rawClient, _server, _auth);

    public SubscriptionBundleStatus SubscriptionBundleStatus =>
        field ??= new SubscriptionBundleStatus(_rawClient, _server, _auth);

    public SubscriptionBundles SubscriptionBundles => field ??= new SubscriptionBundles(_rawClient, _server, _auth);

    public SubscriptionInvoiceAccount SubscriptionInvoiceAccount =>
        field ??= new SubscriptionInvoiceAccount(_rawClient, _server, _auth);

    public SubscriptionNotes SubscriptionNotes => field ??= new SubscriptionNotes(_rawClient, _server, _auth);

    public SubscriptionProducts SubscriptionProducts => field ??= new SubscriptionProducts(_rawClient, _server, _auth);

    public SubscriptionRenewals SubscriptionRenewals => field ??= new SubscriptionRenewals(_rawClient, _server, _auth);

    public SubscriptionStatus SubscriptionStatus => field ??= new SubscriptionStatus(_rawClient, _server, _auth);

    public Subscriptions Subscriptions => field ??= new Subscriptions(_rawClient, _server, _auth);

    public WebhooksApi WebhooksApi => field ??= new WebhooksApi(_rawClient, _server, _auth);

    public Workspaces Workspaces => field ??= new Workspaces(_rawClient, _server, _auth);
}
