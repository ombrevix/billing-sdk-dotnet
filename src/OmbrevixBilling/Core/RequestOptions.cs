using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using OmbrevixBilling.Core.Hooks;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Core;

public sealed record RequestOptions
{
    public LogLevel? LogLevel { get; init; }

    public IReadOnlyList<HeaderParam>? Headers { get; init; }

    public IReadOnlyList<SdkHook>? Hooks { get; init; }
}
