﻿using BetterVendors.Utilities;
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
    public class MechantGuild : IModEventHandler, IAreaLoadingStagesHandler
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
            HandleSceneLoaded();
        }

        public void OnAreaScenesLoaded()
        {

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
            InThroneRoom = HamHelpers.InThroneRoom();
            if ((InGuild = Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals(merchGuildId)))
                LibraryLoad();
        }
        public static void LibraryLoad(bool force = false)
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            if (Game.Instance.Player.MainCharacter.Value.FreeformData["BVMechantGuildLoadOnce"] == 0 || force)
            {
                foreach (UnitEntityData e in Kingmaker.Game.Instance.State.Units)
                {
                    if (!e.IsMainCharacter && !(e.Faction.AssetGuid.Equals("72f240260881111468db610b6c37c099")))
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

            foreach (UnitEntityData e in Game.Instance.State.Units)
            {
                string goblinVend = "d044c070bc9c4129930307ae16fd17f8";
                if (e.Faction.AssetGuid.Equals("72f240260881111468db610b6c37c099"))
                {
                    e.Position = new Vector3(16.85f, 0.07f, 6.74f);
                    e.Orientation = 90f;
                }
                if (e.Blueprint.AssetGuid.Equals(goblinVend) && e.FreeformData["Upgraded"] == 0)
                {
                    e.Destroy();
                    VendorBlueprints.NewVendors[goblinVend].Spawn();
                    VendorBlueprints.NewVendors[goblinVend].EntityData.FreeformData["Upgraded"] = 1;
                }

            }
            Game.Instance.Player.MainCharacter.Value.Position = new Vector3(16.43f, 0.12f, -0.55f);
            Game.Instance.Player.MainCharacter.Value.Orientation = 90f;
        }

        public static bool TP()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            BlueprintAreaEnterPoint ep = new BlueprintAreaEnterPoint();
            bool result = false;

            if (InThroneRoom) //TODO: change getter to check if in throne room, do not set it...
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
