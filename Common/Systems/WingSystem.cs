using System.Collections.Generic;
using HookStatsAndWingStats.Helpers;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
	public static Dictionary<string, WingStats> WingStats { get; set; } = new();

	public override void PostSetupContent() {
		Init_VanillaWings();
		Init_ModdedWings();
	}

	public override void Unload() {
		WingStats = null;
	}

	private void Init_VanillaWings() {
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CreativeWings)}", new WingStats(ItemID.CreativeWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AngelWings)}", new WingStats(ItemID.AngelWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DemonWings)}", new WingStats(ItemID.DemonWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeafWings)}", new WingStats(ItemID.LeafWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FairyWings)}", new WingStats(ItemID.FairyWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FinWings)}", new WingStats(ItemID.FinWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FrozenWings)}", new WingStats(ItemID.FrozenWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.HarpyWings)}", new WingStats(ItemID.HarpyWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Jetpack)}", new WingStats(ItemID.Jetpack, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RedsWings)}", new WingStats(ItemID.RedsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DTownsWings)}", new WingStats(ItemID.DTownsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WillsWings)}", new WingStats(ItemID.WillsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CrownosWings)}", new WingStats(ItemID.CrownosWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CenxsWings)}", new WingStats(ItemID.CenxsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BejeweledValkyrieWing)}", new WingStats(ItemID.BejeweledValkyrieWing, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Yoraiz0rWings)}", new WingStats(ItemID.Yoraiz0rWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.JimsWings)}", new WingStats(ItemID.JimsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkiphsWings)}", new WingStats(ItemID.SkiphsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LokisWings)}", new WingStats(ItemID.LokisWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ArkhalisWings)}", new WingStats(ItemID.ArkhalisWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeinforsWings)}", new WingStats(ItemID.LeinforsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostarsWings)}", new WingStats(ItemID.GhostarsWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SafemanWings)}", new WingStats(ItemID.SafemanWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FoodBarbarianWings)}", new WingStats(ItemID.FoodBarbarianWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GroxTheGreatWings)}", new WingStats(ItemID.GroxTheGreatWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatWings)}", new WingStats(ItemID.BatWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeeWings)}", new WingStats(ItemID.BeeWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ButterflyWings)}", new WingStats(ItemID.ButterflyWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FlameWings)}", new WingStats(ItemID.FlameWings, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Hoverboard)}", new WingStats(ItemID.Hoverboard, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BoneWings)}", new WingStats(ItemID.BoneWings, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.MothronWings)}", new WingStats(ItemID.MothronWings, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostWings)}", new WingStats(ItemID.GhostWings, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeetleWings)}", new WingStats(ItemID.BeetleWings, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FestiveWings)}", new WingStats(ItemID.FestiveWings, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyWings)}", new WingStats(ItemID.SpookyWings, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TatteredFairyWings)}", new WingStats(ItemID.TatteredFairyWings, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SteampunkWings)}", new WingStats(ItemID.SteampunkWings, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BetsyWings)}", new WingStats(ItemID.BetsyWings, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishronWings)}", new WingStats(ItemID.FishronWings, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RainbowWings)}", new WingStats(ItemID.RainbowWings, 2.75f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsNebula)}", new WingStats(ItemID.WingsNebula, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsVortex)}", new WingStats(ItemID.WingsVortex, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsSolar)}", new WingStats(ItemID.WingsSolar, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsStardust)}", new WingStats(ItemID.WingsStardust, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LongRainbowTrailWings)}", new WingStats(ItemID.LongRainbowTrailWings, 4.50f));
	}

	private void Init_ModdedWings() {
		WingStats.TryAddModdedWing("ModLoader", "AetherBreaker_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "Sailing_Squid_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "Coolmike5000_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "dinidini_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "dschosen_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "POCKETS_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "Saethar_Wings", 1.50f);
		WingStats.TryAddModdedWing("ModLoader", "Zeph_Wings", 1.50f);

		WingStats.TryAddModdedWing("EchoesoftheAncients", "Comet_Wings", 3.50f);
		WingStats.TryAddModdedWing("EchoesoftheAncients", "DuskbulbWings", 4.00f);
		WingStats.TryAddModdedWing("EchoesoftheAncients", "Enkin_Wings", 3.50f);
		WingStats.TryAddModdedWing("EchoesoftheAncients", "InfinityWing", 3.50f);
		WingStats.TryAddModdedWing("EchoesoftheAncients", "Tungqua_Thruster", 3.50f);
		WingStats.TryAddModdedWing("EchoesoftheAncients", "VoidDragWings", 3.00f);

		WingStats.TryAddModdedWing("ClickerClass", "TheScroller", 4.00f);

		WingStats.TryAddModdedWing("SOTS", "TestWings", 1.5f);
		WingStats.TryAddModdedWing("SOTS", "GelWings", 1.30f);

		WingStats.Add("OrchidMod:AbyssalWings", new WingStats(180, 9f, 3.00f));

		WingStats.TryAddModdedWing("VitalityMod", "MachineGunJetpack", 1.50f);
		WingStats.TryAddModdedWing("VitalityMod", "AnarchyWings", 1.50f);
		WingStats.TryAddModdedWing("VitalityMod", "ChaosWings", 1.50f);
		WingStats.TryAddModdedWing("VitalityMod", "CrystalWings", 1.50f);
		WingStats.TryAddModdedWing("VitalityMod", "ForbiddenWings", 1.50f);
		WingStats.TryAddModdedWing("VitalityMod", "GhastlyWings", 3.00f);
		WingStats.TryAddModdedWing("VitalityMod", "BellaRose", 1.50f);

		WingStats.TryAddModdedWing("Consolaria", "SparklyWings", 3.00f);

		WingStats.Add("FargowiltasSouls:GelicWings", new WingStats(100, 6.75f, 1.50f));
		WingStats.Add("FargowiltasSouls:DimensionSoul", new WingStats(int.MaxValue, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:EternitySoul", new WingStats(int.MaxValue, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:FlightMasterySoul", new WingStats(int.MaxValue, 18f, 3.00f));

		WingStats.TryAddModdedWing("Gensokyo", "BloomWings", 1.50f);
		WingStats.TryAddModdedWing("Gensokyo", "BlossomWings", 1.25f);
		WingStats.TryAddModdedWing("Gensokyo", "ColorfulWings", 3.00f);
		WingStats.TryAddModdedWing("Gensokyo", "HellfireMantle", 3.50f);
		WingStats.TryAddModdedWing("Gensokyo", "IcicleWings", 1.50f);
		WingStats.TryAddModdedWing("Gensokyo", "SwallowtailWings", 1.50f);
		WingStats.TryAddModdedWing("Gensokyo", "SwallowtailWingsUpgraded", 1.25f);

		WingStats.TryAddModdedWing("StormDiversMod", "HellSoulWings", 1.50f);
		WingStats.TryAddModdedWing("StormDiversMod", "StormWings", 1.66f);
		WingStats.TryAddModdedWing("StormDiversMod", "SpaceRockWings", 2.20f);

		WingStats.TryAddModdedWing("Redemption", "XenomiteWings", 1.70f);
		WingStats.TryAddModdedWing("Redemption", "NebWings", 4.00f);

		WingStats.TryAddModdedWing("ThoriumMod", "ShootingStarTurboTuba", 2.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "DemonBloodWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "PhonicWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "SubspaceWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "DragonWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "DreadWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "FleshWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "CelestialTrinity", 2.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "ChampionWing", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "TerrariumWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "WhiteDwarfThrusters", 2.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "TitanWings", 1.50f);
		WingStats.TryAddModdedWing("ThoriumMod", "DridersGrace", 1.50f);
	}
}