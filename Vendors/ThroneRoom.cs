using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using ModMaker;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetterVendors.Utilities;


namespace BetterVendors.Vendors
{
    public class ThroneRoom : IModEventHandler, IAreaLoadingStagesHandler
    {
        public int Priority => 100;

        public void HandleModEnable()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            EventBus.Subscribe(this);
        }
        public void HandleModDisable()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            EventBus.Unsubscribe(this);
        }
        public void OnAreaScenesLoaded()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

        }
        public void OnAreaLoadingComplete()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            if (Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("173c1547502bb7243ad94ef8eec980d0") ||
                Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("c39ed0e2ceb98404b811b13cb5325092"))
            {
                HashSet<string> units = HamHelpers.GetAreaUnitGuids();
                foreach (KeyValuePair<string, Vendor> kvp in VendorBlueprints.NewVendors.Where(n => n.Value.AreaId == Vendor.Area.ThroneRoom))
                {
                    if(!units.Contains(kvp.Value.UnitGuid))
                        kvp.Value.Spawn();
                }
            }
        }
    }
}
