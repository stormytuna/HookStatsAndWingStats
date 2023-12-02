using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;

namespace HookStatsAndWingStats.Helpers;

public struct ColoredText
{
	private readonly string text;
	private readonly Color color;

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