using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using HookStatsAndWingStats.Helpers;
using HookStatsAndWingStats.HookStats;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems;

public class HookGlobalItem : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.ShouldDisplayHookStats();

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        Player player = Main.LocalPlayer;
        HookStatSet hookStats = HookSystem.HookStats[item.GetKey()];
        Item equippedHook = player.EquippedHook();

        if (equippedHook.ShouldDisplayHookStats() && equippedHook.type != item.type && HookConfig.Instance.CompareStats) {
            HookStatSet otherHookStats = HookSystem.HookStats[player.EquippedHook().GetKey()];
            tooltips.AddRange(hookStats.BuildComparisonTooltips(otherHookStats));
            return;
        }

        tooltips.AddRange(hookStats.BuildSoloTooltips());
    }

    public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset) {
        if (line.Name == "Invisible") {
            return false;
        }

        return base.PreDrawTooltipLine(item, line, ref yOffset);
    }
}