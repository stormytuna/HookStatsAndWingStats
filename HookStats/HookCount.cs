using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.HookStats;

public readonly struct HookCount(int hookCount)
{
    private readonly float count = hookCount;

    public readonly string Count => $"{count}";

    public Color GetComparisonColour(float otherHookCount) {
        return count > otherHookCount
            ? MiscConfig.Instance.ComparisonBetterColor
            : count < otherHookCount ? MiscConfig.Instance.ComparisonWorseColor : MiscConfig.Instance.ComparisonEqualColor;
    }

    public TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.HookCount"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(Count, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", ColoredText.Parse(": ", subtitle, value));
    }

    public TooltipLine BuildComparisonTooltip(HookCount otherHookCount) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.HookCount"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(Count, GetComparisonColour(otherHookCount.count));
        ColoredText otherValue = new(otherHookCount.Count, otherHookCount.GetComparisonColour(count));

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
