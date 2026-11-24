using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.WebhooksApi;

/// <summary>
/// The inputs of the CreateEndpoint operation.
/// </summary>
public sealed record CreateEndpointRequest
{
    public CreateOrUpdateEndpointRequest? Body { get; init; }
}
