using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Customers;

/// <summary>
/// The inputs of the UpdateCustomer operation.
/// </summary>
public sealed record UpdateCustomerOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the customer
    /// </summary>
    public required int Id { get; init; }

    public UpdateCustomerRequest? Body { get; init; }
}
