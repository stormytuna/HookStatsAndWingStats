using Terraria.ModLoader;

namespace HookStatsAndWingStats.Helpers;

public static class Helpers
{
	public static bool HasCalamity => ModLoader.TryGetMod("CalamityMod", out _);
}