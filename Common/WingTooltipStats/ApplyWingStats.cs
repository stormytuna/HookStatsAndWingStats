using System.Collections.Generic;
using System.Linq;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.DataStructures;

namespace HookStatsAndWingStats.Common.WingTooltipStats;

public class ApplyWingStats : GlobalItem

{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
		return lateInstantiation && entity.ShouldDisplayWingStats();
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		Player player = Main.LocalPlayer;
		WingStats wingStats = WingSystem.ItemTypeToWingStats[item.type];
		List<TooltipStat> statList = GetTooltipStats(wingStats);
		Item equippedWings = player.equippedWings;

		List<TooltipStat> otherStatsList = new();
		if (equippedWings.ShouldDisplayWingStats() && equippedWings.type != item.type && WingConfig.Instance.CompareStats) {
			WingStats otherWingStats = WingSystem.ItemTypeToWingStats[equippedWings.type];
			otherStatsList = GetTooltipStats(otherWingStats);
		}

		for (int i = 0; i < statList.Count; i++) {
			TooltipStat stat = statList[i];
			if (!stat.IsEnabled) {
				continue;
			}

			string tooltip = $"{stat.GetFormattedSubtitle()} {stat.GetFormattedValueOrComparison(otherStatsList.ElementAtOrDefault(i))}";
			tooltips.Add(new TooltipLine(Mod, $"{stat.InternalName}", tooltip));
		}
	}

	private static List<TooltipStat> GetTooltipStats(WingStats stats) {
		return [
			new WingMaxFlightTime(stats.MaxFlightTime),
			new WingHorizontalSpeed(stats.HorizontalSpeed),
			new WingVerticalSpeedMultiplier(stats.VerticalSpeedMultiplier),
		];
	}
}
