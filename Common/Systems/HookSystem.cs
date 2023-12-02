using System.Collections.Generic;
using HookStatsAndWingStats.Helpers;
using HookStatsAndWingStats.HookStats;
using Terraria.ID;
using Terraria.ModLoader;

namespace HookStatsAndWingStats.Common.Systems;

public class HookSystem : ModSystem
{
	public static Dictionary<string, HookStatSet> HookStats { get; private set; } = new();

	public override void PostSetupContent() {
		Init_VanillaHooks();
		Init_ModdedHooks();
	}

	public override void Unload() {
		HookStats = null;
	}

	private void Init_VanillaHooks() {
		// Pre HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.GrapplingHook)}", new HookStatSet(18.75f * 16f, 11.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmethystHook)}", new HookStatSet(18.75f * 16f, 10f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SquirrelHook)}", new HookStatSet(19 * 16f, 11.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TopazHook)}", new HookStatSet(20.625f * 16f, 10.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SapphireHook)}", new HookStatSet(22.5f * 16f, 11f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.EmeraldHook)}", new HookStatSet(24.375f * 16f, 11.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.RubyHook)}", new HookStatSet(26.25f * 16f, 12f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AmberHook)}", new HookStatSet(27.5f * 16f, 12.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DiamondHook)}", new HookStatSet(29.125f * 16f, 12.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WebSlinger)}", new HookStatSet(22.625f * 16f, 10f, 8, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SkeletronHand)}", new HookStatSet(21.875f * 16f, 15f, 2, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SlimeHook)}", new HookStatSet(18.75f * 16f, 13f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.FishHook)}", new HookStatSet(25f * 16f, 13f, 2, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IvyWhip)}", new HookStatSet(28f * 16f, 13f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.BatHook)}", new HookStatSet(31.25f * 16f, 13.5f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.CandyCaneHook)}", new HookStatSet(25f * 16f, 11.5f, 1, Enums.HookLatchingType.Single));

		// HM
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.DualHook)}", new HookStatSet(27.5f * 16f, 14f, 2, Enums.HookLatchingType.Individual));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.QueenSlimeHook)}", new HookStatSet(30f * 16f, 16f, 1, Enums.HookLatchingType.Single));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ThornHook)}", new HookStatSet(30f * 16f, 16f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.IlluminantHook)}", new HookStatSet(30f * 16f, 15f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.WormHook)}", new HookStatSet(30f * 16f, 15f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.TendonHook)}", new HookStatSet(30f * 16f, 15f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.AntiGravityHook)}", new HookStatSet(31.25f * 16f, 14f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.SpookyHook)}", new HookStatSet(34.375f * 16f, 15.5f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.ChristmasHook)}", new HookStatSet(34.375f * 16f, 15.5f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.LunarHook)}", new HookStatSet(34.375f * 16f, 18f, 4, Enums.HookLatchingType.Simultaneous));
		HookStats.Add($"Terraria:{ItemID.Search.GetName(ItemID.StaticHook)}", new HookStatSet(37.5f * 16f, 16f, 2, Enums.HookLatchingType.Individual));
	}

	private void Init_ModdedHooks() {
		HookStats.Add("SOTS:WormWoodHook", new HookStatSet(80f, 15f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("SOTS:InfernoHook", new HookStatSet(510, 26f, 1, Enums.HookLatchingType.Single));

		HookStats.Add("OrchidMod:MineshaftHook", new HookStatSet(400f, 12f, 2, Enums.HookLatchingType.Single));

		HookStats.Add("Gensokyo:TsuchigomoWebSlinger", new HookStatSet(300f, 10f, 8, Enums.HookLatchingType.Simultaneous));

		HookStats.Add("StormDiversMod:EyeHook", new HookStatSet(528f, 12f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("StormDiversMod:StormHook", new HookStatSet(512f, 18f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("StormDiversMod:DerpHook", new HookStatSet(496f, 16f, 3, Enums.HookLatchingType.Simultaneous));

		HookStats.Add("Redemption:RopeHook", new HookStatSet(500f, 16f, 1, Enums.HookLatchingType.Single));

		HookStats.Add("ThoriumMod:SpringHook", new HookStatSet(17f * 16f, 12f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:OpalHook", new HookStatSet(340f, 10.75f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:AquamarineHook", new HookStatSet(350f, 10.75f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:Leviathan", new HookStatSet(430f, 14f, 10, Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:JewellersWallGrip", new HookStatSet(450f, 13f, 2, Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:AmmutsebaSash", new HookStatSet(480f, 15f, 1, Enums.HookLatchingType.Single));
		HookStats.Add("ThoriumMod:FungalHook", new HookStatSet(480f, 16f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:NeptuneGrasp", new HookStatSet(480f, 15f, 4, Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:DevilsReach", new HookStatSet(520f, 15f, 3, Enums.HookLatchingType.Simultaneous));
		HookStats.Add("ThoriumMod:GhostlyGrapple", new HookStatSet(550f, 16f, 2, Enums.HookLatchingType.Simultaneous));
	}
}