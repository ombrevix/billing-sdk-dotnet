using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Invoices;

/// <summary>
/// The inputs of the CreateInvoice operation.
/// </summary>
public sealed record CreateInvoiceOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public CreateInvoiceRequest? Body { get; init; }
}
