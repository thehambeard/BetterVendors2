using Kingmaker;
using ModMaker;
using ModMaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityModManagerNet;
using static BetterVendors.Main;
using GL = UnityEngine.GUILayout;
using VTI = BetterVendors.Vendors.VendorInject;


namespace BetterVendors.Menus
{
    class VendorInject : IMenuSelectablePage
    {
        public string Name => Local["Menu_Tab_Inject"];

        public int Priority => 300;

        private string searchString = "";
        private static GUILayoutOption[] falseWidth = new GUILayoutOption[] { GUILayout.ExpandWidth(false) };
        Dictionary<string, string> results = new Dictionary<string, string>();
        private static int vendorToolbar = 0;
        
        private string itemAdded = "";

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (!Mod.Enabled) return;
            if (!Game.Instance.Player.ControllableCharacters.Any())
            {
                GL.Label(Local["Menu_Lbl_NotInGame"]);
                return;
            }
            using (new GL.VerticalScope("box"))
            {
                GUILayout.Label(Local["Menu_Txt_Search"]);
                using (new GL.HorizontalScope())
                {
                    bool isDirty = false;
                    GUIHelper.TextField(ref searchString, () => isDirty = true);
                    if (isDirty && searchString.Length > 2)
                    {
                        results = Vendors.VendorInject.SearchItems(searchString);
                    }
                }
                try
                {
                    if (results != null && results.Count > 0)
                    {
                        /*
                        GUILayout.Label(Local["Menu_Txt_VendorPick"], falseWidth);
                        vendorToolbar = GUILayout.Toolbar(vendorToolbar, VTI.VendorTableIds.Keys.ToArray(), new GUIStyle(GUI.skin.button) { wordWrap = true, fixedHeight = 50f }, new GUILayoutOption[] { GL.MaxWidth(800f) });
                        if (GUILayout.Button(string.Format(Local["Menu_Btn_AddAll"], vendorToolbar), falseWidth))
                        {
                            results = Vendors.VendorInject.SearchItems(searchString);
                            foreach (KeyValuePair<string, string> item in results)
                            {
                                Vendors.VendorInject.AddItemToVendor(item.Key, Vendors.VendorInject.VendorTableIds[vendors[vendorToolbar]]);
                            }
                        }
                        foreach (KeyValuePair<string, string> item in results.OrderBy(x => x.Value))
                        {
                            using (new GL.HorizontalScope())
                            {
                                GUILayout.TextField(item.Key, new GUIStyle(GUI.skin.textField) { fixedWidth = 250f });
                                bool flagAdd = GUILayout.Button(string.Format(Local["Menu_Txt_AddToVendor"], item.Value, vendors[vendorToolbar]), falseWidth);
                                if (flagAdd)
                                {
                                    Vendors.VendorInject.AddItemToVendor(item.Key, Vendors.VendorInject.VendorTableIds[vendors[vendorToolbar]]);
                                    itemAdded = item.Key;
                                    
                                }
                                if (item.Key.Equals(itemAdded))
                                    GUILayout.Label(Local["Menu_Txt_ItemAdded"], falseWidth);
                            }
                        }
                        */
                    }
                    else
                        GUILayout.Label(Local["Menu_Lbl_Noresult"]);
                }
                catch (Exception ex)
                {
                    Main.Mod.Error(ex.Message);
                }
            }
        }
    }
}
