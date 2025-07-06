namespace HookStatsAndWingStats.Core.Enums;

public enum HookLatchingType : byte
{
	Single,
	Individual,
	Simultaneous,
	Special
}

public static class HookLatchingTypeExtensions
{
	public static string GetLocalizedName(this HookLatchingType latchingType) {
		return HookStatsAndWingStats.Instance.GetLocalization($"LatchingTypes.{latchingType}").Value;
	}
}
