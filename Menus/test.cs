using ModMaker;
using System.Collections.Generic;
using UnityEngine;
using UnityModManagerNet;
using static BetterVendors.Main;
using GL = UnityEngine.GUILayout;

namespace BetterVendors.Menus
{
#if (DEBUG)
    class Test : IMenuSelectablePage
    {
        public string Name => Local["Menu_Tab_TRV"];

        public int Priority => 200;
        GUIStyle buttonStyle;
        GUIStyle lableStyle;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (GL.Button("Spawn", GL.ExpandWidth(false)))
            {
                foreach (KeyValuePair<string, Vendors.Vendor> kvp in Vendors.VendorBlueprints.NewVendors)
                {
                    Main.Mod.Debug(kvp.Value.AreaId);
                    Main.Mod.Debug(kvp.Value.AreaId == Vendors.Vendor.Area.ThroneRoom);
                    if (kvp.Value.AreaId == Vendors.Vendor.Area.ThroneRoom)
                    {
                        Main.Mod.Debug(kvp.Value.Name);
                        kvp.Value.Spawn();
                    }
                }
            }
        }
    }
#endif
}
