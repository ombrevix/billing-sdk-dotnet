using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Invoices;

/// <summary>
/// The inputs of the RecordPaymentForMultipleInvoices operation.
/// </summary>
public sealed record RecordPaymentForMultipleInvoicesRequest
{
    public CreateMultiInvoicePaymentRequest? Body { get; init; }
}
