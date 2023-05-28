using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using HookStatsAndWingStats.Helpers;
using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems;

public class WingGlobalItem : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.ShouldDisplayWingStats();

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		Player player = Main.LocalPlayer;
		WingStats wingStats = WingSystem.WingStats[item.GetKey()];
		Item equippedWings = player.EquippedWings();

		if (equippedWings?.ShouldDisplayWingStats() == true && equippedWings.type != item.type && HookConfig.Instance.CompareStats) {
			WingStats otherWingStats = WingSystem.WingStats[equippedWings.GetKey()];
			tooltips.AddRange(wingStats.BuildComparisonTooltips(otherWingStats));
			return;
		}

		tooltips.AddRange(wingStats.BuildSoloTooltips());
	}

	public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset) {
		if (line.Name == "Invisible") {
			return false;
		}

		return base.PreDrawTooltipLine(item, line, ref yOffset);
	}
}