using BetterVendors.Utilities;
using UnityEngine;
using GL = UnityEngine.GUILayout;

namespace BetterVendors.Menus
{
    internal static class MenuHelpers
    {
        public static GUIStyle ButtonStyle = new GUIStyle(GUI.skin.button) { fixedWidth = 150f };
        public static GUIStyle LabelStyleFixed = new GUIStyle(GUI.skin.label) { fixedWidth = 60f };
        public static GUIStyle LabelStyleWrap = new GUIStyle(GUI.skin.label) { fixedWidth = 800f, wordWrap = true };
        public static bool NotInGameMessage()
        {
            if (!HamHelpers.InGame())
            {
                GL.Label(Main.Local["Menu_Lbl_NotInGame"]);
                return false;
            }
            else
                return true;
        }

        public static bool NotInThroneRoomMessage()
        {
            if (!HamHelpers.InThroneRoom())
            {
                GL.Label(Main.Local["Menu_Txt_NotInThrone"]);
                return false;
            }
            else
                return true;
        }
    }
}
