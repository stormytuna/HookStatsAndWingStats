using System;
using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Common.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.GlobalItems;

public class WingGlobalItem : GlobalItem
{
	private bool ShouldDisplayWingStats()
		=> WingConfig.Instance.ShowStats &&
		   (WingConfig.Instance.ShowMaxWingTime || WingConfig.Instance.ShowCurWingTime || WingConfig.Instance.ShowHorizontalSpeed || WingConfig.Instance.ShowVerticalMult);

	private TooltipLine WingTitle() {
		string tooltipName = "WingTitle";
		string tooltipText = $"\n{Helpers.ColorText(("~ WING STATS ~", WingConfig.Instance.TitleColor))}";
		if (WingConfig.Instance.DockStats) {
			tooltipText = Helpers.ColorText(("~ WING STATS ~", WingConfig.Instance.TitleColor));
		}

		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private List<TooltipLine> WingFlightTimeCombined(int currentWingTime, int maxWingTime) {
		string formattedCurrentWingTime = WingConfig.Instance.FlightTimeInSeconds ? $"{currentWingTime / 60f:0.00}s" : $"{currentWingTime}";
		string formattedMaxWingTime = WingConfig.Instance.FlightTimeInSeconds ? $"{maxWingTime / 60f:0.00}s" : $"{maxWingTime}";

		if (Main.LocalPlayer.empressBrooch || maxWingTime == -1) {
			formattedCurrentWingTime = "∞";
			formattedMaxWingTime = "∞";
		}

		if (WingConfig.Instance.CombineWingTimes) {
			string tooltipName = "WingFlightTimeCombined";
			string tooltipText = Helpers.ColorText(("Flight time: ", MiscConfig.Instance.StatSubtitleColor), ($"{formattedCurrentWingTime} / {formattedMaxWingTime}",
				MiscConfig.Instance.StatValueColor));
			return new List<TooltipLine> {
				new(Mod, tooltipName, tooltipText)
			};
		}

		string firstTooltipText = Helpers.ColorText(("Current flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedCurrentWingTime, MiscConfig.Instance.StatValueColor));
		string firstTooltipName = "WingFlightTimeCurrent";
		string secondTooltipText = Helpers.ColorText(("Max flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedMaxWingTime, MiscConfig.Instance.StatValueColor));
		string secondTooltipName = "WingFlightTimeMax";
		return new List<TooltipLine> {
			new(Mod, firstTooltipName, firstTooltipText),
			new(Mod, secondTooltipName, secondTooltipText)
		};
	}

	private TooltipLine WingFlightTimeMax(int maxWingTime) {
		string formattedMaxWingTime = WingConfig.Instance.FlightTimeInSeconds ? $"{maxWingTime / 60f:0.00}s" : $"{maxWingTime}";

		if (Main.LocalPlayer.empressBrooch || maxWingTime == -1) {
			formattedMaxWingTime = "∞";
		}

		string tooltipName = "WingFlightTimeMax";
		string tooltipText = Helpers.ColorText(("Max flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedMaxWingTime, MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine WingHorizontalSpeed(float horizontalSpeed) {
		string formattedHorizontalSpeed = WingConfig.Instance.HorizontalSpeedInMPH ? $"{horizontalSpeed * 5.084949379f:0.}mph" : $"{horizontalSpeed}";

		string tooltipName = "WingHorizontalSpeed";
		string tooltipText = Helpers.ColorText(("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor), (formattedHorizontalSpeed, MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine WingVerticalSpeedMultiplier(float verticalSpeedMultiplier) {
		string formattedVerticalSpeedMult = WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1 ? "unknown" : $"{verticalSpeedMultiplier:0.}";

		string tooltipName = "WingVerticalSpeedMult";
		string tooltipText = Helpers.ColorText(("Vertical speed mult: ", MiscConfig.Instance.StatSubtitleColor), (formattedVerticalSpeedMult, MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingTitle() {
		string tooltipName = "CompWingTitle";
		string tooltipText = $"\n{Helpers.ColorText(("~ EQUIPPED ~", MiscConfig.Instance.ComparisonTitleColor))}";
		if (WingConfig.Instance.DockStats) {
			tooltipText = Helpers.ColorText(("~ EQUIPPED ~", MiscConfig.Instance.ComparisonTitleColor));
		}

		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingFlightTimeMax(int maxWingTime, Color valueColor) {
		string formattedMaxWingTime = WingConfig.Instance.FlightTimeInSeconds ? $"{maxWingTime / 60f:0.00}s" : $"{maxWingTime}";
		if (maxWingTime == -1) {
			formattedMaxWingTime = "∞";
		}

		string tooltipName = "CompWingFlightTimeMax";
		string tooltipText = Helpers.ColorText(("Max flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedMaxWingTime, valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingHorizontalSpeed(float horizontalSpeed, Color valueColor) {
		string formattedHorizontalSpeed = WingConfig.Instance.HorizontalSpeedInMPH ? $"{horizontalSpeed * 5.084949379f:0.}mph" : $"{horizontalSpeed}";

		string tooltipName = "CompWingHorizontalSpeed";
		string tooltipText = Helpers.ColorText(("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor), (formattedHorizontalSpeed, valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingVerticalSpeedMultiplier(float verticalSpeedMultiplier, Color valueColor) {
		string formattedVerticalSpeedMult = WingConfig.Instance.ShowUnknownVerticalMults && verticalSpeedMultiplier == -1 ? "unknown" : $"{verticalSpeedMultiplier:0.}";

		string tooltipName = "CompWingVerticalSpeedMult";
		string tooltipText = Helpers.ColorText(("Vertical speed mult: ", MiscConfig.Instance.StatSubtitleColor), (formattedVerticalSpeedMult, valueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		var lines = new List<TooltipLine>();
		Player player = Main.LocalPlayer;

		if (!item.ShouldDisplayWingStats()) {
			return;
		}

		// Get our wing stats
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";
		(int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) = WingSystem.WingStats[key];

		// -2 means to use the WingStats vanilla uses
		WingStats wingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
		if (maxFlightTime == -2) {
			maxFlightTime = wingStats.FlyTime;
		}

		if (horizontalSpeed == -2) {
			horizontalSpeed = wingStats.AccRunSpeedOverride;
		}

		// Check if this item is equipped
		bool isEquipped = false;
		for (int i = 0; i < player.armor.Length; i++) {
			if (player.armor[i].type == item.type && Main.mouseX > Main.screenWidth / 2) {
				isEquipped = true;
			}
		}

		if (!WingConfig.Instance.DockStats) {
			lines.Add(WingTitle());
		}

		if (WingConfig.Instance.ShowCurWingTime && WingConfig.Instance.ShowMaxWingTime && isEquipped) {
			lines.AddRange(WingFlightTimeCombined(Convert.ToInt32(player.wingTime), maxFlightTime));
		} else if (WingConfig.Instance.ShowMaxWingTime) {
			lines.Add(WingFlightTimeMax(maxFlightTime));
		}

		if (WingConfig.Instance.ShowHorizontalSpeed) {
			lines.Add(WingHorizontalSpeed(horizontalSpeed));
		}

		if ((WingConfig.Instance.ShowVerticalMult && verticalSpeedMultiplier != -1) || WingConfig.Instance.ShowUnknownVerticalMults) {
			lines.Add(WingVerticalSpeedMultiplier(verticalSpeedMultiplier));
		}

		if (!WingConfig.Instance.CompareStats || isEquipped) {
			tooltips.AddRange(lines);
			return;
		}

		Item compWings = null;

		// Check equipped armor
		for (int i = 3; i < 8 + player.GetAmountOfExtraAccessorySlotsToShow(); i++) {
			if (player.armor[i].wingSlot < 0) {
				continue;
			}

			// Skip this accessory if its the same as the selected wing
			if (player.armor[i].type == item.type) {
				continue;
			}

			compWings = player.armor[i];
			break;
		}

		if (compWings is null) {
			tooltips.AddRange(lines);
			return;
		}

		string compModName = compWings.ModItem?.Mod.Name ?? "Terraria";
		string compItemName = compWings.ModItem?.Name ?? ItemID.Search.GetName(compWings.type);
		string compKey = $"{compModName}:{compItemName}";
		(int compMaxFlightTime, float compHorizontalSpeed, float compVerticalSpeedMultiplier) = WingSystem.WingStats[compKey];

		WingStats compWingStats = ArmorIDs.Wing.Sets.Stats[compWings.wingSlot];
		if (compMaxFlightTime == -2) {
			compMaxFlightTime = compWingStats.FlyTime;
		}

		if (compHorizontalSpeed == -2) {
			compHorizontalSpeed = compWingStats.AccRunSpeedOverride;
		}

		lines.Add(CompWingTitle());

		if (WingConfig.Instance.ShowMaxWingTime) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparisonValueColor) {
				valueColor = maxFlightTime >= compMaxFlightTime
					? maxFlightTime == compMaxFlightTime
						? MiscConfig.Instance.ComparisonEqualColor
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}

			lines.Add(CompWingFlightTimeMax(compMaxFlightTime, valueColor));
		}

		if (WingConfig.Instance.ShowHorizontalSpeed) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparisonValueColor) {
				valueColor = horizontalSpeed >= compHorizontalSpeed
					? horizontalSpeed == compHorizontalSpeed
						? MiscConfig.Instance.ComparisonEqualColor
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}

			lines.Add(CompWingHorizontalSpeed(compHorizontalSpeed, valueColor));
		}

		if (WingConfig.Instance.ShowVerticalMult) {
			Color valueColor = MiscConfig.Instance.StatValueColor;
			if (MiscConfig.Instance.ComparisonValueColor) {
				valueColor = verticalSpeedMultiplier >= compVerticalSpeedMultiplier
					? verticalSpeedMultiplier == compVerticalSpeedMultiplier
						? MiscConfig.Instance.ComparisonEqualColor
						: MiscConfig.Instance.ComparisonWorseColor
					: MiscConfig.Instance.ComparisonBetterColor;
			}

			lines.Add(CompWingVerticalSpeedMultiplier(compVerticalSpeedMultiplier, valueColor));
		}

		tooltips.AddRange(lines);
	}
}