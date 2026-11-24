using System;
using System.Collections.Generic;
using OmbrevixBilling.Core.Authentication;
using OmbrevixBilling.Core.Authentication.Basic;
using OmbrevixBilling.Core.Configuration;
using OmbrevixBilling.Core.Hooks;
using OmbrevixBilling.Servers;

namespace OmbrevixBilling;

public class OmbrevixBillingClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public LoggingOptions Logging { get; set; } = new();
    public TimeProvider TimeProvider { get; set; } = TimeProvider.System;
    public ServerOptions Server { get; set; } = new();
    /// <summary>
    /// Maximum time to wait for the next frame of a streaming (SSE) response before the stream is
    /// torn down with a timeout. Bounds only the wait for the server between frames, never the
    /// caller's own processing time. Set to null to wait indefinitely.
    /// </summary>
    public TimeSpan? StreamReadTimeout { get; set; } = TimeSpan.FromSeconds(60);
    public IReadOnlyList<SdkHook> Hooks { get; set; } = [];
    /// <summary>
    /// The <c>username</c> is a Ombrevix Ombrevix API key and the <c>password</c> is <c>x</c>. Basic authentication works only with the US and EU environments, which connect to <c>Ombrevix.com</c> directly. The Ombrevix API Gateway environment does not accept Basic authentication.
    /// </summary>
    public BasicAuthCredentials? BasicAuth { get; set; }
    public CredentialProvider<BasicAuthCredentials>? BasicAuthProvider { get; set; }
    /// <summary>
    /// A Ombrevix API Gateway connector token — the only authentication the gateway accepts. Use it with the Ombrevix API Gateway environment. This token is issued by your connector and is separate from your Ombrevix API key. Depending on how the connector was created, it is either a static connector API token you copy from your connector settings (long-lived, valid until you rotate it) or an access token you obtain by exchanging OAuth2 client credentials at <c>https://&lt;connector&gt;.api.ombrevix.example/oauth/token</c>.
    /// </summary>
    public string? BearerAuth { get; set; }
    public CredentialProvider<string>? BearerAuthProvider { get; set; }
}
