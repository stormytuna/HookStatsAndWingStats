using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.DataStructures;

public struct HookStats
{
	public float Reach;
	public float ShootSpeed;
	public float RetractSpeed; // TODO
	public int NumHooks;
	public HookLatchingType LatchingType;

	public HookStats(float reach, float shootSpeed, int numHooks, HookLatchingType latchingType) {
		Reach = reach;
		ShootSpeed = shootSpeed;
		NumHooks = numHooks;
		LatchingType = latchingType;
	}
}
