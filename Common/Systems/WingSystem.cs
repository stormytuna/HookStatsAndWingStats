using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
	/// <summary>
	/// -1 for maxFlightTime or horizontalSpeed means to use the corresponding value from ArmorID.Sets.Wing.Stats
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
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CreativeWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AngelWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DemonWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeafWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FairyWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FinWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FrozenWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.HarpyWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Jetpack)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RedsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DTownsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WillsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CrownosWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CenxsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BejeweledValkyrieWing)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Yoraiz0rWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.JimsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkiphsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LokisWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ArkhalisWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LeinforsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostarsWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SafemanWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FoodBarbarianWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GroxTheGreatWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeeWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ButterflyWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FlameWings)}", (-1, -1, 1.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.Hoverboard)}", (-1, -1, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BoneWings)}", (-1, -1, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.MothronWings)}", (-1, -1, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GhostWings)}", (-1, -1, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BeetleWings)}", (-1, -1, 1.66f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FestiveWings)}", (-1, -1, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyWings)}", (-1, -1, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TatteredFairyWings)}", (-1, -1, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SteampunkWings)}", (-1, -1, 1.80f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BetsyWings)}", (-1, -1, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishronWings)}", (-1, -1, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishronWings)}", (-1, -1, 2.50f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RainbowWings)}", (-1, -1, 2.75f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsNebula)}", (-1, -1, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsVortex)}", (-1, -1, 2.45f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsSolar)}", (-1, -1, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WingsStardust)}", (-1, -1, 3.00f));
		WingStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LongRainbowTrailWings)}", (-1, -1, 4.50f));
	}

	#endregion

	#region Modded

	private void Init_ModdedWings() {
		#region tModLoader

		WingStats.Add("ModLoader:AetherBreaker_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:Sailing_Squid_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:Coolmike5000_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:dinidini_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:dschosen_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:POCKETS_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:Saethar_Wings", (-1, -1, 1.50f));
		WingStats.Add("ModLoader:Zeph_Wings", (-1, -1, 1.50f));

		#endregion

		#region EchoesOfTheAncients

		WingStats.Add("EchoesoftheAncients:Comet_Wings", (-1, -1, 3.50f));
		WingStats.Add("EchoesoftheAncients:DuskbulbWings", (-1, -1, 4.00f));
		WingStats.Add("EchoesoftheAncients:Enkin_Wings", (-1, -1, 3.50f));
		WingStats.Add("EchoesoftheAncients:InfinityWing", (-1, -1, 3.50f));
		WingStats.Add("EchoesoftheAncients:Tungqua_Thruster", (-1, -1, 3.50f));
		WingStats.Add("EchoesoftheAncients:VoidDragWings", (-1, -1, 3.00f));

		#endregion

		#region ClickerClass

		WingStats.Add("ClickerClass:TheScroller", (-1, -1, 4.00f));

		#endregion

		#region SecretsOfTheShadows

		WingStats.Add("SOTS:TestWings", (-1, -1, 1.5f));
		WingStats.Add("SOTS:GelWings", (-1, -1, 1.30f));

		#endregion

		#region Orchid

		WingStats.Add("OrchidMod:AbyssalWings", (180, 9f, 3.00f));

		#endregion

		#region VitalityMod

		WingStats.Add("VitalityMod:MachineGunJetpack", (-1, -1, 1.50f));
		WingStats.Add("VitalityMod:AnarchyWings", (-1, -1, 1.50f));
		WingStats.Add("VitalityMod:ChaosWings", (-1, -1, 1.50f));
		WingStats.Add("VitalityMod:CrystalWings", (-1, -1, 1.50f));
		WingStats.Add("VitalityMod:ForbiddenWings", (-1, -1, 1.50f));
		WingStats.Add("VitalityMod:GhastlyWings", (-1, -1, 3.00f));
		WingStats.Add("VitalityMod:BellaRose", (-1, -1, 1.50f));

		#endregion

		#region Consolaria

		WingStats.Add("Consolaria:SparklyWings", (-1, -1, 3.00f));

		#endregion

		#region FargosSouls

		WingStats.Add("FargowiltasSouls:GelicWings", (100, 6.75f, 1.50f));
		WingStats.Add("FargowiltasSouls:DimensionSoul", (-1, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:EternitySoul", (-1, 25f, 3.00f));
		WingStats.Add("FargowiltasSouls:FlightMasterySoul", (-1, 18f, 3.00f));

		#endregion

		#region Gensokyo

		WingStats.Add("Gensokyo:BloomWings", (-1, -1, 1.50f));
		WingStats.Add("Gensokyo:BlossomWings", (-1, -1, 1.25f));
		WingStats.Add("Gensokyo:ColorfulWings", (-1, -1, 3.00f));
		WingStats.Add("Gensokyo:HellfireMantle", (-1, -1, 3.50f));
		WingStats.Add("Gensokyo:IcicleWings", (-1, -1, 1.50f));
		WingStats.Add("Gensokyo:SwallowtailWings", (-1, -1, 1.50f));
		WingStats.Add("Gensokyo:SwallowtailWingsUpgraded", (-1, -1, 1.25f));

		#endregion

		#region StormDiversMod

		WingStats.Add("StormDiversMod:HellSoulWings", (-1, -1, 1.50f));
		WingStats.Add("StormDiversMod:StormWings", (-1, -1, 1.66f));
		WingStats.Add("StormDiversMod:SpaceRockWings", (-1, -1, 2.20f));

		#endregion

		#region ModOfRedemption

		WingStats.Add("Redemption:XenomiteWings", (-1, -1, 1.70f));
		WingStats.Add("Redemption:NebWings", (-1, -1, 4.00f));

		#endregion

		#region ThoriumMod

		WingStats.Add("ThoriumMod:ShootingStarTurboTuba", (-1, -1, 2.50f));
		WingStats.Add("ThoriumMod:DemonBloodWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:PhonicWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:SubspaceWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:DragonWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:DreadWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:FleshWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:CelestialTrinity", (-1, -1, 2.50f));
		WingStats.Add("ThoriumMod:ChampionWing", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:TerrariumWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:WhiteDwarfThrusters", (-1, -1, 2.50f));
		WingStats.Add("ThoriumMod:TitanWings", (-1, -1, 1.50f));
		WingStats.Add("ThoriumMod:DridersGrace", (-1, -1, 1.50f));

		#endregion
	}

	#endregion
}