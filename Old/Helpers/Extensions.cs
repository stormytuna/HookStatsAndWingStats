using System.Collections.Generic;
using System.Linq;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Helpers;

public static class Extensions
{
	public static string GetModName(this Item item) => item.ModItem?.Mod.Name ?? "Terraria";

	public static string GetItemName(this Item item) => item.ModItem?.Name ?? ItemID.Search.GetName(item.type);

	public static string GetKey(this Item item) => $"{item.GetModName()}:{item.GetItemName()}";

	private static readonly string[] calamityFamilyMods = { "Terraria", "CalimityMod", "CalValEX", "CatalystMod" };

	public static bool IsCalamityFamily(this Item item) {
		string modName = item.GetModName();
		return calamityFamilyMods.Contains(modName);
	}

	public static Item EquippedHook(this Player player) => player.miscEquips[4];

	public static bool ShouldDisplayHookStats(this Item item) {
		string key = item.GetKey();

		bool displayingAnyStats = HookConfig.Instance.ShowStats && (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowRetractSpeed || HookConfig.Instance.ShowNumHooks || HookConfig.Instance.ShowLatchingType);
		bool itemHasHookStats = HookSystem.HookStats.ContainsKey(key);
		bool careAboutCalamity = !Helpers.HasCalamity || item.IsCalamityFamily();
		return displayingAnyStats && itemHasHookStats && careAboutCalamity;
	}

	public static Item EquippedWings(this Player player) {
		for (int i = 3; i < 8 + player.GetAmountOfExtraAccessorySlotsToShow(); i++) {
			Item accessory = player.armor[i];
			if (accessory.wingSlot >= 0) {
				return accessory;
			}
		}

		return null;
	}

	/*
	public static bool ShouldDisplayWingStats(this Item item) {
		string key = item.GetKey();

		bool displayingAnyStats = WingConfig.Instance.ShowStats && (WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);
		bool itemHasWingStats = WingSystem.WingStats.ContainsKey(key);
		bool careAboutCalamity = !Helpers.HasCalamity || item.IsCalamityFamily();
		return displayingAnyStats && itemHasWingStats && careAboutCalamity;
	}

	public static void TryAddModdedWing(this Dictionary<string, WingStats> dict, string modName, string itemName, float verticalSpeedMult) {
		if (ModLoader.TryGetMod(modName, out Mod mod) && mod.TryFind(itemName, out ModItem modItem)) {
			dict[$"{modName}:{itemName}"] = new WingStats(modItem.Type, verticalSpeedMult);
		}
	}
	*/
}
