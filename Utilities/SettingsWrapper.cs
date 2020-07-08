using static BetterVendors.Main;
using System.Collections.Generic;
using UnityEngine;
using ModMaker.Utility;

namespace BetterVendors.Utilities
{
    public static class SettingsWrapper
    {
        public static string LocalizationFileName
        {
            get => Mod.Settings.localizationFileName;
            set => Mod.Settings.localizationFileName = value;
        }

        public static string ModPath
        {
            get => Mod.Settings.modPath;
            set => Mod.Settings.modPath = value;
        }

        public static HashSet<string> VendorTrashItems
        {
            get => Mod.Settings.garbage;
            set => Mod.Settings.garbage = value;
        }

        public static Color TrashColor
        {
            get => Mod.Settings.trashColor;
            set => Mod.Settings.trashColor = value;
        }

        public static Color ScrollColor
        {
            get => Mod.Settings.scrollColor;
            set => Mod.Settings.scrollColor = value;
        }
        public static bool ToggleHighlightScrolls
        {
            get => Mod.Settings.toggleHighlightScrolls;
            set => Mod.Settings.toggleHighlightScrolls = value;
        }
        public static bool ToggleVendorTrash
        {
            get => Mod.Settings.toggleVendorTrash;
            set => Mod.Settings.toggleVendorTrash = value;
        }

        public static bool ToggleAutoSell
        {
            get => Mod.Settings.toggleAutoSell;
            set => Mod.Settings.toggleAutoSell = value;
        }

        public static bool ToggleVendorProgression
        {
            get => Mod.Settings.toggleVendorProgression;
            set => Mod.Settings.toggleVendorProgression = value;
        }

        public static bool ToggleShowTrash
        {
            get => Mod.Settings.toggleShowTrash;
            set => Mod.Settings.toggleShowTrash = value;
        }

        public static SerializableDictionary<string, Vector3> Positions
        {
            get => Mod.Settings.positions;
            set => Mod.Settings.positions = value;
        }
        public static SerializableDictionary<string, Vector3> Rotations
        {
            get => Mod.Settings.rotations;
            set => Mod.Settings.rotations = value;
        }
    }
}