using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats {
    public class HookStatsAndWingStats : Mod {
        public static Dictionary<int, Tuple<float, float, int, int>> VanillaHookStats { get; set; } = new Dictionary<int, Tuple<float, float, int, int>>();
        public static Dictionary<Tuple<string, string>, Tuple<float, float, int, int>> ModdedHookStats { get; set; } = new Dictionary<Tuple<string, string>, Tuple<float, float, int, int>>();
        public static Dictionary<int, int> VanillaWingVerticalMults { get; set; } = new Dictionary<int, int>();
        public static Dictionary<Tuple<string, string>, int> ModdedWingVerticalMults { get; set; } = new Dictionary<Tuple<string, string>, int>();
        public static Dictionary<Tuple<string, string>, Tuple<int, float, int>> ModdedWingStatsOverride { get; set; } = new Dictionary<Tuple<string, string>, Tuple<int, float, int>>();

        public override void Load() {
            Init_VanillaHooks();
            Init_VanillaWings();
            Init_ModdedHooks();
            Init_ModdedWings();
        }

        public override void Unload() {
            VanillaHookStats = null;
            ModdedHookStats = null;
            VanillaWingVerticalMults = null;
            ModdedWingVerticalMults = null;
            ModdedWingStatsOverride = null;
        }

        #region Vanilla

        private void Init_VanillaHooks() {
            // Pre HM
            VanillaHookStats.Add(ItemID.GrapplingHook, new(18.75f * 16f, 11.5f, 1, 0));
            VanillaHookStats.Add(ItemID.AmethystHook, new(18.75f * 16f, 10f, 1, 0));
            VanillaHookStats.Add(ItemID.SquirrelHook, new(19 * 16f, 11.5f, 1, 0));
            VanillaHookStats.Add(ItemID.TopazHook, new(20.625f * 16f, 10.5f, 1, 0));
            VanillaHookStats.Add(ItemID.SapphireHook, new(22.5f * 16f, 11f, 1, 0));
            VanillaHookStats.Add(ItemID.EmeraldHook, new(24.375f * 16f, 11.5f, 1, 0));
            VanillaHookStats.Add(ItemID.RubyHook, new(26.25f * 16f, 12f, 1, 0));
            VanillaHookStats.Add(ItemID.AmberHook, new(27.5f * 16f, 12.5f, 1, 0));
            VanillaHookStats.Add(ItemID.DiamondHook, new(29.125f * 16f, 12.5f, 1, 0));
            VanillaHookStats.Add(ItemID.WebSlinger, new(22.625f * 16f, 10f, 8, 1));
            VanillaHookStats.Add(ItemID.SkeletronHand, new(21.875f * 16f, 15f, 2, 1));
            VanillaHookStats.Add(ItemID.SlimeHook, new(18.75f * 16f, 13f, 3, 1));
            VanillaHookStats.Add(ItemID.FishHook, new(25f * 16f, 13f, 2, 1));
            VanillaHookStats.Add(ItemID.IvyWhip, new(28f * 16f, 13f, 3, 1));
            VanillaHookStats.Add(ItemID.BatHook, new(31.25f * 16f, 13.5f, 1, 0));
            VanillaHookStats.Add(ItemID.CandyCaneHook, new(25f * 16f, 11.5f, 1, 0));

            // HM
            VanillaHookStats.Add(ItemID.DualHook, new(27.5f * 16f, 14f, 2, 2));
            VanillaHookStats.Add(ItemID.QueenSlimeHook, new(30f * 16f, 16f, 1, 0));
            VanillaHookStats.Add(ItemID.ThornHook, new(30f * 16f, 16f, 3, 1));
            VanillaHookStats.Add(ItemID.IlluminantHook, new(30f * 16f, 15f, 3, 1));
            VanillaHookStats.Add(ItemID.WormHook, new(30f * 16f, 15f, 3, 1));
            VanillaHookStats.Add(ItemID.TendonHook, new(30f * 16f, 15f, 3, 1));
            VanillaHookStats.Add(ItemID.AntiGravityHook, new(31.25f * 16f, 14f, 3, 1));
            VanillaHookStats.Add(ItemID.SpookyHook, new(34.375f * 16f, 15.5f, 3, 1));
            VanillaHookStats.Add(ItemID.ChristmasHook, new(34.375f * 16f, 15.5f, 3, 1));
            VanillaHookStats.Add(ItemID.LunarHook, new(34.375f * 16f, 18f, 4, 1));
            VanillaHookStats.Add(ItemID.StaticHook, new(37.5f * 16f, 16f, 2, 2));
        }

        private void Init_VanillaWings() {
            VanillaWingVerticalMults.Add(4978, 150); // Fledgling wings
            VanillaWingVerticalMults.Add(ItemID.AngelWings, 150);
            VanillaWingVerticalMults.Add(ItemID.DemonWings, 150);
            VanillaWingVerticalMults.Add(ItemID.LeafWings, 150);
            VanillaWingVerticalMults.Add(ItemID.FairyWings, 150);
            VanillaWingVerticalMults.Add(ItemID.FinWings, 150);
            VanillaWingVerticalMults.Add(ItemID.FrozenWings, 150);
            VanillaWingVerticalMults.Add(ItemID.HarpyWings, 150);
            VanillaWingVerticalMults.Add(ItemID.Jetpack, 150);
            VanillaWingVerticalMults.Add(ItemID.RedsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.DTownsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.WillsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.CrownosWings, 150);
            VanillaWingVerticalMults.Add(ItemID.CenxsWings, 150);
            VanillaWingVerticalMults.Add(3228, 150); // Lazure's barrier platform
            VanillaWingVerticalMults.Add(ItemID.Yoraiz0rWings, 150);
            VanillaWingVerticalMults.Add(ItemID.JimsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.SkiphsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.LokisWings, 150);
            VanillaWingVerticalMults.Add(ItemID.ArkhalisWings, 150);
            VanillaWingVerticalMults.Add(ItemID.LeinforsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.GhostarsWings, 150);
            VanillaWingVerticalMults.Add(ItemID.SafemanWings, 150);
            VanillaWingVerticalMults.Add(ItemID.FoodBarbarianWings, 150);
            VanillaWingVerticalMults.Add(ItemID.GroxTheGreatWings, 150);
            VanillaWingVerticalMults.Add(ItemID.BatWings, 150);
            VanillaWingVerticalMults.Add(ItemID.BeeWings, 150);
            VanillaWingVerticalMults.Add(ItemID.ButterflyWings, 150);
            VanillaWingVerticalMults.Add(ItemID.FlameWings, 150);
            VanillaWingVerticalMults.Add(ItemID.Hoverboard, 166);
            VanillaWingVerticalMults.Add(ItemID.BoneWings, 166);
            VanillaWingVerticalMults.Add(ItemID.MothronWings, 166);
            VanillaWingVerticalMults.Add(ItemID.GhostWings, 166);
            VanillaWingVerticalMults.Add(ItemID.BeetleWings, 166);
            VanillaWingVerticalMults.Add(ItemID.FestiveWings, 180);
            VanillaWingVerticalMults.Add(ItemID.SpookyWings, 180);
            VanillaWingVerticalMults.Add(ItemID.TatteredFairyWings, 180);
            VanillaWingVerticalMults.Add(ItemID.SteampunkWings, 180);
            VanillaWingVerticalMults.Add(ItemID.BetsyWings, 250);
            VanillaWingVerticalMults.Add(4823, 275); // Empress wings
            VanillaWingVerticalMults.Add(ItemID.FishronWings, 250);
            VanillaWingVerticalMults.Add(ItemID.WingsNebula, 245);
            VanillaWingVerticalMults.Add(ItemID.WingsVortex, 245);
            VanillaWingVerticalMults.Add(ItemID.WingsSolar, 300);
            VanillaWingVerticalMults.Add(ItemID.WingsStardust, 300);
            VanillaWingVerticalMults.Add(4954, 450); // Starboard
        }

        #endregion

        #region Modded

        private void Init_ModdedHooks() {
            #region SecretsOfTheShadows
            ModdedHookStats.Add(new("SOTS", "WormWoodHook"), new(480f, 15f, 1, 0));
            ModdedHookStats.Add(new("SOTS", "InfernoHook"), new(510, 26f, 1, 0));
            #endregion

            #region Orchid
            ModdedHookStats.Add(new("OrchidMod", "MineshaftHook"), new(400f, 12f, 2, 0));
            #endregion

            #region Gensokyo
            ModdedHookStats.Add(new("Gensokyo", "TsuchigomoWebSlinger"), new(300f, 10f, 8, 1));
            #endregion

            #region StormDiversMod
            ModdedHookStats.Add(new("StormDiversMod", "EyeHook"), new(528f, 12f, 1, 0));
            ModdedHookStats.Add(new("StormDiversMod", "StormHook"), new(512f, 18f, 1, 0));
            ModdedHookStats.Add(new("StormDiversMod", "DerpHook"), new(496f, 16f, 3, 1));
            #endregion
        }

        private void Init_ModdedWings() {
            #region ModLoader
            ModdedWingVerticalMults.Add(new("ModLoader", "AetherBreaker_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "Sailing_Squid_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "Coolmike5000_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "dinidini_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "dschosen_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "POCKETS_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "Saethar_Wings"), 150);
            ModdedWingVerticalMults.Add(new("ModLoader", "Zeph_Wings"), 150);
            #endregion

            #region EchoesOfTheAncients
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "Comet_Wings"), 350);
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "DuskbulbWings"), 400);
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "Enkin_Wings"), 350);
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "InfinityWing"), 350);
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "Tungqua_Thruster"), 350);
            ModdedWingVerticalMults.Add(new("EchoesoftheAncients", "VoidDragWings"), 300);
            #endregion

            #region ClickerClass
            ModdedWingVerticalMults.Add(new("ClickerClass", "TheScroller"), 400);
            #endregion

            #region SecretsOfTheShadows
            ModdedWingVerticalMults.Add(new("SOTS", "TestWings"), 150);
            ModdedWingVerticalMults.Add(new("SOTS", "GelWings"), 130);
            #endregion

            #region Orchid
            ModdedWingStatsOverride.Add(new("OrchidMod", "AbyssalWings"), new(180, 9f, 300));
            #endregion

            #region VitalityMod
            ModdedWingVerticalMults.Add(new("VitalityMod", "MachineGunJetpack"), 150);
            ModdedWingVerticalMults.Add(new("VitalityMod", "AnarchyWings"), 150);
            ModdedWingVerticalMults.Add(new("VitalityMod", "ChaosWings"), 150);
            ModdedWingVerticalMults.Add(new("VitalityMod", "CrystalWings"), 150);
            ModdedWingVerticalMults.Add(new("VitalityMod", "ForbiddenWings"), 150);
            ModdedWingVerticalMults.Add(new("VitalityMod", "GhastlyWings"), 300);
            ModdedWingVerticalMults.Add(new("VitalityMod", "BellaRose"), 150);
            #endregion

            #region Consolaria
            ModdedWingVerticalMults.Add(new("Consolaria", "SparklyWings"), 300);
            #endregion

            #region FargosSouls
            ModdedWingStatsOverride.Add(new("FargowiltasSouls", "GelicWings"), new(100, 6.75f, 150));
            ModdedWingStatsOverride.Add(new("FargowiltasSouls", "DimensionSoul"), new(-1, 25f, 300));
            ModdedWingStatsOverride.Add(new("FargowiltasSouls", "EternitySoul"), new(-1, 25f, 300));
            ModdedWingStatsOverride.Add(new("FargowiltasSouls", "FlightMasterySoul"), new(-1, 18f, 300));
            #endregion

            #region Gensokyo
            ModdedWingVerticalMults.Add(new("Gensokyo", "BloomWings"), 150);
            ModdedWingVerticalMults.Add(new("Gensokyo", "BlossomWings"), 125);
            ModdedWingVerticalMults.Add(new("Gensokyo", "ColorfulWings"), 300);
            ModdedWingVerticalMults.Add(new("Gensokyo", "HellfireMantle"), 350);
            ModdedWingVerticalMults.Add(new("Gensokyo", "IcicleWings"), 150);
            ModdedWingVerticalMults.Add(new("Gensokyo", "SwallowtailWings"), 150);
            ModdedWingVerticalMults.Add(new("Gensokyo", "SwallowtailWingsUpgraded"), 125);
            #endregion

            #region StormDiversMod
            ModdedWingVerticalMults.Add(new("StormDiversMod", "HellSoulWings"), 150);
            ModdedWingVerticalMults.Add(new("StormDiversMod", "StormWings"), 166);
            ModdedWingVerticalMults.Add(new("StormDiversMod", "SpaceRockWings"), 220);
            #endregion
        }

        #endregion
    }
}