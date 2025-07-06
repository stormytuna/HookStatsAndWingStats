using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class HookConfig : ModConfig
{
	public static HookConfig Instance {
		get => ModContent.GetInstance<HookConfig>();
	}

	public override ConfigScope Mode {
		get => ConfigScope.ClientSide;
	}

	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[Header("Stats")]
	[DefaultValue(true)]
	public bool ShowReach { get; set; }
	
	[DefaultValue(true)]
	public bool ReachInTiles { get; set; }
	
	[DefaultValue(true)]
	public bool ShowShootSpeed { get; set; }

	[DefaultValue(true)]
	public bool ShowRetractSpeed { get; set; }
	
	[DefaultValue(true)]
	public bool SpeedsInTilesPerSecond { get; set; }

	[DefaultValue(true)]
	public bool ShowNumHooks { get; set; }

	[DefaultValue(true)]
	public bool ShowLatchingType { get; set; }
}
