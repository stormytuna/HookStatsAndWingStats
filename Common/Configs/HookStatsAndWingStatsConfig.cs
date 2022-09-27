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

        [Header("Wing Stats")]

        [Label("Display wing stats")]
        [DefaultValue(true)]
        public bool DisplayWingStats { get; set; }

        [Label("Wing stats title color")]
        [DefaultValue(typeof(Color), "255, 0, 127, 255")]
        public Color WingStatsTitleColor { get; set; }

        [Label("Display current flight time")]
        [DefaultValue(true)]
        public bool DisplayCurrentWingTime { get; set; }

        [Label("Display max flight time")]
        [DefaultValue(true)]
        public bool DisplayMaxWingTime { get; set; }

        [Label("Combine current and max flight time")]
        [Tooltip("Will be displayed as Flight time: [current]/[max]")]
        [DefaultValue(true)]
        public bool CombineCurrentAndMaxWingTime { get; set; }

        [Label("Display flight time in seconds")]
        [Tooltip("Disabling this displays flight time in frames")]
        [DefaultValue(true)]
        public bool DisplayFlightTimeInSeconds { get; set; }

        [Label("Display wing horizontal speed")]
        [DefaultValue(true)]
        public bool DisplayWingHorizontalSpeed { get; set; }

        [Label("Wing horizontal speed is measured in mph")]
        [Tooltip("Turning this off will display speed in raw units instead of mph\nDisplaying in mph may cause descrepencies due to rounding errors")]
        [DefaultValue(true)]
        public bool HorizontalSpeedMeasuredInMPH { get; set; }

        [Label("Display wing vertical speed multiplier")]
        [DefaultValue(true)]
        public bool DisplayWingVerticalSpeedMult { get; set; }

        [Label("Display wing vertical speed multiplier even when unknown")]
        [Tooltip("Sometimes the vertical speed multiplier stat will not be found correctly. With this set to true, it will display as unknown instead of not being displayed")]
        [DefaultValue(false)]
        public bool DisplayWingVerticalSpeedMultEvenWhenUnknown { get; set; }
    }
}