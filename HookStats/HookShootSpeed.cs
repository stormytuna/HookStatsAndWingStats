using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.HookStats;

public readonly struct HookShootSpeed(float shootSpeed)
{
    private readonly float shootSpeed = shootSpeed;

    public readonly string ShootSpeed => HookConfig.Instance.VelocityInMph ? $"{shootSpeed * 5.084949379f:00.}mph" : $"{shootSpeed:00.}";

    public Color GetComparisonColour(float otherShootSpeed) {
        return shootSpeed > otherShootSpeed
            ? MiscConfig.Instance.ComparisonBetterColor
            : shootSpeed < otherShootSpeed ? MiscConfig.Instance.ComparisonWorseColor : MiscConfig.Instance.ComparisonEqualColor;
    }

    public TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.ShootSpeed"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(ShootSpeed, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookShootSpeed", ColoredText.Parse(": ", subtitle, value));
    }

    public TooltipLine BuildComparisonTooltip(HookShootSpeed otherShootSpeed) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.ShootSpeed"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(ShootSpeed, GetComparisonColour(otherShootSpeed.shootSpeed));
        ColoredText otherValue = new(otherShootSpeed.ShootSpeed, otherShootSpeed.GetComparisonColour(shootSpeed));

        return new TooltipLine(HookStatsAndWingStats.Instance, "HookShootSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
