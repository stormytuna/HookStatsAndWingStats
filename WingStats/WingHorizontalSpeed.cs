using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.WingStats;

public readonly struct WingHorizontalSpeed(float horizontalSpeed)
{
    private readonly float horizontalSpeed = horizontalSpeed;

    public readonly string HorizontalSpeed => WingConfig.Instance.HorizontalSpeedInMph ? $"{horizontalSpeed * 5.084949379f:0.}mph" : $"{horizontalSpeed:0.}";

    public readonly Color GetComparisonColor(float otherHorizontalSpeed) {
        return horizontalSpeed > otherHorizontalSpeed
            ? MiscConfig.Instance.ComparisonBetterColor
            : horizontalSpeed < otherHorizontalSpeed ? MiscConfig.Instance.ComparisonWorseColor : MiscConfig.Instance.ComparisonEqualColor;
    }

    public readonly TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.HorizontalSpeed"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(HorizontalSpeed, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", ColoredText.Parse(": ", subtitle, value));
    }

    public readonly TooltipLine BuildComparisonTooltip(WingHorizontalSpeed otherHorizontalSpeed) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.HorizontalSpeed"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(HorizontalSpeed, GetComparisonColor(otherHorizontalSpeed.horizontalSpeed));
        ColoredText otherValue = new(otherHorizontalSpeed.HorizontalSpeed, otherHorizontalSpeed.GetComparisonColor(horizontalSpeed));

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
