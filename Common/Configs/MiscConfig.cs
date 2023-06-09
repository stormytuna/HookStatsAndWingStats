using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class MiscConfig : ModConfig
{
	private const string configPath = "Mods.HookStatsAndWingStats.Configs.MiscConfig";

	public static MiscConfig Instance => ModContent.GetInstance<MiscConfig>();

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Label($"${configPath}.ComparisonTitleColor.Label")]
	[Tooltip($"${configPath}.ComparisonTitleColor.Tooltip")]
	[DefaultValue(typeof(Color), "0, 71, 171, 255")]
	public Color ComparisonTitleColor { get; set; }

	[Label($"${configPath}.ComparisonValueColor.Label")]
	[Tooltip($"${configPath}.ComparisonValueColor.Tooltip")]
	[DefaultValue(true)]
	public bool ComparisonValueColor { get; set; }

	[Label($"${configPath}.ComparisonBetterColor.Label")]
	[Tooltip($"${configPath}.ComparisonBetterColor.Tooltip")]
	[DefaultValue(typeof(Color), "0, 255, 0, 255")]
	public Color ComparisonBetterColor { get; set; }

	[Label($"${configPath}.ComparisonWorseColor.Label")]
	[Tooltip($"${configPath}.ComparisonWorseColor.Tooltip")]
	[DefaultValue(typeof(Color), "255, 0, 0, 255")]
	public Color ComparisonWorseColor { get; set; }

	[Label($"${configPath}.ComparisonEqualColor.Label")]
	[Tooltip($"${configPath}.ComparisonEqualColor.Tooltip")]
	[DefaultValue(typeof(Color), "255, 165, 0, 255")]
	public Color ComparisonEqualColor { get; set; }

	[Label($"${configPath}.StatSubtitleColor.Label")]
	[Tooltip($"${configPath}.StatSubtitleColor.Tooltip")]
	[DefaultValue(typeof(Color), "180, 180, 180, 255")]
	public Color StatSubtitleColor { get; set; }

	[Label($"${configPath}.StatValueColor.Label")]
	[Tooltip($"${configPath}.StatValueColor.Tooltip")]
	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color StatValueColor { get; set; }
}