using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems
{
    public class WingSystem : ModSystem
    {
        public static Dictionary<int, int> VanillaWingVerticalMults { get; set; } = new Dictionary<int, int>();
        public static Dictionary<Tuple<string, string>, int> ModdedWingVerticalMults { get; set; } = new Dictionary<Tuple<string, string>, int>();
        public static Dictionary<Tuple<string, string>, Tuple<int, float, int>> ModdedWingStatsOverride { get; set; } = new Dictionary<Tuple<string, string>, Tuple<int, float, int>>();

        public override void Load() {
            Init_VanillaWings();
            Init_ModdedWings();
        }

        public override void Unload() {
            VanillaWingVerticalMults = null;
            ModdedWingVerticalMults = null;
            ModdedWingStatsOverride = null;
        }

        #region Vanilla

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

            #region ModOfRedemption
            ModdedWingVerticalMults.Add(new("Redemption", "XenomiteWings"), 170);
            ModdedWingVerticalMults.Add(new("Redemption", "NebWings"), 400);
            #endregion

            #region ThoriumMod
            ModdedWingVerticalMults.Add(new("ThoriumMod", "ShootingStarTurboTuba"), 250);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "DemonBloodWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "PhonicWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "SubspaceWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "DragonWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "DreadWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "FleshWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "CelestialTrinity"), 250);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "ChampionWing"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "TerrariumWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "WhiteDwarfThrusters"), 250);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "TitanWings"), 150);
            ModdedWingVerticalMults.Add(new("ThoriumMod", "DridersGrace"), 150);
            #endregion
        }

        #endregion
    }
}
