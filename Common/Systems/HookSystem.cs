using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class HookSystem : ModSystem
{
	public static Dictionary<string, (float tileReach, float shootSpeed, int numHooks, int latchingType)> HookStats { get; private set; } = new();
	
	public override void Load() {
		Init_VanillaHooks();
		Init_ModdedHooks();
	}

	public override void Unload() {
		HookStats = null;
	}

	#region Vanilla

	private void Init_VanillaHooks() {
		// Pre HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GrapplingHook)}", (18.75f * 16f, 11.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmethystHook)}", (18.75f * 16f, 10f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SquirrelHook)}", (19 * 16f, 11.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TopazHook)}", (20.625f * 16f, 10.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SapphireHook)}", (22.5f * 16f, 11f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.EmeraldHook)}", (24.375f * 16f, 11.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RubyHook)}", (26.25f * 16f, 12f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmberHook)}", (27.5f * 16f, 12.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DiamondHook)}", (29.125f * 16f, 12.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WebSlinger)}", (22.625f * 16f, 10f, 8, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkeletronHand)}", (21.875f * 16f, 15f, 2, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SlimeHook)}", (18.75f * 16f, 13f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishHook)}", (25f * 16f, 13f, 2, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IvyWhip)}", (28f * 16f, 13f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatHook)}", (31.25f * 16f, 13.5f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CandyCaneHook)}", (25f * 16f, 11.5f, 1, 0));

		// HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DualHook)}", (27.5f * 16f, 14f, 2, 2));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.QueenSlimeHook)}", (30f * 16f, 16f, 1, 0));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ThornHook)}", (30f * 16f, 16f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IlluminantHook)}", (30f * 16f, 15f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WormHook)}", (30f * 16f, 15f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TendonHook)}", (30f * 16f, 15f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AntiGravityHook)}", (31.25f * 16f, 14f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyHook)}", (34.375f * 16f, 15.5f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ChristmasHook)}", (34.375f * 16f, 15.5f, 3, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LunarHook)}", (34.375f * 16f, 18f, 4, 1));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.StaticHook)}", (37.5f * 16f, 16f, 2, 2));
	}

	#endregion

	#region Modded

	private void Init_ModdedHooks() {
		#region SecretsOfTheShadows

		HookStats.Add("SOTS:WormWoodHook", (480f, 15f, 1, 0));
		HookStats.Add("SOTS:InfernoHook", (510, 26f, 1, 0));

		#endregion

		#region Orchid

		HookStats.Add("OrchidMod:MineshaftHook", (400f, 12f, 2, 0));

		#endregion

		#region Gensokyo

		HookStats.Add("Gensokyo:TsuchigomoWebSlinger", (300f, 10f, 8, 1));

		#endregion

		#region StormDiversMod

		HookStats.Add("StormDiversMod:EyeHook", (528f, 12f, 1, 0));
		HookStats.Add("StormDiversMod:StormHook", (512f, 18f, 1, 0));
		HookStats.Add("StormDiversMod:DerpHook", (496f, 16f, 3, 1));

		#endregion

		#region ModOfRedemption

		HookStats.Add("Redemption:RopeHook", (500f, 16f, 1, 0));

		#endregion

		#region ThoriumMod

		HookStats.Add("ThoriumMod:SpringHook", (17f * 16f, 12f, 1, 0));
		HookStats.Add("ThoriumMod:OpalHook", (340f, 10.75f, 1, 0));
		HookStats.Add("ThoriumMod:AquamarineHook", (350f, 10.75f, 1, 0));
		HookStats.Add("ThoriumMod:Leviathan", (430f, 14f, 10, 1));
		HookStats.Add("ThoriumMod:JewellersWallGrip", (450f, 13f, 2, 1));
		HookStats.Add("ThoriumMod:AmmutsebaSash", (480f, 15f, 1, 0));
		HookStats.Add("ThoriumMod:FungalHook", (480f, 16f, 3, 1));
		HookStats.Add("ThoriumMod:NeptuneGrasp", (480f, 15f, 4, 1));
		HookStats.Add("ThoriumMod:DevilsReach", (520f, 15f, 3, 1));
		HookStats.Add("ThoriumMod:GhostlyGrapple", (550f, 16f, 2, 1));

		#endregion
	}

	#endregion
}