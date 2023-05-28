using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class MiscConfig : ModConfig
{
	public static MiscConfig Instance => ModContent.GetInstance<MiscConfig>();

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(typeof(Color), "0, 71, 171, 255")]
	public Color ComparisonTitleColor { get; set; }

	[DefaultValue(true)]
	public bool ComparisonValueColor { get; set; }

	[DefaultValue(typeof(Color), "0, 255, 0, 255")]
	public Color ComparisonBetterColor { get; set; }

	[DefaultValue(typeof(Color), "255, 0, 0, 255")]
	public Color ComparisonWorseColor { get; set; }

	[DefaultValue(typeof(Color), "255, 165, 0, 255")]
	public Color ComparisonEqualColor { get; set; }

	[DefaultValue(true)]
	public bool ColorBlindAssistanceIcons { get; set; }

	[DefaultValue(typeof(Color), "180, 180, 180, 255")]
	public Color StatSubtitleColor { get; set; }

	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color StatValueColor { get; set; }
}