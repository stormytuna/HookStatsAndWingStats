# Hook Stats and Wing Stats

## Mod Calls

You can use these calls any point after this mods' `PostSetupContent` hooks are finished called. If the base stats of any of your hooks or wings change during gameplay, consider updating them in this mods' database with one of the following calls.

If you'd like to use a call inside `PostSetupContent`, make sure to set `sortAfter=HookStatsAndWingStats` in `build.txt` so your changes are not overwritten by this mod.

This mod makes some assumptions about hooks and wings to autopopulate stats:
- Hook items set `.shoot` to a projectile with `.aiStyle == 7`
- Wing items set `.wingSlot` to a value `>= 0` (NOTE: This is automatically done for you if you use the `[AutoLoadEquip(EquipType.Wings)]` attribute.)

These assumptions are made once during loading, and are only used to autopopulate the database. If you have any items that don't fit these assumptions, you are able to use the calls to set their stats.

If you're adding support for this mod where there was none previously, please see the [hook stats] and [wing stats] source code to see if I've manually added support already. If you see your mod mentioned in either of those files, reach out to me via discord so I can remove it from this mod.

### SetHookStats

`.Call("SetHookStats", int hookItemType, float hookReach, float hookShootSpeed, int numHooks, int latchingType)`
- `int hookItemType`, the item type of the hook you're setting.
- `float hookReach`, the maximum reach of the hook in pixels, this is the same value you would return in `ModProjectile.GrappleRange`.
- `float hookShootSpeed`, the speed the hook is shot at in pixels per frame, this is the same value you would set `Item.shootSpeed` to.
- `int numHooks`, the number of hooks the player is able to have out simultaneously.
- `int latchingType`, the latching behaviour of the hook. Can be one of:
    - 0, Single, the hook shoots 1 hook, and only one hook may be latched at once. (ex. Grappling Hook, Emerald Hook, Hook of Dissonance.)
    - 1, Individual, the hook can shoot multiple hooks, but only one hook may be latched at once. (ex. Web Slinger, Dual Hook, Static Hook.)
    - 2, Simultaneous, the hook can shoot multiple hooks, and multiple hooks can be latched at once. (ex. Slime Hook, Illuminant Hook, Lunar Hook.)
    - 3, Special, anything not covered by the above (no vanilla hooks fit this.)

### SetWingStats

`.Call("SetWingStats", int wingItemType, int maxFlightTime, float horizontalSpeed, float verticalSpeedMultiplier)`
- `int wingItemType`, the item type of the wings you're setting.
- `int maxFlightTime`, the maximum flight time in frames, this is the same value you would pass as `flyTime` in the `WingStats` constructor. If your wings have an infinite flight time, pass `int.MaxValue`.
- `float horizontalSpeed`, the maximum horizontal speed in pixels per frame, this is the same value you would pass as `flySpeedOverride` in the `WingStats` constructor.
- `float verticalSpeedMultiplier`, the vertical speed multiplier as a decimal, this is the same value you would set `maxAscentMultiplier` to in `ModItem.VerticalWingSpeeds`.
