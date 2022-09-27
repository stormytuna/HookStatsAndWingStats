using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using System;
using HookStatsAndWingStats.Common.Configs;
using Terraria.DataStructures;

namespace HookStatsAndWingStats.Common.GlobalItems
{
    public class HookStatsAndWingStatsGlobalItem : GlobalItem
    {
        private HookStatsAndWingStats mod = ModContent.GetInstance<HookStatsAndWingStats>();
        private HookStatsAndWingStatsConfig modConfig = ModContent.GetInstance<HookStatsAndWingStatsConfig>();
        private bool hasCalamity;

        private void CheckForCalamity()
        {
            if (ModLoader.TryGetMod("CalamityMod", out _))
                hasCalamity = true;
        }

        private bool ItemIsCalamityFamily(string itemModName)
            => itemModName != "Terraria" && itemModName != "CalamityMod" && itemModName != "CalValEX" && itemModName != "CatalystMod";

        private TooltipLine Hook_Title()
        {
            TooltipLine line = new TooltipLine(Mod, "HookTitle", "\n~ HOOK STATS ~");
            line.OverrideColor = modConfig.HookStatsTitleColor;
            return line;
        }

        private TooltipLine Hook_Reach(float reach)
        {
            return new TooltipLine(Mod, "HookReach", $"Reach: {reach} units");
        }

        private TooltipLine Hook_Velocity(float velocity)
        {
            return new TooltipLine(Mod, "HookVelocity", $"Velocity: {velocity}");
        }

        private TooltipLine Hook_HookCount(int hookCount)
        {
            return new TooltipLine(Mod, "HookCount", $"Hooks: {hookCount}");
        }

        private TooltipLine Hook_LatchingType(int latchingType)
        {
            switch (latchingType)
            {
                default:
                    return new TooltipLine(Mod, "HookStat", "Latch Type: Single");
                case 1:
                    return new TooltipLine(Mod, "HookStat", "Latch Type: Simultaneous");
                case 2:
                    return new TooltipLine(Mod, "HookStat", "Latch Type: Individual");
            }
        }

        private TooltipLine Wing_Title()
        {
            TooltipLine line = new TooltipLine(Mod, "WingTitle", "\n~ WING STATS ~");
            line.OverrideColor = modConfig.WingStatsTitleColor;
            return line;
        }

        private TooltipLine Wing_FlightTime_Combined(int currentWingTime, int maxWingTime)
        {
            if (Main.LocalPlayer.empressBrooch)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Flight time: ∞ / ∞");

            if (modConfig.DisplayFlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Flight time: {currentWingTime / 60f}s / {maxWingTime / 60f}s");

            return new TooltipLine(Mod, "WingFlightTimeCombined", $"Flight time: {currentWingTime} / {maxWingTime}");
        }

        private TooltipLine Wing_FlightTime_CurrentWingTime(int currentWingTime)
        {
            if (Main.LocalPlayer.empressBrooch)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Current flight time: ∞");

            if (modConfig.DisplayFlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Current flight time: {currentWingTime / 60f}s");

            return new TooltipLine(Mod, "WingFlightTimeCombined", $"Current flight time: {currentWingTime}");
        }

        private TooltipLine Wing_FlightTime_MaxWingTime(int maxWingTime)
        {
            if (Main.LocalPlayer.empressBrooch)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Max flight time: ∞");

            if (modConfig.DisplayFlightTimeInSeconds)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Max flight time: {maxWingTime / 60f}s");

            return new TooltipLine(Mod, "WingFlightTimeCombined", $"Max flight time: {maxWingTime}");
        }

        private TooltipLine Wing_HorizontalSpeed(float horizontalSpeed)
        {
            if (modConfig.HorizontalSpeedMeasuredInMPH)
                return new TooltipLine(Mod, "WingFlightTimeCombined", $"Horizontal speed: {horizontalSpeed * 5.084949379f}mph");

            return new TooltipLine(Mod, "WingFlightTimeCombined", $"Horizontal speed: {horizontalSpeed} units");
        }

        private TooltipLine Wing_VerticalSpeedMultiplier(float verticalSpeedMultiplier)
        {
            if (modConfig.DisplayWingVerticalSpeedMultEvenWhenUnknown && verticalSpeedMultiplier == -1)
                return new TooltipLine(Mod, "WingVerticalSpeedMult", $"Vertical speed multiplier: Unknown");

            return new TooltipLine(Mod, "WingVerticalSpeedMult", $"Vertical speed multiplier: {verticalSpeedMultiplier}%");
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

            CheckForCalamity();

            // Hooks
            // Have to be done manually, vanilla ranges and hooks are hard coded
            if ((mod.vanillaHookStats.ContainsKey(item.type) || mod.moddedHookStats.ContainsKey(new(modName, itemName))) && modConfig.DisplayHookStats && (ItemIsCalamityFamily(modName) || !hasCalamity))
            {
                Tuple<float, float, int, int> value;
                if (modName != "Terraria")
                    value = mod.moddedHookStats[new(modName, itemName)];
                else
                    value = mod.vanillaHookStats[item.type];

                lines.Add(Hook_Title());
                if (modConfig.DisplayHookReach)
                    lines.Add(Hook_Reach(value.Item1));
                if (modConfig.DisplayHookVelocity)
                    lines.Add(Hook_Velocity(value.Item2));
                if (modConfig.DisplayHookCount)
                    lines.Add(Hook_HookCount(value.Item3));
                if (modConfig.DisplayHookLatchingType)
                    lines.Add(Hook_LatchingType(value.Item4));

                tooltips.AddRange(lines);
            }

            // Wings
            // Can be done mostly through WingStats, vertical speed multiplier is hard coded so need a dict for that
            if (item.wingSlot > 0 && modConfig.DisplayWingStats && (ItemIsCalamityFamily(modName) || !hasCalamity))
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
                Tuple<int, float, int> value;
                // Check if we have a modded wingstats override
                if (mod.moddedWingStatsOverride.ContainsKey(new(modName, itemName)))
                    value = mod.moddedWingStatsOverride[new(modName, itemName)];
                // Check if our item is modded...
                else if (modName != "Terraria")
                    value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.vanillaWingVerticalMults[item.type]);
                // ... or vanilla 
                else
                    value = new(wingStats.FlyTime, wingStats.AccRunSpeedOverride, mod.moddedWingVerticalMults[new(modName, itemName)]);

                lines.Add(Wing_Title());

                // Flight time
                // If we're using combined wing times and is equipped - display as combined using players wing time
                if (modConfig.CombineCurrentAndMaxWingTime && modConfig.DisplayCurrentWingTime && modConfig.DisplayMaxWingTime && isEquipped)
                {
                    lines.Add(Wing_FlightTime_Combined(Convert.ToInt32(player.wingTime), value.Item1));
                }

                // If we're not using combined and is equipped - display separerately using players wing time
                else if (isEquipped)
                {
                    if (modConfig.DisplayMaxWingTime)
                        lines.Add(Wing_FlightTime_MaxWingTime(value.Item1));
                    if (modConfig.DisplayCurrentWingTime)
                        lines.Add(Wing_FlightTime_CurrentWingTime(Convert.ToInt32(player.wingTime)));
                }

                // If it's not equipped - display only MaxWingTime using items wing time
                else
                {
                    if (modConfig.DisplayMaxWingTime)
                        lines.Add(Wing_FlightTime_MaxWingTime(value.Item1));
                }

                // Other stats
                if (modConfig.DisplayWingHorizontalSpeed)
                    lines.Add(Wing_HorizontalSpeed(value.Item2));
                if (modConfig.DisplayWingVerticalSpeedMult)
                    lines.Add(Wing_VerticalSpeedMultiplier(value.Item3));

                tooltips.AddRange(lines);
            }
        }
    }
}