using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

[Label("Hook Config")]
public class HookConfig : ModConfig
{
	public static HookConfig Instance;

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Header("Hook Stats")]
	[Label("Display hook stats")]
	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[Label("Dock hook stats")]
	[Tooltip("This removes the linebreak between the stats and the rest of the tooltip")]
	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[Label("Display comparison to equipped hook")]
	[Tooltip("This displays a comparison between the selected hook and your equipped hook")]
	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[Label("Dock comparison")]
	[Tooltip("This removes the linebreak between the comparison and the rest of the tooltip. Note, will not remove the \"- EQUIPPED -\" line")]
	[DefaultValue(false)]
	public bool DockComparison { get; set; }

	[Label("Hook stats title color")]
	[DefaultValue(typeof(Color), "255, 164, 0, 255")]
	public Color TitleColor { get; set; }

	[Label("Display reach")]
	[DefaultValue(true)]
	public bool ShowReach { get; set; }

	[Label("Display velocity")]
	[DefaultValue(true)]
	public bool ShowVelocity { get; set; }

	[Label("Display hook count")]
	[DefaultValue(true)]
	public bool ShowCount { get; set; }

	[Label("Display latching type")]
	[Tooltip("Single: Only one hook can be active\nSimultaneous: Many hooks can be active\nIndividual: Many hooks can be shot but only one can be latched")]
	[DefaultValue(true)]
	public bool ShowLatchingType { get; set; }
}

[Label("Wing Config")]
public class WingConfig : ModConfig
{
	public static WingConfig Instance;

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Header("Wing Stats")]
	[Label("Display wing stats")]
	[DefaultValue(true)]
	public bool ShowStats { get; set; }

	[Label("Dock wing stats")]
	[Tooltip("This removes the linebreak between the stats and the rest of the tooltip")]
	[DefaultValue(false)]
	public bool DockStats { get; set; }

	[Label("Display comparison to equipped wings")]
	[Tooltip("This displays a comparison between the selected wings and your equipped wings")]
	[DefaultValue(true)]
	public bool CompareStats { get; set; }

	[Label("Dock comparison")]
	[Tooltip("This removes the linebreak between the comparison and the rest of the tooltip. Note, will not remove the \"- EQUIPPED -\" line")]
	[DefaultValue(false)]
	public bool DockComparison { get; set; }

	[Label("Wing stats title color")]
	[DefaultValue(typeof(Color), "255, 0, 127, 255")]
	public Color TitleColor { get; set; }

	[Label("Display current flight time")]
	[DefaultValue(true)]
	public bool ShowCurWingTime { get; set; }

	[Label("Display max flight time")]
	[DefaultValue(true)]
	public bool ShowMaxWingTime { get; set; }

	[Label("Combine current and max flight time")]
	[Tooltip("Will be displayed as 'Flight time: [current]/[max]'")]
	[DefaultValue(true)]
	public bool CombineWingTimes { get; set; }

	[Label("Display flight time in seconds")]
	[Tooltip("Disabling this displays flight time in frames")]
	[DefaultValue(true)]
	public bool FlightTimeInSeconds { get; set; }

	[Label("Display wing horizontal speed")]
	[DefaultValue(true)]
	public bool ShowHorizontalSpeed { get; set; }

	[Label("Wing horizontal speed is measured in mph")]
	[Tooltip("Turning this off will display speed in raw units instead of mph\nDisplaying in mph may cause descrepencies due to rounding errors")]
	[DefaultValue(true)]
	public bool HorizontalSpeedInMPH { get; set; }

	[Label("Display wing vertical speed multiplier")]
	[DefaultValue(true)]
	public bool ShowVerticalMult { get; set; }

	[Label("Display wing vertical speed multiplier even when unknown")]
	[Tooltip("Sometimes the vertical speed multiplier stat will not be found correctly. With this set to true, it will display as 'unknown' instead of not being displayed")]
	[DefaultValue(true)]
	public bool ShowUnknownVerticalMults { get; set; }
}

[Label("Misc Config")]
public class MiscConfig : ModConfig
{
	public static MiscConfig Instance;

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Header("Misc")]
	[Label("Comparison title color")]
	[DefaultValue(typeof(Color), "0, 71, 171, 255")]
	public Color ComparisonTitleColor { get; set; }

	[Label("Comparison change value colours")]
	[Tooltip("Whether comparisons should have equal/better/worse colour changes")]
	[DefaultValue(true)]
	public bool ComparionsValueColors { get; set; }

	[Label("Comparison better color")]
	[Tooltip("The colour a value is when comparing things with a better value")]
	[DefaultValue(typeof(Color), "0, 255, 0, 255")]
	public Color ComparisonBetterColor { get; set; }

	[Label("Comparison worse color")]
	[Tooltip("The colour a value is when comparing things with a worse value")]
	[DefaultValue(typeof(Color), "255, 0, 0, 255")]
	public Color ComparisonWorseColor { get; set; }

	[Label("Comparison equal color")]
	[Tooltip("The colour a value is when comparing things with an equal value")]
	[DefaultValue(typeof(Color), "255, 165, 0, 255")]
	public Color ComparisonEqualColor { get; set; }

	[Label("Stat subtitle color")]
	[Tooltip("A subtitle might be 'Hooks' or 'Horizontal speed'")]
	[DefaultValue(typeof(Color), "180, 180, 180, 255")]
	public Color StatSubtitleColor { get; set; }

	[Label("Stat value color")]
	[Tooltip("A value might be '24mph' or '3s'")]
	[DefaultValue(typeof(Color), "255, 255, 255, 255")]
	public Color StatValueColor { get; set; }
}