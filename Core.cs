﻿using BetterVendors.Utilities;
using Kingmaker.PubSubSystem;
using ModMaker;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using static BetterVendors.Main;
using static BetterVendors.Utilities.SettingsWrapper;
using BetterVendors.Vendors;
using ModMaker.Utility;

namespace BetterVendors
{
    class Core :
        IModEventHandler
    {
        public int Priority => 200;

        public void ResetSettings()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            Mod.ResetSettings();
            Mod.Settings.lastModVersion = Mod.Version.ToString();
            LocalizationFileName = Local.FileName;
            VendorBlueprints.ResetPositions();
        }
        public void HandleModEnable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            if (!string.IsNullOrEmpty(LocalizationFileName))
            {
                Local.Import(LocalizationFileName, e => Mod.Error(e));
                LocalizationFileName = Local.FileName;
            }
            
            if (!Version.TryParse(Mod.Settings.lastModVersion, out Version version) || version < new Version(2, 0, 0))
                ResetSettings();
            else
            {
                Mod.Settings.lastModVersion = Mod.Version.ToString();
            }

            EventBus.Subscribe(this);
        }

        public void HandleModDisable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            EventBus.Unsubscribe(this);
        }
    }
}