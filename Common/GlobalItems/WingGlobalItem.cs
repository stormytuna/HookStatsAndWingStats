using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems {
    public class WingGlobalItem : GlobalItem {
        private bool ShouldDisplayWingStats()
            => WingConfig.Instance.ShowStats && (WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowCurWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);

        private TooltipLine WingTitle() {
            TooltipLine line = new TooltipLine(Mod, "WingTitle", "\n~ WING STATS ~");
            line.OverrideColor = WingConfig.Instance.TitleColor;
            return line;
        }

        private TooltipLine WingFlightTimeCombined(int currentWingTime, int maxWingTime) {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, "∞ / ∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, $"{(currentWingTime / 60f):0.00}s / {maxWingTime / 60f:0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime} / {maxWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingFlightTimeCurrent(int currentWingTime, int maxWingTime) {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.CombineWingTimes)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime / 60f:0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingFlightTimeMax(int maxWingTime) {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{(maxWingTime / 60f):0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{maxWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingHorizontalSpeed(float horizontalSpeed) {
            if (WingConfig.Instance.HorizontalSpeedInMPH)
                return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed * 5.084949379f:0.}mph", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", Helpers.WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingVerticalSpeedMultiplier(float verticalSpeedMultiplier) {
            if (WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1)
                return new TooltipLine(Mod, "WingVerticalSpeedMult", Helpers.WrapLine("Vertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, "unknown", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingVerticalSpeedMult", Helpers.WrapLine("Vertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, $"{verticalSpeedMultiplier}%", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine CompWingTitle() {
            TooltipLine line;
            if (WingConfig.Instance.DockComparison)
                line = new TooltipLine(Mod, "CompWingTitle", "~ EQUIPPED ~");
            else
                line = new TooltipLine(Mod, "CompWingTitle", "\n~ EQUIPPED ~");
            line.OverrideColor = MiscConfig.Instance.ComparisonTitleColor;
            return line;
        }

        private TooltipLine CompWingFlightTimeMax(int maxWingTime, Color valueColor) {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", valueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{(maxWingTime / 60f):0.00}s", valueColor));

            return new TooltipLine(Mod, "CompWingFlightTimeCombined", Helpers.WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{maxWingTime}", valueColor));
        }

        private TooltipLine CompWingHorizontalSpeed(float horizontalSpeed, Color valueColor) {
            if (WingConfig.Instance.HorizontalSpeedInMPH)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", Helpers.WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed * 5.084949379f:0.}mph", valueColor));

            return new TooltipLine(Mod, "CompWingFlightTimeCombined", Helpers.WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed}", valueColor));
        }

        private TooltipLine CompWingVerticalSpeedMultiplier(float verticalSpeedMultiplier, Color valueColor) {
            if (WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1)
                return new TooltipLine(Mod, "WingVerticalSpeedMult", Helpers.WrapLine("CompVertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, "unknown", valueColor));

            return new TooltipLine(Mod, "WingVerticalSpeedMult", Helpers.WrapLine("CompVertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, $"{verticalSpeedMultiplier}%", valueColor));
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            List<TooltipLine> lines = new List<TooltipLine>();
            Player player = Main.LocalPlayer;

            // modName and itemName, needed for modded items
            string modName = "Terraria"; // Init this as Terraria to check for modded items later
            string itemName = item.Name;
            if (item.ModItem != null) {
                modName = item.ModItem.Mod.Name;
                itemName = item.ModItem.Name;
            }
            Tuple<string, string> key = new(modName, itemName);

            // Can be done mostly through WingStats, vertical speed multiplier is hard coded so need a dict for that
            if (item.wingSlot > 0 && ShouldDisplayWingStats() && (Helpers.ItemIsCalamityFamily(modName) || !Helpers.HasCalamity)) {
                // Declaring stuff
                WingStats wingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
                bool isEquipped = false;

                // Check if this item is equipped
                for (int i = 0; i < player.armor.Length; i++) {
                    if (player.armor[i].type == item.type && Main.mouseX > Main.screenWidth / 2)
                        isEquipped = true;
                }

                // Build our Tuple
                Tuple<int, float, int> value = new(0, 0, -1);
                // Check if we have a modded wingstats override
                if (WingSystem.ModdedWingStatsOverride.ContainsKey(key))
                    value = WingSystem.ModdedWingStatsOverride[key];
                // Check if our item is modded...
                else if (modName != "Terraria") {
                    if (WingSystem.ModdedWingVerticalMults.ContainsKey(key))
                        value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, WingSystem.ModdedWingVerticalMults[key]);
                    else
                        value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, -1);
                }
                // ... or vanilla 
                else
                    value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, WingSystem.VanillaWingVerticalMults[item.type]);

                if (!WingConfig.Instance.DockStats)
                    lines.Add(WingTitle());

                // Flight time
                // If we're using combined wing times and is equipped - display as combined using players wing time
                if (WingConfig.Instance.CombineWingTimes && WingConfig.Instance.ShowCurWingTime && WingConfig.Instance.ShowMaxWingTime && isEquipped) {
                    lines.Add(WingFlightTimeCombined(Convert.ToInt32(player.wingTime), value.Item1));
                }

                // If we're not using combined and is equipped - display separerately using players wing time
                else if (isEquipped) {
                    if (WingConfig.Instance.ShowMaxWingTime)
                        lines.Add(WingFlightTimeMax(value.Item1));
                    if (WingConfig.Instance.ShowCurWingTime)
                        lines.Add(WingFlightTimeCurrent(Convert.ToInt32(player.wingTime), value.Item1));
                }

                // If it's not equipped - display only MaxWingTime using items wing time
                else {
                    if (WingConfig.Instance.ShowMaxWingTime)
                        lines.Add(WingFlightTimeMax(value.Item1));
                }

                // Other stats
                if (WingConfig.Instance.ShowHorizontalSpeed)
                    lines.Add(WingHorizontalSpeed(value.Item2));
                if (WingConfig.Instance.ShowVerticalMult && (value.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults)
                    lines.Add(WingVerticalSpeedMultiplier(value.Item3));

                // Wing comparison stats
                if (WingConfig.Instance.CompareStats) {
                    Tuple<int, float, int> compValue = null;

                    // Check equipped armor
                    for (int i = 3; i < 7 + player.GetAmountOfExtraAccessorySlotsToShow(); i++) {
                        if (player.armor[i].wingSlot > 0) {
                            // Skip this armor if its the same as the selected wing
                            if (player.armor[i].type == item.type)
                                continue;

                            Item compItem = player.armor[i];
                            WingStats compWingStats = ArmorIDs.Wing.Sets.Stats[compItem.wingSlot];

                            // modName and itemName, needed for modded items
                            string compModName = "Terraria"; // Init this as Terraria to check for modded items later
                            string compItemName = compItem.Name;
                            if (compItem.ModItem != null) {
                                compModName = item.ModItem.Mod.Name;
                                compItemName = item.ModItem.Name;
                            }

                            Tuple<string, string> compKey = new(compModName, compItemName);
                            // Build our Tuple
                            // Check if we have a modded wingstats override
                            if (WingSystem.ModdedWingStatsOverride.ContainsKey(compKey))
                                compValue = WingSystem.ModdedWingStatsOverride[compKey];
                            // Check if our item is modded...
                            else if (compModName != "Terraria") {
                                if (WingSystem.ModdedWingVerticalMults.ContainsKey(key))
                                    compValue = new(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, WingSystem.ModdedWingVerticalMults[compKey]);
                                else
                                    compValue = new(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, -1);
                            }
                            // ... or vanilla 
                            else
                                compValue = new(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, WingSystem.VanillaWingVerticalMults[compItem.type]);
                        }
                    }

                    // Print actual lines
                    if (compValue != null) {
                        lines.Add(CompWingTitle());

                        if (!MiscConfig.Instance.ComparionsValueColors) {
                            if (WingConfig.Instance.ShowMaxWingTime)
                                lines.Add(CompWingFlightTimeMax(compValue.Item1, MiscConfig.Instance.StatValueColor));
                            if (WingConfig.Instance.ShowHorizontalSpeed)
                                lines.Add(CompWingHorizontalSpeed(compValue.Item2, MiscConfig.Instance.StatValueColor));
                            if (WingConfig.Instance.ShowVerticalMult && (compValue.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults)
                                lines.Add(CompWingVerticalSpeedMultiplier(compValue.Item3, MiscConfig.Instance.StatValueColor));
                        }
                        else {
                            Color valueColor;
                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item1 < compValue.Item1)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item1 > compValue.Item1)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (WingConfig.Instance.ShowMaxWingTime)
                                lines.Add(CompWingFlightTimeMax(compValue.Item1, valueColor));

                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item2 < compValue.Item2)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item2 > compValue.Item2)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (WingConfig.Instance.ShowHorizontalSpeed)
                                lines.Add(CompWingHorizontalSpeed(compValue.Item2, valueColor));

                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item3 < compValue.Item3)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item3 > compValue.Item3)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (WingConfig.Instance.ShowVerticalMult)
                                lines.Add(CompWingVerticalSpeedMultiplier(compValue.Item3, valueColor));
                        }
                    }
                }

                tooltips.AddRange(lines);
            }
        }
    }
}