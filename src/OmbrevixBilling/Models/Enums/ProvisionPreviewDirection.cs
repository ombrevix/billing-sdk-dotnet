using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ProvisionPreviewDirection>))]
public sealed record ProvisionPreviewDirection : OpenStringEnum<ProvisionPreviewDirection>
{
    private ProvisionPreviewDirection(string value) : base(value)
    {
    }

    public static readonly ProvisionPreviewDirection Upgrade = new("upgrade");

    public static readonly ProvisionPreviewDirection Downgrade = new("downgrade");

    public TResult Match<TResult>(Func<TResult> onUpgrade,
        Func<TResult> onDowngrade,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Upgrade => onUpgrade(),
            _ when this == Downgrade => onDowngrade(),
            _ => otherwise(Value)
        };

    public void Match(Action onUpgrade, Action onDowngrade, Action<string> otherwise)
    {
        if (this == Upgrade) onUpgrade();
        else if (this == Downgrade) onDowngrade();
        else otherwise(Value);
    }
}
