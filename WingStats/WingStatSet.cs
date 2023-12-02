using System;
using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VanillaWingStats = Terraria.DataStructures.WingStats;

namespace HookStatsAndWingStats.WingStats;
public readonly struct WingStatSet
{
    public WingMaxFlightTime MaxFlightTime { get; }
    public WingHorizontalSpeed HorizontalSpeed { get; }
    public WingVerticalSpeedMultiplier VerticalSpeedMultiplier { get; }

    public WingStatSet(int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) {
        MaxFlightTime = new WingMaxFlightTime(maxFlightTime);
        HorizontalSpeed = new WingHorizontalSpeed(horizontalSpeed);
        VerticalSpeedMultiplier = new WingVerticalSpeedMultiplier(verticalSpeedMultiplier);
    }

    /// <summary>
    ///     This overload fetches maxFlightTime and horizontalSpeed from the items WingStats
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="verticalSpeedMultiplier"></param>
    public WingStatSet(int itemType, float verticalSpeedMultiplier) {
        Item item = ContentSamples.ItemsByType[itemType];
        if (item.wingSlot < 0) {
            throw new ArgumentException($"Item with type {itemType} does not have wing stats");
        }

        VanillaWingStats vanillaWingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
        MaxFlightTime = new WingMaxFlightTime(vanillaWingStats.FlyTime);
        HorizontalSpeed = new WingHorizontalSpeed(vanillaWingStats.AccRunSpeedOverride);
        VerticalSpeedMultiplier = new WingVerticalSpeedMultiplier(verticalSpeedMultiplier);
    }

    public List<TooltipLine> BuildSoloTooltips() {
        List<TooltipLine> result = [];

        if (WingConfig.Instance.ShowTitle) {
            if (!WingConfig.Instance.DockStats) {
                // See HookStatsAndWingStats.Helpers.HookStats@31:17
                result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
            }

            ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.Title"), WingConfig.Instance.TitleColor);
            result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "WingTitle", title.Value));
        }

        if (WingConfig.Instance.ShowMaxWingTime) {
            result.Add(MaxFlightTime.BuildSoloTooltip());
        }

        if (WingConfig.Instance.ShowHorizontalSpeed) {
            result.Add(HorizontalSpeed.BuildSoloTooltip());
        }

        if ((WingConfig.Instance.ShowVerticalMult && VerticalSpeedMultiplier.IsKnown) || WingConfig.Instance.ShowUnknownVerticalMults) {
            result.Add(VerticalSpeedMultiplier.BuildSoloTooltip());
        }

        return result;
    }

    public List<TooltipLine> BuildComparisonTooltips(WingStatSet otherWingStats) {
        List<TooltipLine> result = [];

        if (WingConfig.Instance.ShowTitle) {
            if (!WingConfig.Instance.DockStats) {
                // See HookStatsAndWingStats.Helpers.HookStats@31:17
                result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
            }

            ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.Title"), WingConfig.Instance.TitleColor);
            result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "WingTitle", title.Value));
        }

        if (WingConfig.Instance.ShowMaxWingTime) {
            result.Add(MaxFlightTime.BuildComparisonTooltip(otherWingStats.MaxFlightTime));
        }

        if (WingConfig.Instance.ShowHorizontalSpeed) {
            result.Add(HorizontalSpeed.BuildComparisonTooltip(otherWingStats.HorizontalSpeed));
        }

        if ((WingConfig.Instance.ShowVerticalMult && VerticalSpeedMultiplier.IsKnown) || WingConfig.Instance.ShowUnknownVerticalMults) {
            result.Add(VerticalSpeedMultiplier.BuildComparisonTooltip(otherWingStats.VerticalSpeedMultiplier));
        }

        return result;
    }
}
