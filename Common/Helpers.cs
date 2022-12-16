using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common {
    public static class Helpers {
        private static bool? _hasCalamity = null;
        public static bool HasCalamity {
            get {
                if (_hasCalamity is null) {
                    _hasCalamity = ModLoader.TryGetMod("CalamityMod", out _);
                }

                return (bool)_hasCalamity;
            }
        }

        public static bool ItemIsCalamityFamily(string itemModName)
            => itemModName != "Terraria" && itemModName != "CalamityMod" && itemModName != "CalValEX" && itemModName != "CatalystMod";

        public static string WrapLine(string subtitle, Color subColor, string value, Color valColor) {
            return WrapLine(subtitle, subColor.Hex3(), value, valColor.Hex3());
        }

        public static string WrapLine(string subtitle, string subColorHex, string value, string valColorHex) {
            return $"[c/{subColorHex}:{subtitle}][c/{valColorHex}:{value}]";
        }
    }
}
