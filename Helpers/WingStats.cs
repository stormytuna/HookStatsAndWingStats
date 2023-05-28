using System;
using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VanillaWingStats = Terraria.DataStructures.WingStats;

namespace HookStatsAndWingStats.Helpers;

public class WingStats
{
	public WingMaxFlightTime MaxFlightTime { get; }
	public WingHorizontalSpeed HorizontalSpeed { get; }
	public WingVerticalSpeedMultiplier VerticalSpeedMultiplier { get; }

	public WingStats(int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) {
		MaxFlightTime = new WingMaxFlightTime(maxFlightTime);
		HorizontalSpeed = new WingHorizontalSpeed(horizontalSpeed);
		VerticalSpeedMultiplier = new WingVerticalSpeedMultiplier(verticalSpeedMultiplier);
	}

	/// <summary>
	///     This overload fetches maxFlightTime and horizontalSpeed from the items WingStats
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="verticalSpeedMultiplier"></param>
	public WingStats(int itemType, float verticalSpeedMultiplier) {
		Item item = ContentSamples.ItemsByType[itemType];
		if (item.wingSlot < 0) {
			throw new ArgumentException($"Item with type {itemType} does not have wing stats");
		}

		VanillaWingStats vanillaWingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];
		MaxFlightTime = new WingMaxFlightTime(vanillaWingStats.FlyTime);
		HorizontalSpeed = new WingHorizontalSpeed(vanillaWingStats.AccRunSpeedOverride);
		VerticalSpeedMultiplier = new WingVerticalSpeedMultiplier(verticalSpeedMultiplier);
	}

	public List<TooltipLine> BuildSoloTooltips() {
		List<TooltipLine> result = new();

		if (WingConfig.Instance.ShowTitle) {
			if (!WingConfig.Instance.DockStats) {
				// See HookStatsAndWingStats.Helpers.HookStats@31:17
				result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
			}

			ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.Title"), WingConfig.Instance.TitleColor);
			result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "WingTitle", title.Value));
		}

		if (WingConfig.Instance.ShowMaxWingTime) {
			result.Add(MaxFlightTime.BuildSoloTooltip());
		}

		if (WingConfig.Instance.ShowHorizontalSpeed) {
			result.Add(HorizontalSpeed.BuildSoloTooltip());
		}

		if ((WingConfig.Instance.ShowVerticalMult && VerticalSpeedMultiplier.IsKnown) || WingConfig.Instance.ShowUnknownVerticalMults) {
			result.Add(VerticalSpeedMultiplier.BuildSoloTooltip());
		}

		return result;
	}

	public List<TooltipLine> BuildComparisonTooltips(WingStats otherWingStats) {
		List<TooltipLine> result = new();

		if (WingConfig.Instance.ShowTitle) {
			if (!WingConfig.Instance.DockStats) {
				// See HookStatsAndWingStats.Helpers.HookStats@31:17
				result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
			}

			ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.Title"), WingConfig.Instance.TitleColor);
			result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "WingTitle", title.Value));
		}

		if (WingConfig.Instance.ShowMaxWingTime) {
			result.Add(MaxFlightTime.BuildComparisonTooltip(otherWingStats.MaxFlightTime));
		}

		if (WingConfig.Instance.ShowHorizontalSpeed) {
			result.Add(HorizontalSpeed.BuildComparisonTooltip(otherWingStats.HorizontalSpeed));
		}

		if ((WingConfig.Instance.ShowVerticalMult && VerticalSpeedMultiplier.IsKnown) || WingConfig.Instance.ShowUnknownVerticalMults) {
			result.Add(VerticalSpeedMultiplier.BuildComparisonTooltip(otherWingStats.VerticalSpeedMultiplier));
		}

		return result;
	}
}

public class WingMaxFlightTime
{
	private readonly int maxFlightTime;
	private readonly bool isInfinite;

	public WingMaxFlightTime(int maxFlightTime) {
		this.maxFlightTime = maxFlightTime;
		isInfinite = int.MaxValue == maxFlightTime;
	}

	public string MaxFlightTime {
		get {
			if (isInfinite) {
				return "∞";
			}

			if (WingConfig.Instance.FlightTimeInSeconds) {
				return $"{maxFlightTime / 60f:.00}s";
			}

			return $"{maxFlightTime}";
		}
	}

	public Color GetComparisonColor(int otherMaxFlightTime) {
		if (maxFlightTime > otherMaxFlightTime) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (maxFlightTime < otherMaxFlightTime) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.MaxFlightTime"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(MaxFlightTime, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingMaxFlightTime", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildSoloTooltip(int currentFlightTime) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.FlightTime"), MiscConfig.Instance.StatSubtitleColor);

		string parsedCurrentFlightTime = WingConfig.Instance.FlightTimeInSeconds ? $"{currentFlightTime / 60f:00.}s" : $"{currentFlightTime}";
		if (isInfinite) {
			parsedCurrentFlightTime = "∞";
		} else if (WingConfig.Instance.FlightTimeInSeconds) {
			parsedCurrentFlightTime = $"{currentFlightTime / 60f:0.00}s";
		} else {
			parsedCurrentFlightTime = $"{currentFlightTime}";
		}

		ColoredText current = new(parsedCurrentFlightTime, MiscConfig.Instance.StatValueColor);
		ColoredText max = new(MaxFlightTime, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingFlightTime", $"{subtitle.Value}: {current.Value} / {max.Value}");
	}

	public TooltipLine BuildComparisonTooltip(WingMaxFlightTime otherMaxFlightTime) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.MaxFlightTime"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(MaxFlightTime, GetComparisonColor(otherMaxFlightTime.maxFlightTime));
		ColoredText otherValue = new(otherMaxFlightTime.MaxFlightTime, otherMaxFlightTime.GetComparisonColor(maxFlightTime));

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingMaxFlightTime", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}

public class WingHorizontalSpeed
{
	private readonly float horizontalSpeed;

	public WingHorizontalSpeed(float horizontalSpeed) {
		this.horizontalSpeed = horizontalSpeed;
	}

	public string HorizontalSpeed {
		get {
			if (WingConfig.Instance.HorizontalSpeedInMph) {
				return $"{horizontalSpeed * 5.084949379f:0.}mph";
			}

			return $"{horizontalSpeed:0.}";
		}
	}

	public Color GetComparisonColor(float otherHorizontalSpeed) {
		if (horizontalSpeed > otherHorizontalSpeed) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (horizontalSpeed < otherHorizontalSpeed) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.HorizontalSpeed"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(HorizontalSpeed, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(WingHorizontalSpeed otherHorizontalSpeed) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.HorizontalSpeed"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(HorizontalSpeed, GetComparisonColor(otherHorizontalSpeed.horizontalSpeed));
		ColoredText otherValue = new(otherHorizontalSpeed.HorizontalSpeed, otherHorizontalSpeed.GetComparisonColor(horizontalSpeed));

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}

public class WingVerticalSpeedMultiplier
{
	private readonly float verticalSpeedMultiplier;
	private readonly bool isUnknown;

	public WingVerticalSpeedMultiplier(float verticalSpeedMultiplier) {
		this.verticalSpeedMultiplier = verticalSpeedMultiplier;
		isUnknown = float.IsNaN(verticalSpeedMultiplier);
	}

	public string VerticalSpeedMultiplier {
		get {
			if (isUnknown) {
				return "Unknown";
			}

			return $"{verticalSpeedMultiplier * 100f:.}%";
		}
	}

	public bool IsKnown => !isUnknown;

	public Color GetComparisonColor(float otherVerticalSpeedMultiplier) {
		if (isUnknown || float.IsNaN(otherVerticalSpeedMultiplier)) {
			return MiscConfig.Instance.ComparisonEqualColor;
		}

		if (verticalSpeedMultiplier > otherVerticalSpeedMultiplier) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (verticalSpeedMultiplier < otherVerticalSpeedMultiplier) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.VerticalSpeedMultiplier"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(VerticalSpeedMultiplier, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingVerticalSpeedMultiplier", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(WingVerticalSpeedMultiplier otherVerticalSpeedMultiplier) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.WingStats.VerticalSpeedMultiplier"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(VerticalSpeedMultiplier, GetComparisonColor(otherVerticalSpeedMultiplier.verticalSpeedMultiplier));
		ColoredText otherValue = new(otherVerticalSpeedMultiplier.VerticalSpeedMultiplier, otherVerticalSpeedMultiplier.GetComparisonColor(verticalSpeedMultiplier));

		return new TooltipLine(HookStatsAndWingStats.Instance, "WingHorizontalSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}