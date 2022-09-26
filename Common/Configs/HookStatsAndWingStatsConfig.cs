using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace HookStatsAndWingStats.Common.Configs
{
    public class HookStatsAndWingStatsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Hook Stats")]

        [Label("Display hook stats")]
        [DefaultValue(true)]
        public bool DisplayHookStats { get; set; }

        [Label("Hook stats title color")]
        [DefaultValue(typeof(Color), "255, 164, 0, 255")]
        public Color HookStatsTitleColor { get; set; }

        [Label("Display reach")]
        [DefaultValue(true)]
        public bool DisplayHookReach { get; set; }

        [Label("Display velocity")]
        [DefaultValue(true)]
        public bool DisplayHookVelocity { get; set; }

        [Label("Display hook count")]
        [DefaultValue(true)]
        public bool DisplayHookCount { get; set; }

        [Label("Display latching type")]
        [DefaultValue(true)]
        public bool DisplayHookLatchingType { get; set; }
    }
}