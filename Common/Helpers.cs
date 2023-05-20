using System;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common;

public static class Helpers
{
	public static bool HasCalamity => ModLoader.TryGetMod("CalamityMod", out _);

	public static bool ItemIsCalamityFamily(string itemModName)
		=> itemModName != "Terraria" && itemModName != "CalamityMod" && itemModName != "CalValEX" && itemModName != "CatalystMod";

	public static string ColorText(params (string text, Color color)[] stringColorPairs) {
		string ret = "";

		for (int i = 0; i < stringColorPairs.Length; i++) {
			string text = stringColorPairs[i].text;
			Color color = stringColorPairs[i].color;
			ret += $"[c/{color.Hex3()}:{text}]";
		}

		return ret;
	}

	public static bool ShouldDisplayHookStats(this Item item) {
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";

		bool displayingAnyStats = HookConfig.Instance.ShowStats &&
		                          (HookConfig.Instance.ShowReach || HookConfig.Instance.ShowVelocity || HookConfig.Instance.ShowCount || HookConfig.Instance.ShowLatchingType);
		bool haveHookStats = HookSystem.HookStats.ContainsKey(key);
		bool careAboutCalamity = ItemIsCalamityFamily(modName) || !HasCalamity;
		return displayingAnyStats && haveHookStats && careAboutCalamity;
	}

	public static Item EquippedHook(this Player player) => player.miscEquips[4];

	public static bool HookIsRegisteredInDicts(this Item item) {
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";
		return HookSystem.HookStats.ContainsKey(key);
	}

	public static bool ShouldDisplayWingStats(this Item item) {
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";

		bool displayingAnyStats = WingConfig.Instance.ShowStats &&
		                          (WingConfig.Instance.ShowCurWingTime || WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);
		bool haveWingStats = WingSystem.WingStats.ContainsKey(key);
		bool careAboutCalamity = ItemIsCalamityFamily(modName) || !HasCalamity;
		return displayingAnyStats && haveWingStats && careAboutCalamity;
	}
}