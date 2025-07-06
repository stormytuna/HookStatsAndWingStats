using FishUtils.Helpers;
using HookStatsAndWingStats.Common.Configs;
using HookStatsAndWingStats.Core.Enums;
using HookStatsAndWingStats.DataStructures;
using HookStatsAndWingStats.Helpers;
using Humanizer;
using Terraria;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Core;

public abstract class TooltipStat(object value) : ILoadable
{
	public object Value { get; } = value;
	
	public abstract ComparisonResult Compare(TooltipStat other);

	public virtual bool IsEnabled {
		get => true;
	}
	
	public virtual string FormattedValue {
		get => Value.ToString();
	}
	
	public virtual string InternalName {
		get => GetType().Name;
	}

	public virtual LocalizedText Subtitle {
		get => HookStatsAndWingStats.Instance.GetLocalization($"StatSubtitles.{InternalName}");
	}

	public void Load(Mod mod) {
		_ = Subtitle;
	}

	public void Unload() { }

	public virtual string GetFormattedSubtitle() {
		var subtitle = $"{Subtitle.Value}:";
		return subtitle.ApplyColor(MiscConfig.Instance.StatSubtitleColor.WithMouseTextPulsing());
	}
	
	public string GetFormattedValueOrComparison(TooltipStat other = null) {
		if (other is null) {
			return FormattedValue.ApplyColor(MiscConfig.Instance.StatValueColor.WithMouseTextPulsing());
		}
		
		var defaultColor = MiscConfig.Instance.StatValueColor.WithMouseTextPulsing().Hex3();
		var betterColor = MiscConfig.Instance.ComparisonBetterColor.WithMouseTextPulsing().Hex3();
		var worseColor = MiscConfig.Instance.ComparisonWorseColor.WithMouseTextPulsing().Hex3();
		var equalColor = MiscConfig.Instance.ComparisonEqualColor.WithMouseTextPulsing().Hex3();
		string comparisonTemplate = "[c/{2}:{3}] → [c/{0}:{1}]";
		
		return Compare(other) switch {
			ComparisonResult.Equal => comparisonTemplate.FormatWith(equalColor, FormattedValue, defaultColor, other.FormattedValue),
			ComparisonResult.Better => comparisonTemplate.FormatWith(betterColor, FormattedValue, defaultColor, other.FormattedValue),
			ComparisonResult.Worse => comparisonTemplate.FormatWith(worseColor, FormattedValue, defaultColor, other.FormattedValue),
			_ => FormattedValue,
		};
	}
}
