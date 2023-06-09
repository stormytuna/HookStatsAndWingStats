using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class HookConfig : ModConfig
{
	private const string configPath = "Mods.HookStatsAndWingStats.Configs.HookConfig";

	public static HookConfig Instance => ModContent.GetInstance<HookConfig>();

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Label($"${configPath}.ShowStats.Label")]
	[Tooltip($"${configPath}.ShowStats.Tooltip")]
	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[Label($"${configPath}.CompareStats.Label")]
	[Tooltip($"${configPath}.CompareStats.Tooltip")]
	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[Label($"${configPath}.DockStats.Label")]
	[Tooltip($"${configPath}.DockStats.Tooltip")]
	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[Label($"${configPath}.ShowTitle.Label")]
	[Tooltip($"${configPath}.ShowTitle.Tooltip")]
	[DefaultValue(false)]
	public bool ShowTitle { get; set; }

	[Label($"${configPath}.TitleColor.Label")]
	[Tooltip($"${configPath}.TitleColor.Tooltip")]
	[DefaultValue(typeof(Color), "224, 89, 22, 255")]
	public Color TitleColor { get; set; }

	[Label($"${configPath}.ShowReach.Label")]
	[Tooltip($"${configPath}.ShowReach.Tooltip")]
	[DefaultValue(true)]
	public bool ShowReach { get; set; }

	[Label($"${configPath}.ReachInTiles.Label")]
	[Tooltip($"${configPath}.ReachInTiles.Tooltip")]
	[DefaultValue(true)]
	public bool ReachInTiles { get; set; }

	[Label($"${configPath}.ShowVelocity.Label")]
	[Tooltip($"${configPath}.ShowVelocity.Tooltip")]
	[DefaultValue(true)]
	public bool ShowVelocity { get; set; }

	[Label($"${configPath}.VelocityInMph.Label")]
	[Tooltip($"${configPath}.VelocityInMph.Tooltip")]
	[DefaultValue(false)]
	public bool VelocityInMph { get; set; }

	[Label($"${configPath}.ShowCount.Label")]
	[Tooltip($"${configPath}.ShowCount.Tooltip")]
	[DefaultValue(true)]
	public bool ShowCount { get; set; }

	[Label($"${configPath}.ShowLatchingType.Label")]
	[Tooltip($"${configPath}.ShowLatchingType.Tooltip")]
	[DefaultValue(true)]
	public bool ShowLatchingType { get; set; }
}