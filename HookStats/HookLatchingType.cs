using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.HookStats;

public readonly struct HookLatchingType(Enums.HookLatchingType latchingType)
{
    private readonly Enums.HookLatchingType latchingType = latchingType;

    public readonly string LatchingType => Language.GetTextValue($"Mods.HookStatsAndWingStats.HookStats.LatchingTypes.{latchingType}");

    public readonly Color GetComparisonColour(Enums.HookLatchingType otherLatchingType) {
        return latchingType == otherLatchingType || latchingType == Enums.HookLatchingType.Special || otherLatchingType == Enums.HookLatchingType.Special
            ? MiscConfig.Instance.ComparisonEqualColor
            : latchingType > otherLatchingType ? MiscConfig.Instance.ComparisonBetterColor : MiscConfig.Instance.ComparisonWorseColor;
    }

    public readonly TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.LatchingType"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(LatchingType, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookLatchingType", ColoredText.Parse(": ", subtitle, value));
    }

    public readonly TooltipLine BuildComparisonTooltip(HookLatchingType otherLatchingType) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.LatchingType"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(LatchingType, GetComparisonColour(otherLatchingType.latchingType));
        ColoredText otherValue = new(otherLatchingType.LatchingType, otherLatchingType.GetComparisonColour(latchingType));

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
