namespace HookStatsAndWingStats.DataStructures;

public struct WingStats
{
	public int MaxFlightTime;
	public float HorizontalSpeed;
	public float? VerticalSpeedMultiplier;

	public WingStats(int maxFlightTime, float horizontalSpeed, float? verticalSpeedMultiplier) {
		MaxFlightTime = maxFlightTime;
		HorizontalSpeed = horizontalSpeed;
		VerticalSpeedMultiplier = verticalSpeedMultiplier;
	}

	public WingStats(int itemType, float? verticalSpeedMultiplier = null) {
		Item item = ContentSamples.ItemsByType[itemType];
		VanillaWingStats vanillaWingStats = ArmorIDs.Wing.Sets.Stats[item.wingSlot];

		MaxFlightTime = vanillaWingStats.FlyTime;
		HorizontalSpeed = vanillaWingStats.AccRunSpeedOverride;
		VerticalSpeedMultiplier = verticalSpeedMultiplier;

		if (HorizontalSpeed == -1) {
			Player dummyPlayer = new();

			// Values taken from vanilla, these are the defaults with no other boosts
			float speed = dummyPlayer.accRunSpeed = 3f;
			float unused = dummyPlayer.maxRunSpeed = 0.08f;
			try {
				item.ModItem.HorizontalWingSpeeds(dummyPlayer, ref speed, ref unused);
				HorizontalSpeed = speed;
			}
			catch {
				HookStatsAndWingStats.Instance.Logger.Error("Ran into an issue trying to fetch horizontal speeds for " + ItemID.Search.GetName(item.type));
			}
		}
	}
}
