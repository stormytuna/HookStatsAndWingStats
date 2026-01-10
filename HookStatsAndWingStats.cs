using System;
using HookStatsAndWingStats.Common.Systems;

namespace HookStatsAndWingStats;

public class HookStatsAndWingStats : Mod
{
	public static HookStatsAndWingStats Instance {
		get => ModContent.GetInstance<HookStatsAndWingStats>();
	}

	public override object Call(params object[] args) {
		if (args is ["SetHookStats", int hookItemType, float hookReach, float hookShootSpeed, int numHooks, int latchingType]) {
			if (!Enum.IsDefined(typeof(Core.Enums.HookLatchingType), latchingType)) {
				throw new ArgumentOutOfRangeException(nameof(latchingType), "Invalid latching type! See https://github.com/stormytuna/HookStatsAndWingStats");
			}

			HookSystem.AddModdedHook(hookItemType, hookReach, hookShootSpeed, numHooks, latchingType);
			return 0;
		}

		if (args is ["SetWingStats", int wingItemType, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier]) {
			WingSystem.AddModdedWing(wingItemType, maxFlightTime, horizontalSpeed, verticalSpeedMultiplier);
			return 0;
		}

		throw new ArgumentException("Invalid call! See https://github.com/stormytuna/HookStatsAndWingStats");
	}
}

public class HookStatsAndWingStatsCallsTests : ModSystem
{
	public override bool IsLoadingEnabled(Mod mod) {
		return false;
	}

	public override void PostSetupContent() {
		if (ModLoader.TryGetMod(nameof(HookStatsAndWingStats), out Mod hookStatsAndWingStats)) {
			hookStatsAndWingStats.Call("SetHookStats", ItemID.MagicMirror, 16f * 16f, 16f, 5, 1);
			hookStatsAndWingStats.Call("SetWingStats", ItemID.IronPickaxe, 3 * 60, 10f, 2.2f);
		}
	}
}
