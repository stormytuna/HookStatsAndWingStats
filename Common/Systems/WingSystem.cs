using System.Collections.Generic;
using HookStatsAndWingStats.WingStats;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
    public static Dictionary<string, WingStatSet> WingStats { get; set; } = [];

    public override void PostSetupContent() {
        Init_VanillaWings();
        Init_ModdedWings();
    }

    public override void Unload() => WingStats = null;

    private void Init_VanillaWings() {
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CreativeWings)}", new WingStatSet(ItemID.CreativeWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AngelWings)}", new WingStatSet(ItemID.AngelWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DemonWings)}", new WingStatSet(ItemID.DemonWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeafWings)}", new WingStatSet(ItemID.LeafWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FairyWings)}", new WingStatSet(ItemID.FairyWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FinWings)}", new WingStatSet(ItemID.FinWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FrozenWings)}", new WingStatSet(ItemID.FrozenWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.HarpyWings)}", new WingStatSet(ItemID.HarpyWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Jetpack)}", new WingStatSet(ItemID.Jetpack, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RedsWings)}", new WingStatSet(ItemID.RedsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DTownsWings)}", new WingStatSet(ItemID.DTownsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WillsWings)}", new WingStatSet(ItemID.WillsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CrownosWings)}", new WingStatSet(ItemID.CrownosWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CenxsWings)}", new WingStatSet(ItemID.CenxsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BejeweledValkyrieWing)}", new WingStatSet(ItemID.BejeweledValkyrieWing, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Yoraiz0rWings)}", new WingStatSet(ItemID.Yoraiz0rWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.JimsWings)}", new WingStatSet(ItemID.JimsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkiphsWings)}", new WingStatSet(ItemID.SkiphsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LokisWings)}", new WingStatSet(ItemID.LokisWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ArkhalisWings)}", new WingStatSet(ItemID.ArkhalisWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeinforsWings)}", new WingStatSet(ItemID.LeinforsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostarsWings)}", new WingStatSet(ItemID.GhostarsWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SafemanWings)}", new WingStatSet(ItemID.SafemanWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FoodBarbarianWings)}", new WingStatSet(ItemID.FoodBarbarianWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GroxTheGreatWings)}", new WingStatSet(ItemID.GroxTheGreatWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatWings)}", new WingStatSet(ItemID.BatWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeeWings)}", new WingStatSet(ItemID.BeeWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ButterflyWings)}", new WingStatSet(ItemID.ButterflyWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FlameWings)}", new WingStatSet(ItemID.FlameWings, 1.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Hoverboard)}", new WingStatSet(ItemID.Hoverboard, 1.66f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BoneWings)}", new WingStatSet(ItemID.BoneWings, 1.66f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.MothronWings)}", new WingStatSet(ItemID.MothronWings, 1.66f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostWings)}", new WingStatSet(ItemID.GhostWings, 1.66f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeetleWings)}", new WingStatSet(ItemID.BeetleWings, 1.66f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FestiveWings)}", new WingStatSet(ItemID.FestiveWings, 1.80f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyWings)}", new WingStatSet(ItemID.SpookyWings, 1.80f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TatteredFairyWings)}", new WingStatSet(ItemID.TatteredFairyWings, 1.80f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SteampunkWings)}", new WingStatSet(ItemID.SteampunkWings, 1.80f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BetsyWings)}", new WingStatSet(ItemID.BetsyWings, 2.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishronWings)}", new WingStatSet(ItemID.FishronWings, 2.50f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RainbowWings)}", new WingStatSet(ItemID.RainbowWings, 2.75f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsNebula)}", new WingStatSet(ItemID.WingsNebula, 2.45f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsVortex)}", new WingStatSet(ItemID.WingsVortex, 2.45f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsSolar)}", new WingStatSet(ItemID.WingsSolar, 3.00f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsStardust)}", new WingStatSet(ItemID.WingsStardust, 3.00f));
        WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LongRainbowTrailWings)}", new WingStatSet(ItemID.LongRainbowTrailWings, 4.50f));
    }

    private void Init_ModdedWings() {
        TryAddModdedWings("ModLoader", "AetherBreaker_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "Sailing_Squid_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "Coolmike5000_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "dinidini_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "dschosen_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "POCKETS_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "Saethar_Wings", 1.50f);
        TryAddModdedWings("ModLoader", "Zeph_Wings", 1.50f);

        TryAddModdedWings("EchoesoftheAncients", "Comet_Wings", 3.50f);
        TryAddModdedWings("EchoesoftheAncients", "DuskbulbWings", 4.00f);
        TryAddModdedWings("EchoesoftheAncients", "Enkin_Wings", 3.50f);
        TryAddModdedWings("EchoesoftheAncients", "InfinityWing", 3.50f);
        TryAddModdedWings("EchoesoftheAncients", "Tungqua_Thruster", 3.50f);
        TryAddModdedWings("EchoesoftheAncients", "VoidDragWings", 3.00f);

        TryAddModdedWings("ClickerClass", "TheScroller", 4.00f);

        TryAddModdedWings("SOTS", "TestWings", 1.5f);
        TryAddModdedWings("SOTS", "GelWings", 1.30f);

        WingStats.Add("OrchidMod:AbyssalWings", new WingStatSet(180, 9f, 3.00f));

        TryAddModdedWings("VitalityMod", "MachineGunJetpack", 1.50f);
        TryAddModdedWings("VitalityMod", "AnarchyWings", 1.50f);
        TryAddModdedWings("VitalityMod", "ChaosWings", 1.50f);
        TryAddModdedWings("VitalityMod", "CrystalWings", 1.50f);
        TryAddModdedWings("VitalityMod", "ForbiddenWings", 1.50f);
        TryAddModdedWings("VitalityMod", "GhastlyWings", 3.00f);
        TryAddModdedWings("VitalityMod", "BellaRose", 1.50f);

        TryAddModdedWings("Consolaria", "SparklyWings", 3.00f);

        WingStats.Add("FargowiltasSouls:GelicWings", new WingStatSet(100, 6.75f, 1.50f));
        WingStats.Add("FargowiltasSouls:DimensionSoul", new WingStatSet(int.MaxValue, 25f, 3.00f));
        WingStats.Add("FargowiltasSouls:EternitySoul", new WingStatSet(int.MaxValue, 25f, 3.00f));
        WingStats.Add("FargowiltasSouls:FlightMasterySoul", new WingStatSet(int.MaxValue, 18f, 3.00f));

        TryAddModdedWings("Gensokyo", "BloomWings", 1.50f);
        TryAddModdedWings("Gensokyo", "BlossomWings", 1.25f);
        TryAddModdedWings("Gensokyo", "ColorfulWings", 3.00f);
        TryAddModdedWings("Gensokyo", "HellfireMantle", 3.50f);
        TryAddModdedWings("Gensokyo", "IcicleWings", 1.50f);
        TryAddModdedWings("Gensokyo", "SwallowtailWings", 1.50f);
        TryAddModdedWings("Gensokyo", "SwallowtailWingsUpgraded", 1.25f);

        TryAddModdedWings("StormDiversMod", "HellSoulWings", 1.50f);
        TryAddModdedWings("StormDiversMod", "StormWings", 1.66f);
        TryAddModdedWings("StormDiversMod", "SpaceRockWings", 2.20f);

        TryAddModdedWings("Redemption", "XenomiteWings", 1.70f);
        TryAddModdedWings("Redemption", "NebWings", 4.00f);

        TryAddModdedWings("ThoriumMod", "ShootingStarTurboTuba", 2.50f);
        TryAddModdedWings("ThoriumMod", "DemonBloodWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "PhonicWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "SubspaceWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "DragonWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "DreadWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "FleshWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "CelestialTrinity", 2.50f);
        TryAddModdedWings("ThoriumMod", "ChampionWing", 1.50f);
        TryAddModdedWings("ThoriumMod", "TerrariumWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "WhiteDwarfThrusters", 2.50f);
        TryAddModdedWings("ThoriumMod", "TitanWings", 1.50f);
        TryAddModdedWings("ThoriumMod", "DridersGrace", 1.50f);
    }

    private static void TryAddModdedWings(string modName, string itemName, float verticalSpeedMult) {
        if (ModLoader.TryGetMod(modName, out Mod mod) && mod.TryFind(itemName, out ModItem modItem)) {
            WingStats[$"{modName}:{itemName}"] = new WingStatSet(modItem.Type, verticalSpeedMult);
        }
    }
}