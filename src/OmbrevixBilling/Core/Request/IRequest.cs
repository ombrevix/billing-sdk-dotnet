using System.Net.Http;

namespace OmbrevixBilling.Core.Request;

internal interface IRequest
{
    HttpContent Get();

    bool CanRetry { get; }
}
