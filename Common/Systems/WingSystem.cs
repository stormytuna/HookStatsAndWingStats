using System.Collections.Generic;
using System.Linq;
using HookStatsAndWingStats.DataStructures;
using MonoMod.RuntimeDetour;

namespace HookStatsAndWingStats.Common.Systems;

public class WingSystem : ModSystem
{
	public static Dictionary<int, WingStats> ItemTypeToWingStats { get; private set; } = new();

	public override void PostSetupContent() {
		InitializeDefaultValues();
		InititalizeKnownModdedValues();
	}

	public override void Unload() {
		ItemTypeToWingStats.Clear();
		ItemTypeToWingStats = null;
	}

	private static void InitializeDefaultValues() {
		ItemTypeToWingStats.Add(ItemID.CreativeWings, new WingStats(ItemID.CreativeWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.AngelWings, new WingStats(ItemID.AngelWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.DemonWings, new WingStats(ItemID.DemonWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LeafWings, new WingStats(ItemID.LeafWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FairyWings, new WingStats(ItemID.FairyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FinWings, new WingStats(ItemID.FinWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FrozenWings, new WingStats(ItemID.FrozenWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.HarpyWings, new WingStats(ItemID.HarpyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Jetpack, new WingStats(ItemID.Jetpack, 1.50f));
		ItemTypeToWingStats.Add(ItemID.RedsWings, new WingStats(ItemID.RedsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.DTownsWings, new WingStats(ItemID.DTownsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.WillsWings, new WingStats(ItemID.WillsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.CrownosWings, new WingStats(ItemID.CrownosWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.CenxsWings, new WingStats(ItemID.CenxsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BejeweledValkyrieWing, new WingStats(ItemID.BejeweledValkyrieWing, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Yoraiz0rWings, new WingStats(ItemID.Yoraiz0rWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.JimsWings, new WingStats(ItemID.JimsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.SkiphsWings, new WingStats(ItemID.SkiphsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LokisWings, new WingStats(ItemID.LokisWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.ArkhalisWings, new WingStats(ItemID.ArkhalisWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.LeinforsWings, new WingStats(ItemID.LeinforsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.GhostarsWings, new WingStats(ItemID.GhostarsWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.SafemanWings, new WingStats(ItemID.SafemanWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FoodBarbarianWings, new WingStats(ItemID.FoodBarbarianWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.GroxTheGreatWings, new WingStats(ItemID.GroxTheGreatWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BatWings, new WingStats(ItemID.BatWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.BeeWings, new WingStats(ItemID.BeeWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.ButterflyWings, new WingStats(ItemID.ButterflyWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.FlameWings, new WingStats(ItemID.FlameWings, 1.50f));
		ItemTypeToWingStats.Add(ItemID.Hoverboard, new WingStats(ItemID.Hoverboard, 1.66f));
		ItemTypeToWingStats.Add(ItemID.BoneWings, new WingStats(ItemID.BoneWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.MothronWings, new WingStats(ItemID.MothronWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.GhostWings, new WingStats(ItemID.GhostWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.BeetleWings, new WingStats(ItemID.BeetleWings, 1.66f));
		ItemTypeToWingStats.Add(ItemID.FestiveWings, new WingStats(ItemID.FestiveWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.SpookyWings, new WingStats(ItemID.SpookyWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.TatteredFairyWings, new WingStats(ItemID.TatteredFairyWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.SteampunkWings, new WingStats(ItemID.SteampunkWings, 1.80f));
		ItemTypeToWingStats.Add(ItemID.BetsyWings, new WingStats(ItemID.BetsyWings, 2.50f));
		ItemTypeToWingStats.Add(ItemID.FishronWings, new WingStats(ItemID.FishronWings, 2.50f));
		ItemTypeToWingStats.Add(ItemID.RainbowWings, new WingStats(ItemID.RainbowWings, 2.75f));
		ItemTypeToWingStats.Add(ItemID.WingsNebula, new WingStats(ItemID.WingsNebula, 2.45f));
		ItemTypeToWingStats.Add(ItemID.WingsVortex, new WingStats(ItemID.WingsVortex, 2.45f));
		ItemTypeToWingStats.Add(ItemID.WingsSolar, new WingStats(ItemID.WingsSolar, 3.00f));
		ItemTypeToWingStats.Add(ItemID.WingsStardust, new WingStats(ItemID.WingsStardust, 3.00f));
		ItemTypeToWingStats.Add(ItemID.LongRainbowTrailWings, new WingStats(ItemID.LongRainbowTrailWings, 4.50f));

		foreach ((int _, Item item) in ContentSamples.ItemsByType.Skip(ItemID.Count)) {
			if (item.wingSlot >= 0) {
				Player dummyPlayer = new();
				float unused1 = 0.5f;
				float unused2 = 0.1f;
				float unused3 = 0.1f;				
				float verticalMult = 1.5f;
				float unused4 = 0.1f;

				try {
					item.ModItem.VerticalWingSpeeds(dummyPlayer, ref unused1, ref unused2, ref unused3, ref verticalMult, ref unused4);
					TryAddModdedWing(item, verticalMult);
				} catch {
					HookStatsAndWingStats.Instance.Logger.Error("Ran into an issue trying to fetch vertical speeds for " + ItemID.Search.GetName(item.type));
					TryAddModdedWing(item, null);
					return;
				}
			}
		}
	}

	private static void InititalizeKnownModdedValues() {
		TryUpdateModdedWingStats("FargowiltasSouls", "DimensionSoul", int.MaxValue, 25f, 3.00f);
		TryUpdateModdedWingStats("FargowiltasSouls", "EternitySoul", int.MaxValue, 25f, 3.00f);
		TryUpdateModdedWingStats("FargowiltasSouls", "FlightMasterySoul", int.MaxValue, 18f, 3.00f);
	}

	private static void TryUpdateModdedWingStats(string modName, string itemName, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) {
		if (ModContent.TryFind(modName, itemName, out ModItem modItem)) {
			ItemTypeToWingStats[modItem.Type] = new WingStats(maxFlightTime, horizontalSpeed, verticalSpeedMultiplier);
		}
	}

	private static void TryAddModdedWing(Item item, float? verticalMult = null) {
		if (!ItemTypeToWingStats.ContainsKey(item.type)) {
			ItemTypeToWingStats[item.type] = new WingStats(item.type, verticalMult);
		}
	}

	public static void AddModdedWing(int itemType, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier) {
		ItemTypeToWingStats[itemType] = new WingStats(maxFlightTime, horizontalSpeed, verticalSpeedMultiplier);
	}
}
