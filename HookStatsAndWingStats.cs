using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HookStatsAndWingStats
{
    public class HookStatsAndWingStats : Mod
    {
        public Dictionary<int, Tuple<float, float, int, int>> vanillaHookStats { get; set; } = new Dictionary<int, Tuple<float, float, int, int>>();
        public Dictionary<Tuple<string, string>, Tuple<int, int, int>> moddedHookStats { get; set; } = new Dictionary<Tuple<string, string>, Tuple<int, int, int>>();
        public Dictionary<int, int> vanillaWingVerticalMults { get; set; } = new Dictionary<int, int>();
        public Dictionary<Tuple<string, string>, int> moddedWingVerticalMults { get; set; } = new Dictionary<Tuple<string, string>, int>();

        public override void Load()
        {
            Init_VanillaHooks();
            Init_VanillaWings();
            Init_ModdedHooks();
            Init_ModdedWings();
        }

        private void Init_VanillaHooks()
        {
            // Pre HM
            vanillaHookStats.Add(ItemID.GrapplingHook, new(18.75f, 11.5f, 1, 0));
            vanillaHookStats.Add(ItemID.AmethystHook, new(18.75f, 10f, 1, 0));
            vanillaHookStats.Add(ItemID.SquirrelHook, new(19, 11.5f, 1, 0));
            vanillaHookStats.Add(ItemID.TopazHook, new(20.625f, 10.5f, 1, 0));
            vanillaHookStats.Add(ItemID.SapphireHook, new(22.5f, 11f, 1, 0));
            vanillaHookStats.Add(ItemID.EmeraldHook, new(24.375f, 11.5f, 1, 0));
            vanillaHookStats.Add(ItemID.RubyHook, new(26.25f, 12f, 1, 0));
            vanillaHookStats.Add(ItemID.AmberHook, new(27.5f, 12.5f, 1, 0));
            vanillaHookStats.Add(ItemID.DiamondHook, new(29.125f, 12.5f, 1, 0));
            vanillaHookStats.Add(ItemID.WebSlinger, new(22.625f, 10f, 8, 1));
            vanillaHookStats.Add(ItemID.SkeletronHand, new(21.875f, 15f, 2, 1));
            vanillaHookStats.Add(ItemID.SlimeHook, new(18.75f, 13f, 3, 1));
            vanillaHookStats.Add(ItemID.FishHook, new(25f, 13f, 2, 1));
            vanillaHookStats.Add(ItemID.IvyWhip, new(28f, 13f, 3, 1));
            vanillaHookStats.Add(ItemID.BatHook, new(31.25f, 13.5f, 1, 0));
            vanillaHookStats.Add(ItemID.CandyCaneHook, new(25f, 11.5f, 1, 0));

            // HM
            vanillaHookStats.Add(ItemID.DualHook, new(27.5f, 14f, 2, 2));
            vanillaHookStats.Add(ItemID.QueenSlimeHook, new(30f, 16f, 1, 0));
            vanillaHookStats.Add(ItemID.ThornHook, new(30f, 16f, 3, 1));
            vanillaHookStats.Add(ItemID.IlluminantHook, new(30f, 15f, 3, 1));
            vanillaHookStats.Add(ItemID.WormHook, new(30f, 15f, 3, 1));
            vanillaHookStats.Add(ItemID.TendonHook, new(30f, 15f, 3, 1));
            vanillaHookStats.Add(ItemID.AntiGravityHook, new(31.25f, 14f, 3, 1));
            vanillaHookStats.Add(ItemID.SpookyHook, new(34.375f, 15.5f, 3, 1));
            vanillaHookStats.Add(ItemID.ChristmasHook, new(34.375f, 15.5f, 3, 1));
            vanillaHookStats.Add(ItemID.LunarHook, new(34.375f, 18f, 4, 1));
            vanillaHookStats.Add(ItemID.StaticHook, new(37.5f, 16f, 2, 2));
        }

        private void Init_VanillaWings()
        {
            vanillaWingVerticalMults.Add(4978, 150); // Fledgling wings
            vanillaWingVerticalMults.Add(ItemID.AngelWings, 150);
            vanillaWingVerticalMults.Add(ItemID.DemonWings, 150);
            vanillaWingVerticalMults.Add(ItemID.LeafWings, 150);
            vanillaWingVerticalMults.Add(ItemID.FairyWings, 150);
            vanillaWingVerticalMults.Add(ItemID.FinWings, 150);
            vanillaWingVerticalMults.Add(ItemID.FrozenWings, 150);
            vanillaWingVerticalMults.Add(ItemID.HarpyWings, 150);
            vanillaWingVerticalMults.Add(ItemID.Jetpack, 150);
            vanillaWingVerticalMults.Add(ItemID.RedsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.DTownsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.WillsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.CrownosWings, 150);
            vanillaWingVerticalMults.Add(ItemID.CenxsWings, 150);
            vanillaWingVerticalMults.Add(3228, 150); // Lazure's barrier platform
            vanillaWingVerticalMults.Add(ItemID.Yoraiz0rWings, 150);
            vanillaWingVerticalMults.Add(ItemID.JimsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.SkiphsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.LokisWings, 150);
            vanillaWingVerticalMults.Add(ItemID.ArkhalisWings, 150);
            vanillaWingVerticalMults.Add(ItemID.LeinforsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.GhostarsWings, 150);
            vanillaWingVerticalMults.Add(ItemID.SafemanWings, 150);
            vanillaWingVerticalMults.Add(ItemID.FoodBarbarianWings, 150);
            vanillaWingVerticalMults.Add(ItemID.GroxTheGreatWings, 150);
            vanillaWingVerticalMults.Add(ItemID.BatWings, 150);
            vanillaWingVerticalMults.Add(ItemID.BeeWings, 150);
            vanillaWingVerticalMults.Add(ItemID.ButterflyWings, 150);
            vanillaWingVerticalMults.Add(ItemID.FlameWings, 150);
            vanillaWingVerticalMults.Add(ItemID.Hoverboard, 166);
            vanillaWingVerticalMults.Add(ItemID.BoneWings, 166);
            vanillaWingVerticalMults.Add(ItemID.MothronWings, 166);
            vanillaWingVerticalMults.Add(ItemID.GhostWings, 166);
            vanillaWingVerticalMults.Add(ItemID.BeetleWings, 166);
            vanillaWingVerticalMults.Add(ItemID.FestiveWings, 180);
            vanillaWingVerticalMults.Add(ItemID.SpookyWings, 180);
            vanillaWingVerticalMults.Add(ItemID.TatteredFairyWings, 180);
            vanillaWingVerticalMults.Add(ItemID.SteampunkWings, 180);
            vanillaWingVerticalMults.Add(ItemID.BetsyWings, 250);
            vanillaWingVerticalMults.Add(4823, 275); // Empress wings
            vanillaWingVerticalMults.Add(ItemID.FishronWings, 250);
            vanillaWingVerticalMults.Add(ItemID.WingsNebula, 245);
            vanillaWingVerticalMults.Add(ItemID.WingsVortex, 245);
            vanillaWingVerticalMults.Add(ItemID.WingsSolar, 300);
            vanillaWingVerticalMults.Add(ItemID.WingsStardust, 300);
            vanillaWingVerticalMults.Add(4954, 450); // Starboard
        }

        private void Init_ModdedHooks()
        {

        }

        private void Init_ModdedWings()
        {
            #region ModLoader
            moddedWingVerticalMults.Add(new("ModLoader", "AetherBreaker_Wings"), 150);
            moddedWingVerticalMults.Add(new("ModLoader", "Coolmike5000_Wings"), 150);
            moddedWingVerticalMults.Add(new("ModLoader", "dinidini_Wings"), 150);
            #endregion

            moddedWingVerticalMults.Add(new("EchoesoftheAncients", "VoidDragWings"), 150);
        }
    }
}