using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.WingStats;

public readonly struct WingMaxFlightTime(int maxFlightTime)
{
    private readonly int maxFlightTime = maxFlightTime;
    private readonly bool isInfinite = int.MaxValue == maxFlightTime;

    public readonly string MaxFlightTime => isInfinite ? "∞" : WingConfig.Instance.FlightTimeInSeconds ? $"{maxFlightTime / 60f:.00}s" : $"{maxFlightTime}";

    public readonly Color GetComparisonColor(int otherMaxFlightTime) {
        return maxFlightTime > otherMaxFlightTime
            ? MiscConfig.Instance.ComparisonBetterColor
            : maxFlightTime < otherMaxFlightTime ? MiscConfig.Instance.ComparisonWorseColor : MiscConfig.Instance.ComparisonEqualColor;
    }

    public readonly TooltipLine BuildSoloTooltip() {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.MaxFlightTime"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText value = new(MaxFlightTime, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingMaxFlightTime", ColoredText.Parse(": ", subtitle, value));
    }

    public readonly TooltipLine BuildSoloTooltip(int currentFlightTime) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.FlightTime"), MiscConfig.Instance.StatSubtitleColor);

        string parsedCurrentFlightTime = isInfinite ? "∞" : WingConfig.Instance.FlightTimeInSeconds ? $"{currentFlightTime / 60f:0.00}s" : $"{currentFlightTime}";
        ColoredText current = new(parsedCurrentFlightTime, MiscConfig.Instance.StatValueColor);
        ColoredText max = new(MaxFlightTime, MiscConfig.Instance.StatValueColor);

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingFlightTime", $"{subtitle.Value}: {current.Value} / {max.Value}");
    }

    public readonly TooltipLine BuildComparisonTooltip(WingMaxFlightTime otherMaxFlightTime) {
        ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.MaxFlightTime"), MiscConfig.Instance.StatSubtitleColor);
        ColoredText thisValue = new(MaxFlightTime, GetComparisonColor(otherMaxFlightTime.maxFlightTime));
        ColoredText otherValue = new(otherMaxFlightTime.MaxFlightTime, otherMaxFlightTime.GetComparisonColor(maxFlightTime));

        return new TooltipLine(HookStatsAndWingStats.Instance, "WingMaxFlightTime", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
    }
}
