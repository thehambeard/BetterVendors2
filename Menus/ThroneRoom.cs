using ModMaker;
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
                if (GL.Button("Reload Library", falseWidth))
                {
                    Mod.Debug(Main.Library == null);
                    Main.Library = ResourcesLibrary.LibraryObject;
                    //Helpers.GuidStorage.load(Properties.Resources.blueprints, true);
                    //Vendors.VendorBlueprints.CreateAllVendors();
                    //Vendors.MechantGuild.CreateMerchantGuild();
                }
                if (GL.Button("Spawn Throne Vendors", falseWidth))
                {
                    Vendors.ThroneRoom.HandleAreaLoad();
                }
                if (GL.Button("Despawn Vendors", falseWidth))
                {
                    foreach (KeyValuePair<string, Vendors.Vendor> kvp in Vendors.VendorBlueprints.NewVendors.Where(n => n.Value.AreaId == Vendors.Vendor.Area.ThroneRoom))
                    {
                        kvp.Value.Destroy();
                    }
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
                        vendor.Move(Game.Instance.Player.MainCharacter.Value.Position, 
                            Game.Instance.Player.MainCharacter.Value.OrientationDirection);
                    }
                }
            }
        }
    }
}
