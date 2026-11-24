namespace OmbrevixBilling.Requests.Customers;

/// <summary>
/// The inputs of the ReadCustomer operation.
/// </summary>
public sealed record ReadCustomerRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the customer
    /// </summary>
    public required int Id { get; init; }
}
