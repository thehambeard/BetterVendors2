# BetterVendors
A mod for Pathfinder Kingmaker, [KingmakerModMaker](https://github.com/lucianposton/KingmakerModMaker) is required to compile.

## Version 2.0.0
* Moved Entire code base to Harmony 2.0
* Moved KingmakerModMaker to Harmony 2.0
* Moved Cotw/EA helpers to Harmony 2.0
* Added the merchant guild
  * The guild contains 4 new vendors that have the rushlight vendor tables
* Fixed some throne room vendors not being interactable
* Fixed VendorProgression giving Zarci the best stuff right off the bat
* Changed the way throne room vendors are handled, all vendors are held in the same dictionary
* Throne room vendors now have their own BlueprintUnit
* Throne room vendors have only basic dialog now for quick interaction
* Removed enabling/disabling individual throne room vendors, unnecessary feature
* Moved arcane vendor progression from arsinoe to zarci

## TODO:
* Add support for keeping of a particular item even though it's on the trash list
* Rework hacky source code
* Add support for DLC
* revist vendor progression code for improvements, bugs, etc. 
* Bug: Moving vendors after load duplicates vendor

## Notes:
* Before upgrading to 2.0 of the mod despawn the throne room vendors
* Before uninstalling 2.0 of the mod despawn the vendors 

## Ensure these are added:
VendorTables:
- [ ] C2_VendorTableLarge.03139ca71b2f2a34bae0a8a11a342fe4.json
- [ ] C2_VendorTableSmall.efa12e6fcc198a748875fea573e94175.json
- [X] C3_VendorTableLarge.b3bc1bb9f4a59f3438edc505e0f3b407.json
- [ ] C3_VendorTableSmall.9126c670f0743b647b4e9ba850214d8d.json
- [X] C4_VendorTableLarge.fc01b45fee3606749a21d9612c5629a6.json
- [X] C4_VendorTableSmall.4b1bb03a5d19a534bad2aa5cd766af92.json
- [ ] C61_IssiliVendorTable.1cfdec17b06a47740bacb7a7ea9dd0c6.json
- [ ] DLC2QuartermasterBaseTable.8035c1313902fae4796d36065e769297.json
- [ ] DLC2QuartermasterImprovedTable.7c68519dca4334c408227bb0140ac50f.json
- [ ] Rushlight_GeneralistVendorTable.78e1aab1a8d9f4649ae83388c33283cd.json
- [ ] Rushlight_MagicVendorTable.2712cf5716e578f4e95165cb43dda8ae.json
- [ ] Rushlight_SmithVendorTable.0d506a80e3f07544394d812ad7014cf3.json
- [ ] C71_GoblinVendorTable.488ce39f5594cff4f8a8228e95b091e3.json
- [ ] Custom vendor table for the items below
 
Items:
- [ ] BetrayalFirstItem.92cfdd028ba3bff4f9f29858f81b1c71.json
- [ ] BetrayalSecondItem.8b6da0c2cead68d49bbc95316db2883f.json
- [ ] ArmorBandedMailArmyItem.95ac218cacaaf574bbe3d294bdca4f64.json
- [ ] CelestialArmorItem.e9d7a6a56346fd942853490c89ece7d1.json
- [ ] WarpathItem.67faf43ace752b54eb831dfae5059b89.json
- [ ] BonethreaderBootsItem.591b91f6bd5b7d841a6cf3a9d401f4eb.json
- [ ] BootsOfTheLightStepItem.815cc85ce13ab64428253aea3b6708a8.json
- [ ] BootsOfTheSwampItem.1ccb68fd1e0f6d141b739e3744e5af4e.json
- [ ] BracersSpikedHodagItem.0237641b0c2de344d85821840419b4d2.json
- [ ] HatWitchRedItem.c26987a7ed22f3347b75d1dac40d4feb.json
- [ ] HeadbandOfPerfection2.b9b49933be6ac7f4aa3c71c602227332.json
- [ ] HelmetArmagItem.d22b682ccd5672042891b1a7882278a9.json
- [ ] HelmetDragonscaleBlackItem.19f27f871b1934a47b08b78fbccc3865.json
- [ ] HelmetEvilItem.9fdbea707a02b8d448e8e46fd3088468.json
- [ ] HelmetEvilTeethItem.24f5cdf6f8d58064aa843e625616f94c.json
- [ ] HelmetFullplateCyclopsGroetusItem.107013e973a60eb44a067184c80fa5d9.json
- [ ] HelmetFullplatePitaxGuardItem.e2f801723e487a34ebb6155936ebd1aa.json
- [ ] HelmetFullplateRichSilverBlueItem.282393f860a510b429432e13943f27c0.json
- [ ] HelmetFullplateRoyalItem.a3713ad3603420447bfaa1c4e552e55d.json
- [ ] HelmetFullplateVilderavnItem.aa7077c0a39efbd46a1fb7997b8d8411.json
- [ ] HelmetHalfPlateFeyItem.b4a543719a69c1142af4b0c0832137b3.json
- [ ] HelmetNobleItem.6e937af0f78bb474092f00ee0d531886.json
- [ ] RogueCapItem.e7dbbfd147a9e214396a4fbaf68563dd.json
- [ ] AmuletOfTimeTrickery.8fdd83cc5f9d57e4387430a1b437de0c.json
- [ ] LegacyOfAccursedTree.622909c22c966f64e98e265c8cee594b.json
- [ ] LissomItem.41664943b58f3e04f9d898a9747295aa.json
- [ ] LongbowOfErastilItem.2f771b62ffb4bdf45a425ba0a0130217.json
- [ ] LongswordKnightMasterworkItem.6db47f17f3711974c8e816e30ff0a40f.json
- [ ] MorningstarRoyalLegendaryCorrosiveItem.ddece7b44eb78c44fb9aca7eb5d94d17.json
- [ ] MorningstarRoyalLegendaryFlamingItem.e893f03f60b704241a0b47febbc06c77.json
- [ ] MorningstarRoyalLegendaryFrostItem.f65775e982d9d87478d3013a0a7c52c3.json
- [ ] MorningstarRoyalLegendaryShockItem.d120d33fb4e082242ba4fcae5f0bd094.json
- [ ] MorningstarRoyalLegendaryThunderingItem.e7e93ed90f0e8294889d34b74c2f1286.json
- [ ] TeamworkItem.336dd76bbd5998347a3fbed7f4cbbd4a.json
- [ ] Tongi5MithralItem.eee4d2c600f03654c930203164722ff2.json
- [ ] TridentArmyNormalItem.ffe8ae794fe34294fb565ed3f677ece0.json
- [ ] TwinSerpentsItem.fa02b3d13a6598c4f97acfbabfe1e01e.json
- [ ] VenomItem.934a377b465e2334084a31c938916c74.json
- [ ] ViolentMischiefItem.1f04244d7816cf74b8039b65560b0cdf.json
- [ ] BardichePitaxGuardItem.c7e5f05e1dd1c9644adf31b0a5f0d121.json
- [ ] BattleaxeOfEarthWrath.39ac939af34e75d48aff1554bdc8dc19.json
- [ ] FrostBladeItem.b0691dc56a4a5b1498f129eef0948447.json
- [ ] BanditLightMaceItem.815f9ba2e31fdab49a7464df3189b71b.json
- [ ] SwordOfEternalSquire.59a594b9b6d72c74692d53632ed29b0d.json
- [ ] TangledClawsItem.7510be4c91e6a754d8c887db44585324.json
- [ ] Tongi5MithralItem.eee4d2c600f03654c930203164722ff2.json
- [ ] BladedPlateItem.b99f5d0d7f30c9e4f9f7afbdf0adc264.json
