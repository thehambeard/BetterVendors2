using Kingmaker.EntitySystem.Entities;
using Kingmaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterVendors.Utilities
{
    public static class HamHelpers
    {
        public static HashSet<string> GetAreaUnitGuids()
        {
            HashSet<string> unitGuids = new HashSet<string>();
            foreach (UnitEntityData ud in Game.Instance.State.Units)
            {
                unitGuids.Add(ud.Blueprint.AssetGuid);
            }
            return unitGuids;
        }
    }
}

