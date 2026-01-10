namespace HookStatsAndWingStats.DataStructures;

public struct WingStats
{
	public int MaxFlightTime;
	public float HorizontalSpeed;
	public float? VerticalSpeedMultiplier;

	public WingStats(int maxFlightTime, float horizontalSpeed, float? verticalSpeedMultiplier = null) {
		MaxFlightTime = maxFlightTime;
		HorizontalSpeed = horizontalSpeed;
		VerticalSpeedMultiplier = verticalSpeedMultiplier;
	}

	public WingStats(int itemType, float verticalSpeedMultiplier) {
		Item item = ContentSamples.ItemsByType[itemType];
		VanillaWingStats vanillaWingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];

		MaxFlightTime = vanillaWingStats.FlyTime;
		HorizontalSpeed = vanillaWingStats.AccRunSpeedOverride;
		VerticalSpeedMultiplier = verticalSpeedMultiplier;
	}
}
