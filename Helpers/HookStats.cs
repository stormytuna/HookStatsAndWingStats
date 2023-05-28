using System.Collections.Generic;
using HookStatsAndWingStats.Common.Configs;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Helpers;

public class HookStats
{
	public HookReach Reach { get; }
	public HookShootSpeed ShootSpeed { get; }
	public HookHookCount HookCount { get; }
	public HookLatchingType LatchingType { get; }

	public HookStats(float reach, float shootSpeed, int hookCount, Enums.HookLatchingType latchingType) {
		Reach = new HookReach(reach);
		ShootSpeed = new HookShootSpeed(shootSpeed);
		HookCount = new HookHookCount(hookCount);
		LatchingType = new HookLatchingType(latchingType);
	}

	public List<TooltipLine> BuildSoloTooltips() {
		List<TooltipLine> result = new();

		if (HookConfig.Instance.ShowTitle) {
			if (!HookConfig.Instance.DockStats) {
				// This used to say 'If youre reading this, I hope you have a nice day' but I had to shorten it so the tooltip background panel rendered properly sooooo....
				// If youre reading *this*, I hope you have an amazing day :D
				result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
			}

			ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Title"), HookConfig.Instance.TitleColor);
			result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "HookTitle", title.Value));
		}

		if (HookConfig.Instance.ShowReach) {
			result.Add(Reach.BuildSoloTooltip());
		}

		if (HookConfig.Instance.ShowVelocity) {
			result.Add(ShootSpeed.BuildSoloTooltip());
		}

		if (HookConfig.Instance.ShowCount) {
			result.Add(HookCount.BuildSoloTooltip());
		}

		if (HookConfig.Instance.ShowLatchingType) {
			result.Add(LatchingType.BuildSoloTooltip());
		}

		return result;
	}

	public List<TooltipLine> BuildComparisonTooltips(HookStats otherHookStats) {
		List<TooltipLine> result = new();

		if (HookConfig.Instance.ShowTitle) {
			if (!HookConfig.Instance.DockStats) {
				// This used to say 'If youre reading this, I hope you have a nice day' but I had to shorten it so the tooltip background panel rendered properly sooooo....
				// If youre reading *this*, I hope you have an amazing day :D
				result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "Invisible", "a"));
			}

			ColoredText title = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Title"), HookConfig.Instance.TitleColor);
			result.Add(new TooltipLine(HookStatsAndWingStats.Instance, "HookTitle", title.Value));
		}

		if (HookConfig.Instance.ShowReach) {
			result.Add(Reach.BuildComparisonTooltip(otherHookStats.Reach));
		}

		if (HookConfig.Instance.ShowVelocity) {
			result.Add(ShootSpeed.BuildComparisonTooltip(otherHookStats.ShootSpeed));
		}

		if (HookConfig.Instance.ShowCount) {
			result.Add(HookCount.BuildComparisonTooltip(otherHookStats.HookCount));
		}

		if (HookConfig.Instance.ShowLatchingType) {
			result.Add(LatchingType.BuildComparisonTooltip(otherHookStats.LatchingType));
		}

		return result;
	}
}

public class HookReach
{
	private readonly float reach;

	public HookReach(float reach) {
		this.reach = reach;
	}

	public string Reach {
		get {
			if (HookConfig.Instance.ReachInTiles) {
				return $"{reach / 16f:00.}";
			}

			return $"{reach}";
		}
	}

	public Color GetComparisonColour(float otherReach) {
		if (reach > otherReach) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (reach < otherReach) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Reach"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(Reach, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookReach", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(HookReach otherReach) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Reach"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(Reach, GetComparisonColour(otherReach.reach));
		ColoredText otherValue = new(otherReach.Reach, otherReach.GetComparisonColour(reach));

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookReach", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}

public class HookShootSpeed
{
	private readonly float shootSpeed;

	public HookShootSpeed(float shootSpeed) {
		this.shootSpeed = shootSpeed;
	}

	public string ShootSpeed {
		get {
			if (HookConfig.Instance.VelocityInMph) {
				return $"{shootSpeed * 5.084949379f:00.}mph";
			}

			return $"{shootSpeed:00.}";
		}
	}

	public Color GetComparisonColour(float otherShootSpeed) {
		if (shootSpeed > otherShootSpeed) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (shootSpeed < otherShootSpeed) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.ShootSpeed"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(ShootSpeed, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookShootSpeed", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(HookShootSpeed otherShootSpeed) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.Reach"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(ShootSpeed, GetComparisonColour(otherShootSpeed.shootSpeed));
		ColoredText otherValue = new(otherShootSpeed.ShootSpeed, otherShootSpeed.GetComparisonColour(shootSpeed));

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookShootSpeed", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}

public class HookHookCount
{
	private readonly float hookCount;

	public HookHookCount(int hookCount) {
		this.hookCount = hookCount;
	}

	public string HookCount => $"{hookCount}";

	public Color GetComparisonColour(float otherHookCount) {
		if (hookCount > otherHookCount) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		if (hookCount < otherHookCount) {
			return MiscConfig.Instance.ComparisonWorseColor;
		}

		return MiscConfig.Instance.ComparisonEqualColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.HookCount"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(HookCount, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(HookHookCount otherHookCount) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.HookCount"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(HookCount, GetComparisonColour(otherHookCount.hookCount));
		ColoredText otherValue = new(otherHookCount.HookCount, otherHookCount.GetComparisonColour(hookCount));

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}

public class HookLatchingType
{
	private readonly Enums.HookLatchingType latchingType;

	public HookLatchingType(Enums.HookLatchingType latchingType) {
		this.latchingType = latchingType;
	}

	public string LatchingType => Language.GetTextValue($"Mods.HookStatsAndWingStats.HookStats.LatchingTypes.{latchingType}");

	public Color GetComparisonColour(Enums.HookLatchingType otherLatchingType) {
		if (latchingType == otherLatchingType || latchingType == Enums.HookLatchingType.Special || otherLatchingType == Enums.HookLatchingType.Special) {
			return MiscConfig.Instance.ComparisonEqualColor;
		}

		if (latchingType > otherLatchingType) {
			return MiscConfig.Instance.ComparisonBetterColor;
		}

		return MiscConfig.Instance.ComparisonWorseColor;
	}

	public TooltipLine BuildSoloTooltip() {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.LatchingType"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText value = new(LatchingType, MiscConfig.Instance.StatValueColor);

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookLatchingType", ColoredText.Parse(": ", subtitle, value));
	}

	public TooltipLine BuildComparisonTooltip(HookLatchingType otherLatchingType) {
		ColoredText subtitle = new(Language.GetTextValue("Mods.HookStatsAndWingStats.HookStats.LatchingType"), MiscConfig.Instance.StatSubtitleColor);
		ColoredText thisValue = new(LatchingType, GetComparisonColour(otherLatchingType.latchingType));
		ColoredText otherValue = new(otherLatchingType.LatchingType, otherLatchingType.GetComparisonColour(latchingType));

		return new TooltipLine(HookStatsAndWingStats.Instance, "HookCount", $"{subtitle.Value}: {thisValue.Value} ({otherValue.Value})");
	}
}