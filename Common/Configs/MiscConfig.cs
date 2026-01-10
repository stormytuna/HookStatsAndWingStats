using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace HookStatsAndWingStats.Common.Configs;

public class MiscConfig : ModConfig
{
	public static MiscConfig Instance {
		get => ModContent.GetInstance<MiscConfig>();
	}

	public static string GetDecimalPlaceFormatter() {
		int numDecimalPlaces = Instance.DecimalPrecision;
		return new string('#', numDecimalPlaces);
	}

	public override ConfigScope Mode {
		get => ConfigScope.ClientSide;
	}

	[DefaultValue(1)]
	[Slider]
	[Range(0, 4)]
	public int DecimalPrecision { get; set; }

	[DefaultValue(false)]
	public bool ShowUnknownStats { get; set; }

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
