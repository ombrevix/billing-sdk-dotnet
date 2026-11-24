using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Servers;

public class EbbOptions
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
                [TemplateParam.ForServer("workspace", OmbrevixApiGateway.Workspace)]));

    public class UsOptions
    {
        public string BaseUrl { get; set; } = "https://events.ombrevix.example/{workspace}";
        public string Workspace { get; set; } = "subdomain";
    }

    public class EuOptions
    {
        public string BaseUrl { get; set; } = "https://events.ombrevix.example/{workspace}";
        public string Workspace { get; set; } = "subdomain";
    }

    public class OmbrevixApiGatewayOptions
    {
        public string BaseUrl { get; set; } = "https://events.ombrevix.example/{workspace}";
        public string Workspace { get; set; } = "subdomain";
    }
}
