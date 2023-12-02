using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Helpers;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.HookStats;

public readonly struct HookStatSet(float reach, float shootSpeed, int hookCount, Enums.HookLatchingType latchingType)
{
    public HookReach Reach { get; } = new HookReach(reach);
    public HookShootSpeed ShootSpeed { get; } = new HookShootSpeed(shootSpeed);
    public HookCount Count { get; } = new HookCount(hookCount);
    public HookLatchingType LatchingType { get; } = new HookLatchingType(latchingType);

    public readonly List<TooltipLine> BuildSoloTooltips() {
        List<TooltipLine> result = [];

        if (HookConfig.Instance.ShowTitle) {
            if (!HookConfig.Instance.DockStats) {
                // This used to say 'If youre reading this, I hope you have a nice day' but I had to shorten it so the tooltip background panel rendered properly sooooo....
                // If youre reading *this*, I hope you have an amazing day :D
                result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
            }

            ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Title"), HookConfig.Instance.TitleColor);
            result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "HookTitle", title.Value));
        }

        if (HookConfig.Instance.ShowReach) {
            result.Add(Reach.BuildSoloTooltip());
        }

        if (HookConfig.Instance.ShowVelocity) {
            result.Add(ShootSpeed.BuildSoloTooltip());
        }

        if (HookConfig.Instance.ShowCount) {
            result.Add(Count.BuildSoloTooltip());
        }

        if (HookConfig.Instance.ShowLatchingType) {
            result.Add(LatchingType.BuildSoloTooltip());
        }

        return result;
    }

    public readonly List<TooltipLine> BuildComparisonTooltips(HookStatSet otherHookStats) {
        List<TooltipLine> result = [];

        if (HookConfig.Instance.ShowTitle) {
            if (!HookConfig.Instance.DockStats) {
                // This used to say 'If youre reading this, I hope you have a nice day' but I had to shorten it so the tooltip background panel rendered properly sooooo....
                // If youre reading *this*, I hope you have an amazing day :D
                result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
            }

            ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Title"), HookConfig.Instance.TitleColor);
            result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "HookTitle", title.Value));
        }

        if (HookConfig.Instance.ShowReach) {
            result.Add(Reach.BuildComparisonTooltip(otherHookStats.Reach));
        }

        if (HookConfig.Instance.ShowVelocity) {
            result.Add(ShootSpeed.BuildComparisonTooltip(otherHookStats.ShootSpeed));
        }

        if (HookConfig.Instance.ShowCount) {
            result.Add(Count.BuildComparisonTooltip(otherHookStats.Count));
        }

        if (HookConfig.Instance.ShowLatchingType) {
            result.Add(LatchingType.BuildComparisonTooltip(otherHookStats.LatchingType));
        }

        return result;
    }
}
