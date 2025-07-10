using System.Linq;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;

namespace HookStatsAndWingStats;

public static class HookStatsAndWingStatsHelpers
{
	// TODO: remove later, unneeded once changing to item type
	public static string GetModName(this Item item) {
		return item.ModItem?.Mod.Name ?? "Terraria";
	}

	public static string GetItemName(this Item item) {
		return item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
	}

	public static string GetKey(this Item item) {
		return $"{item.GetModName()}:{item.GetItemName()}";
	}

	public static bool HasCalamity {
		get => ModLoader.TryGetMod("CalamityMod", out _);
	}

	private static readonly string[] calamityFamilyMods = ["Terraria", "CalimityMod", "CalValEX", "CatalystMod"];

	public static bool IsCalamityFamily(this Item item) {
		string modName = item.GetModName();
		return calamityFamilyMods.Contains(modName);
	}

	public static Item EquippedHook(this Player player) {
		return player.miscEquips[4];
	}

	public static bool ShouldDisplayHookStats(this Item item) {
		string key = item.GetKey();

		bool displayingAnyStats = HookConfig.Instance.ShowStats && (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowRetractSpeed || HookConfig.Instance.ShowNumHooks || HookConfig.Instance.ShowLatchingType);
		bool itemHasHookStats = HookSystem.HookStats.ContainsKey(key);
		bool careAboutCalamity = HasCalamity || item.IsCalamityFamily();
		return displayingAnyStats && itemHasHookStats && careAboutCalamity;
	}

	public static bool ShouldDisplayWingStats(this Item item) {
		string key = item.GetKey();

		bool displayingAnyStats = WingConfig.Instance.ShowStats && (WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);
		bool itemHasWingStats = WingSystem.WingStats.ContainsKey(key);
		bool careAboutCalamity = HasCalamity || item.IsCalamityFamily();
		return displayingAnyStats && itemHasWingStats && careAboutCalamity;
	}
}
