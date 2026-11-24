using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.WebhooksApi;

/// <summary>
/// The inputs of the UpdateEndpoint operation.
/// </summary>
public sealed record UpdateEndpointRequest
{
    /// <summary>
    /// The Ombrevix Billing id for the endpoint that should be updated
    /// </summary>
    public required int EndpointId { get; init; }

    public CreateOrUpdateEndpointRequest? Body { get; init; }
}
