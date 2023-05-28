using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class HookConfig : ModConfig
{
	public static HookConfig Instance => ModContent.GetInstance<HookConfig>();

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[DefaultValue(false)]
	public bool ShowTitle { get; set; }

	[DefaultValue(typeof(Color), "224, 89, 22, 255")]
	public Color TitleColor { get; set; }

	[DefaultValue(true)]
	public bool ShowReach { get; set; }

	[DefaultValue(true)]
	public bool ReachInTiles { get; set; }

	[DefaultValue(true)]
	public bool ShowVelocity { get; set; }

	[DefaultValue(false)]
	public bool VelocityInMph { get; set; }

	[DefaultValue(true)]
	public bool ShowCount { get; set; }

	[DefaultValue(true)]
	public bool ShowLatchingType { get; set; }
}