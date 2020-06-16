using BetterVendors.Utilities;
using Kingmaker;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.View.Roaming;
using ModMaker;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BetterVendors.Vendors
{
    public class BVMechantGuild : IModEventHandler, IAreaLoadingStagesHandler
    {
        public static bool InThroneRoom { get; set; }
        public static bool IsStone { get; set; }
        public static bool InGuild { get; set; }

        public int Priority => 200;

        static LibraryScriptableObject Library => Main.Library;

        static readonly string capLibEP = "e2a1da2a5eeb1004984f13f304d7d4d8";
        static readonly string capLib = "e100798af67576b459fb345cdd4e77ce";
        static readonly string merchGuildEpId = "26b7b66f082f46dd8e9223be3148b5ad";
        static readonly string merchGuildId = "ad32ee064ec3404ca88a4096dee94967";

        public void OnAreaLoadingComplete()
        {

        }

        public void OnAreaScenesLoaded()
        {
            HandleSceneLoaded();
        }

        public static void CreateMerchantGuild()
        {

            var merchGuildEpBp = Library.CopyAndAdd<BlueprintAreaEnterPoint>(capLibEP, "MerchantGuildEp", merchGuildEpId);
            var merchGuildBp = Library.CopyAndAdd<BlueprintArea>(capLib, "MerchantGuild", merchGuildId);
            Helpers.SetField(merchGuildEpBp, "m_Area", merchGuildBp);
        }

        public static void HandleSceneLoaded()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            InThroneRoom = Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("173c1547502bb7243ad94ef8eec980d0") ||
                Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("c39ed0e2ceb98404b811b13cb5325092");
            if ((InGuild = Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals(merchGuildId)))
                LibraryLoad();
        }
        public static void LibraryLoad()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            Game.Instance.Player.MainCharacter.Value.Position = new Vector3(16.5f, 0.1f, -0.5f);

            if (Game.Instance.Player.MainCharacter.Value.FreeformData["BVMechantGuildLoadOnce"] == 0)
            {

                foreach (UnitEntityData e in Game.Instance.State.Units.All)
                {
                    if (!e.IsMainCharacter)
                        e.Destroy();
                }
                foreach (MapObjectEntityData m in Game.Instance.State.MapObjects.All)
                    m.Destroy();
                foreach (RoamingWaypointData d in Game.Instance.State.RoamingWaypoints.All)
                    d.Destroy();
                foreach (CutscenePlayerData c in Game.Instance.State.Cutscenes.All)
                    c.Destroy();
                Game.Instance.CurrentlyLoadedArea.AreaName = Helpers.CreateString("MerchantGuild", "Merchant Guild");
                foreach (KeyValuePair<string, Vendor> kvp in VendorBlueprints.NewVendors.Where(n => n.Value.AreaId == Vendor.Area.MerchantGuild))
                {
                    kvp.Value.Spawn();
                }
                Game.Instance.Player.MainCharacter.Value.FreeformData["BVMechantGuildLoadOnce"] = 1;
            }
        }

        public static bool TP()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            BlueprintAreaEnterPoint ep = new BlueprintAreaEnterPoint();
            bool result = false;

            Main.Mod.Debug(InThroneRoom);
            Main.Mod.Debug(IsStone);
            Main.Mod.Debug(InGuild);

            if (InThroneRoom)
            {
                IsStone = Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("c39ed0e2ceb98404b811b13cb5325092");
                ep = ResourcesLibrary.TryGetBlueprint<BlueprintAreaEnterPoint>(merchGuildEpId);
                result = true;
            }
            if (InGuild)
            {
                if (IsStone)
                {
                    ep = ResourcesLibrary.TryGetBlueprint<BlueprintAreaEnterPoint>("3a9748aba32e1694f80a6cae9b7b3f99");
                }
                else
                {
                    ep = ResourcesLibrary.TryGetBlueprint<BlueprintAreaEnterPoint>("21fb2ff53d1e2fb4c9b06f067ab89435");
                }
                //LibraryUnload();
                result = true;
            }
            if (result)
            {
                GameHelper.EnterToArea(ep, Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
            }
            return result;
        }

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
    }
}
