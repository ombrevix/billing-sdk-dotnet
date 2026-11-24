using OmbrevixBilling.Core;
using OmbrevixBilling.Core.Authentication;
using OmbrevixBilling.Core.Authentication.Basic;
using OmbrevixBilling.Core.Authentication.Bearer;

namespace OmbrevixBilling;

internal sealed class AuthSchemes
{
    public IAuthScheme BasicAuth { get; }
    public IAuthScheme BearerAuth { get; }

    public AuthSchemes(OmbrevixBillingClientOptions options)
    {
        BasicAuth =
            BasicAuthScheme.Create(
                "BasicAuth",
                options.BasicAuthProvider,
                options.BasicAuth.WithEnvironmentDefaults(
                    "OMBREVIX_BILLING_BASIC_AUTH_USERNAME",
                    "OMBREVIX_BILLING_BASIC_AUTH_PASSWORD"));
        BearerAuth =
            BearerAuthScheme.Create(
                "BearerAuth",
                options.BearerAuthProvider,
                options.BearerAuth ?? EnvironmentVariables.Get("OMBREVIX_BILLING_BEARER_AUTH"));
    }
}
