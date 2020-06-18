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
        public static HashSet<string> AreaUnitGuids = new HashSet<string>();
        public static void updateAreaUnitGuids()
        {
            AreaUnitGuids.Clear();
            foreach (UnitEntityData ud in Game.Instance.State.Units)
            {
                AreaUnitGuids.Add(ud.Blueprint.AssetGuid);
            }
        }

        public static bool InThroneRoom()
        {
            return (Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("173c1547502bb7243ad94ef8eec980d0") ||
                Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("c39ed0e2ceb98404b811b13cb5325092"));
        }

        public static bool InGuildHall()
        {
            return Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("ad32ee064ec3404ca88a4096dee94967");
        }

        public static bool InGame() { return Game.Instance.Player.ControllableCharacters.Any(); }
    }
}

