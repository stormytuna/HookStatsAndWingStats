using System;
using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems;

public class HookGlobalItem : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.HookIsRegisteredInDicts();

	private TooltipLine HookTitle() {
		string tooltipName = "HookTitle";
		string tooltipText = Helpers.ColorText(("\n~ HOOK STATS ~", HookConfig.Instance.TitleColor));
		if (HookConfig.Instance.DockStats) {
			tooltipText = Helpers.ColorText(("~ HOOK STATS ~", HookConfig.Instance.TitleColor));
		}
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine HookReach(float reach) {
		string tooltipName = "HookReach";
		string tooltipText = Helpers.ColorText(("Reach: ", MiscConfig.Instance.StatSubtitleColor), ($"{reach / 16f} tiles", MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine HookVelocity(float velocity) {
		string tooltipName = "HookVelocity";
		string tooltipText = Helpers.ColorText(("Velocity: ", MiscConfig.Instance.StatSubtitleColor), ($"{velocity}", MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}


	private TooltipLine HookCount(int hookCount) {
		string tooltipName = "HookCount";
		string tooltipText = Helpers.ColorText(("Hooks: ", MiscConfig.Instance.StatSubtitleColor), ($"{hookCount}", MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine HookLatchingType(int latchingType) {
		string latchingString = latchingType switch {
			1 => "Single",
			2 => "Simultaneous",
			3 => "Individual",
			_ => "Special"
		};
		string tooltipName = "HookCount";
		string tooltipText = Helpers.ColorText(("Hooks: ", MiscConfig.Instance.StatSubtitleColor), ($"{latchingString}", MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine ComparisonHookTitle() {
		string tooltipName = "HookComparisonTitle";
		string tooltipText = Helpers.ColorText(("\n~ EQUIPPED ~", MiscConfig.Instance.ComparisonTitleColor));
		if (HookConfig.Instance.DockStats) {
			tooltipText = Helpers.ColorText(("~ EQUIPPED ~", MiscConfig.Instance.ComparisonTitleColor));
		}
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompareHookReach(float reach, Color valueColor) {
		string tooltipName = "HookComparisonReach";
		string tooltipText = Helpers.ColorText(("Reach: ", MiscConfig.Instance.StatSubtitleColor), ($"{reach / 16f} tiles", valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompareHookVelocity(float velocity, Color valueColor) {
		string tooltipName = "HookComparisonVelocity";
		string tooltipText = Helpers.ColorText(("Velocity: ", MiscConfig.Instance.StatSubtitleColor), ($"{velocity}", valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompareHookCount(int hookCount, Color valueColor) {
		string tooltipName = "HookComparisonCount";
		string tooltipText = Helpers.ColorText(("Hooks: ", MiscConfig.Instance.StatSubtitleColor), ($"{hookCount}", valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompareHookLatchingType(int latchingType, Color valueColor) {
		string latchingString = latchingType switch {
			1 => "Single",
			2 => "Simultaneous",
			3 => "Individual",
			_ => "Special"
		};
		string tooltipName = "HookComparisonCount";
		string tooltipText = Helpers.ColorText(("Hooks: ", MiscConfig.Instance.StatSubtitleColor), ($"{latchingString}", valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		// Some vars we use later
		var lines = new List<TooltipLine>();
		Player player = Main.LocalPlayer;
		
		// Return early if we shouldn't display hook stats
		if (!item.ShouldDisplayHookStats()) {
			return;
		}

		// Get our hook stats
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";
		(float tileReach, float shootSpeed, int numHooks, int latchingType) = HookSystem.HookStats[key];

		// Main block
		if (!HookConfig.Instance.DockStats) {
			lines.Add(HookTitle());
		}

		if (HookConfig.Instance.ShowReach) {
			lines.Add(HookReach(tileReach));
		}

		if (HookConfig.Instance.ShowVelocity) {
			lines.Add(HookVelocity(shootSpeed));
		}

		if (HookConfig.Instance.ShowCount) {
			lines.Add(HookCount(numHooks));
		}

		if (HookConfig.Instance.ShowLatchingType) {
			lines.Add(HookLatchingType(latchingType));
		}

		// Return early if we shouldn't display a comparison
		bool isEquipped = player.EquippedHook().type == item.type && Main.mouseX > Main.screenWidth / 3;
		if (!player.EquippedHook().HookIsRegisteredInDicts() || !HookConfig.Instance.CompareStats || isEquipped) {
			tooltips.AddRange(lines);
			return;
		}

		string compModName = player.EquippedHook().ModItem?.Mod.Name ?? "Terraria";
		string compItemName = player.EquippedHook().ModItem?.Name ?? ItemID.Search.GetName(player.EquippedHook().type);
		string compKey = $"{compModName}:{compItemName}";
		(float compTileReach, float compShootSpeed, int compNumHooks, int compLatchingType) = HookSystem.HookStats[compKey];

		// Comparison block
		lines.Add(ComparisonHookTitle());

		if (HookConfig.Instance.ShowReach) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparionsValueColors) {
				valueColor = tileReach >= compTileReach
					? tileReach == compTileReach 
						? MiscConfig.Instance.ComparisonEqualColor 
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}
			lines.Add(CompareHookReach(compTileReach, valueColor));
		}

		if (HookConfig.Instance.ShowVelocity) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparionsValueColors) {
				valueColor = shootSpeed >= compShootSpeed
					? shootSpeed == compShootSpeed
						? MiscConfig.Instance.ComparisonEqualColor
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}

			lines.Add(CompareHookVelocity(compShootSpeed, valueColor));
		}

		if (HookConfig.Instance.ShowCount) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparionsValueColors) {
				valueColor = numHooks >= compNumHooks
					? numHooks == compNumHooks
						? MiscConfig.Instance.ComparisonEqualColor
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}

			lines.Add(CompareHookCount(compNumHooks, valueColor));
		}

		if (HookConfig.Instance.ShowLatchingType) {
			lines.Add(CompareHookLatchingType(compNumHooks, MiscConfig.Instance.StatValueColor));
		}

		tooltips.AddRange(lines);
	}
}