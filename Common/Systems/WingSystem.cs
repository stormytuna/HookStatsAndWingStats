using System.Collections.Generic;
using HookStatsAndWingStats.DataStructures;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
	public static Dictionary<int, WingStats> ItemTypeToWingStats { get; private set; } = new();

	public override void PostSetupContent() {
		Init_VanillaWings();
		Init_ModdedWings();
	}

	public override void Unload() {
		ItemTypeToWingStats = null;
	}

	private static void Init_VanillaWings() {
		ItemTypeToWingStats.Add(ItemID.CreativeWings, new WingStats(ItemID.CreativeWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.AngelWings, new WingStats(ItemID.AngelWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.DemonWings, new WingStats(ItemID.DemonWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LeafWings, new WingStats(ItemID.LeafWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FairyWings, new WingStats(ItemID.FairyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FinWings, new WingStats(ItemID.FinWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FrozenWings, new WingStats(ItemID.FrozenWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.HarpyWings, new WingStats(ItemID.HarpyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Jetpack, new WingStats(ItemID.Jetpack, 1.50f));
		ItemTypeToWingStats.Add(ItemID.RedsWings, new WingStats(ItemID.RedsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.DTownsWings, new WingStats(ItemID.DTownsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.WillsWings, new WingStats(ItemID.WillsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.CrownosWings, new WingStats(ItemID.CrownosWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.CenxsWings, new WingStats(ItemID.CenxsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BejeweledValkyrieWing, new WingStats(ItemID.BejeweledValkyrieWing, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Yoraiz0rWings, new WingStats(ItemID.Yoraiz0rWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.JimsWings, new WingStats(ItemID.JimsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.SkiphsWings, new WingStats(ItemID.SkiphsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LokisWings, new WingStats(ItemID.LokisWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.ArkhalisWings, new WingStats(ItemID.ArkhalisWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LeinforsWings, new WingStats(ItemID.LeinforsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.GhostarsWings, new WingStats(ItemID.GhostarsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.SafemanWings, new WingStats(ItemID.SafemanWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FoodBarbarianWings, new WingStats(ItemID.FoodBarbarianWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.GroxTheGreatWings, new WingStats(ItemID.GroxTheGreatWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BatWings, new WingStats(ItemID.BatWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BeeWings, new WingStats(ItemID.BeeWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.ButterflyWings, new WingStats(ItemID.ButterflyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FlameWings, new WingStats(ItemID.FlameWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Hoverboard, new WingStats(ItemID.Hoverboard, 1.66f));
		ItemTypeToWingStats.Add(ItemID.BoneWings, new WingStats(ItemID.BoneWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.MothronWings, new WingStats(ItemID.MothronWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.GhostWings, new WingStats(ItemID.GhostWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.BeetleWings, new WingStats(ItemID.BeetleWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.FestiveWings, new WingStats(ItemID.FestiveWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.SpookyWings, new WingStats(ItemID.SpookyWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.TatteredFairyWings, new WingStats(ItemID.TatteredFairyWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.SteampunkWings, new WingStats(ItemID.SteampunkWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.BetsyWings, new WingStats(ItemID.BetsyWings, 2.50f));
		ItemTypeToWingStats.Add(ItemID.FishronWings, new WingStats(ItemID.FishronWings, 2.50f));
		ItemTypeToWingStats.Add(ItemID.RainbowWings, new WingStats(ItemID.RainbowWings, 2.75f));
		ItemTypeToWingStats.Add(ItemID.WingsNebula, new WingStats(ItemID.WingsNebula, 2.45f));
		ItemTypeToWingStats.Add(ItemID.WingsVortex, new WingStats(ItemID.WingsVortex, 2.45f));
		ItemTypeToWingStats.Add(ItemID.WingsSolar, new WingStats(ItemID.WingsSolar, 3.00f));
		ItemTypeToWingStats.Add(ItemID.WingsStardust, new WingStats(ItemID.WingsStardust, 3.00f));
		ItemTypeToWingStats.Add(ItemID.LongRainbowTrailWings, new WingStats(ItemID.LongRainbowTrailWings, 4.50f));
	}

	private void Init_ModdedWings() {
		TryAddModdedWing("ModLoader", "AetherBreaker_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "Sailing_Squid_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "Coolmike5000_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "dinidini_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "dschosen_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "POCKETS_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "Saethar_Wings", 1.50f);
		TryAddModdedWing("ModLoader", "Zeph_Wings", 1.50f);

		TryAddModdedWing("EchoesoftheAncients", "Comet_Wings", 3.50f);
		TryAddModdedWing("EchoesoftheAncients", "DuskbulbWings", 4.00f);
		TryAddModdedWing("EchoesoftheAncients", "Enkin_Wings", 3.50f);
		TryAddModdedWing("EchoesoftheAncients", "InfinityWing", 3.50f);
		TryAddModdedWing("EchoesoftheAncients", "Tungqua_Thruster", 3.50f);
		TryAddModdedWing("EchoesoftheAncients", "VoidDragWings", 3.00f);

		TryAddModdedWing("ClickerClass", "TheScroller", 4.00f);

		TryAddModdedWing("SOTS", "TestWings", 1.5f);
		TryAddModdedWing("SOTS", "GelWings", 1.30f);

		TryAddModdedWing("OrchidMod", "AbyssalWings", new WingStats(180, 9f, 3.00f));

		TryAddModdedWing("VitalityMod", "MachineGunJetpack", 1.50f);
		TryAddModdedWing("VitalityMod", "AnarchyWings", 1.50f);
		TryAddModdedWing("VitalityMod", "ChaosWings", 1.50f);
		TryAddModdedWing("VitalityMod", "CrystalWings", 1.50f);
		TryAddModdedWing("VitalityMod", "ForbiddenWings", 1.50f);
		TryAddModdedWing("VitalityMod", "GhastlyWings", 3.00f);
		TryAddModdedWing("VitalityMod", "BellaRose", 1.50f);

		TryAddModdedWing("Consolaria", "SparklyWings", 3.00f);

		TryAddModdedWing("FargowiltasSouls", "GelicWings", new WingStats(100, 6.75f, 1.50f));
		TryAddModdedWing("FargowiltasSouls", "DimensionSoul", new WingStats(int.MaxValue, 25f, 3.00f));
		TryAddModdedWing("FargowiltasSouls", "EternitySoul", new WingStats(int.MaxValue, 25f, 3.00f));
		TryAddModdedWing("FargowiltasSouls", "FlightMasterySoul", new WingStats(int.MaxValue, 18f, 3.00f));

		TryAddModdedWing("Gensokyo", "BloomWings", 1.50f);
		TryAddModdedWing("Gensokyo", "BlossomWings", 1.25f);
		TryAddModdedWing("Gensokyo", "ColorfulWings", 3.00f);
		TryAddModdedWing("Gensokyo", "HellfireMantle", 3.50f);
		TryAddModdedWing("Gensokyo", "IcicleWings", 1.50f);
		TryAddModdedWing("Gensokyo", "SwallowtailWings", 1.50f);
		TryAddModdedWing("Gensokyo", "SwallowtailWingsUpgraded", 1.25f);

		TryAddModdedWing("StormDiversMod", "HellSoulWings", 1.50f);
		TryAddModdedWing("StormDiversMod", "StormWings", 1.66f);
		TryAddModdedWing("StormDiversMod", "SpaceRockWings", 2.20f);

		TryAddModdedWing("Redemption", "XenomiteWings", 1.70f);
		TryAddModdedWing("Redemption", "NebWings", 4.00f);

		TryAddModdedWing("ThoriumMod", "ShootingStarTurboTuba", 2.50f);
		TryAddModdedWing("ThoriumMod", "DemonBloodWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "PhonicWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "SubspaceWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "DragonWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "DreadWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "FleshWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "CelestialTrinity", 2.50f);
		TryAddModdedWing("ThoriumMod", "ChampionWing", 1.50f);
		TryAddModdedWing("ThoriumMod", "TerrariumWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "WhiteDwarfThrusters", 2.50f);
		TryAddModdedWing("ThoriumMod", "TitanWings", 1.50f);
		TryAddModdedWing("ThoriumMod", "DridersGrace", 1.50f);
	}

	private void TryAddModdedWing(string modName, string itemName, WingStats stats) {
		if (ModContent.TryFind($"{modName}/{itemName}", out ModItem item)) {
			ItemTypeToWingStats.Add(item.Type, stats);
		}
	}
	
	private void TryAddModdedWing(string modName, string itemName, float verticalMult) {
		if (ModContent.TryFind($"{modName}/{itemName}", out ModItem item)) {
			ItemTypeToWingStats.Add(item.Type, new WingStats(item.Type, verticalMult));
		}
	}

	public static void AddModdedWing(int itemType, float verticalMult) {
		ItemTypeToWingStats.Add(itemType, new WingStats(itemType, verticalMult));
	}
	
	public static void AddModdedWing(int itemType, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) {
		ItemTypeToWingStats.Add(itemType, new WingStats(maxFlightTime, horizontalSpeed, verticalSpeedMultiplier));
	}
}
