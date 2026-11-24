using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class DeletePrepaidUsageProvisionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private readonly Optional<SubscriptionAddonProvisionError> _subscriptionAddonProvisionErrorValue;

    private DeletePrepaidUsageProvisionError(Optional<RawError> noContentValue,
        Optional<SubscriptionAddonProvisionError> subscriptionAddonProvisionErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
        _subscriptionAddonProvisionErrorValue = subscriptionAddonProvisionErrorValue;
    }

    private static DeletePrepaidUsageProvisionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default, default);

    private static DeletePrepaidUsageProvisionError AsSubscriptionAddonProvisionError(SubscriptionAddonProvisionError value) =>
        new(default, Optional<SubscriptionAddonProvisionError>.Some(value), default);

    private static DeletePrepaidUsageProvisionError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public bool TryGetSubscriptionAddonProvisionError([NotNullWhen(true)] out SubscriptionAddonProvisionError? value) =>
        _subscriptionAddonProvisionErrorValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<RawError, TResult> onNoContent,
        Func<SubscriptionAddonProvisionError, TResult> onSubscriptionAddonProvisionError,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetSubscriptionAddonProvisionError(
                out var subscriptionAddonProvisionErrorValue) => onSubscriptionAddonProvisionError(
                subscriptionAddonProvisionErrorValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(DeletePrepaidUsageProvisionError)} holds no value.")
        };

    public void Match(Action<RawError> onNoContent,
        Action<SubscriptionAddonProvisionError> onSubscriptionAddonProvisionError,
        Action<RawError> otherwise)
    {
        if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetSubscriptionAddonProvisionError(
            out var subscriptionAddonProvisionErrorValue)) onSubscriptionAddonProvisionError(
            subscriptionAddonProvisionErrorValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(DeletePrepaidUsageProvisionError)} holds no value.");
    }

    private static Task<DeletePrepaidUsageProvisionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<SubscriptionAddonProvisionError>().As(AsSubscriptionAddonProvisionError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DeletePrepaidUsageProvisionError> Response { get; } = new(Create);
}
