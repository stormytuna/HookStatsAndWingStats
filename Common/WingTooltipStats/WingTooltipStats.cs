using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.Core.Enums;
using Terraria.Localization;

namespace HookStatsAndWingStats.Common.WingTooltipStats;

public class WingMaxFlightTime(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => WingConfig.Instance.ShowMaxWingTime;
	}

	public override string FormattedValue {
		get {
			// TODO: handle infinite flight time
			int value = (int)Value;

			if (value == int.MaxValue) {
				return "∞";
			}

			if (WingConfig.Instance.FlightTimeInSeconds) {
				string formatter = $"0.{MiscConfig.GetDecimalPlaceFormatter()}";
				return (value / 60f).ToString(formatter) + "s";
			}

			return $"{value}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareInts(Value, other.Value);
	}
}

public class WingHorizontalSpeed(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => WingConfig.Instance.ShowHorizontalSpeed;
	}

	public override string FormattedValue {
		get {
			float value = (float)Value;
			string formatter = $"0.{MiscConfig.GetDecimalPlaceFormatter()}";

			if (WingConfig.Instance.HorizontalSpeedInMph) {
				return (value * Consts.UnitsPerFrameToMilesPerHour).ToString(formatter) + "mph";
			}

			return value.ToString(formatter);
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class WingVerticalSpeedMultiplier(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get { 
			bool enabled = WingConfig.Instance.ShowVerticalMult;
			bool shouldShow = Value is not null || MiscConfig.Instance.ShowUnknownStats;
			return enabled && shouldShow;
		}
	}

	public override string FormattedValue {
		get {
			if (Value is null) {
				return Language.GetTextValue($"Mods.{nameof(HookStatsAndWingStats)}.Unknown");
			}

			float value = (float)Value;

			return $"{value:P0}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		if (Value is null || other.Value is null) {
			return ComparisonResult.Equal;
		}

		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}
