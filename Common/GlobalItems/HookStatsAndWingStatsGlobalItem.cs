using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using System;
using HookStatsAndWingStats.Common.Configs;

namespace HookStatsAndWingStats.Common.GlobalItems
{
    public class HookStatsAndWingStatsGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var mod = ModContent.GetInstance<HookStatsAndWingStats>();
            var modConfig = ModContent.GetInstance<HookStatsAndWingStatsConfig>();
            List<TooltipLine> lines = new List<TooltipLine>();

            // Hooks
            // Have to be done manually, vanilla ranges and hooks are hard coded
            if (mod.vanillaHookStats.ContainsKey(item.type) && modConfig.DisplayHookStats)
            {
                var value = mod.vanillaHookStats[item.type];
                
                lines.Add(new TooltipLine(Mod, "HookBuffer", ""));
                TooltipLine temp = new TooltipLine(Mod, "HookTitle", "\n~ HOOK STATS ~");
                temp.OverrideColor = modConfig.HookStatsTitleColor;
                lines.Add(temp);
                if (modConfig.DisplayHookReach)
                    lines.Add(new TooltipLine(Mod, "HookStat", $"Reach: {value.Item1}"));
                if (modConfig.DisplayHookVelocity)
                    lines.Add(new TooltipLine(Mod, "HookStat", $"Velocity: {value.Item2}"));
                if (modConfig.DisplayHookCount)
                    lines.Add(new TooltipLine(Mod, "HookStat", $"Hooks: {value.Item3}"));
                if (modConfig.DisplayHookLatchingType)
                {
                    switch (value.Item4)
                    {
                        case 0:
                            lines.Add(new TooltipLine(Mod, "HookStat", "Latch Type: Single"));
                            break;
                        case 1:
                            lines.Add(new TooltipLine(Mod, "HookStat", "Latch Type: Simultaneous"));
                            break;
                        case 2:
                            lines.Add(new TooltipLine(Mod, "HookStat", "Latch Type: Individual"));
                            break;
                    }
                }

                tooltips.AddRange(lines);
            }

            // Wings
        }
    }
}