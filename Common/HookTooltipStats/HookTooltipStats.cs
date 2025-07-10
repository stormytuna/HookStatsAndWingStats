using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Core;
using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.Common.HookTooltipStats;

public class HookReach(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowReach;
	}

	public override string FormattedValue {
		get {
			float value = (float)Value;

			if (HookConfig.Instance.ReachInTiles) {
				return $"{value / 16f:0.##}";
			}

			return $"{value:0.##}";
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

			if (HookConfig.Instance.SpeedsInTilesPerSecond) {
				return $"{value * Consts.UnitsPerFrameToTilesPerSecond:0.##}";
			}

			return $"{value:0.##}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class HookRetractSpeed(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowRetractSpeed;
	}

	public override string FormattedValue {
		get {
			float value = (float)Value;

			if (HookConfig.Instance.SpeedsInTilesPerSecond) {
				return $"{value * Consts.UnitsPerFrameToTilesPerSecond:0.##}";
			}

			return $"{value:0.##}";
		}
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareFloats(Value, other.Value);
	}
}

public class HookNumHooks(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowNumHooks;
	}

	public override ComparisonResult Compare(TooltipStat other) {
		return CommonStatComparisons.CompareInts(Value, other.Value);
	}
}

public class HookLatchingType(object value) : TooltipStat(value)
{
	public override bool IsEnabled {
		get => HookConfig.Instance.ShowLatchingType;
	}

	public override ComparisonResult Compare(TooltipStat other) {
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
