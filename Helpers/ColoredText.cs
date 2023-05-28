using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;

namespace HookStatsAndWingStats.Helpers;

public class ColoredText
{
	private string text { get; }
	private Color color { get; }

	public string Value {
		get {
			Color mouseTextColor = color * (Main.mouseTextColor / 255f);
			return $"[c/{mouseTextColor.Hex3()}:{text}]";
		}
	}

	public static string Parse(string seperator, params ColoredText[] coloredTexts) {
		string result = "";

		for (int i = 0; i < coloredTexts.Length - 1; i++) {
			result += $"{coloredTexts[i].Value}{seperator}";
		}

		result += $"{coloredTexts.Last().Value}";
		return result;
	}

	public ColoredText(string text, Color color) {
		this.text = text;
		this.color = color;
	}
}