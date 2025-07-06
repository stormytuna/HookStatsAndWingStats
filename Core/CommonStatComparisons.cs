using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.Core;

public static class CommonStatComparisons
{
	public static ComparisonResult CompareFloats(object a, object b) {
		var floatA = (float)a;
		var floatB = (float)b;
		
		if (floatA > floatB) {
			return ComparisonResult.Better;
		} 
		
		if (floatA < floatB) {
			return ComparisonResult.Worse;
		}
		
		return ComparisonResult.Equal;
	}	
	
	public static ComparisonResult CompareInts(object a, object b) {
		var intA = (int)a;
		var intB = (int)b;
		
		if (intA > intB) {
			return ComparisonResult.Better;
		} 
		
		if (intB > intA) {
			return ComparisonResult.Worse;
		}
		
		return ComparisonResult.Equal;
	}	
}
