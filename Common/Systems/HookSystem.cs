using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using HookStats = HookStatsAndWingStats.DataStructures.HookStats;

namespace HookStatsAndWingStats.Common.Systems;

public class HookSystem : ModSystem
{
	public static Dictionary<string, HookStats> HookStats { get; private set; } = new();

	public override void PostSetupContent() {
		Init_VanillaHooks();
		Init_ModdedHooks();
	}

	public override void Unload() {
		HookStats = null;
	}

	// TODO: convert to item ids
	private void Init_VanillaHooks() {
		// Pre HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GrapplingHook)}", new HookStats(18.75f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmethystHook)}", new HookStats(18.75f * 16f, 10f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SquirrelHook)}", new HookStats(19 * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TopazHook)}", new HookStats(20.625f * 16f, 10.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SapphireHook)}", new HookStats(22.5f * 16f, 11f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.EmeraldHook)}", new HookStats(24.375f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RubyHook)}", new HookStats(26.25f * 16f, 12f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmberHook)}", new HookStats(27.5f * 16f, 12.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DiamondHook)}", new HookStats(29.125f * 16f, 12.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WebSlinger)}", new HookStats(22.625f * 16f, 10f, 8, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkeletronHand)}", new HookStats(21.875f * 16f, 15f, 2, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SlimeHook)}", new HookStats(18.75f * 16f, 13f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishHook)}", new HookStats(25f * 16f, 13f, 2, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IvyWhip)}", new HookStats(28f * 16f, 13f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatHook)}", new HookStats(31.25f * 16f, 13.5f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CandyCaneHook)}", new HookStats(25f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));

		// HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DualHook)}", new HookStats(27.5f * 16f, 14f, 2, Core.Enums.HookLatchingType.Individual));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.QueenSlimeHook)}", new HookStats(30f * 16f, 16f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ThornHook)}", new HookStats(30f * 16f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IlluminantHook)}", new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WormHook)}", new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TendonHook)}", new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AntiGravityHook)}", new HookStats(31.25f * 16f, 14f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyHook)}", new HookStats(34.375f * 16f, 15.5f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ChristmasHook)}", new HookStats(34.375f * 16f, 15.5f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LunarHook)}", new HookStats(34.375f * 16f, 18f, 4, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.StaticHook)}", new HookStats(37.5f * 16f, 16f, 2, Core.Enums.HookLatchingType.Individual));
	}

	private void Init_ModdedHooks() {
		HookStats.Add("SOTS:WormWoodHook", new HookStats(80f, 15f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("SOTS:InfernoHook", new HookStats(510, 26f, 1, Core.Enums.HookLatchingType.Single));

		HookStats.Add("OrchidMod:MineshaftHook", new HookStats(400f, 12f, 2, Core.Enums.HookLatchingType.Single));

		HookStats.Add("Gensokyo:TsuchigomoWebSlinger", new HookStats(300f, 10f, 8, Core.Enums.HookLatchingType.Simultaneous));

		HookStats.Add("StormDiversMod:EyeHook", new HookStats(528f, 12f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("StormDiversMod:StormHook", new HookStats(512f, 18f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("StormDiversMod:DerpHook", new HookStats(496f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));

		HookStats.Add("Redemption:RopeHook", new HookStats(500f, 16f, 1, Core.Enums.HookLatchingType.Single));

		HookStats.Add("ThoriumMod:SpringHook", new HookStats(17f * 16f, 12f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:OpalHook", new HookStats(340f, 10.75f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:AquamarineHook", new HookStats(350f, 10.75f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:Leviathan", new HookStats(430f, 14f, 10, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:JewellersWallGrip", new HookStats(450f, 13f, 2, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:AmmutsebaSash", new HookStats(480f, 15f, 1, Core.Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:FungalHook", new HookStats(480f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:NeptuneGrasp", new HookStats(480f, 15f, 4, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:DevilsReach", new HookStats(520f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:GhostlyGrapple", new HookStats(550f, 16f, 2, Core.Enums.HookLatchingType.Simultaneous));
	}
}
