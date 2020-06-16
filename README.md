# BetterVendors
A mod for Pathfinder Kingmaker, [KingmakerModMaker](https://github.com/lucianposton/KingmakerModMaker) is required to compile.

## Version 2.0.0
* Moved KingmakerModMaker to Harmony 2.0
* Moved Cotw/EA helpers to Harmony 2.0
* Added the merchant guild
  * The guild contains 4 new vendors that have the rushlight vendor tables
* Fixed some throne room vendors not being interactable
* Changed the way throne room vendors are handled, all vendors are held in the same dictionary
* Throne room vendors now have their own BlueprintUnit
* Throne room vendors have only basic dialog now for quick interaction

## TODO:
* Move rest codebase to Harmony 2.0
* Add support for keeping of a particular item even though it's on the trash list
* Rework hacky source code
* Add check to see if previous version vendors are in throne room
* VendorProgression seems to be giving Zarci the best stuff right off the bat
* Merchant Guild menu

## Notes:
* Before upgrading to 2.0 of the mod despawn the throne room vendors
* Before uninstalling 2.0 of the mod despawn the vendors 
