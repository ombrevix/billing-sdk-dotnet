using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class BulkUpdateSubscriptionAddonsPriceOptionsError : ApiError
{
    private readonly Optional<AddonPriceOptionError> _addonPriceOptionErrorValue;

    private BulkUpdateSubscriptionAddonsPriceOptionsError(Optional<AddonPriceOptionError> addonPriceOptionErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _addonPriceOptionErrorValue = addonPriceOptionErrorValue;
    }

    private static BulkUpdateSubscriptionAddonsPriceOptionsError AsAddonPriceOptionError(AddonPriceOptionError value) =>
        new(Optional<AddonPriceOptionError>.Some(value), default);

    private static BulkUpdateSubscriptionAddonsPriceOptionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetAddonPriceOptionError([NotNullWhen(true)] out AddonPriceOptionError? value) =>
        _addonPriceOptionErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<AddonPriceOptionError, TResult> onAddonPriceOptionError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAddonPriceOptionError(out var addonPriceOptionErrorValue) => onAddonPriceOptionError(
                addonPriceOptionErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException(
                $"{nameof(BulkUpdateSubscriptionAddonsPriceOptionsError)} holds no value.")
        };

    public void Match(Action<AddonPriceOptionError> onAddonPriceOptionError, Action<RawError> otherwise)
    {
        if (TryGetAddonPriceOptionError(out var addonPriceOptionErrorValue)) onAddonPriceOptionError(
            addonPriceOptionErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException(
            $"{nameof(BulkUpdateSubscriptionAddonsPriceOptionsError)} holds no value.");
    }

    private static Task<BulkUpdateSubscriptionAddonsPriceOptionsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<AddonPriceOptionError>().As(AsAddonPriceOptionError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<BulkUpdateSubscriptionAddonsPriceOptionsError> Response { get; } = new(Create);
}
