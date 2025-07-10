using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.DataStructures;

public struct HookStats(float reach, float shootSpeed, int numHooks, HookLatchingType latchingType)
{
	public float Reach = reach;
	public float ShootSpeed = shootSpeed;
	public float RetractSpeed; // TODO
	public int NumHooks = numHooks;
	public HookLatchingType LatchingType = latchingType;
}
