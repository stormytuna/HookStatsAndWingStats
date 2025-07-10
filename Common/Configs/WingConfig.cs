using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class WingConfig : ModConfig
{
	public static WingConfig Instance {
		get => ModContent.GetInstance<WingConfig>();
	}

	public override ConfigScope Mode {
		get => ConfigScope.ClientSide;
	}

	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[DefaultValue(true)]
	public bool ShowMaxWingTime { get; set; }

	[DefaultValue(true)]
	public bool FlightTimeInSeconds { get; set; }

	[DefaultValue(true)]
	public bool ShowHorizontalSpeed { get; set; }

	[DefaultValue(true)]
	public bool HorizontalSpeedInMph { get; set; }

	[DefaultValue(true)]
	public bool ShowVerticalMult { get; set; }

	[DefaultValue(true)]
	public bool ShowUnknownVerticalMults { get; set; }
}
