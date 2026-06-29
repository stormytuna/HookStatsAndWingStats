using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.Core.Enums;
using Terraria.Localization;

namespace HookStatsAndWingStats.Common.HookTooltipStats;

public class HookReach(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowReach;
	}

	public override string FormattedValue {
		get {
			float value = (float)Value;
			string formatter = $"0.{MiscConfig.GetDecimalPlaceFormatter()}";


			if (HookConfig.Instance.ReachInTiles) {
				return (value / 16f).ToString(formatter);
			}

			return value.ToString(formatter);
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class HookShootSpeed(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowShootSpeed;
	}

	public override string FormattedValue {
		get {
			float value = (float)Value;
			string formatter = $"0.{MiscConfig.GetDecimalPlaceFormatter()}";

			if (HookConfig.Instance.ShootSpeedInTilesPerSecond) {
				return (value * Consts.UnitsPerFrameToTilesPerSecond).ToString(formatter);
			}

			return value.ToString(formatter);
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class HookNumHooks(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get {
			bool enabled = HookConfig.Instance.ShowNumHooks;
			bool shouldShow = Value is not null || MiscConfig.Instance.ShowUnknownStats;
			return enabled && shouldShow;
		}
	}

	public override string FormattedValue {
		get {
			if (Value is null) {
				return Language.GetTextValue($"Mods.{nameof(HookStatsAndWingStats)}.Unknown");
			}

			return base.FormattedValue;
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		if (Value is null || other.Value is null) {
			return ComparisonResult.Equal;
		}

		return CommonStatComparisons.CompareInts(Value, other.Value);
	}
}

public class HookLatchingType(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get {
			bool enabled = HookConfig.Instance.ShowLatchingType;
			bool shouldShow = Value is not null || MiscConfig.Instance.ShowUnknownStats;
			return enabled && shouldShow;
		}
	}

	public override string FormattedValue {
		get {
			if (Value is null) {
				return Language.GetTextValue($"Mods.{nameof(HookStatsAndWingStats)}.Unknown");
			}

			return Language.GetTextValue($"Mods.{nameof(HookStatsAndWingStats)}.LatchingTypes.{Value}");
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		if (Value is null || other.Value is null) {
			return ComparisonResult.Equal;
		}

		Core.Enums.HookLatchingType value = (Core.Enums.HookLatchingType)Value;
		Core.Enums.HookLatchingType otherValue = (Core.Enums.HookLatchingType)other.Value;

		if (value == otherValue || value == Core.Enums.HookLatchingType.Special || otherValue == Core.Enums.HookLatchingType.Special) {
			return ComparisonResult.Equal;
		}

		if (value > otherValue) {
			return ComparisonResult.Better;
		}

		return ComparisonResult.Worse;
	}
}
