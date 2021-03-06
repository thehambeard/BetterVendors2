﻿using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using System.Reflection;
using UnityEngine;

namespace BetterVendors.Vendors
{
    public class Vendor
    {
        public enum Area
        {
            ThroneRoom,
            MerchantGuild
        }
        public UnitEntityData EntityData { get; private set; }
        public Area AreaId { get; private set; }
        public string UnitGuid { get; private set; }
        public string DialogGuid { get; private set; }
        public string CueGuid { get; private set; }
        public string AnsListGuid { get; private set; }
        public string AnswerShowGuid { get; private set; }
        public string AnswerExitGuid { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public string PrefabId { get; private set; }
        public string VendorTableOrig { get; private set; }
        public string VendorTableGuid { get; private set; }
        public bool HasSpawned { get; private set; }
        public bool Enabled { get; private set; }
        public Vector3 Posistion { get; set; }
        public Quaternion Rotation { get; set; }
        public bool Shared { get; private set; }

        private static LibraryScriptableObject Library => Main.Library;

        public Vendor(Area areaId, Vector3 posistion, Quaternion rotation, bool enabled, string unitGuid, string dialogGuid, string cueGuid, string ansListGuid, string answerShowGuid, string answerExitGuid, string name, string displayName, string description, string prefabId, string vendorTableOrig, string vendorTableGuid, bool shared)
        {
            this.AreaId = areaId;
            this.Posistion = posistion;
            this.Rotation = rotation;
            this.Enabled = enabled;
            this.UnitGuid = unitGuid;
            this.DialogGuid = dialogGuid;
            this.CueGuid = cueGuid;
            this.AnsListGuid = ansListGuid;
            this.AnswerShowGuid = answerShowGuid;
            this.AnswerExitGuid = answerExitGuid;
            this.Description = description;
            this.Name = name;
            this.DisplayName = displayName;
            this.PrefabId = prefabId;
            this.VendorTableOrig = vendorTableOrig;
            this.VendorTableGuid = vendorTableGuid;
            this.HasSpawned = false;
            this.Shared = shared;
        }

        public void Spawn()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            this.Destroy();
            if (this.Enabled)
                this.EntityData = Game.Instance.EntityCreator.SpawnUnit((BlueprintUnit)Library.BlueprintsByAssetId[this.UnitGuid], this.Posistion, this.Rotation, Game.Instance.CurrentScene.MainState);
        }

        public void Destroy()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());

            foreach (UnitEntityData unit in Game.Instance.State.Units)
            {
                if (unit.Blueprint.AssetGuid.Equals(this.UnitGuid))
                    unit.Destroy();
            }
        }
        public void Enable()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            this.Enabled = true;
            this.Spawn();
        }

        public void Disable()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            this.Enabled = false;
            this.Destroy();
        }

        public void Move(Vector3 posistion, Vector3 rotation)
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            this.Posistion = posistion;
            this.Rotation = Quaternion.LookRotation(rotation);
            this.Enabled = true;
            this.Spawn();
        }
    }
}
