using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
	/// <summary>
	///     -2 for maxFlightTime or horizontalSpeed means to use the corresponding value from ArmorID.Sets.Wing.Stats
	/// </summary>
	public static Dictionary<string, (int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier)> WingStats { get; set; } = new();

	public override void Load() {
		Init_VanillaWings();
		Init_ModdedWings();
	}

	public override void Unload() {
		WingStats = null;
	}

	#region Vanilla

	private void Init_VanillaWings() {
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CreativeWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AngelWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DemonWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeafWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FairyWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FinWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FrozenWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.HarpyWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Jetpack)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RedsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DTownsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WillsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CrownosWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CenxsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BejeweledValkyrieWing)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Yoraiz0rWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.JimsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkiphsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LokisWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ArkhalisWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeinforsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostarsWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SafemanWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FoodBarbarianWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GroxTheGreatWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeeWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ButterflyWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FlameWings)}", (-2, -2, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Hoverboard)}", (-2, -2, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BoneWings)}", (-2, -2, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.MothronWings)}", (-2, -2, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostWings)}", (-2, -2, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeetleWings)}", (-2, -2, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FestiveWings)}", (-2, -2, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyWings)}", (-2, -2, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TatteredFairyWings)}", (-2, -2, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SteampunkWings)}", (-2, -2, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BetsyWings)}", (-2, -2, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishronWings)}", (-2, -2, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RainbowWings)}", (-2, -2, 2.75f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsNebula)}", (-2, -2, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsVortex)}", (-2, -2, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsSolar)}", (-2, -2, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsStardust)}", (-2, -2, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LongRainbowTrailWings)}", (-2, -2, 4.50f));
	}

	#endregion

	#region Modded

	private void Init_ModdedWings() {
		#region tModLoader

		WingStats.Add("ModLoader:AetherBreaker_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:Sailing_Squid_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:Coolmike5000_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:dinidini_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:dschosen_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:POCKETS_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:Saethar_Wings", (-2, -2, 1.50f));
		WingStats.Add("ModLoader:Zeph_Wings", (-2, -2, 1.50f));

		#endregion

		#region EchoesOfTheAncients

		WingStats.Add("EchoesoftheAncients:Comet_Wings", (-2, -2, 3.50f));
		WingStats.Add("EchoesoftheAncients:DuskbulbWings", (-2, -2, 4.00f));
		WingStats.Add("EchoesoftheAncients:Enkin_Wings", (-2, -2, 3.50f));
		WingStats.Add("EchoesoftheAncients:InfinityWing", (-2, -2, 3.50f));
		WingStats.Add("EchoesoftheAncients:Tungqua_Thruster", (-2, -2, 3.50f));
		WingStats.Add("EchoesoftheAncients:VoidDragWings", (-2, -2, 3.00f));

		#endregion

		#region ClickerClass

		WingStats.Add("ClickerClass:TheScroller", (-2, -2, 4.00f));

		#endregion

		#region SecretsOfTheShadows

		WingStats.Add("SOTS:TestWings", (-2, -2, 1.5f));
		WingStats.Add("SOTS:GelWings", (-2, -2, 1.30f));

		#endregion

		#region Orchid

		WingStats.Add("OrchidMod:AbyssalWings", (180, 9f, 3.00f));

		#endregion

		#region VitalityMod

		WingStats.Add("VitalityMod:MachineGunJetpack", (-2, -2, 1.50f));
		WingStats.Add("VitalityMod:AnarchyWings", (-2, -2, 1.50f));
		WingStats.Add("VitalityMod:ChaosWings", (-2, -2, 1.50f));
		WingStats.Add("VitalityMod:CrystalWings", (-2, -2, 1.50f));
		WingStats.Add("VitalityMod:ForbiddenWings", (-2, -2, 1.50f));
		WingStats.Add("VitalityMod:GhastlyWings", (-2, -2, 3.00f));
		WingStats.Add("VitalityMod:BellaRose", (-2, -2, 1.50f));

		#endregion

		#region Consolaria

		WingStats.Add("Consolaria:SparklyWings", (-2, -2, 3.00f));

		#endregion

		#region FargosSouls

		WingStats.Add("FargowiltasSouls:GelicWings", (100, 6.75f, 1.50f));
		WingStats.Add("FargowiltasSouls:DimensionSoul", (-2, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:EternitySoul", (-2, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:FlightMasterySoul", (-2, 18f, 3.00f));

		#endregion

		#region Gensokyo

		WingStats.Add("Gensokyo:BloomWings", (-2, -2, 1.50f));
		WingStats.Add("Gensokyo:BlossomWings", (-2, -2, 1.25f));
		WingStats.Add("Gensokyo:ColorfulWings", (-2, -2, 3.00f));
		WingStats.Add("Gensokyo:HellfireMantle", (-2, -2, 3.50f));
		WingStats.Add("Gensokyo:IcicleWings", (-2, -2, 1.50f));
		WingStats.Add("Gensokyo:SwallowtailWings", (-2, -2, 1.50f));
		WingStats.Add("Gensokyo:SwallowtailWingsUpgraded", (-2, -2, 1.25f));

		#endregion

		#region StormDiversMod

		WingStats.Add("StormDiversMod:HellSoulWings", (-2, -2, 1.50f));
		WingStats.Add("StormDiversMod:StormWings", (-2, -2, 1.66f));
		WingStats.Add("StormDiversMod:SpaceRockWings", (-2, -2, 2.20f));

		#endregion

		#region ModOfRedemption

		WingStats.Add("Redemption:XenomiteWings", (-2, -2, 1.70f));
		WingStats.Add("Redemption:NebWings", (-2, -2, 4.00f));

		#endregion

		#region ThoriumMod

		WingStats.Add("ThoriumMod:ShootingStarTurboTuba", (-2, -2, 2.50f));
		WingStats.Add("ThoriumMod:DemonBloodWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:PhonicWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:SubspaceWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:DragonWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:DreadWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:FleshWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:CelestialTrinity", (-2, -2, 2.50f));
		WingStats.Add("ThoriumMod:ChampionWing", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:TerrariumWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:WhiteDwarfThrusters", (-2, -2, 2.50f));
		WingStats.Add("ThoriumMod:TitanWings", (-2, -2, 1.50f));
		WingStats.Add("ThoriumMod:DridersGrace", (-2, -2, 1.50f));

		#endregion
	}

	#endregion
}