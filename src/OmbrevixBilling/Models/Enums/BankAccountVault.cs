using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// The vault that stores the payment profile with the provided vault_token. Use <c>bogus</c> for testing.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BankAccountVault>))]
public sealed record BankAccountVault : OpenStringEnum<BankAccountVault>
{
    private BankAccountVault(string value) : base(value)
    {
    }

    public static readonly BankAccountVault Authorizenet = new("authorizenet");

    public static readonly BankAccountVault BlueSnap = new("blue_snap");

    public static readonly BankAccountVault Simulated = new("simulated");

    public static readonly BankAccountVault Forte = new("forte");

    public static readonly BankAccountVault Gocardless = new("gocardless");

    public static readonly BankAccountVault NativePayments = new("native_payments");

    public static readonly BankAccountVault Obp = new("obp");

    public static readonly BankAccountVault StripeConnect = new("stripe_connect");

    public TResult Match<TResult>(Func<TResult> onAuthorizenet,
        Func<TResult> onBlueSnap,
        Func<TResult> onSimulated,
        Func<TResult> onForte,
        Func<TResult> onGocardless,
        Func<TResult> onNativePayments,
        Func<TResult> onObp,
        Func<TResult> onStripeConnect,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Authorizenet => onAuthorizenet(),
            _ when this == BlueSnap => onBlueSnap(),
            _ when this == Simulated => onSimulated(),
            _ when this == Forte => onForte(),
            _ when this == Gocardless => onGocardless(),
            _ when this == NativePayments => onNativePayments(),
            _ when this == Obp => onObp(),
            _ when this == StripeConnect => onStripeConnect(),
            _ => otherwise(Value)
        };

    public void Match(Action onAuthorizenet,
        Action onBlueSnap,
        Action onSimulated,
        Action onForte,
        Action onGocardless,
        Action onNativePayments,
        Action onObp,
        Action onStripeConnect,
        Action<string> otherwise)
    {
        if (this == Authorizenet) onAuthorizenet();
        else if (this == BlueSnap) onBlueSnap();
        else if (this == Simulated) onSimulated();
        else if (this == Forte) onForte();
        else if (this == Gocardless) onGocardless();
        else if (this == NativePayments) onNativePayments();
        else if (this == Obp) onObp();
        else if (this == StripeConnect) onStripeConnect();
        else otherwise(Value);
    }
}
