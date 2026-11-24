using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// Indicates the type of datafield. A text datafield allows any string value. Dropdown and radio datafields have a set of values that can be selected. Defaults to 'text'.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DatafieldInput>))]
public sealed record DatafieldInput : OpenStringEnum<DatafieldInput>
{
    private DatafieldInput(string value) : base(value)
    {
    }

    public static readonly DatafieldInput BalanceTracker = new("balance_tracker");

    public static readonly DatafieldInput Text = new("text");

    public static readonly DatafieldInput Radio = new("radio");

    public static readonly DatafieldInput Dropdown = new("dropdown");

    public TResult Match<TResult>(Func<TResult> onBalanceTracker,
        Func<TResult> onText,
        Func<TResult> onRadio,
        Func<TResult> onDropdown,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BalanceTracker => onBalanceTracker(),
            _ when this == Text => onText(),
            _ when this == Radio => onRadio(),
            _ when this == Dropdown => onDropdown(),
            _ => otherwise(Value)
        };

    public void Match(Action onBalanceTracker,
        Action onText,
        Action onRadio,
        Action onDropdown,
        Action<string> otherwise)
    {
        if (this == BalanceTracker) onBalanceTracker();
        else if (this == Text) onText();
        else if (this == Radio) onRadio();
        else if (this == Dropdown) onDropdown();
        else otherwise(Value);
    }
}
