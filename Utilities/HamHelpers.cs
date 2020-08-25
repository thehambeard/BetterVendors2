using Kingmaker;
using System.Linq;
using UnityEngine;

namespace BetterVendors.Utilities
{
    public static class HamHelpers
    {

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

        public static Vector3 StringToVector3(string s)
        {
            string[] cords = s.Split(' ');
            if (cords.Length != 3) return new Vector3();
            return new Vector3(float.Parse(cords[0]), float.Parse(cords[1]), float.Parse(cords[2]));
        }
    }
}

