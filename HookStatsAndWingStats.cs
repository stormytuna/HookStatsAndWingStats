using System;
using HookStatsAndWingStats.Common.Systems;

namespace HookStatsAndWingStats;

public class HookStatsAndWingStats : Mod
{
	public static HookStatsAndWingStats Instance {
		get => ModContent.GetInstance<HookStatsAndWingStats>();
	}

	public override object Call(params object[] args) {
		if (args is ["AddHookStats", int hookItemType, float hookReach, float hookShootSpeed, int numHooks, int latchingType]) {
			if (!Enum.IsDefined(typeof(Core.Enums.HookLatchingType), latchingType)) {
				throw new ArgumentOutOfRangeException(nameof(latchingType), "Invalid latching type! See https://github.com/stormytuna/HookStatsAndWingStats");
			}
			
			HookSystem.AddModdedHook(hookItemType, hookReach, hookShootSpeed, numHooks, latchingType);
			return 0;
		}

		if (args is ["AddWingStats", int wingItemType, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier]) {
			WingSystem.AddModdedWing(wingItemType, maxFlightTime, horizontalSpeed, verticalSpeedMultiplier);
			return 0;
		}

		if (args is ["AddWingStats", int wingItemType2, float verticalSpeedMultiplier2]) {
			WingSystem.AddModdedWing(wingItemType2, verticalSpeedMultiplier2);
			return 0;
		}

		throw new ArgumentException("Invalid call! See https://github.com/stormytuna/HookStatsAndWingStats");
	}
}
