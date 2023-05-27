using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class HookConfig : ModConfig
{
	public static HookConfig Instance;

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[DefaultValue(false)]
	public bool DockComparison { get; set; }

	[DefaultValue(typeof(Color), "255, 164, 0, 255")]
	public Color TitleColor { get; set; }

	[DefaultValue(true)]
	public bool ShowReach { get; set; }

	[DefaultValue(true)]
	public bool ShowVelocity { get; set; }

	[DefaultValue(true)]
	public bool ShowCount { get; set; }

	[DefaultValue(true)]
	public bool ShowLatchingType { get; set; }
}

public class WingConfig : ModConfig
{
	public static WingConfig Instance;

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[DefaultValue(false)]
	public bool DockComparison { get; set; }

	[DefaultValue(typeof(Color), "255, 0, 127, 255")]
	public Color TitleColor { get; set; }

	[DefaultValue(true)]
	public bool ShowCurWingTime { get; set; }

	[DefaultValue(true)]
	public bool ShowMaxWingTime { get; set; }

	[DefaultValue(true)]
	public bool CombineWingTimes { get; set; }

	[DefaultValue(true)]
	public bool FlightTimeInSeconds { get; set; }

	[DefaultValue(true)]
	public bool ShowHorizontalSpeed { get; set; }

	[DefaultValue(true)]
	public bool HorizontalSpeedInMPH { get; set; }

	[DefaultValue(true)]
	public bool ShowVerticalMult { get; set; }

	[DefaultValue(true)]
	public bool ShowUnknownVerticalMults { get; set; }
}

public class MiscConfig : ModConfig
{
	public static MiscConfig Instance;

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

	[DefaultValue(typeof(Color), "180, 180, 180, 255")]
	public Color StatSubtitleColor { get; set; }

	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color StatValueColor { get; set; }
}