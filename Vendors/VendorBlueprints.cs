using BetterVendors.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.Utility;
using ModMaker;
using ModMaker.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static BetterVendors.Utilities.SettingsWrapper;

namespace BetterVendors.Vendors
{
    
    public class VendorBlueprints : IModEventHandler
    {
        
        public static Dictionary<string, string> CloneGuids = new Dictionary<string, string>
        {
            {"arsinoe", "ae8de86d673a43aaa3c96b62978ac75b" },
            {"hassuf" , "bd9607a0746543068abf099290d5ba6b" },
            {"zarcie" , "dcf8a96cb8234654a1d9b66ba5e8f81d" },
            {"verdal" , "803e8f2fdd85417da9653b79dd2bd528" }
        };

        //defaults
        private static readonly Vector3 verdalPos = new Vector3(-1.1f, 0.6f, 7.5f);
        private static readonly Vector3 verdalRot = new Vector3(0.46f, 0, -0.88f);
        private static readonly Vector3 zarciePos = new Vector3(0.5f, 1.6f, 7.6f);
        private static readonly Vector3 zarcieRot = new Vector3(-0.48f, 0, -0.87f);
        private static readonly Vector3 hassufPos = new Vector3(-5.0f, 0.6f, 7.2f);
        private static readonly Vector3 hassufRot = new Vector3(-0.46f, 0, -0.88f);
        private static readonly Vector3 arsinoePos = new Vector3(-7.2f, 0.6f, 8.5f);
        private static readonly Vector3 arsinoeRot = new Vector3(-0.07f, 0, -0.99f);

        static LibraryScriptableObject Library => Main.Library;

        public int Priority => 600;

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
                    "a236e7b043ea4011bf184e3e81627030",  true //VendorTableGuid
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
                    "d221bdcca04541009f24598147cf79f3",  true //VendorTableGuid
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
                    "8b75798d1486401d8ff93b0c80adb42c",  true //VendorTableGuid
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
                    "What can I do you fer.", //Description
                    "5ec40f5a960494447af318080e7a4d58", //Prefab
                    "03139ca71b2f2a34bae0a8a11a342fe4", //VendorTableOriginal C2 large
                    "17e43258ad39434a82368e669f8a2743",  true //VendorTableGuid
                    ) },
            { "3b8cbb604e63405da0449c9c388087d7",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.8f, 0.0f, 7.7f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0f, 0.0f)),
                    true,
                    "3b8cbb604e63405da0449c9c388087d7", //UnitGuid
                    "3007fe899e1c431cb0b51da742ce76f6", //DialogGuid
                    "5019dbb8ef9644aeaba92570be6b47fa", //CueGuid
                    "1507fc1081ca4d96bd591ae3818c0bd0", //AnsListGuid
                    "893ba702f81b4fb5877533c18368d9a2", //AnswerShowGuid
                    "24aadd5f0a4c47cb98bbabeb803f9231", //AnswerExitGuid
                    "NookMerchant", //name
                    "Nook", //DisplayName
                    "I'll be there with bells on! Ho Ho!", //Description
                    "5e8b8c5216543b94fb863325409f0a0f", //Prefab
                    "efa12e6fcc198a748875fea573e94175", //VendorTableOriginal C2 small
                    "266185454c7e44549fbfa52288af3bf4",  true //VendorTableGuid
                    ) },
            { "164d8ddd554c4d53b8a7f20ac9cdba89",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(21.7f, 0.0f, 11.2f),
                    Quaternion.LookRotation(new Vector3(-1.0f, 0.0f, 0.0f)),
                    true,
                    "164d8ddd554c4d53b8a7f20ac9cdba89", //UnitGuid
                    "8953babd3a12497cae9e7d4abf58bb0d", //DialogGuid
                    "b7d4597db21c4fe2b8c9c984c93fb477", //CueGuid
                    "bc684b1f79d84339919c41b94bacc138", //AnsListGuid
                    "458b4825f6504e38a8941fc2e653c5e4", //AnswerShowGuid
                    "2b7a543173874bb3910f53fed6899390", //AnswerExitGuid
                    "BeedleMerchant", //name
                    "Beedle", //DisplayName
                    "Something good will happen to you! Something good indeed.", //Description
                    "6e8f58e9489bcb747beb203f72e807a2", //Prefab
                    "9126c670f0743b647b4e9ba850214d8d", //VendorTableOriginal c3 large
                    "3459b752099e498abf75d118cc0564e7",  true //VendorTableGuid
                    ) },
            { "78920ba3a51d407e89d4ff4bbf811310",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(20.4f, 0.0f, -8.8f),
                    Quaternion.LookRotation(new Vector3( -0.8f, 0f, 0.5f)),
                    true,
                    "78920ba3a51d407e89d4ff4bbf811310", //UnitGuid
                    "f69ef2e9b8ef44bfa6d714ae97c16bc2", //DialogGuid
                    "f461622e2b8c4e829c7a1e5a9c680d1f", //CueGuid
                    "a698db720c0343d485650218cea2dde3", //AnsListGuid
                    "0de89140dd4044eb843661217e20d5e0", //AnswerShowGuid
                    "aa952ed7f068404ba211f9a0d91688c9", //AnswerExitGuid
                    "MarcusMerchant", //name
                    "Marcus", //DisplayName
                    "If I can't find what you need, it can't be found in the stolen lands.", //Description
                    "5324e8cdfb5a79a479eb5668a4f0ae1c", //Prefab
                    "1cfdec17b06a47740bacb7a7ea9dd0c6", //C61_IssiliVendorTable
                    "847195acd5f94a68b1930d1162bc7005",  true //VendorTableGuid
                    ) },
            { "08089c7248134457b9c7c6eaf5afbec5",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(13.0f, 0.0f, -22.8f),
                    Quaternion.LookRotation(new Vector3( 0.3f, 0f, 0.9f)),
                    true,
                    "08089c7248134457b9c7c6eaf5afbec5", //UnitGuid
                    "3a8629660a3c4fce8f76cb89e6140696", //DialogGuid
                    "849ca17d591049d58eacd9cbc337f152", //CueGuid
                    "15a77797867c484b87169da78d68b6df", //AnsListGuid
                    "9117b8c4f7434b50975c4decf688da62", //AnswerShowGuid
                    "9631b44a088e486fb64739b722c2a455", //AnswerExitGuid
                    "PatchesMerchant", //name
                    "Patches", //DisplayName
                    "You've come for the trinkets haven't you?", //Description
                    "f8dcfbcd0d6de5b4d8689479419ac930", //Prefab
                    "8035c1313902fae4796d36065e769297", //VendorTableOriginal DLC2QuartermasterBaseTable
                    "2eed726aaaeb40f9b4b68388fbeee954",  true //VendorTableGuid
                    ) },
            { "0856b394a0514e03b653115747a2c9bb",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(19.0f, 0.0f, -22.4f),
                    Quaternion.LookRotation(new Vector3( -0.9f, 0f, 0.2f)),
                    true,
                    "0856b394a0514e03b653115747a2c9bb", //UnitGuid
                    "e7cb4ba3a97d47849b4ddaf1f42e9062", //DialogGuid
                    "30a7c01c932c44479260b10d417bffad", //CueGuid
                    "aa69870be8464b059aca535eda749d2a", //AnsListGuid
                    "cda130d870a349158ac29d9790bfa041", //AnswerShowGuid
                    "3d20f218d44946e0ba71afcc86a8a4b4", //AnswerExitGuid
                    "TemMerchant", //name
                    "Tem", //DisplayName
                    "Us Tems have a deep history.", //Description
                    "2d769df1ef63e964eb990c87f1de5026", //Prefab
                    "7c68519dca4334c408227bb0140ac50f", //VendorTableOriginal DLC2QuartermasterImprovedTable
                    "67bf04711f384f9f8335b1ac8133f0d3",  true //VendorTableGuid
                    ) },
            { "0e8dc2a8630446c489a84197b3a56902",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(18.8f, 0.0f, -28.4f),
                    Quaternion.LookRotation(new Vector3( -0.5f, 0f, 0.8f)),
                    true,
                    "0e8dc2a8630446c489a84197b3a56902", //UnitGuid
                    "5dcaa0c0028a48ceb05f8548b45e7be1", //DialogGuid
                    "90517f6616004af68082993bcec0b89a", //CueGuid
                    "ac6dc204e20a4683811386c5ed3a0f1b", //AnsListGuid
                    "8ca32f65df264666ab9998719d66a255", //AnswerShowGuid
                    "293a3eb35a8e4ea28c6a7eb4febc3017", //AnswerExitGuid
                    "PorkrindMerchant", //name
                    "Porkrind", //DisplayName
                    "Welcome!", //Description
                    "9c6d635d9937580449ab6f02a8149053", //Prefab
                    "78e1aab1a8d9f4649ae83388c33283cd", //VendorTableOriginal Rushlight_GeneralistVendorTable
                    "00ca8f56f68f4c16a5d564f889b6e60c",  false //VendorTableGuid
                    ) },
            { "c94a3d4bd748431eb9b85ae7249f1d5f",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(12.9f, 0.0f, -28.5f),
                    Quaternion.LookRotation(new Vector3( 0.4f, 0f, 0.8f)),
                    true,
                    "c94a3d4bd748431eb9b85ae7249f1d5f", //UnitGuid
                    "030cb3cb0b4447139a6c66bffc9674a9", //DialogGuid
                    "507fba8d77d64fd59d767f637105788b", //CueGuid
                    "6585c46b2a53472794d7de2a46594f1b", //AnsListGuid
                    "988b33ca3a244d24a3a83ea6ad048fef", //AnswerShowGuid
                    "4c6a62d8f61b44e39b6f1b4f184629c9", //AnswerExitGuid
                    "MoiraMerchant", //name
                    "Moira", //DisplayName
                    "Take care, it's a big stolen land.", //Description
                    "8e57c26884df05b4ab38f34538b72c28", //Prefab
                    "2712cf5716e578f4e95165cb43dda8ae", //VendorTableOriginal Rushlight_MagicVendorTable
                    "022c478394fb424091b604d5d5c2ba5e",  false //VendorTableGuid
                    ) },
            { "4d544e1766c94b3c98355f97e3eb50fd",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(25.4f, 0.0f, -22.3f),
                    Quaternion.LookRotation(new Vector3( -0.9f, 0f, 0.0f)),
                    true,
                    "4d544e1766c94b3c98355f97e3eb50fd", //UnitGuid
                    "f1f7d8c3c6c34f6d842d06ee5af73b1a", //DialogGuid
                    "36d89abfefe0443bb28b71c96fbf0926", //CueGuid
                    "931c636bf55a4b69937b09b60b8fc901", //AnsListGuid
                    "1d083776acb04404be604885ca0be002", //AnswerShowGuid
                    "4f14617012b64432bfb5bc2b259d9db5", //AnswerExitGuid
                    "DrebinMerchant", //name
                    "Drebin", //DisplayName
                    "Drebins, we have yours.", //Description
                    "903822fc596783f4c82d6ad217cdf4e1", //Prefab
                    "0d506a80e3f07544394d812ad7014cf3", //VendorTableOriginal Rushlight_SmithVendorTable
                    "994026259c3e495b80d07720402c6bae",  false //VendorTableGuid
                    ) },
            { "d044c070bc9c4129930307ae16fd17f8",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(1.2f, 0.0f, -18.3f),
                    Quaternion.LookRotation(new Vector3( 0.0f, 0f, -1.0f)),
                    true,
                    "d044c070bc9c4129930307ae16fd17f8", //UnitGuid
                    "de1b8e4fb6124379a8dbd824489e24c0", //DialogGuid
                    "d27a7ae9088a480983d6ae46ee3b8426", //CueGuid
                    "fac7f26f318445c794b90aa5567eb3fb", //AnsListGuid
                    "c9b2d81c791b4cc086e7e35fb15eaffc", //AnswerShowGuid
                    "0a4095fff56243f6b059da7ea9921b6f", //AnswerExitGuid
                    "GoblinMerchant", //name
                    "Goblin Trader", //DisplayName
                    "You ever been to Varnhold?", //Description
                    "2db8287e83e344b4c8a2415d5750393e", //Prefab
                    "488ce39f5594cff4f8a8228e95b091e3", //VendorTableOriginal C71_GoblinVendorTable
                    "591b0b52eaac41f39ddc0b9bd57b4bf7",  false //VendorTableGuid
                    ) },
            { "94f1d2c05db54a7ab7b0c25881dca72b",
                new Vendor(
                    Vendor.Area.MerchantGuild,
                    new Vector3(4.3f, 0.0f, -28.7f),
                    Quaternion.LookRotation(new Vector3( -0.9f, 0f, -0.0f )),
                    true,
                    "94f1d2c05db54a7ab7b0c25881dca72b", //UnitGuid
                    "b6638b63c3bb4d98816d054a3e6015d5", //DialogGuid
                    "cdb4bcfa9c2c425485b91a8c6ef7a615", //CueGuid
                    "aab514b23760420d8b1a955ad31d1cc6", //AnsListGuid
                    "5bace2ca61d946dbae734af66915b827", //AnswerShowGuid
                    "9b8b0151d173472aa7f71348cf7a8575", //AnswerExitGuid
                    "VoloMerchant", //name
                    "Volo", //DisplayName
                    "I know a bit about all things magical. Come see what I have collected on my travels.", //Description
                    "43cfb6a02522db343b0f78d0cab62ed4", //Prefab
                    "dce232e52e1943e89fcb1a8b2d123fa0", //VendorTableOriginal Custom
                    "none",  true //VendorTableGuid
                    ) },
            { CloneGuids["hassuf"],
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    hassufPos,
                    Quaternion.LookRotation(hassufRot),
                    true,
                    CloneGuids["hassuf"], //UnitGuid
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
                    "none",  true //VendorTableGuid
                    ) },
            { CloneGuids["verdal"],
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    verdalPos,
                    Quaternion.LookRotation(verdalRot),
                    true,
                    CloneGuids["verdal"], //UnitGuid
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
                    "none",  true //VendorTableGuid
                    ) },
            { CloneGuids["zarcie"],
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    zarciePos,
                    Quaternion.LookRotation(zarcieRot),
                    true,
                    CloneGuids["zarcie"], //UnitGuid
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
                    "none",  true //VendorTableGuid
                    ) },
            { CloneGuids["arsinoe"],
                new Vendor(
                    Vendor.Area.ThroneRoom, //Area Id
                    arsinoePos,
                    Quaternion.LookRotation(arsinoeRot),
                    true,
                    CloneGuids["arsinoe"], //UnitGuid
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
                    "none",  true //VendorTableGuid
                    ) }
        };

        public static void CreateAllVendors()
        {
            foreach (KeyValuePair<string, Vendor> kvp in NewVendors)
            {
                if (kvp.Value.Shared)
                    CreateSharedVendor(kvp.Value);
                else
                    CreateVendor(kvp.Value);
            }
        }

        public static void CreateSharedVendor(Vendor ven)
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            Main.Mod.Debug(ven.Name);
            Main.Mod.Debug(ven.UnitGuid);
            try
            {
                var unit = Library.CopyAndAdd<BlueprintUnit>("e0449cfcf8ad6084ebfc161fb73e9a27", ven.Name, ven.UnitGuid);
                var dialog = Library.CopyAndAdd<BlueprintDialog>("cd572bf45986d134591b8ff48e1f191f", ven.Name + ".Dialog01", ven.DialogGuid);
                var cueBase = Library.CopyAndAdd<BlueprintCue>("0f6773f2ad1af654291e4a20cfa417ad", dialog.name + ".Cue01", ven.CueGuid);
                var answersList = Library.CopyAndAdd<BlueprintAnswersList>("e30c7b55e7c8a6249a1334c4442414de", cueBase.name + ".AnsList01", ven.AnsListGuid);
                var answerLook = Library.CopyAndAdd<BlueprintAnswer>("719394baae0fe7645aa8e6c743556f04", answersList.name + ".Ans01", ven.AnswerShowGuid);
                var answerExit = Library.CopyAndAdd<BlueprintAnswer>("938dc0b52670b9a4fb3d3ee611819f0f", answersList.name + ".Ans02", ven.AnswerExitGuid);
                var vendorTable = ScriptableObject.CreateInstance<BlueprintSharedVendorTable>();
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
                unit.LocalizedName = ScriptableObject.CreateInstance<SharedStringAsset>();
                unit.LocalizedName.name = ven.Name + ".Local";
                unit.LocalizedName.String = Helpers.CreateString(ven.Name + ".Local.Str", ven.DisplayName);
            }
            catch (Exception ex)
            {
                Main.Mod.Debug(ex.Message);
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
                var vendorTable = ScriptableObject.CreateInstance<BlueprintUnitLoot>();
                if (!(ven.VendorTableGuid == "none"))
                {
                    vendorTable = Library.CopyAndAdd<BlueprintUnitLoot>(ven.VendorTableOrig, unit.name + ".VendorTable", ven.VendorTableGuid);
                }
                else
                {
                    vendorTable = Library.Get<BlueprintUnitLoot>(ven.VendorTableOrig);
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
                unit.LocalizedName = ScriptableObject.CreateInstance<SharedStringAsset>();
                unit.LocalizedName.name = ven.Name + ".Local";
                unit.LocalizedName.String = Helpers.CreateString(ven.Name + ".Local.Str", ven.DisplayName);
            }
            catch (Exception ex)
            {
                Main.Mod.Debug(ex.Message);
            }
        }

        public static void ResetPositions()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            Positions = new SerializableDictionary<string, Vector3>();
            Rotations = new SerializableDictionary<string, Vector3>();
            Positions.Add(CloneGuids["hassuf"], hassufPos);
            Rotations.Add(CloneGuids["hassuf"], hassufRot);
            Positions.Add(CloneGuids["zarcie"], zarciePos);
            Rotations.Add(CloneGuids["zarcie"], zarcieRot);
            Positions.Add(CloneGuids["arsinoe"], arsinoePos);
            Rotations.Add(CloneGuids["arsinoe"], arsinoeRot);
            Positions.Add(CloneGuids["verdal"], verdalPos);
            Rotations.Add(CloneGuids["verdal"], verdalRot);
        }

        public void HandleModEnable()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
            foreach (KeyValuePair<string, string> kvp in CloneGuids)
            {
                NewVendors[kvp.Value].Posistion = Positions[kvp.Value];
                NewVendors[kvp.Value].Rotation = Quaternion.LookRotation(Rotations[kvp.Value]);
            }
        }

        public void HandleModDisable() { }
    }
}
