using BetterVendors.Vendors;
using Kingmaker.PubSubSystem;
using ModMaker;
using System;
using System.Reflection;
using UnityEngine;
using static BetterVendors.Main;
using static BetterVendors.Utilities.SettingsWrapper;

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
            ToggleAutoSell = false;
            ToggleHighlightScrolls = true;
            ToggleShowTrash = true;
            ToggleVendorProgression = true;
            ToggleVendorTrash = true;
            ScrollColor = new Color(0f, 1f, 0f, 1f);
            TrashColor = new Color(1f, 0f, 0f, .2f);
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

            if (!Version.TryParse(Mod.Settings.lastModVersion, out Version version) || version > new Version(2, 1, 0))
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