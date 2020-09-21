using BetterVendors.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
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
        public int Count { get; private set; }
        public Dictionary<string, int> Table;

        public NewVendorTable(string name, string guid, Dictionary<string, int> table, bool autoId = true)
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
                new NewVendorTable("Volo.VendorTable", "dce232e52e1943e89fcb1a8b2d123fa0", new Dictionary<string, int>
                {
                        {"92cfdd028ba3bff4f9f29858f81b1c71", 1},
                        {"8b6da0c2cead68d49bbc95316db2883f", 1},
                        {"95ac218cacaaf574bbe3d294bdca4f64", 1},
                        {"e9d7a6a56346fd942853490c89ece7d1", 1},
                        {"67faf43ace752b54eb831dfae5059b89", 1},
                        {"591b91f6bd5b7d841a6cf3a9d401f4eb", 1},
                        {"815cc85ce13ab64428253aea3b6708a8", 1},
                        {"1ccb68fd1e0f6d141b739e3744e5af4e", 1},
                        {"0237641b0c2de344d85821840419b4d2", 1},
                        {"c26987a7ed22f3347b75d1dac40d4feb", 1},
                        {"b9b49933be6ac7f4aa3c71c602227332", 1},
                        {"d22b682ccd5672042891b1a7882278a9", 1},
                        {"19f27f871b1934a47b08b78fbccc3865", 1},
                        {"9fdbea707a02b8d448e8e46fd3088468", 1},
                        {"24f5cdf6f8d58064aa843e625616f94c", 1},
                        {"107013e973a60eb44a067184c80fa5d9", 1},
                        {"e2f801723e487a34ebb6155936ebd1aa", 1},
                        {"282393f860a510b429432e13943f27c0", 1},
                        {"a3713ad3603420447bfaa1c4e552e55d", 1},
                        {"aa7077c0a39efbd46a1fb7997b8d8411", 1},
                        {"b4a543719a69c1142af4b0c0832137b3", 1},
                        {"6e937af0f78bb474092f00ee0d531886", 1},
                        {"e7dbbfd147a9e214396a4fbaf68563dd", 1},
                        {"8fdd83cc5f9d57e4387430a1b437de0c", 1},
                        {"622909c22c966f64e98e265c8cee594b", 1},
                        {"41664943b58f3e04f9d898a9747295aa", 1},
                        {"2f771b62ffb4bdf45a425ba0a0130217", 1},
                        {"6db47f17f3711974c8e816e30ff0a40f", 1},
                        {"ddece7b44eb78c44fb9aca7eb5d94d17", 1},
                        {"e893f03f60b704241a0b47febbc06c77", 1},
                        {"f65775e982d9d87478d3013a0a7c52c3", 1},
                        {"d120d33fb4e082242ba4fcae5f0bd094", 1},
                        {"e7e93ed90f0e8294889d34b74c2f1286", 1},
                        {"336dd76bbd5998347a3fbed7f4cbbd4a", 1},
                        {"eee4d2c600f03654c930203164722ff2", 1},
                        {"ffe8ae794fe34294fb565ed3f677ece0", 1},
                        {"fa02b3d13a6598c4f97acfbabfe1e01e", 1},
                        {"934a377b465e2334084a31c938916c74", 1},
                        {"1f04244d7816cf74b8039b65560b0cdf", 1},
                        {"c7e5f05e1dd1c9644adf31b0a5f0d121", 1},
                        {"39ac939af34e75d48aff1554bdc8dc19", 1},
                        {"b0691dc56a4a5b1498f129eef0948447", 1},
                        {"815f9ba2e31fdab49a7464df3189b71b", 1},
                        {"59a594b9b6d72c74692d53632ed29b0d", 1},
                        {"7510be4c91e6a754d8c887db44585324", 1},
                        {"b99f5d0d7f30c9e4f9f7afbdf0adc264", 1}
                })
            },
            {
                "54b3716b416b428e9b3326427f396020", //Guid
                new NewVendorTable("Potion.VendorTable", "54b3716b416b428e9b3326427f396020", new Dictionary<string, int>
                {
                        {"d52566ae8cbe8dc4dae977ef51c27d91", 99}, //PotionOfCureLightWounds", 99},
		                {"fe7e87dc45fbcb845b7755f0733b5465", 99}, //PotionOfEnlargePerson", 99},
		                {"a05bfdfe2df01204ab8e367c2c0b72ce", 99}, //PotionOfFeatherStep", 99},
		                {"ab4961408ba080449afd3e65aa0acbc1", 99}, //PotionOfMageArmor", 99},
		                {"b70aa3e06d55bfd41b9ee6d3a89bc0a8", 99}, //PotionOfOfVanish", 99},
		                {"ec487c0ecc801e048aed50851d937fd8", 99}, //PotionOfProtectionFromChaos", 99},
		                {"de000ebb9b86c8f48b77576965303183", 99}, //PotionOfProtectionFromEvil", 99},
		                {"e5e2567210888184cb3c552c02e86b89", 99}, //PotionOfProtectionFromGood", 99},
		                {"31a74f20fcba2c9419738a94f6727dd6", 99}, //PotionOfProtectionFromLaw", 99},
		                {"0a6a7bbf0ddcebb4f8c4c7bd5d20c003", 99}, //PotionOfReducePerson", 99},
		                {"bc93a78d71bef084fa155e529660ed0d", 99}, //PotionOfShieldOfFaith", 99},
		                {"3bcbf79b01e4db044a6f06d86cec9117", 99}, //PotionOfAid", 99},
		                {"99ba9a93eb1c3cf42bfa641a59580f5b", 99}, //PotionOfBarkskin", 99},
		                {"a3879b4e94c50854a873a0334fbbe36c", 99}, //PotionOfBearsEndurance", 99},
		                {"5bb722fed5172ed48baa2139246bc355", 99}, //PotionOfBlur", 99},
		                {"2983c97b71ba60443b1c749854ef53a1", 99}, //PotionOfBullsStrength", 99},
		                {"94b24d55f514cdd45a79d34904fea944", 99}, //PotionOfCatsGrace", 99},
		                {"f991f3051c3b9e64fabc87891077b613", 99}, //PotionOfCureModerateWounds", 99},
		                {"91d681b0bf6c39047a46f50ec98bf72d", 99}, //PotionOfEaglesSplendor", 99},
		                {"17f132fa2c8c213479640212ae444005", 99}, //PotionOfFoxsCunning", 99},
		                {"5f9fe6030695f48489b59887536748e8", 99}, //PotionOfInvisibility", 99},
		                {"db548855a06daba4cb57f34f4780fd02", 99}, //PotionOfOwlsWisdom", 99},
		                {"b248613596724524fbbe894309af2003", 99}, //PotionOfProtectionFromArrows", 99},
		                {"2b269b69a86843546bdf17a9c3c431c3", 99}, //PotionOfResistAcid", 99},
		                {"755b60529a25f1e4f8e44436d927fc6f", 99}, //PotionOfResistCold", 99},
		                {"5d4a59a63e6192c40a73d4b2bd722328", 99}, //PotionOfResistElectricity", 99},
		                {"6e37f3e99bfa1fb4a9ad8db1775aa7aa", 99}, //PotionOfResistFire", 99},
		                {"1365aee7d18c85d438f5b027122ca8cf", 99}, //PotionOfRestorationLesser", 99},
		                {"e76d14096063ee041bdb1d13d8172599", 99}, //PotionOfCureSeriousWounds", 99},
		                {"e21a5ab9509a943409bbd791e9685b03", 99}, //PotionOfDisplacement", 99},
		                {"42f01c3ad12d4f84c93f89e165384780", 99}, //PotionOfHeroism", 99},
		                {"30d3dfb67a23cbf4a98044a8f1141b67", 99}, //PotionOfProtectionFromAcid", 99},
		                {"3a66c695016483a47b4f77ed0ff2e7fb", 99}, //PotionOfProtectionFromCold", 99},
		                {"4d85e4763c365454d8f03335197ba6c4", 99}, //PotionOfProtectionFromElectricity", 99},
		                {"4cd7b3330e46f424e88602da4e358836", 99}, //PotionOfProtectionFromFire", 99},
		                {"bafd5734adc579641904284aa380dd48", 99}, //PotionOfRemoveBlindness", 99},
		                {"152944f618996bb4992030141bc96659", 99} //PotionOfRemoveCurse{"
                })
            },
            {
                "387c142f6db54758a8d7eb52a0a2666e", //Guid
                new NewVendorTable("Goblin.VendorTable", "387c142f6db54758a8d7eb52a0a2666e", new Dictionary<string, int>
                {
                    {"3584c2a2f8b5b1b43ae11128f0ff1583", 1 }, //tome of clear thought
                    {"37e2f09923a96234ca486bc9db0b6ad6", 1 }, //tome of leadership
                    {"419a486154514594c99193da785d4302", 1 }, //tome of wisdom
                    {"2d4d510a69da09c48893f945ec197210", 1 }, //manual of bodily health
                    {"b8ea6d2f787c7004c9cab9f519f687f8", 1 }, //dex book
                    {"7a7b1dfa67aa4544aa468d0558b1f667", 1 }, //str book
                    {"d254a9e1b1ebcf44faa326b277c937c5", 1 }, //amulet of dying wisdomm
                    {"193082c3f970e7740a02013ad775cd64", 1 }, //battlemasters plate
                    {"11e350708227f3b4eaf641a5b5fd2863", 1 }, //boots of creeping death
                    {"1e08c0e0300bff442ab9f8152f231f1f", 1 }, //bracers of deflection
                    {"47f01a08b59205c4eac8c33a1fcb6b6a", 1 }, //Charon's Touch
                    {"465bcf20235d0d04593d671bf9b607f0", 1 }, //Cloak of the Lion
                    {"8db1c151a8250f7479a5f23a615babdf", 1 }, //helmet of the guiding light
                    {"3d389d17a341eba49859791ad8e091e6", 1 }, //Lions Claw
                    {"90a937ee70b7e8d4fa48d796022921d4", 1 }, //Oak Leathers
                    {"9772ab64fdf645245ac8ee27b1e5ba69", 1 } //Ring of the natural born commander
                })
            }
        };

        public static void CreateVendorTables()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            foreach (KeyValuePair<string, NewVendorTable> vendors in vendorTables)
            {
                var newTable = ScriptableObject.CreateInstance<BlueprintSharedVendorTable>();

                newTable.name = vendors.Value.Name;
                newTable.AutoIdentifyAllItems = vendors.Value.AutoId;

                Library.AddAsset(newTable, vendors.Key);

                List<LootItemsPackFixed> list = new List<LootItemsPackFixed>();

                foreach (KeyValuePair<string, int> blueprintGuid in vendors.Value.Table)
                {
                    var blueprintScriptableObject = ResourcesLibrary.TryGetBlueprint<BlueprintScriptableObject>(blueprintGuid.Key);
                    var lootItem = new LootItem();
                    var packed = ScriptableObject.CreateInstance<LootItemsPackFixed>();
                    Helpers.SetField(lootItem, "m_Item", blueprintScriptableObject as BlueprintItem);
                    Helpers.SetField(lootItem, "m_Type", LootItemType.Item);
                    Helpers.SetField(packed, "m_Item", lootItem);
                    Helpers.SetField(packed, "m_Count", blueprintGuid.Value);
                    list.Add(packed);
                }

                newTable.ComponentsArray = list.ToArray();
            }
        }
    }
}
