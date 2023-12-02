using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.WingStats;
public readonly struct WingVerticalSpeedMultiplier
{
    private readonly float verticalSpeedMultiplier;
    private readonly bool isUnknown;

    public WingVerticalSpeedMultiplier(float verticalSpeedMultiplier) {
        this.verticalSpeedMultiplier = verticalSpeedMultiplier;
        isUnknown = float.IsNaN(verticalSpeedMultiplier);
    }

    public string VerticalSpeedMultiplier => isUnknown ? "Unknown" : $"{verticalSpeedMultiplier * 100f:.}%";

    public bool IsKnown => !isUnknown;

    public Color GetComparisonColor(float otherVerticalSpeedMultiplier) {
        if (isUnknown || float.IsNaN(otherVerticalSpeedMultiplier)) {
            return MiscConfig.Instance.ComparisonEqualColor;
        }

        if (verticalSpeedMultiplier > otherVerticalSpeedMultiplier) {
            return MiscConfig.Instance.ComparisonBetterColor;
        }

        if (verticalSpeedMultiplier < otherVerticalSpeedMultiplier) {
            return MiscConfig.Instance.ComparisonWorseColor;
        }

        return MiscConfig.Instance.ComparisonEqualColor;
    }

    public TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.VerticalSpeedMultiplier"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(VerticalSpeedMultiplier, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingVerticalSpeedMultiplier", ColoredText.Parse(": ", subtitle, value));
    }

    public TooltipLine BuildComparisonTooltip(WingVerticalSpeedMultiplier otherVerticalSpeedMultiplier) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.VerticalSpeedMultiplier"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(VerticalSpeedMultiplier, GetComparisonColor(otherVerticalSpeedMultiplier.verticalSpeedMultiplier));
        ColoredText otherValue = new(otherVerticalSpeedMultiplier.VerticalSpeedMultiplier, otherVerticalSpeedMultiplier.GetComparisonColor(verticalSpeedMultiplier));

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
