using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems
{
    public class HookSystem : ModSystem
    {
        // Tuple is represented as (tilereach, shootspeed, numhooks, latchingtype)
        public static Dictionary<int, Tuple<float, float, int, int>> VanillaHookStats { get; set; } = new Dictionary<int, Tuple<float, float, int, int>>();
        public static Dictionary<Tuple<string, string>, Tuple<float, float, int, int>> ModdedHookStats { get; set; } = new Dictionary<Tuple<string, string>, Tuple<float, float, int, int>>();

        public override void Load() {
            Init_VanillaHooks();
            Init_ModdedHooks();
        }

        public override void Unload() {
            VanillaHookStats = null;
            ModdedHookStats = null;
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

            #region ModOfRedemption
            ModdedHookStats.Add(new("Redemption", "RopeHook"), new(500f, 16f, 1, 0));
            #endregion

            #region ThoriumMod
            ModdedHookStats.Add(new("ThoriumMod", "SpringHook"), new(17f * 16f, 12f, 1, 0));
            ModdedHookStats.Add(new("ThoriumMod", "OpalHook"), new(340f, 10.75f, 1, 0));
            ModdedHookStats.Add(new("ThoriumMod", "AquamarineHook"), new(350f, 10.75f, 1, 0));
            ModdedHookStats.Add(new("ThoriumMod", "Leviathan"), new(430f, 14f, 10, 1));
            ModdedHookStats.Add(new("ThoriumMod", "JewellersWallGrip"), new(450f, 13f, 2, 1));
            ModdedHookStats.Add(new("ThoriumMod", "AmmutsebaSash"), new(480f, 15f, 1, 0));
            ModdedHookStats.Add(new("ThoriumMod", "FungalHook"), new(480f, 16f, 3, 1));
            ModdedHookStats.Add(new("ThoriumMod", "NeptuneGrasp"), new(480f, 15f, 4, 1));
            ModdedHookStats.Add(new("ThoriumMod", "DevilsReach"), new(520f, 15f, 3, 1));
            ModdedHookStats.Add(new("ThoriumMod", "GhostlyGrapple"), new(550f, 16f, 2, 1));
            #endregion
        }

        #endregion
    }
}
