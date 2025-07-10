using System.Collections.Generic;
using HookStats = HookStatsAndWingStats.DataStructures.HookStats;

namespace HookStatsAndWingStats.Common.Systems;

public class HookSystem : ModSystem
{
	public static Dictionary<int, HookStats> ItemTypeToHookStats { get; private set; } = new();

	public override void PostSetupContent() {
		Init_VanillaHooks();
		Init_ModdedHooks();
	}

	public override void Unload() {
		ItemTypeToHookStats = null;
	}

	private static void Init_VanillaHooks() {
		ItemTypeToHookStats.Add(ItemID.GrapplingHook, new HookStats(18.75f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.AmethystHook, new HookStats(18.75f * 16f, 10f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.SquirrelHook, new HookStats(19 * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.TopazHook, new HookStats(20.625f * 16f, 10.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.SapphireHook, new HookStats(22.5f * 16f, 11f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.EmeraldHook, new HookStats(24.375f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.RubyHook, new HookStats(26.25f * 16f, 12f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.AmberHook, new HookStats(27.5f * 16f, 12.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.DiamondHook, new HookStats(29.125f * 16f, 12.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.WebSlinger, new HookStats(22.625f * 16f, 10f, 8, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.SkeletronHand, new HookStats(21.875f * 16f, 15f, 2, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.SlimeHook, new HookStats(18.75f * 16f, 13f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.FishHook, new HookStats(25f * 16f, 13f, 2, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.IvyWhip, new HookStats(28f * 16f, 13f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.BatHook, new HookStats(31.25f * 16f, 13.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.CandyCaneHook, new HookStats(25f * 16f, 11.5f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.DualHook, new HookStats(27.5f * 16f, 14f, 2, Core.Enums.HookLatchingType.Individual));
		ItemTypeToHookStats.Add(ItemID.QueenSlimeHook, new HookStats(30f * 16f, 16f, 1, Core.Enums.HookLatchingType.Single));
		ItemTypeToHookStats.Add(ItemID.ThornHook, new HookStats(30f * 16f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.IlluminantHook, new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.WormHook, new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.TendonHook, new HookStats(30f * 16f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.AntiGravityHook, new HookStats(31.25f * 16f, 14f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.SpookyHook, new HookStats(34.375f * 16f, 15.5f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.ChristmasHook, new HookStats(34.375f * 16f, 15.5f, 3, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.LunarHook, new HookStats(34.375f * 16f, 18f, 4, Core.Enums.HookLatchingType.Simultaneous));
		ItemTypeToHookStats.Add(ItemID.StaticHook, new HookStats(37.5f * 16f, 16f, 2, Core.Enums.HookLatchingType.Individual));
	}

	private static void Init_ModdedHooks() {
		TryAddModdedHook("SOTS", "WormWoodHook", new HookStats(80f, 15f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("SOTS", "InfernoHook", new HookStats(510, 26f, 1, Core.Enums.HookLatchingType.Single));

		TryAddModdedHook("OrchidMod", "MineshaftHook", new HookStats(400f, 12f, 2, Core.Enums.HookLatchingType.Single));

		TryAddModdedHook("Gensokyo", "TsuchigomoWebSlinger", new HookStats(300f, 10f, 8, Core.Enums.HookLatchingType.Simultaneous));

		TryAddModdedHook("StormDiversMod", "EyeHook", new HookStats(528f, 12f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("StormDiversMod", "StormHook", new HookStats(512f, 18f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("StormDiversMod", "DerpHook", new HookStats(496f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));

		TryAddModdedHook("Redemption", "RopeHook", new HookStats(500f, 16f, 1, Core.Enums.HookLatchingType.Single));

		TryAddModdedHook("ThoriumMod", "SpringHook", new HookStats(17f * 16f, 12f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("ThoriumMod", "OpalHook", new HookStats(340f, 10.75f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("ThoriumMod", "AquamarineHook", new HookStats(350f, 10.75f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("ThoriumMod", "Leviathan", new HookStats(430f, 14f, 10, Core.Enums.HookLatchingType.Simultaneous));
		TryAddModdedHook("ThoriumMod", "JewellersWallGrip", new HookStats(450f, 13f, 2, Core.Enums.HookLatchingType.Simultaneous));
		TryAddModdedHook("ThoriumMod", "AmmutsebaSash", new HookStats(480f, 15f, 1, Core.Enums.HookLatchingType.Single));
		TryAddModdedHook("ThoriumMod", "FungalHook", new HookStats(480f, 16f, 3, Core.Enums.HookLatchingType.Simultaneous));
		TryAddModdedHook("ThoriumMod", "NeptuneGrasp", new HookStats(480f, 15f, 4, Core.Enums.HookLatchingType.Simultaneous));
		TryAddModdedHook("ThoriumMod", "DevilsReach", new HookStats(520f, 15f, 3, Core.Enums.HookLatchingType.Simultaneous));
		TryAddModdedHook("ThoriumMod", "GhostlyGrapple", new HookStats(550f, 16f, 2, Core.Enums.HookLatchingType.Simultaneous));
	}

	private static void TryAddModdedHook(string modName, string itemName, HookStats stats) {
		if (ModContent.TryFind($"{modName}/{itemName}", out ModItem item)) {
			ItemTypeToHookStats.Add(item.Type, stats);
		}
	}

	public static void AddModdedHook(int itemType, float hookReach, float hookShootSpeed, int numHooks, int latchingType) {
		ItemTypeToHookStats.Add(itemType, new HookStats(hookReach, hookShootSpeed, numHooks, (Core.Enums.HookLatchingType)latchingType));	
	}
}
