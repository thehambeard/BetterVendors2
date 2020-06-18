using BetterVendors.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BetterVendors.Vendors
{
    public class VendorBlueprints
    {
        static LibraryScriptableObject Library => Main.Library;

        public static Dictionary<string, Vendor> NewVendors = new Dictionary<string, Vendor>
        {
            { "47466adc4e4e476cb84680e0eef02f0f",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.8f, 0.0f, -2.3f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0.0f, 0.0f)),
                    true,
                    "47466adc4e4e476cb84680e0eef02f0f", //UnitGuid
                    "9fd9d69420dd4dfcba5d93c267eee263", //DialogGuid
                    "cb8a2d99026e4914a58e48b1db0eddca", //CueGuid
                    "afbba311f84f4de7a0ebb1a65fe8199c", //AnsListGuid
                    "a94f0ca5267c4504a1203e6adac13f64", //AnswerShowGuid
                    "d777a274cc844837b487ac2e80ff4e31", //AnswerExitGuid
                    "BillThePony",
                    "Bill The Pony",
                    "Here stands the famous pony, Bill",
                    "447d2907feec82545b3773fbb4709588", //Pony Model
                    "fc01b45fee3606749a21d9612c5629a6", //C4_Large
                    "a236e7b043ea4011bf184e3e81627030" // VendorTableGuid
                    ) },

            { "ce05d9f6286c4c1aa8e4b78f837a44e5",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.8f, 0.0f, 4.5f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0.0f, 0.0f)),
                    true,
                    "ce05d9f6286c4c1aa8e4b78f837a44e5", //UnitGuid
                    "12f9363fea5f445e990b1396af57da74", //DialogGuid
                    "54f461aa26aa45838af71bedc9d03f4c", //CueGuid
                    "4abfe0a780654467ae10fa29b86f47ec", //AnsListGuid
                    "82d0a73cc6f34642b5206842986fb54f", //AnswerShowGuid
                    "fde5a80615a74e3f9ef1b6d74824207a", //AnswerExitGuid
                    "CreeperScamp", //name
                    "Creeper the Scamp", //DisplayName
                    "Hello Caldera! I'm here all week!", //Description
                    "a470a95a5ba6afc44979d25a018914cf", //Prefab goblin
                    "4b1bb03a5d19a534bad2aa5cd766af92", //VendorTableOriginal C4 small
                    "d221bdcca04541009f24598147cf79f3" // VendorTableGuid
                    ) },

            { "ee55f77e5be944ec9f74c382852a04ee",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.8f, 0.0f, 0.9f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0.0f, 0.0f)),
                    true,
                    "ee55f77e5be944ec9f74c382852a04ee", //UnitGuid
                    "f0d6b22c1663481c986da96c3fd1ddf6", //DialogGuid
                    "e562c6ac184c4b1c87ea74443da654d9", //CueGuid
                    "dab5c73200ca481f9c19cedaa563f56f", //AnsListGuid
                    "f92cc52043644ba4b6bec55ca6ad3e25", //AnswerShowGuid
                    "c94fb3ae2c324215a2e7bc4440c1d038", //AnswerExitGuid
                    "ReivMerchant", //name
                    "Reiv the Merchant", //DisplayName
                    "Got some rare things on sale, stranger", //Description
                    "8ebc6d74fa132d9478d0f2ee298e429d", //Prefab
                    "b3bc1bb9f4a59f3438edc505e0f3b407", //VendorTableOriginal C3 large
                    "8b75798d1486401d8ff93b0c80adb42c" // VendorTableGuid
                    ) },
            { "930ec057042542d8ad562bb5cfc7e4ee",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.8f, 0.0f, -6.0f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0.0f, 0.0f)),
                    true,
                    "930ec057042542d8ad562bb5cfc7e4ee", //UnitGuid
                    "6c4997f09e0b47f189b7b3bd400ec36e", //DialogGuid
                    "f65e3aa28d0240cfa6bd67ebebdd0bde", //CueGuid
                    "e30ab3bb45d94d59be56a853768a51ca", //AnsListGuid
                    "12b9ebaba95f4b02b6170a4e11387063", //AnswerShowGuid
                    "17c6f33ae6f54f599692abfec7e84024", //AnswerExitGuid
                    "GriswoldMerchant", //name
                    "Griswold", //DisplayName
                    "Got some rare things on sale, stranger", //Description
                    "5ec40f5a960494447af318080e7a4d58", //Prefab
                    "b3bc1bb9f4a59f3438edc505e0f3b407", //VendorTableOriginal C3 large
                    "" // VendorTableGuid
                    ) },
            { "bd9607a0746543068abf099290d5ba6b",
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    new Vector3(-5.0f, 0.6f, 7.2f),
                    Quaternion.LookRotation(new Vector3(-0.46f, 0, -0.88f)),
                    true,
                    "bd9607a0746543068abf099290d5ba6b", //UnitGuid
                    "f57c3145fc3b4946a2301168ea77b749", //DialogGuid
                    "0910f95f84bb4b0a8eb1704a4bd66c6d", //CueGuid
                    "b3131e685b364fddb63efa5e4cd7c945", //AnsListGuid
                    "9e005348772f4ed9b671809495815af7", //AnswerShowGuid
                    "97d503f1078e4fd8902b868863b3ef00", //AnswerExitGuid
                    "HassufClone", //name
                    "Hassuf", //DisplayName
                    "It's good to get out of the sun for a while, your grace.", //Description
                    "2a3af8edd0eed284a9bc201eb061bd0f", //Prefab
                    "8c17a31b6a9a6eb4cbb668902e9edcb1", //firstvendortable
                    "none" // VendorTableGuid
                    ) },
            { "803e8f2fdd85417da9653b79dd2bd528",
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    new Vector3(-1.1f, 0.6f, 7.5f),
                    Quaternion.LookRotation(new Vector3(0.46f, 0, -0.88f)),
                    true,
                    "803e8f2fdd85417da9653b79dd2bd528", //UnitGuid
                    "65175fc690e748f39760c2f1dbb57cda", //DialogGuid
                    "8da93cfafa4f43d4ac668fd29baec76d", //CueGuid
                    "a43c2f192b394ec8ae4da8a4c4e95f63", //AnsListGuid
                    "1533931ee2b2476696570ab2dc5a0aa9", //AnswerShowGuid
                    "355437746d134910a0129898ac361f7b", //AnswerExitGuid
                    "VerdelClone", //name
                    "Verdel", //DisplayName
                    "How can I be of service, your grace?", //Description
                    "8efa5d7293480494390c2283001eb420", //Prefab
                    "7de959347266092448d8a72089ef9778", //VendorTableOriginal 
                    "none" // VendorTableGuid
                    ) },
            { "dcf8a96cb8234654a1d9b66ba5e8f81d",
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    new Vector3(0.5f, 1.6f, 7.6f),
                    Quaternion.LookRotation(new Vector3(-0.48f, 0, -0.87f)),
                    true,
                    "dcf8a96cb8234654a1d9b66ba5e8f81d", //UnitGuid
                    "5d1f75fcd11c49678234049aacabb0b4", //DialogGuid
                    "83e0b988af3b4565a93d62e6914298ca", //CueGuid
                    "a866396da73b42f3ad47f764b463a5c1", //AnsListGuid
                    "709e09d5493545d6bd9522bbd64da342", //AnswerShowGuid
                    "5c3bb3e402ca4daf887b1d09e227cc5b", //AnswerExitGuid
                    "ZarcieClone", //name
                    "Zarcie", //DisplayName
                    "G'day your grace.", //Description
                    "5dfb4b6869af5e54ba4774ed8957628b", //Prefab
                    "5450d563aab78134196ee9a932e88671", //VendorTableOriginal 
                    "none" // VendorTableGuid
                    ) },
            { "ae8de86d673a43aaa3c96b62978ac75b",
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    new Vector3(-7.2f, 0.6f, 8.5f),
                    Quaternion.LookRotation(new Vector3(-0.07f, 0, -0.99f)),
                    true,
                    "ae8de86d673a43aaa3c96b62978ac75b", //UnitGuid
                    "027ad6e4e13545039b1a45ff1eb0cc04", //DialogGuid
                    "d030e275030a40598857bae6087eb050", //CueGuid
                    "1db8726f34964ef0837f19b03eaba034", //AnsListGuid
                    "15f8e49ab48b43a8b1f8e3fd326814f5", //AnswerShowGuid
                    "b7c71f28313842a68c87b2efd61fda88", //AnswerExitGuid
                    "ArsinoeClone", //name
                    "Arsinoe", //DisplayName
                    "Blessed be, your grace", //Description
                    "de9134fe1b5b3e941bdf7b2cf3979bea", //Prefab
                    "afa2c7f292b8e1c4d9c835f0e8047dd3", //VendorTableOriginal
                    "none" // VendorTableGuid
                    ) }
        };

        public static void CreateAllVendors()
        {
            foreach (KeyValuePair<string, Vendor> kvp in NewVendors)
            {
                CreateVendor(kvp.Value);
            }
        }

        public static void CreateVendor(Vendor ven)
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            try
            {
                var unit = Library.CopyAndAdd<BlueprintUnit>("e0449cfcf8ad6084ebfc161fb73e9a27", ven.Name, ven.UnitGuid);
                var dialog = Library.CopyAndAdd<BlueprintDialog>("cd572bf45986d134591b8ff48e1f191f", ven.Name + ".Dialog01", ven.DialogGuid);
                var cueBase = Library.CopyAndAdd<BlueprintCue>("0f6773f2ad1af654291e4a20cfa417ad", dialog.name + ".Cue01", ven.CueGuid);
                var answersList = Library.CopyAndAdd<BlueprintAnswersList>("e30c7b55e7c8a6249a1334c4442414de", cueBase.name + ".AnsList01", ven.AnsListGuid);
                var answerLook = Library.CopyAndAdd<BlueprintAnswer>("719394baae0fe7645aa8e6c743556f04", answersList.name + ".Ans01", ven.AnswerShowGuid);
                var answerExit = Library.CopyAndAdd<BlueprintAnswer>("938dc0b52670b9a4fb3d3ee611819f0f", answersList.name + ".Ans02", ven.AnswerExitGuid);
                BlueprintSharedVendorTable vendorTable = new BlueprintSharedVendorTable();
                if (!(ven.VendorTableGuid == "none"))
                {
                    vendorTable = Library.CopyAndAdd<BlueprintSharedVendorTable>(ven.VendorTableOrig, unit.name + ".VendorTable", ven.VendorTableGuid);
                }
                else
                {
                    vendorTable = Library.Get<BlueprintSharedVendorTable>(ven.VendorTableOrig);
                }

                dialog.FirstCue.Cues[0] = cueBase;
                cueBase.Text = Helpers.CreateString(cueBase.name + ".Text", ven.Description);
                cueBase.ParentAsset = dialog;
                answerLook.ParentAsset = answersList;
                answerExit.ParentAsset = answersList;
                answersList.Answers.Clear();
                answersList.Answers.Add(answerLook);
                answersList.Answers.Add(answerExit);
                cueBase.Answers = answersList.Answers;
                answersList.ParentAsset = cueBase;
                DialogOnClick newDialog = unit.GetComponent<DialogOnClick>().CreateCopy(delegate (DialogOnClick dc)
                {
                    dc.Dialog = dialog;
                    dc.name = unit.name + ".OnClick";
                });
                AddVendorItems newVendorTable = unit.GetComponent<AddVendorItems>().CreateCopy(delegate (AddVendorItems avi)
                {
                    avi.name = unit.name + "VendorTable";
                    avi.m_Loot = vendorTable;
                });
                unit.ReplaceComponent<AddVendorItems>(newVendorTable);
                unit.ReplaceComponent<DialogOnClick>(newDialog);
                unit.Prefab.AssetId = ven.PrefabId;
                Main.Mod.Debug(ven.DisplayName);
                Main.Mod.Debug(ven.Name);
                unit.LocalizedName = new SharedStringAsset
                {
                    name = ven.Name + ".Local",
                    String = Helpers.CreateString(ven.Name + ".Local.Str", ven.DisplayName)
                };
            }
            catch (Exception ex)
            {
                Main.Mod.Debug(ex.Message);
            }
        }
    }
}
