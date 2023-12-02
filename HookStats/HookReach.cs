using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.HookStats;

public readonly struct HookReach(float reach)
{
    private readonly float reach = reach;

    public readonly string Reach => HookConfig.Instance.ReachInTiles ? $"{reach / 16f:00.}" : $"{reach}";

    public Color GetComparisonColour(float otherReach) {
        return reach > otherReach
            ? MiscConfig.Instance.ComparisonBetterColor
            : reach < otherReach ? MiscConfig.Instance.ComparisonWorseColor : MiscConfig.Instance.ComparisonEqualColor;
    }

    public TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Reach"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(Reach, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookReach", ColoredText.Parse(": ", subtitle, value));
    }

    public TooltipLine BuildComparisonTooltip(HookReach otherReach) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Reach"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(Reach, GetComparisonColour(otherReach.reach));
        ColoredText otherValue = new(otherReach.Reach, otherReach.GetComparisonColour(reach));

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookReach", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
