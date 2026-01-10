using System.Collections.Generic;
using System.Linq;
using HookStats = HookStatsAndWingStats.DataStructures.HookStats;

namespace HookStatsAndWingStats.Common.Systems;

public class HookSystem : ModSystem
{
	public static Dictionary<int, HookStats> ItemTypeToHookStats { get; private set; } = new();

	public override void PostSetupContent() {
		InitializeDefaultValues();
		InitializeKnownModdedValues();
	}

	public override void Unload() {
		ItemTypeToHookStats = null;
	}

	private static void InitializeDefaultValues() {
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

		foreach ((_, Item item) in ContentSamples.ItemsByType.Skip(ItemID.Count)) {
			if (ContentSamples.ProjectilesByType[item.shoot].aiStyle == ProjAIStyleID.Hook) {
				TryAddModdedHook(item);
			}
		}
	}

	private static void InitializeKnownModdedValues() {
		TryUpdateModdedHookCountAndLatchingType("SOTS", "WormWoodHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("SOTS", "InfernoHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("SOTS", "HardlightHook", 1, Core.Enums.HookLatchingType.Single);

		TryUpdateModdedHookCountAndLatchingType("OrchidMineshaft", "MineshaftHook", 2, Core.Enums.HookLatchingType.Single);

		TryUpdateModdedHookCountAndLatchingType("Gensokyo", "TsuchigomoWebSlinger", 8, Core.Enums.HookLatchingType.Simultaneous);

		TryUpdateModdedHookCountAndLatchingType("StormDiversMod", "EyeHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("StormDiversMod", "StormHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("StormDiversMod", "DerpHook", 3, Core.Enums.HookLatchingType.Simultaneous);

		TryUpdateModdedHookCountAndLatchingType("Redemption", "RopeHook", 1, Core.Enums.HookLatchingType.Single);

		TryAddModdedHook("ThoriumMod", "SpringHook", 17f * 16f, 12f, 1, Core.Enums.HookLatchingType.Special);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "OpalHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "AquamarineHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "Leviathan", 10, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "JewellersWallGrip", 2, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "AmmutsebaSash", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "FungalHook", 3, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "NeptuneGrasp", 4, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "DevilsReach", 3, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "GhostlyGrapple", 2, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("ThoriumMod", "ZephyrsGrip", 1, Core.Enums.HookLatchingType.Single);

		TryUpdateModdedHookCountAndLatchingType("Remnants", "LuminousHook", 1, Core.Enums.HookLatchingType.Single);

		TryUpdateModdedHookCountAndLatchingType("SpiritMod", "AvianHook", 3, Core.Enums.HookLatchingType.Simultaneous);
		TryUpdateModdedHookCountAndLatchingType("SpiritMod", "KelpHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("SpiritMod", "MagnetHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("SpiritMod", "ThornHook", 1, Core.Enums.HookLatchingType.Single);
		TryUpdateModdedHookCountAndLatchingType("SpiritMod", "CoilHook", 2, Core.Enums.HookLatchingType.Simultaneous);

		TryUpdateModdedHookCountAndLatchingType("StarlightRiver", "TentacleHook", 1, Core.Enums.HookLatchingType.Single);
	}

	private static void TryAddModdedHook(Item item) {
		if (!ItemTypeToHookStats.ContainsKey(item.type)) {
			int projType = item.shoot;
			ModProjectile proj = ContentSamples.ProjectilesByType[projType].ModProjectile;
			float hookReach = proj.GrappleRange();
			float hookShootSpeed = item.shootSpeed;
			ItemTypeToHookStats[item.type] = new HookStats(hookReach, hookShootSpeed);
		}
	}

	private static void TryAddModdedHook(string modName, string itemName, float hookReach, float hookShootSpeed, int numHooks, Core.Enums.HookLatchingType latchingType) {
		if (ModContent.TryFind(modName, itemName, out ModItem modItem)) {
			ItemTypeToHookStats[modItem.Type] = new HookStats(hookReach, hookShootSpeed, numHooks, latchingType);
		}
	}

	private static void TryUpdateModdedHookCountAndLatchingType(string modName, string itemName, int numHooks, Core.Enums.HookLatchingType latchingType) {
		if (ModContent.TryFind(modName, itemName, out ModItem modItem)) {
			if (ItemTypeToHookStats.ContainsKey(modItem.Type)) {
				HookStats stats = ItemTypeToHookStats[modItem.Type];
				stats.NumHooks = numHooks;
				stats.LatchingType = latchingType;
				ItemTypeToHookStats[modItem.Type] = stats;
			} else {
				HookStatsAndWingStats.Instance.Logger.Info("Modded hook not found. Mod: " + modName + ", item: " + itemName);
			}
		}
	}

	public static void AddModdedHook(int itemType, float hookReach, float hookShootSpeed, int numHooks, int latchingType) {
		ItemTypeToHookStats[itemType] = new HookStats(hookReach, hookShootSpeed, numHooks, (Core.Enums.HookLatchingType)latchingType);
	}
}
