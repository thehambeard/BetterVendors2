﻿using BetterVendors.Utilities;
using BetterVendors.Vendors;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using ModMaker;
using ModMaker.Utility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityModManagerNet;
using static BetterVendors.Main;
using GL = UnityEngine.GUILayout;

namespace BetterVendors.Menus
{
    class ThroneRoom : IMenuSelectablePage
    {
        public string Name => Local["Menu_Tab_TRV"];

        public int Priority => 100;
        private string tpEP = "";

        private static GUILayoutOption[] falseWidth = new GUILayoutOption[] { GUILayout.ExpandWidth(false) };
        private static List<string> oldVendors = new List<string> { "e0449cfcf8ad6084ebfc161fb73e9a27", "dbd0b3fced8738247b7c87dc77ef74f6", "478862ab88b8ef24385cb386c1644dc2", "3c7ad1ac37ba5224b93d77dd9b6ab723" };

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
#if (DEBUG)
            OnGUIDebugFunctions();
#endif
            if (!Mod.Enabled) return;
            if (!MenuHelpers.NotInGameMessage()) return;
            OnGUIMerchant();
            OnGUITrash();
            OnGUIThroneRoom();
        }
#if (DEBUG)
        private void OnGUIDebugFunctions()
        {
            using (new GUISubScope("Debug", "box"))
            {
                if (Game.Instance.Player.MainCharacter != null)
                {
                    var position = Game.Instance.Player.MainCharacter.Value.Position;
                    var rotation = Game.Instance.Player.MainCharacter.Value.OrientationDirection;
                    var combined = $"{position.x}f, {position.y}f, {position.z}f {rotation.x}f, {rotation.y}f, {rotation.z}f";
                    GL.TextField(combined, falseWidth);
                }
                if (GL.Button("TP Throne Room", falseWidth))
                {
                    GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>("21fb2ff53d1e2fb4c9b06f067ab89435"), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }
                if (GL.Button("TP Stone Throne", falseWidth))
                {
                    GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>("3a9748aba32e1694f80a6cae9b7b3f99"), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }
                if (GL.Button("TP Guild", falseWidth))
                {
                    GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>("26b7b66f082f46dd8e9223be3148b5ad"), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }
                tpEP = GL.TextField(tpEP);
                if (GL.Button("TP EP", falseWidth))
                {
                    if (tpEP != "")
                        GameHelper.EnterToArea(Library.Get<BlueprintAreaEnterPoint>(tpEP), Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
                }

                if (GL.Button("Reload Library", falseWidth))
                {
                    Library = ResourcesLibrary.LibraryObject;
                    Helpers.Load();
                    Helpers.Reload();
                }
                if (GL.Button("Add Stock", falseWidth))
                {
                    Vendors.ProgressionLogic.AddStock();
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
                if (GL.Button("Recreate VendorTables", falseWidth))
                    VendorTableBlueprints.CreateVendorTables();
                if (GL.Button("Reset Vendors", falseWidth))
                {
                    VendorBlueprints.ResetPositions();
                }
                if (GL.Button("Respawn Guild", falseWidth))
                {
                    MechantGuild.LibraryLoad(true);
                }
                if (GL.Button("Test getter/setter", falseWidth))
                {
                    BlueprintAbilityResource bar = Library.Get<BlueprintAbilityResource>("17b6158d363e4844fa073483eb2655f8");
                    bar.TestSetGet();
                }
            }
        }
#endif

        private void OnGUIMerchant()
        {
            using (new GUISubScope("Merchant Guild", "box"))
            {
                GUI.enabled = (HamHelpers.InThroneRoom() || HamHelpers.InGuildHall());
                GL.Label(Local["Menu_Lbl_Teleport"], MenuHelpers.LabelStyleWrap, falseWidth);
                if (GL.Button(Local["Menu_Btn_Teleport"], MenuHelpers.ButtonStyle, falseWidth))
                {
                    Vendors.MechantGuild.TP();
                }
                GUI.enabled = true;
            }

        }

        private void OnGUITrash()
        {
            using (new GUISubScope("Vendor Trash", "box"))
            {
                GUI.enabled = HamHelpers.InValidSellArea();
                GL.Label(Local["Menu_Lbl_TrashIt"], MenuHelpers.LabelStyleWrap, falseWidth);
                if (GL.Button(Local["Menu_Btn_TrashIt"], MenuHelpers.ButtonStyle, falseWidth))
                {
                    VendorTrashController.Trash();
                }
                GUI.enabled = true;
            }
        }

        private void OnGUIThroneRoom()
        {
            using (new GUISubScope(Local["Menu_Tab_TRV"], "box"))
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
                
                GL.Label(Local["Menu_Txt_CleanOld"]);
                if (GL.Button(Local["Menu_Btn_CleanOld"], MenuHelpers.ButtonStyle, falseWidth))
                {
                    foreach (UnitEntityData unit in Game.Instance.State.Units)
                    {
                        if (oldVendors.Contains(unit.Blueprint.AssetGuid))
                            unit.Destroy();
                    }
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
                    if (GL.Button(Local["Menu_Btn_Enable"], MenuHelpers.ButtonStyle, falseWidth))
                    {
                        SettingsWrapper.VendorEnabled[vendor.UnitGuid] = true;
                        vendor.Enable();
                    }
                    if (GL.Button(Local["Menu_Btn_Disable"], MenuHelpers.ButtonStyle, falseWidth))
                    {
                        SettingsWrapper.VendorEnabled[vendor.UnitGuid] = false;
                        vendor.Disable();
                    }
                }
            }
        }
    }
}
