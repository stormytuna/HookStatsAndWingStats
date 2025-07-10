using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.Core;

public static class CommonStatComparisons
{
	public static ComparisonResult CompareFloats(object a, object b) {
		float floatA = (float)a;
		float floatB = (float)b;

		if (floatA > floatB) {
			return ComparisonResult.Better;
		}

		if (floatA < floatB) {
			return ComparisonResult.Worse;
		}

		return ComparisonResult.Equal;
	}

	public static ComparisonResult CompareInts(object a, object b) {
		int intA = (int)a;
		int intB = (int)b;

		if (intA > intB) {
			return ComparisonResult.Better;
		}

		if (intB > intA) {
			return ComparisonResult.Worse;
		}

		return ComparisonResult.Equal;
	}
}
