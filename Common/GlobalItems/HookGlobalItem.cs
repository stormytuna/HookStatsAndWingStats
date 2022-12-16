using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems {
    public class HookGlobalItem : GlobalItem {
        private static bool ShouldDisplayHookStats {
            get => HookConfig.Instance.ShowStats && (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowVelocity || HookConfig.Instance.ShowCount || HookConfig.Instance.ShowLatchingType);
        }

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
            string modName = "Terraria"; // Init this as Terraria to check for modded items later
            string itemName = item.Name;
            if (item.ModItem is not null) {
                modName = item.ModItem.Mod.Name;
                itemName = item.ModItem.Name;
            }
            Tuple<string, string> key = new(modName, itemName);

            // Have to be done manually, vanilla ranges and hooks are hard coded
            if ((HookSystem.VanillaHookStats.ContainsKey(item.type) || HookSystem.ModdedHookStats.ContainsKey(key)) && ShouldDisplayHookStats && (Helpers.ItemIsCalamityFamily(modName) || !Helpers.HasCalamity)) {
                Tuple<float, float, int, int> value;
                if (modName != "Terraria")
                    value = HookSystem.ModdedHookStats[key];
                else
                    value = HookSystem.VanillaHookStats[item.type];

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

                // Comparison block
                if (HookConfig.Instance.CompareStats) {
                    Tuple<float, float, int, int> compValue = null;

                    for (int i = 0; i < player.miscEquips.Length; i++) {
                        int equippedType = player.miscEquips[i].type;
                        if (HookSystem.VanillaHookStats.ContainsKey(equippedType) && equippedType != item.type) {
                            compValue = HookSystem.VanillaHookStats[player.miscEquips[i].type];
                            break;
                        }

                        if (player.armor[i].ModItem != null) {
                            string equippedName = player.miscEquips[i].ModItem.Name;
                            string equippedMod = player.miscEquips[i].ModItem.Mod.Name;
                            if (HookSystem.ModdedHookStats.ContainsKey(new(equippedMod, equippedName))) {
                                compValue = HookSystem.ModdedHookStats[new(equippedMod, equippedName)];
                                break;
                            }
                        }
                    }

                    if (compValue != null) {
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
                        }
                        else {
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
                    }
                }

                tooltips.AddRange(lines);
            }
        }
    }
}
