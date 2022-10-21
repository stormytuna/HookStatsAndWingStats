using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HookStatsAndWingStats.Common.Configs;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace HookStatsAndWingStats.Common.GlobalItems
{
    public class HookStatsAndWingStatsGlobalItem : GlobalItem
    {
        private HookStatsAndWingStats mod => ModContent.GetInstance<HookStatsAndWingStats>();
        private bool HasCalamity()
        {
            if (ModLoader.TryGetMod("CalamityMod", out _))
                return true;

            return false;
        }

        private bool ItemIsCalamityFamily(string itemModName)
            => itemModName != "Terraria" && itemModName != "CalamityMod" && itemModName != "CalValEX" && itemModName != "CatalystMod";

        private bool ShouldDisplayHookStats()
            => HookConfig.Instance.ShowStats && (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowVelocity || HookConfig.Instance.ShowCount || HookConfig.Instance.ShowLatchingType);

        private bool ShouldDisplayWingStats()
            => WingConfig.Instance.ShowStats && (WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowCurWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);

        private string WrapLine(string subtitle, Color subColor, string value, Color valColor)
        {
            return WrapLine(subtitle, subColor.Hex3().ToUpper(), value, valColor.Hex3());
        }

        private string WrapLine(string subtitle, string subColorHex, string value, string valColorHex)
        {
            return $"[c/{subColorHex}:{subtitle}][c/{valColorHex}:{value}]";
        }

        private TooltipLine ComparisonTitle(bool linebreak)
        {
            TooltipLine line;
            if (linebreak)
                line = new TooltipLine(Mod, "ComparisonTitle", "\n~ EQUIPPED ~");
            else
                line = new TooltipLine(Mod, "ComparisonTitle", "~ EQUIPPED ~");
            line.OverrideColor = MiscConfig.Instance.ComparisonTitleColor;
            return line;
        }

        private TooltipLine HookTitle()
        {
            TooltipLine line = new TooltipLine(Mod, "HookTitle", "\n~ HOOK STATS ~");
            line.OverrideColor = HookConfig.Instance.TitleColor;
            return line;
        }

        private TooltipLine HookReach(float reach)
        {
            return new TooltipLine(Mod, "HookReach", WrapLine("Reach: ", MiscConfig.Instance.StatSubtitleColor, $"{reach / 16f} tiles", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookVelocity(float velocity)
        {
            return new TooltipLine(Mod, "HookVelocity", WrapLine("Velocity: ", MiscConfig.Instance.StatSubtitleColor, $"{velocity}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookCount(int hookCount)
        {
            return new TooltipLine(Mod, "HookCount", WrapLine("Hooks: ", MiscConfig.Instance.StatSubtitleColor, $"{hookCount}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine HookLatchingType(int latchingType)
        {
            switch (latchingType)
            {
                default:
                    return new TooltipLine(Mod, "HookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Single", MiscConfig.Instance.StatValueColor));
                case 1:
                    return new TooltipLine(Mod, "HookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Simultaneous", MiscConfig.Instance.StatValueColor));
                case 2:
                    return new TooltipLine(Mod, "HookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Individual", MiscConfig.Instance.StatValueColor));
            }
        }

        private TooltipLine CompareHookReach(float reach, Color valueColor)
        {
            return new TooltipLine(Mod, "CompHookReach", WrapLine("Reach: ", MiscConfig.Instance.StatSubtitleColor, $"{reach / 16f} tiles", valueColor));
        }

        private TooltipLine CompareHookVelocity(float velocity, Color valueColor)
        {
            return new TooltipLine(Mod, "CompHookVelocity", WrapLine("Velocity: ", MiscConfig.Instance.StatSubtitleColor, $"{velocity}", valueColor));
        }

        private TooltipLine CompareHookCount(int hookCount, Color valueColor)
        {
            return new TooltipLine(Mod, "CompHookCount", WrapLine("Hooks: ", MiscConfig.Instance.StatSubtitleColor, $"{hookCount}", valueColor));
        }

        private TooltipLine CompareHookLatchingType(int latchingType, Color valueColor)
        {
            switch (latchingType)
            {
                default:
                    return new TooltipLine(Mod, "CompHookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Single", valueColor));
                case 1:
                    return new TooltipLine(Mod, "CompHookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Simultaneous", valueColor));
                case 2:
                    return new TooltipLine(Mod, "CompHookStat", WrapLine("Latch type: ", MiscConfig.Instance.StatSubtitleColor, "Individual", valueColor));
            }
        }

        private TooltipLine WingTitle()
        {
            TooltipLine line = new TooltipLine(Mod, "WingTitle", "\n~ WING STATS ~");
            line.OverrideColor = WingConfig.Instance.TitleColor;
            return line;
        }

        private TooltipLine WingFlightTimeCombined(int currentWingTime, int maxWingTime)
        {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, "∞ / ∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, $"{(currentWingTime / 60f):0.00}s / {maxWingTime / 60f:0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Flight time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime} / {maxWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingFlightTimeCurrent(int currentWingTime, int maxWingTime)
        {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.CombineWingTimes)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime / 60f:0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Current flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{currentWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingFlightTimeMax(int maxWingTime)
        {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", MiscConfig.Instance.StatValueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{(maxWingTime / 60f):0.00}s", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{maxWingTime}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingHorizontalSpeed(float horizontalSpeed)
        {
            if (WingConfig.Instance.HorizontalSpeedInMPH)
                return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed * 5.084949379f:0.}mph", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingFlightTimeCombined", WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed}", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine WingVerticalSpeedMultiplier(float verticalSpeedMultiplier)
        {
            if (WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1)
                return new TooltipLine(Mod, "WingVerticalSpeedMult", WrapLine("Vertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, "unknown", MiscConfig.Instance.StatValueColor));

            return new TooltipLine(Mod, "WingVerticalSpeedMult", WrapLine("Vertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, $"{verticalSpeedMultiplier}%", MiscConfig.Instance.StatValueColor));
        }

        private TooltipLine CompWingFlightTimeMax(int maxWingTime, Color valueColor)
        {
            if (Main.LocalPlayer.empressBrooch || maxWingTime == -1)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, "∞", valueColor));

            if (WingConfig.Instance.FlightTimeInSeconds)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{(maxWingTime / 60f):0.00}s", valueColor));

            return new TooltipLine(Mod, "CompWingFlightTimeCombined", WrapLine("Max flight Time: ", MiscConfig.Instance.StatSubtitleColor, $"{maxWingTime}", valueColor));
        }

        private TooltipLine CompWingHorizontalSpeed(float horizontalSpeed, Color valueColor)
        {
            if (WingConfig.Instance.HorizontalSpeedInMPH)
                return new TooltipLine(Mod, "CompWingFlightTimeCombined", WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed * 5.084949379f:0.}mph", valueColor));

            return new TooltipLine(Mod, "CompWingFlightTimeCombined", WrapLine("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor, $"{horizontalSpeed}", valueColor));
        }

        private TooltipLine CompWingVerticalSpeedMultiplier(float verticalSpeedMultiplier, Color valueColor)
        {
            if (WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1)
                return new TooltipLine(Mod, "WingVerticalSpeedMult", WrapLine("CompVertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, "unknown", valueColor));

            return new TooltipLine(Mod, "WingVerticalSpeedMult", WrapLine("CompVertical speed multiplier: ", MiscConfig.Instance.StatSubtitleColor, $"{verticalSpeedMultiplier}%", valueColor));
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            List<TooltipLine> lines = new List<TooltipLine>();
            Player player = Main.LocalPlayer;

            // modName and itemName, needed for modded items
            string modName = "Terraria"; // Init this as Terraria to check for modded items later
            string itemName = item.Name;
            if (item.ModItem != null)
            {
                modName = item.ModItem.Mod.Name;
                itemName = item.ModItem.Name;
            }
            Tuple<string, string> key = new(modName, itemName);

            // Hooks
            // Have to be done manually, vanilla ranges and hooks are hard coded
            if ((mod.vanillaHookStats.ContainsKey(item.type) || mod.moddedHookStats.ContainsKey(key)) && ShouldDisplayHookStats() && (ItemIsCalamityFamily(modName) || !HasCalamity()))
            {
                Tuple<float, float, int, int> value;
                if (modName != "Terraria")
                    value = mod.moddedHookStats[key];
                else
                    value = mod.vanillaHookStats[item.type];

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
                if (HookConfig.Instance.CompareStats)
                {
                    Tuple<float, float, int, int> compValue = null;

                    for (int i = 0; i < player.miscEquips.Length; i++)
                    {
                        int equippedType = player.miscEquips[i].type;
                        if (mod.vanillaHookStats.ContainsKey(equippedType) && equippedType != item.type)
                        {
                            compValue = mod.vanillaHookStats[player.miscEquips[i].type];
                            break;
                        }
                        
                        if (player.armor[i].ModItem != null)
                        {
                            string equippedName = player.miscEquips[i].ModItem.Name;
                            string equippedMod = player.miscEquips[i].ModItem.Mod.Name;
                            if (mod.moddedHookStats.ContainsKey(new(equippedMod, equippedName)))
                            {
                                compValue = mod.moddedHookStats[new(equippedMod, equippedName)];
                                break;
                            }
                        }
                    }

                    if (compValue != null)
                    {
                        lines.Add(ComparisonTitle(HookConfig.Instance.DockComparison));

                        if (!MiscConfig.Instance.ComparionsValueColors)
                        {
                            if (HookConfig.Instance.ShowReach)
                                lines.Add(CompareHookReach(compValue.Item1, MiscConfig.Instance.StatValueColor));
                            if (HookConfig.Instance.ShowVelocity)
                                lines.Add(CompareHookVelocity(compValue.Item2, MiscConfig.Instance.StatValueColor));
                            if (HookConfig.Instance.ShowCount)
                                lines.Add(CompareHookCount(compValue.Item3, MiscConfig.Instance.StatValueColor));
                            if (HookConfig.Instance.ShowLatchingType)
                                lines.Add(CompareHookLatchingType(compValue.Item4, MiscConfig.Instance.StatValueColor));
                        }
                        else
                        {
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

            // Wings
            // Can be done mostly through WingStats, vertical speed multiplier is hard coded so need a dict for that
            if (item.wingSlot > 0 && ShouldDisplayWingStats() && (ItemIsCalamityFamily(modName) || !HasCalamity()))
            {
                // Declaring stuff
                WingStats wingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
                bool isEquipped = false;

                // Check if this item is equipped
                for (int i = 0; i < player.armor.Length; i++)
                {
                    if (player.armor[i].type == item.type && Main.mouseX > Main.screenWidth / 2)
                        isEquipped = true;
                }

                // Build our Tuple
                Tuple<int, float, int> value = new(0, 0, -1);
                // Check if we have a modded wingstats override
                if (mod.moddedWingStatsOverride.ContainsKey(key))
                    value = mod.moddedWingStatsOverride[key];
                // Check if our item is modded...
                else if (modName != "Terraria")
                {
                    if (mod.moddedWingVerticalMults.ContainsKey(key))
                        value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.moddedWingVerticalMults[key]);
                    else
                        value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, -1);
                }
                // ... or vanilla 
                else
                    value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.vanillaWingVerticalMults[item.type]);

                if (!WingConfig.Instance.DockStats)
                    lines.Add(WingTitle());

                // Flight time
                // If we're using combined wing times and is equipped - display as combined using players wing time
                if (WingConfig.Instance.CombineWingTimes && WingConfig.Instance.ShowCurWingTime && WingConfig.Instance.ShowMaxWingTime && isEquipped)
                {
                    lines.Add(WingFlightTimeCombined(Convert.ToInt32(player.wingTime), value.Item1));
                }

                // If we're not using combined and is equipped - display separerately using players wing time
                else if (isEquipped)
                {
                    if (WingConfig.Instance.ShowMaxWingTime)
                        lines.Add(WingFlightTimeMax(value.Item1));
                    if (WingConfig.Instance.ShowCurWingTime)
                        lines.Add(WingFlightTimeCurrent(Convert.ToInt32(player.wingTime), value.Item1));
                }

                // If it's not equipped - display only MaxWingTime using items wing time
                else
                {
                    if (WingConfig.Instance.ShowMaxWingTime)
                        lines.Add(WingFlightTimeMax(value.Item1));
                }

                // Other stats
                if (WingConfig.Instance.ShowHorizontalSpeed)
                    lines.Add(WingHorizontalSpeed(value.Item2));
                if (WingConfig.Instance.ShowVerticalMult && (value.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults)
                    lines.Add(WingVerticalSpeedMultiplier(value.Item3));

                // Wing comparison stats
                if (WingConfig.Instance.CompareStats)
                {
                    Tuple<int, float, int> compValue = null;

                    // Check equipped armor
                    for (int i = 3; i < 7 + player.GetAmountOfExtraAccessorySlotsToShow(); i++)
                    {
                        if (player.armor[i].wingSlot > 0)
                        {
                            // Skip this armor if its the same as the selected wing
                            if (player.armor[i].type == item.type)
                                continue;

                            // modName and itemName, needed for modded items
                            string compModName = "Terraria"; // Init this as Terraria to check for modded items later
                            string compItemName = item.Name;
                            if (item.ModItem != null)
                            {
                                compModName = item.ModItem.Mod.Name;
                                compItemName = item.ModItem.Name;
                            }

                            Tuple<string, string> compKey = new(compModName, compItemName);
                            // Build our Tuple
                            // Check if we have a modded wingstats override
                            if (mod.moddedWingStatsOverride.ContainsKey(compKey))
                                compValue = mod.moddedWingStatsOverride[compKey];
                            // Check if our item is modded...
                            else if (compModName != "Terraria")
                            {
                                if (mod.moddedWingVerticalMults.ContainsKey(key))
                                    compValue = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.moddedWingVerticalMults[key]);
                                else
                                    compValue = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, -1);
                            }
                            // ... or vanilla 
                            else
                                compValue = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.vanillaWingVerticalMults[item.type]);
                        }
                    }

                    // Print actual lines
                    if (compValue != null)
                    {
                        lines.Add(ComparisonTitle(WingConfig.Instance.DockComparison));

                        if (!MiscConfig.Instance.ComparionsValueColors)
                        {
                            if (WingConfig.Instance.ShowMaxWingTime)
                                lines.Add(CompWingFlightTimeMax(value.Item1, MiscConfig.Instance.StatValueColor));
                            if (WingConfig.Instance.ShowHorizontalSpeed)
                                lines.Add(CompWingHorizontalSpeed(value.Item2, MiscConfig.Instance.StatValueColor));
                            if (WingConfig.Instance.ShowVerticalMult && (value.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults)
                                lines.Add(CompWingVerticalSpeedMultiplier(value.Item3, MiscConfig.Instance.StatValueColor));
                        }
                        else
                        {
                            Color valueColor;
                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item1 < compValue.Item1)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item1 > compValue.Item1)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (HookConfig.Instance.ShowReach)
                                lines.Add(CompWingFlightTimeMax(compValue.Item1, valueColor));

                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item2 < compValue.Item2)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item2 > compValue.Item2)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (HookConfig.Instance.ShowVelocity)
                                lines.Add(CompWingHorizontalSpeed(compValue.Item2, valueColor));

                            valueColor = MiscConfig.Instance.ComparisonEqualColor;
                            if (value.Item3 < compValue.Item3)
                                valueColor = MiscConfig.Instance.ComparisonBetterColor;
                            if (value.Item3 > compValue.Item3)
                                valueColor = MiscConfig.Instance.ComparisonWorseColor;
                            if (HookConfig.Instance.ShowCount)
                                lines.Add(CompWingVerticalSpeedMultiplier(compValue.Item3, valueColor));
                        }
                    }
                }

                tooltips.AddRange(lines);
            }
        }
    }
}