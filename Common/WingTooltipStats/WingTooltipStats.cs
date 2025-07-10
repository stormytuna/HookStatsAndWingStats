using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.Common.WingTooltipStats;

public class WingMaxFlightTime(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => WingConfig.Instance.ShowMaxWingTime;
	}

	public override string FormattedValue {
		get {
			// TODO: handle infinite flight time
			float value = (float)Value;

			if (WingConfig.Instance.FlightTimeInSeconds) {
				return $"{value / 60f:0.##}s";
			}

			return $"{value}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
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

			if (WingConfig.Instance.HorizontalSpeedInMph) {
				return $"{value * Consts.UnitsPerFrameToMilesPerHour:0.##}mph";
			}

			return $"{value:0.}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class WingVerticalSpeedMultiplier(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => WingConfig.Instance.ShowVerticalMult;
	}

	public override string FormattedValue {
		get {
			if (Value is null) {
				return "Unknown";
			}

			float value = (float)Value;

			return $"{value:P0}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}
