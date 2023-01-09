using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems
{
    public class HookGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.HookIsRegisteredInDicts();

        private TooltipLine HookTitle() {
            TooltipLine line = new TooltipLine(Mod, "HookTitle", "\n~ HOOK STATS ~");
            line.OverrideColor = HookConfig.Instance.TitleColor;
            return line;
        }

        private TooltipLine HookReach(float reach) {
            return new TooltipLine(Mod, "HookReach", Helpers.WrapLine("Reach: ", MiscConfig.Instance.StatSubtitleColor, $"{reach / 16f} tiles", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookVelocity(float velocity) {
            return new TooltipLine(Mod, "HookVelocity", Helpers.WrapLine("Velocity: ", MiscConfig.Instance.StatSubtitleColor, $"{velocity}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookCount(int hookCount) {
            return new TooltipLine(Mod, "HookCount", Helpers.WrapLine("Hooks: ", MiscConfig.Instance.StatSubtitleColor, $"{hookCount}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookLatchingType(int latchingType) {
            switch (latchingType) {
                default:
                    return new TooltipLine(Mod, "HookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Single", MiscConfig.Instance.StatValueColor));
                case 1:
                    return new TooltipLine(Mod, "HookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Simultaneous", MiscConfig.Instance.StatValueColor));
                case 2:
                    return new TooltipLine(Mod, "HookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Individual", MiscConfig.Instance.StatValueColor));
            }
        }

        private TooltipLine ComparisonHookTitle() {
            TooltipLine line;
            if (HookConfig.Instance.DockComparison)
                line = new TooltipLine(Mod, "CompHookTitle", "~ EQUIPPED ~");
            else
                line = new TooltipLine(Mod, "CompHookTitle", "\n~ EQUIPPED ~");
            line.OverrideColor = MiscConfig.Instance.ComparisonTitleColor;
            return line;
        }

        private TooltipLine CompareHookReach(float reach, Color valueColor) {
            return new TooltipLine(Mod, "CompHookReach", Helpers.WrapLine("Reach: ", MiscConfig.Instance.StatSubtitleColor, $"{reach / 16f} tiles", valueColor));
        }

        private TooltipLine CompareHookVelocity(float velocity, Color valueColor) {
            return new TooltipLine(Mod, "CompHookVelocity", Helpers.WrapLine("Velocity: ", MiscConfig.Instance.StatSubtitleColor, $"{velocity}", valueColor));
        }

        private TooltipLine CompareHookCount(int hookCount, Color valueColor) {
            return new TooltipLine(Mod, "CompHookCount", Helpers.WrapLine("Hooks: ", MiscConfig.Instance.StatSubtitleColor, $"{hookCount}", valueColor));
        }

        private TooltipLine CompareHookLatchingType(int latchingType, Color valueColor) {
            switch (latchingType) {
                default:
                    return new TooltipLine(Mod, "CompHookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Single", valueColor));
                case 1:
                    return new TooltipLine(Mod, "CompHookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Simultaneous", valueColor));
                case 2:
                    return new TooltipLine(Mod, "CompHookStat", Helpers.WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Individual", valueColor));
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            // Some vars we use later
            List<TooltipLine> lines = new List<TooltipLine>();
            Player player = Main.LocalPlayer;

            // modName and itemName, needed for modded items
            string modName = item.ModItem?.Mod.Name ?? "Terraria";
            string itemName = item.ModItem?.Name ?? item.Name;
            Tuple<string, string> key = new(modName, itemName);

            // Return early if we shouldn't display hook stats
            if (!item.ShouldDisplayHookStats()) {
                return;
            }

            // Have to be done manually, vanilla ranges and hooks are hard coded
            Tuple<float, float, int, int> value = modName == "Terraria" ? HookSystem.VanillaHookStats[item.type] : HookSystem.ModdedHookStats[key];

            // Main block
            if (!HookConfig.Instance.DockStats)
                lines.Add(HookTitle());
            if (HookConfig.Instance.ShowReach)
                lines.Add(HookReach(value.Item1));
            if (HookConfig.Instance.ShowVelocity)
                lines.Add(HookVelocity(value.Item2));
            if (HookConfig.Instance.ShowCount)
                lines.Add(HookCount(value.Item3));
            if (HookConfig.Instance.ShowLatchingType)
                lines.Add(HookLatchingType(value.Item4));

            // Return early if we shouldn't display a comparison
            if (!player.EquippedHook().HookIsRegisteredInDicts() || !HookConfig.Instance.CompareStats) {
                tooltips.AddRange(lines);
                return;
            }

            string compModName = player.EquippedHook().ModItem?.Mod.Name ?? "Terraria";
            string compItemName = player.EquippedHook().ModItem?.Name ?? player.EquippedHook().Name;
            Tuple<string, string> compKey = new(compModName, compItemName);
            Tuple<float, float, int, int> compValue = compModName == "Terraria" ? HookSystem.VanillaHookStats[player.EquippedHook().type] : HookSystem.ModdedHookStats[compKey];

            // Comparison block
            lines.Add(ComparisonHookTitle());

            if (!MiscConfig.Instance.ComparionsValueColors) {
                if (HookConfig.Instance.ShowReach)
                    lines.Add(CompareHookReach(compValue.Item1, MiscConfig.Instance.StatValueColor));
                if (HookConfig.Instance.ShowVelocity)
                    lines.Add(CompareHookVelocity(compValue.Item2, MiscConfig.Instance.StatValueColor));
                if (HookConfig.Instance.ShowCount)
                    lines.Add(CompareHookCount(compValue.Item3, MiscConfig.Instance.StatValueColor));
                if (HookConfig.Instance.ShowLatchingType)
                    lines.Add(CompareHookLatchingType(compValue.Item4, MiscConfig.Instance.StatValueColor));
            } else {
                Color valueColor;
                valueColor = MiscConfig.Instance.ComparisonEqualColor;
                if (value.Item1 < compValue.Item1)
                    valueColor = MiscConfig.Instance.ComparisonBetterColor;
                if (value.Item1 > compValue.Item1)
                    valueColor = MiscConfig.Instance.ComparisonWorseColor;
                if (HookConfig.Instance.ShowReach)
                    lines.Add(CompareHookReach(compValue.Item1, valueColor));

                valueColor = MiscConfig.Instance.ComparisonEqualColor;
                if (value.Item2 < compValue.Item2)
                    valueColor = MiscConfig.Instance.ComparisonBetterColor;
                if (value.Item2 > compValue.Item2)
                    valueColor = MiscConfig.Instance.ComparisonWorseColor;
                if (HookConfig.Instance.ShowVelocity)
                    lines.Add(CompareHookVelocity(compValue.Item2, valueColor));

                valueColor = MiscConfig.Instance.ComparisonEqualColor;
                if (value.Item3 < compValue.Item3)
                    valueColor = MiscConfig.Instance.ComparisonBetterColor;
                if (value.Item3 > compValue.Item3)
                    valueColor = MiscConfig.Instance.ComparisonWorseColor;
                if (HookConfig.Instance.ShowCount)
                    lines.Add(CompareHookCount(compValue.Item3, valueColor));

                valueColor = MiscConfig.Instance.ComparisonEqualColor;
                if (value.Item4 != 2 && compValue.Item4 == 2)
                    valueColor = MiscConfig.Instance.ComparisonBetterColor;
                if (value.Item4 == 2 && compValue.Item4 != 2)
                    valueColor = MiscConfig.Instance.ComparisonWorseColor;
                if (HookConfig.Instance.ShowLatchingType)
                    lines.Add(CompareHookLatchingType(compValue.Item4, valueColor));
            }

            tooltips.AddRange(lines);
        }
    }
}
