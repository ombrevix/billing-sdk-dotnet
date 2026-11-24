using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Offers;

/// <summary>
/// The inputs of the CreateOffer operation.
/// </summary>
public sealed record CreateOfferOperationRequest
{
    public CreateOfferRequest? Body { get; init; }
}
