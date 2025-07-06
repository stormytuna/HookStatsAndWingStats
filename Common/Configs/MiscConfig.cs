using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class MiscConfig : ModConfig
{
	private const string configPath = "Mods.HookStatsAndWingStats.Configs.MiscConfig";

	public static MiscConfig Instance {
		get => ModContent.GetInstance<MiscConfig>();
	}

	public override ConfigScope Mode {
		get => ConfigScope.ClientSide;
	}
	
	[Header("Colors")]
	[DefaultValue(typeof(Color), "0, 255, 0, 255")]
	public Color ComparisonBetterColor { get; set; }

	[DefaultValue(typeof(Color), "255, 0, 0, 255")]
	public Color ComparisonWorseColor { get; set; }

	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color ComparisonEqualColor { get; set; }

	[DefaultValue(typeof(Color), "200, 200, 200, 255")]
	public Color StatSubtitleColor { get; set; }

	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color StatValueColor { get; set; }
}
