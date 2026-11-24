using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Servers;

public class OauthOptions
{
    public UsOptions Us { get; set; } = new();
    public EuOptions Eu { get; set; } = new();
    public OmbrevixApiGatewayOptions OmbrevixApiGateway { get; set; } = new();

    internal UrlTemplate Resolve(ServerEnvironment environment, string path) =>
        environment.Match(
            () => new UrlTemplate(Us.BaseUrl, path, [TemplateParam.ForServer("connector", Us.Connector)]),
            () => new UrlTemplate(Eu.BaseUrl, path, [TemplateParam.ForServer("connector", Eu.Connector)]),
            () => new UrlTemplate(
                OmbrevixApiGateway.BaseUrl,
                path,
                [TemplateParam.ForServer("connector", OmbrevixApiGateway.Connector)]));

    public class UsOptions
    {
        public string BaseUrl { get; set; } = "https://{connector}.api.ombrevix.example";
        public string Connector { get; set; } = "connector";
    }

    public class EuOptions
    {
        public string BaseUrl { get; set; } = "https://{connector}.api.ombrevix.example";
        public string Connector { get; set; } = "connector";
    }

    public class OmbrevixApiGatewayOptions
    {
        public string BaseUrl { get; set; } = "https://{connector}.api.ombrevix.example";
        public string Connector { get; set; } = "connector";
    }
}
