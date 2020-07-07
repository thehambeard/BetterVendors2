using BetterVendors.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
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
	public class NewVendorTable
	{
		public string Name { get; private set; }
		public string Guid { get; private set; }
		public bool AutoId { get; private set; }
		public List<string> Table;

		public NewVendorTable(string name, string guid, List<string> table, bool autoId = true)
        {
			this.Name = name;
			this.Guid = guid;
			this.AutoId = autoId;
			this.Table = table;
        }

    }
    public class VendorTableBlueprints
    {
        static LibraryScriptableObject Library => Main.Library;
        static Dictionary<string, NewVendorTable> vendorTables = new Dictionary<string, NewVendorTable>
        {
            {
				"dce232e52e1943e89fcb1a8b2d123fa0", //Guid
                new NewVendorTable("VoloVendorTable", "", new List<string>
                {
						"92cfdd028ba3bff4f9f29858f81b1c71",
						"8b6da0c2cead68d49bbc95316db2883f",
						"95ac218cacaaf574bbe3d294bdca4f64",
						"e9d7a6a56346fd942853490c89ece7d1",
						"67faf43ace752b54eb831dfae5059b89",
						"591b91f6bd5b7d841a6cf3a9d401f4eb",
						"815cc85ce13ab64428253aea3b6708a8",
						"1ccb68fd1e0f6d141b739e3744e5af4e",
						"0237641b0c2de344d85821840419b4d2",
						"c26987a7ed22f3347b75d1dac40d4feb",
						"b9b49933be6ac7f4aa3c71c602227332",
						"d22b682ccd5672042891b1a7882278a9",
						"19f27f871b1934a47b08b78fbccc3865",
						"9fdbea707a02b8d448e8e46fd3088468",
						"24f5cdf6f8d58064aa843e625616f94c",
						"107013e973a60eb44a067184c80fa5d9",
						"e2f801723e487a34ebb6155936ebd1aa",
						"282393f860a510b429432e13943f27c0",
						"a3713ad3603420447bfaa1c4e552e55d",
						"aa7077c0a39efbd46a1fb7997b8d8411",
						"b4a543719a69c1142af4b0c0832137b3",
						"6e937af0f78bb474092f00ee0d531886",
						"e7dbbfd147a9e214396a4fbaf68563dd",
						"8fdd83cc5f9d57e4387430a1b437de0c",
						"622909c22c966f64e98e265c8cee594b",
						"41664943b58f3e04f9d898a9747295aa",
						"2f771b62ffb4bdf45a425ba0a0130217",
						"6db47f17f3711974c8e816e30ff0a40f",
						"ddece7b44eb78c44fb9aca7eb5d94d17",
						"e893f03f60b704241a0b47febbc06c77",
						"f65775e982d9d87478d3013a0a7c52c3",
						"d120d33fb4e082242ba4fcae5f0bd094",
						"e7e93ed90f0e8294889d34b74c2f1286",
						"336dd76bbd5998347a3fbed7f4cbbd4a",
						"eee4d2c600f03654c930203164722ff2",
						"ffe8ae794fe34294fb565ed3f677ece0",
						"fa02b3d13a6598c4f97acfbabfe1e01e",
						"934a377b465e2334084a31c938916c74",
						"1f04244d7816cf74b8039b65560b0cdf",
						"c7e5f05e1dd1c9644adf31b0a5f0d121",
						"39ac939af34e75d48aff1554bdc8dc19",
						"b0691dc56a4a5b1498f129eef0948447",
						"815f9ba2e31fdab49a7464df3189b71b",
						"59a594b9b6d72c74692d53632ed29b0d",
						"7510be4c91e6a754d8c887db44585324",
						"eee4d2c600f03654c930203164722ff2",
						"b99f5d0d7f30c9e4f9f7afbdf0adc264",
				})
            }
        };

		public static void CreateVendorTables()
        {
			Main.Mod.Debug(MethodBase.GetCurrentMethod());
			foreach(KeyValuePair<string, NewVendorTable> vendors in vendorTables)
            {
				var newTable = ScriptableObject.CreateInstance<BlueprintSharedVendorTable>();
				
				newTable.name = vendors.Value.Name;
				newTable.AutoIdentifyAllItems = vendors.Value.AutoId;

				if(!Library.BlueprintsByAssetId.ContainsKey(vendors.Key)) Library.AddAsset(newTable, vendors.Key);

				List<LootItemsPackFixed> list = new List<LootItemsPackFixed>();

				foreach (string blueprintGuid in vendors.Value.Table)
                {
					var blueprintScriptableObject = ResourcesLibrary.TryGetBlueprint<BlueprintScriptableObject>(blueprintGuid);
					var lootItem = new LootItem();
					var packed = ScriptableObject.CreateInstance<LootItemsPackFixed>();
					Helpers.SetField(lootItem, "m_Item", blueprintScriptableObject as BlueprintItem);
					Helpers.SetField(lootItem, "m_Type", LootItemType.Item);
					Helpers.SetField(packed, "m_Item", lootItem);
					Helpers.SetField(packed, "m_Count", 1);
				}

				newTable.ComponentsArray = list.ToArray();
			}
        }
    }
}
