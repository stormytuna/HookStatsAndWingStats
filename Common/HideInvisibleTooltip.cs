using Terraria;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common;

public class HideInvisibleTooltip : GlobalItem
{
	public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset) {
		if (line.Mod == nameof(HookStatsAndWingStats) && line.Name == "Invisible") {
			return false;
		}

		return base.PreDrawTooltipLine(item, line, ref yOffset);
	}
}
