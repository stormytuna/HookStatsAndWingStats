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
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var mod = ModContent.GetInstance<HookStatsAndWingStats>();
            var modConfig = ModContent.GetInstance<HookStatsAndWingStatsConfig>();
            List<TooltipLine> lines = new List<TooltipLine>();
            string modName = "Terraria";
            string itemName = item.Name;
            bool hasCalamity = false;
            if (item.ModItem != null)
            {
                modName = item.ModItem.Mod.Name;
                itemName = item.ModItem.Name;
            }

            if (ModLoader.TryGetMod("CalamityMod", out _))
                hasCalamity = true;


            

            // Hooks
            // Have to be done manually, vanilla ranges and hooks are hard coded
            if ((mod.vanillaHookStats.ContainsKey(item.type) || mod.moddedHookStats.ContainsKey(new(modName, itemName))) && modConfig.DisplayHookStats && ((modName != "Terraria" && modName != "CalamityMod" && modName != "CalValEX" && modName != "CatalystMod") || !hasCalamity))
            {
                var value = mod.vanillaHookStats[item.type];
                
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
            // Can be done mostly through WingStats, vertical speed multiplier is hard coded so need a dict for that
            if (item.wingSlot > 0 && modConfig.DisplayWingStats && ((modName != "Terraria" && modName != "CalamityMod" && modName != "CalValEX" && modName != "CatalystMod") || !hasCalamity) && modName != "FargowiltasSouls")
            {
                // Declaring stuff
                Player player = Main.LocalPlayer;
                WingStats wingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
                bool isEquipped = false;
                
                // Check if this item is equipped
                for (int i = 0; i < player.armor.Length; i++)
                {
                    if (player.armor[i].type == item.type && Main.mouseX > Main.screenWidth / 2)
                        isEquipped = true;
                }

                // Check if we have a modded wingstats override for this item - this is entirely for stinky mod devs who aren't setting WingStats properly
                if (mod.moddedWingStatsOverride.ContainsKey(new(modName, itemName)))
                {
                    wingStats = new WingStats(mod.moddedWingStatsOverride[new(modName, itemName)].Item1, mod.moddedWingStatsOverride[new(modName, itemName)].Item2);
                    mod.moddedWingVerticalMults.Add(new(modName, itemName), mod.moddedWingStatsOverride[new(modName, itemName)].Item3);
                }

                // Add title
                TooltipLine temp = new TooltipLine(Mod, "WingTitle", "\n~ WING STATS ~");
                temp.OverrideColor = modConfig.WingStatsTitleColor;
                lines.Add(temp);

                // Flight time
                // If we're using combined wing times and is equipped - display as combined using players wing time
                if (modConfig.CombineCurrentAndMaxWingTime && modConfig.DisplayCurrentWingTime && modConfig.DisplayMaxWingTime && isEquipped)
                {
                    lines.Add(new TooltipLine(Mod, "WingStat", $"Flight time: {GetWingTime(player.wingTime, true)} / {GetWingTime(player.wingTimeMax, true)}"));
                }
                // If we're not using combined and is equipped - display separerately using players wing time
                else if (isEquipped)
                {
                    if (modConfig.DisplayMaxWingTime)
                        lines.Add(new TooltipLine(Mod, "WingStat", $"Max flight time: {GetWingTime(player.wingTimeMax, true)}"));
                    if (modConfig.DisplayCurrentWingTime)
                        lines.Add(new TooltipLine(Mod, "WingStat", $"Current flight time: {GetWingTime(player.wingTime, true)}"));
                }
                // If it's not equipped - display only MaxWingTime using items wing time
                else
                {
                    if (modConfig.DisplayMaxWingTime)
                        lines.Add(new TooltipLine(Mod, "WingStat", $"Max flight time: {GetWingTime(wingStats.FlyTime, false)}"));
                }
                // Other stats
                if (modConfig.DisplayWingHorizontalSpeed && modConfig.HorizontalSpeedMeasuredInMPH)
                    lines.Add(new TooltipLine(Mod, "WingStat", $"Horizontal speed: {MathF.Round(wingStats.AccRunSpeedOverride * 5.084949379f)}mph"));
                else if (modConfig.DisplayWingHorizontalSpeed && !modConfig.HorizontalSpeedMeasuredInMPH)
                    lines.Add(new TooltipLine(Mod, "WingStat", $"Horizontal speed: {MathF.Round(wingStats.AccRunSpeedOverride * 5.084949379f)} units"));
                if (modConfig.DisplayWingVerticalSpeedMult && (mod.vanillaWingVerticalMults.ContainsKey(item.type) || mod.moddedWingVerticalMults.ContainsKey(new(modName, itemName))))
                {
                    // If modded
                    if (modName != "Terraria" && ModLoader.TryGetMod(modName, out Mod mod1))
                        lines.Add(new TooltipLine(Mod, "WingStat", $"Verical speed multiplier: {mod.moddedWingVerticalMults[new(modName, itemName)]}%"));
                    // If vanilla
                    else
                        lines.Add(new TooltipLine(Mod, "WingStat", $"Verical speed multiplier: {mod.vanillaWingVerticalMults[item.type]}%"));
                }
                else if (modConfig.DisplayWingVerticalSpeedMultEvenWhenUnknown)
                    lines.Add(new TooltipLine(Mod, "WingStat", $"Verical speed multiplier: Unknown"));

                tooltips.AddRange(lines);
            }
        }

        private string GetWingTime(float wingTime, bool isEquipped)
        {
            if (Main.LocalPlayer.empressBrooch && isEquipped)
                return "∞";
            if (ModContent.GetInstance<HookStatsAndWingStatsConfig>().DisplayFlightTimeInSeconds)
                return (wingTime / 60f).ToString("0.00") + "s";
            return
                wingTime.ToString();
        }
    }
}