using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common
{
    public static class Helpers
    {
        public static bool HasCalamity => ModLoader.TryGetMod("CalamityMod", out _);

        public static bool ItemIsCalamityFamily(string itemModName)
            => itemModName != "Terraria" && itemModName != "CalamityMod" && itemModName != "CalValEX" && itemModName != "CatalystMod";

        public static string WrapLine(string subtitle, Color subColor, string value, Color valColor) {
            return WrapLine(subtitle, subColor.Hex3(), value, valColor.Hex3());
        }

        public static string WrapLine(string subtitle, string subColorHex, string value, string valColorHex) {
            return $"[c/{subColorHex}:{subtitle}][c/{valColorHex}:{value}]";
        }

        public static bool ShouldDisplayHookStats(this Item item) {
            string modName = item.ModItem?.Mod.Name ?? "Terraria";
            string itemName = item.ModItem?.Name ?? item.Name;
            Tuple<string, string> key = new(modName, itemName);

            bool displayingAnyStats = HookConfig.Instance.ShowStats && (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowVelocity || HookConfig.Instance.ShowCount || HookConfig.Instance.ShowLatchingType);
            bool haveHookStats = HookSystem.VanillaHookStats.ContainsKey(item.type) || HookSystem.ModdedHookStats.ContainsKey(key);
            bool careAboutCalamity = ItemIsCalamityFamily(modName) || !HasCalamity;
            return haveHookStats && displayingAnyStats && careAboutCalamity;
        }

        public static Item EquippedHook(this Player player) {
            return player.miscEquips[4];
        }

        public static bool HookIsRegisteredInDicts(this Item item) {
            string modName = item.ModItem?.Mod.Name ?? "Terraria";
            string itemName = item.ModItem?.Name ?? item.Name;
            Tuple<string, string> key = new(modName, itemName);
            return modName == "Terraria" ? HookSystem.VanillaHookStats.ContainsKey(item.type) : HookSystem.ModdedHookStats.ContainsKey(key);
        }
    }
}
