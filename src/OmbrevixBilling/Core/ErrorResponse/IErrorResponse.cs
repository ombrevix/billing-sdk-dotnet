using System.Threading;
using System.Threading.Tasks;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Core.ErrorResponse;

internal interface IErrorResponse<TError>
{
    Task<TError> Map(ResponseContext context, CancellationToken cancellationToken);
}
