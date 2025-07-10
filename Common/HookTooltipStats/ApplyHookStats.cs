using System.Collections.Generic;
using System.Linq;
using System.Text;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.DataStructures;
using Humanizer;
using MonoMod.RuntimeDetour;
using Terraria;
using Terraria.ModLoader;
using HookStats = HookStatsAndWingStats.DataStructures.HookStats;

namespace HookStatsAndWingStats.Common.HookTooltipStats;

public class ApplyHookStats : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
		return lateInstantiation && entity.ShouldDisplayHookStats();
	}
	
	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		var player = Main.LocalPlayer;
		HookStats stats = HookSystem.HookStats[item.GetKey()];
		List<TooltipStat> statList = GetTooltipStats(stats);
		Item equippedHook = player.EquippedHook();

		List<TooltipStat> otherStatsList = new();
		if (equippedHook.ShouldDisplayHookStats() && equippedHook.type != item.type && HookConfig.Instance.CompareStats) {
			var otherHookStats = HookSystem.HookStats[equippedHook.GetKey()];
			otherStatsList = GetTooltipStats(otherHookStats);
		}

		for (int i = 0; i < statList.Count; i++) {
			TooltipStat stat = statList[i];
			if (!stat.IsEnabled) {
				continue;
			}
			
			var tooltip = $"{stat.GetFormattedSubtitle()} {stat.GetFormattedValueOrComparison(otherStatsList.ElementAtOrDefault(i))}";
			tooltips.Add(new TooltipLine(Mod, $"{stat.InternalName}", tooltip));
		}
	}

	private List<TooltipStat> GetTooltipStats(HookStats stats) {
		return [
			new HookReach(stats.Reach),
			new HookShootSpeed(stats.ShootSpeed),
			new HookRetractSpeed(stats.RetractSpeed),
			new HookNumHooks(stats.NumHooks),
			new HookLatchingType(stats.LatchingType),
		];
	}
}
