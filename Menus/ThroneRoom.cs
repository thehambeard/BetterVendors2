﻿using ModMaker;
using UnityEngine;
using UnityModManagerNet;
using GL = UnityEngine.GUILayout;
using GLO = UnityEngine.GUILayoutOption;
using static BetterVendors.Main;
using ModMaker.Utility;
using BetterVendors.Utilities;
using Kingmaker;
using System.Linq;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using BetterVendors.Vendors;
using Kingmaker.Designers;
using Kingmaker.Blueprints.Area;

namespace BetterVendors.Menus
{
    class ThroneRoom : IMenuSelectablePage
    {
        public string Name => Local["Menu_Tab_TRV"];

        public int Priority => 100;
        
        private static GUILayoutOption[] falseWidth = new GUILayoutOption[] { GUILayout.ExpandWidth(false) };

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
#if (DEBUG)
            OnGUIDebugFunctions();
#endif
            
            if (!Mod.Enabled) return;
            if (!MenuHelpers.NotInGameMessage()) return;
            OnGUIMerchant();
            OnGUIThroneRoom();
            
        }

        private void OnGUIDebugFunctions()
        {
            using (new GUISubScope("Debug", "box"))
            {
                string combined = "";
                if (GL.Button("Player", falseWidth))
                {
                    var position = Game.Instance.Player.MainCharacter.Value.Position;
                    var rotation = Game.Instance.Player.MainCharacter.Value.OrientationDirection;
                    combined = $"{position.x}f, {position.y}f, {position.z}f {rotation.x}f, {rotation.y}f, {rotation.z}f";
                }
                GL.TextField(combined, falseWidth);
                if (GL.Button("TP Throne Room", falseWidth))
                {
                    GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>("21fb2ff53d1e2fb4c9b06f067ab89435"), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }
                if (GL.Button("TP Stone Throne", falseWidth))
                {
                    GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>("3a9748aba32e1694f80a6cae9b7b3f99"), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }
                if (GL.Button("Reload Library", falseWidth))
                {
                    Library = ResourcesLibrary.LibraryObject;
                    Helpers.Load();
                    Helpers.Reload();
                }
                if (GL.Button("Spawn Throne Vendors", falseWidth))
                {
                    Vendors.ThroneRoom.HandleAreaLoad();
                }
                if (GL.Button("Despawn Throne Vendors", falseWidth))
                {
                    foreach (KeyValuePair<string, Vendors.Vendor> kvp in Vendors.VendorBlueprints.NewVendors.Where(n => n.Value.AreaId == Vendors.Vendor.Area.ThroneRoom))
                    {
                        kvp.Value.Destroy();
                    }
                }
                if (GL.Button("Recreate Vendors", falseWidth))
                {
                    VendorBlueprints.CreateAllVendors();
                }
                if (GL.Button("Reset Vendors", falseWidth))
                {
                    VendorBlueprints.ResetPositions();
                }
                if (GL.Button("Respawn Guild", falseWidth))
                {
                    MechantGuild.LibraryLoad(true);
                }
                if (GL.Button("Library Information", falseWidth))
                {
                    Helpers.GuidStorage.dump($@"{SettingsWrapper.ModPath}blueprints.txt");
                }
            }
        }

        private void OnGUIMerchant()
        {
            using (new GUISubScope("Merchant Guild", "box"))
            {
                GUI.enabled = (GUI.enabled = (HamHelpers.InThroneRoom() || HamHelpers.InGuildHall()));
                GL.Label(Local["Menu_Lbl_Teleport"], MenuHelpers.LabelStyleWrap, falseWidth);
                if (GL.Button(Local["Menu_Btn_Teleport"], MenuHelpers.ButtonStyle, falseWidth))
                {
                    Vendors.MechantGuild.TP();
                }
                GUI.enabled = true;
            }
        }

        private void OnGUIThroneRoom()
        {
            using (new GUISubScope("Throne Room Vendors", "box"))
            {
                if (!HamHelpers.InThroneRoom())
                {
                    GL.Label(Local["Menu_Txt_NotInThrone"]);
                    return;
                }
                GL.Label(Local["Menu_Lbl_MoveVendor"], MenuHelpers.LabelStyleWrap, falseWidth);
                foreach (KeyValuePair<string, Vendors.Vendor> kvp in Vendors.VendorBlueprints.NewVendors.Where(n => n.Value.AreaId == Vendors.Vendor.Area.ThroneRoom))
                {
                    OnGUIVendors(kvp.Value);
                }
                GUI.enabled = true;
            }
        }
        private void OnGUIVendors(Vendors.Vendor vendor)
        {
            using (new GUISubScope())
            {
                
                using (new GL.HorizontalScope())
                {
                    GL.Label(string.Format("{0}: ", vendor.DisplayName), MenuHelpers.LabelStyleFixed, falseWidth);
                    if (GL.Button(Local["Menu_Btn_MoveVendor"], MenuHelpers.ButtonStyle, falseWidth))
                    {
                        var position = Game.Instance.Player.MainCharacter.Value.Position;
                        var rotation = Game.Instance.Player.MainCharacter.Value.OrientationDirection;

                        SettingsWrapper.Positions[vendor.UnitGuid] = position;
                        SettingsWrapper.Rotations[vendor.UnitGuid] = rotation;
                        vendor.Move(position, rotation);
                    }
                }
            }
        }
    }
}
