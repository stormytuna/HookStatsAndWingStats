using HookStatsAndWingStats.Core.Enums;

namespace HookStatsAndWingStats.DataStructures;

public struct HookStats(float reach, float shootSpeed, int? numHooks = null, HookLatchingType? latchingType = null)
{
	public float Reach = reach;
	public float ShootSpeed = shootSpeed;
	public int? NumHooks = numHooks;
	public HookLatchingType? LatchingType = latchingType;
}
