# BetterVendors
A mod for Pathfinder Kingmaker, [KingmakerModMaker](https://github.com/lucianposton/KingmakerModMaker) is required to compile.

## Version 2.0.0
* Moved Entire code base to Harmony 2.0
* Moved KingmakerModMaker to Harmony 2.0
* Moved Cotw/EA helpers to Harmony 2.0
* Added the merchant guild. The guild contains 14 new vendors, they have the vendor tables of the harder to get to vendors.
These vendor tables include, Rushlight, Skeleton(All possible tables), Varnhold DLC tables including the Goblin Merchant in main campaign, 
Issili, and a vendor that has most of the items that are unobtainable.   
* Fixed some throne room vendors not being interactable
* Fixed VendorProgression giving Zarci the best stuff right off the bat
* Changed the way throne room vendors are handled, all vendors are held in the same dictionary
* Throne room vendors now have their own BlueprintUnit
* Throne room vendors have only basic dialog now for quick interaction
* Removed enabling/disabling individual throne room vendors, unnecessary feature
* Moved arcane vendor progression from arsinoe to zarci
* No longer need to hit the search button for vendor inject, list will update as you type after the 3rd character is typed
* Vendor inject will now confirm that you added the item to the vendor

## TODO:
* Add support for keeping of a particular item even though it's on the trash list
* Rework hacky source code
* Add support for DLC
* Figure out the locations of all the vendors, as of now they spawn on top of eachother
* Revist vendor progression code for improvements, bugs, etc. 
* Bug: Highlighting seems to no longer work after moving to Harmony 2.0?

## Notes:
* Before upgrading to 2.0 of the mod despawn the throne room vendors
* Before uninstalling 2.0 of the mod despawn the vendors 