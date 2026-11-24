using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class PreviewProvisionsError : ApiError
{
    private readonly Optional<AddonProvisionError> _addonProvisionErrorValue;

    private PreviewProvisionsError(Optional<AddonProvisionError> addonProvisionErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _addonProvisionErrorValue = addonProvisionErrorValue;
    }

    private static PreviewProvisionsError AsAddonProvisionError(AddonProvisionError value) =>
        new(Optional<AddonProvisionError>.Some(value), default);

    private static PreviewProvisionsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetAddonProvisionError([NotNullWhen(true)] out AddonProvisionError? value) =>
        _addonProvisionErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<AddonProvisionError, TResult> onAddonProvisionError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetAddonProvisionError(out var addonProvisionErrorValue) => onAddonProvisionError(
                addonProvisionErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(PreviewProvisionsError)} holds no value.")
        };

    public void Match(Action<AddonProvisionError> onAddonProvisionError, Action<RawError> otherwise)
    {
        if (TryGetAddonProvisionError(out var addonProvisionErrorValue)) onAddonProvisionError(
            addonProvisionErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(PreviewProvisionsError)} holds no value.");
    }

    private static Task<PreviewProvisionsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<AddonProvisionError>().As(AsAddonProvisionError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<PreviewProvisionsError> Response { get; } = new(Create);
}
