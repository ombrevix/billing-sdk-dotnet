using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Servers;

public class ProductionOptions
{
    public UsOptions Us { get; set; } = new();
    public EuOptions Eu { get; set; } = new();
    public OmbrevixApiGatewayOptions OmbrevixApiGateway { get; set; } = new();

    internal UrlTemplate Resolve(ServerEnvironment environment, string path) =>
        environment.Match(
            () => new UrlTemplate(Us.BaseUrl, path, [TemplateParam.ForServer("workspace", Us.Workspace)]),
            () => new UrlTemplate(Eu.BaseUrl, path, [TemplateParam.ForServer("workspace", Eu.Workspace)]),
            () => new UrlTemplate(
                OmbrevixApiGateway.BaseUrl,
                path,
                [TemplateParam.ForServer("connector", OmbrevixApiGateway.Connector)]));

    public class UsOptions
    {
        public string BaseUrl { get; set; } = "https://{workspace}.ombrevix.example";
        public string Workspace { get; set; } = "subdomain";
    }

    public class EuOptions
    {
        public string BaseUrl { get; set; } = "https://{workspace}.eu.ombrevix.example";
        public string Workspace { get; set; } = "subdomain";
    }

    public class OmbrevixApiGatewayOptions
    {
        public string BaseUrl { get; set; } = "https://{connector}.api.ombrevix.example/api/v1/billing";
        public string Connector { get; set; } = "connector";
    }
}
