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
		string tooltipText = Helpers.ColorText(("\n~ WING STATS ~", WingConfig.Instance.TitleColor));
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
			return new List<TooltipLine>() {
				new TooltipLine(Mod, tooltipName, tooltipText)
			};
		}

		string firstTooltipText = Helpers.ColorText(("Current flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedCurrentWingTime, MiscConfig.Instance.StatValueColor));
		string firstTooltipName = "WingFlightTimeCurrent";
		string secondTooltipText = Helpers.ColorText(("Max flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedMaxWingTime, MiscConfig.Instance.StatValueColor));
		string secondTooltipName = "WingFlightTimeMax";
		return new List<TooltipLine>() {
			new TooltipLine(Mod, firstTooltipName, firstTooltipText),
			new TooltipLine(Mod, secondTooltipName, secondTooltipText)
		};
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
		string tooltipText = Helpers.ColorText(("\n~ EQUIPPED ~", WingConfig.Instance.TitleColor));
		if (WingConfig.Instance.DockStats) {
			tooltipText = Helpers.ColorText(("~ EQUIPPED ~", WingConfig.Instance.TitleColor));
		}

		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingFlightTimeMax(int maxWingTime, Color valueColor) {
		string formattedMaxWingTime = WingConfig.Instance.FlightTimeInSeconds ? $"{maxWingTime / 60f:0.00}s" : $"{maxWingTime}";
		if (maxWingTime == -1) {
			formattedMaxWingTime = "∞";
		}

		string tooltipName = "CompWingFlightTimeMax";
		string tooltipText = Helpers.ColorText(("Max flight time: ", MiscConfig.Instance.StatSubtitleColor), (formattedMaxWingTime, MiscConfig.Instance.StatValueColor));
		return new TooltipLine(Mod, tooltipName, tooltipText);
	}

	private TooltipLine CompWingHorizontalSpeed(float horizontalSpeed, Color valueColor) {
		string formattedHorizontalSpeed = WingConfig.Instance.HorizontalSpeedInMPH ? $"{horizontalSpeed * 5.084949379f:0.}mph" : $"{horizontalSpeed}";

		string tooltipName = "CompWingHorizontalSpeed";
		string tooltipText = Helpers.ColorText(("Horizontal speed: ", MiscConfig.Instance.StatSubtitleColor), (formattedHorizontalSpeed, MiscConfig.Instance.StatValueColor));
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

		// modName and itemName, needed for modded items
		string modName = item.ModItem?.Mod.Name ?? "Terraria";
		string itemName = item.ModItem?.Name ?? ItemID.Search.GetName(item.type);
		string key = $"{modName}:{itemName}";
		(int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) = WingSystem.WingStats[key];

		// Can be done mostly through WingStats, vertical speed multiplier is hard coded so need a dict for that
		if (item.wingSlot > 0 && ShouldDisplayWingStats() && (Helpers.ItemIsCalamityFamily(modName) || !Helpers.HasCalamity)) {
			// Declaring stuff
			WingStats wingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
			bool isEquipped = false;

			// Check if this item is equipped
			for (int i = 0; i < player.armor.Length; i++) {
				if (player.armor[i].type == item.type && Main.mouseX > Main.screenWidth / 2) {
					isEquipped = true;
				}
			}

			// Build our Tuple
			Tuple<int, float, int> value = new(0, 0, -1);
			// Check if we have a modded wingstats override
			if (WingSystem.ModdedWingStatsOverride.ContainsKey(key)) {
				value = WingSystem.ModdedWingStatsOverride[key];
			}
			// Check if our item is modded...
			else if (modName != "Terraria") {
				if (WingSystem.ModdedWingVerticalMults.ContainsKey(key)) {
					value = new Tuple<int, float, int>(wingStats.FlyTime, wingStats.AccRunSpeedOverride, WingSystem.ModdedWingVerticalMults[key]);
				} else {
					value = new Tuple<int, float, int>(wingStats.FlyTime, wingStats.AccRunSpeedOverride, -1);
				}
			}
			// ... or vanilla 
			else {
				value = new Tuple<int, float, int>(wingStats.FlyTime, wingStats.AccRunSpeedOverride, WingSystem.VanillaWingVerticalMults[item.type]);
			}

			if (!WingConfig.Instance.DockStats) {
				lines.Add(WingTitle());
			}

			// Flight time
			// If we're using combined wing times and is equipped - display as combined using players wing time
			if (WingConfig.Instance.CombineWingTimes && WingConfig.Instance.ShowCurWingTime && WingConfig.Instance.ShowMaxWingTime && isEquipped) {
				lines.Add(WingFlightTimeCombined(Convert.ToInt32(player.wingTime), value.Item1));
			}

			// If we're not using combined and is equipped - display separerately using players wing time
			else if (isEquipped) {
				if (WingConfig.Instance.ShowMaxWingTime) {
					lines.Add(WingFlightTimeMax(value.Item1));
				}

				if (WingConfig.Instance.ShowCurWingTime) {
					lines.Add(WingFlightTimeCurrent(Convert.ToInt32(player.wingTime), value.Item1));
				}
			}

			// If it's not equipped - display only MaxWingTime using items wing time
			else {
				if (WingConfig.Instance.ShowMaxWingTime) {
					lines.Add(WingFlightTimeMax(value.Item1));
				}
			}

			// Other stats
			if (WingConfig.Instance.ShowHorizontalSpeed) {
				lines.Add(WingHorizontalSpeed(value.Item2));
			}

			if ((WingConfig.Instance.ShowVerticalMult && value.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults) {
				lines.Add(WingVerticalSpeedMultiplier(value.Item3));
			}

			// Wing comparison stats
			if (WingConfig.Instance.CompareStats) {
				Tuple<int, float, int> compValue = null;

				// Check equipped armor
				for (int i = 3; i < 7 + player.GetAmountOfExtraAccessorySlotsToShow(); i++) {
					if (player.armor[i].wingSlot > 0) {
						// Skip this armor if its the same as the selected wing
						if (player.armor[i].type == item.type) {
							continue;
						}

						Item compItem = player.armor[i];
						WingStats compWingStats = ArmorIDs.Wing.Sets.Stats[compItem.wingSlot];

						// modName and itemName, needed for modded items
						string compModName = "Terraria"; // Init this as Terraria to check for modded items later
						string compItemName = compItem.Name;
						if (compItem.ModItem is not null) {
							compModName = item.ModItem.Mod.Name;
							compItemName = item.ModItem.Name;
						}

						Tuple<string, string> compKey = new(compModName, compItemName);
						// Build our Tuple
						// Check if we have a modded wingstats override
						if (WingSystem.ModdedWingStatsOverride.ContainsKey(compKey)) {
							compValue = WingSystem.ModdedWingStatsOverride[compKey];
						}
						// Check if our item is modded...
						else if (compModName != "Terraria") {
							if (WingSystem.ModdedWingVerticalMults.ContainsKey(key)) {
								compValue = new Tuple<int, float, int>(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, WingSystem.ModdedWingVerticalMults[compKey]);
							} else {
								compValue = new Tuple<int, float, int>(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, -1);
							}
						}
						// ... or vanilla 
						else {
							compValue = new Tuple<int, float, int>(compWingStats.FlyTime, compWingStats.AccRunSpeedOverride, WingSystem.VanillaWingVerticalMults[compItem.type]);
						}
					}
				}

				// Print actual lines
				if (compValue is not null) {
					lines.Add(CompWingTitle());

					if (!MiscConfig.Instance.ComparionsValueColors) {
						if (WingConfig.Instance.ShowMaxWingTime) {
							lines.Add(CompWingFlightTimeMax(compValue.Item1, MiscConfig.Instance.StatValueColor));
						}

						if (WingConfig.Instance.ShowHorizontalSpeed) {
							lines.Add(CompWingHorizontalSpeed(compValue.Item2, MiscConfig.Instance.StatValueColor));
						}

						if ((WingConfig.Instance.ShowVerticalMult && compValue.Item3 != -1) || WingConfig.Instance.ShowUnknownVerticalMults) {
							lines.Add(CompWingVerticalSpeedMultiplier(compValue.Item3, MiscConfig.Instance.StatValueColor));
						}
					} else {
						Color valueColor;
						valueColor = MiscConfig.Instance.ComparisonEqualColor;
						if (value.Item1 < compValue.Item1) {
							valueColor = MiscConfig.Instance.ComparisonBetterColor;
						}

						if (value.Item1 > compValue.Item1) {
							valueColor = MiscConfig.Instance.ComparisonWorseColor;
						}

						if (WingConfig.Instance.ShowMaxWingTime) {
							lines.Add(CompWingFlightTimeMax(compValue.Item1, valueColor));
						}

						valueColor = MiscConfig.Instance.ComparisonEqualColor;
						if (value.Item2 < compValue.Item2) {
							valueColor = MiscConfig.Instance.ComparisonBetterColor;
						}

						if (value.Item2 > compValue.Item2) {
							valueColor = MiscConfig.Instance.ComparisonWorseColor;
						}

						if (WingConfig.Instance.ShowHorizontalSpeed) {
							lines.Add(CompWingHorizontalSpeed(compValue.Item2, valueColor));
						}

						valueColor = MiscConfig.Instance.ComparisonEqualColor;
						if (value.Item3 < compValue.Item3) {
							valueColor = MiscConfig.Instance.ComparisonBetterColor;
						}

						if (value.Item3 > compValue.Item3) {
							valueColor = MiscConfig.Instance.ComparisonWorseColor;
						}

						if (WingConfig.Instance.ShowVerticalMult) {
							lines.Add(CompWingVerticalSpeedMultiplier(compValue.Item3, valueColor));
						}
					}
				}
			}

			tooltips.AddRange(lines);
		}
	}
}