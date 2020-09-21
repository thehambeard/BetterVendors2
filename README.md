# BetterVendors
A mod for Pathfinder Kingmaker, [KingmakerModMaker](https://github.com/thehambeard/KingmakerModMaker) is required to compile.  Thanks to hsinyuhcan and lucianposton

## Version 2.0.7
* Fixed trash loot only autoselling one item, instead of the stack
* Fixed crash if position/rotation settings were missing
* Fixed Goblin Merchant in guild to sell correct items from varnhold's lot
* Total amount of gold received from autoselling displayed in log
* Added Bokken to the throne room to sell potions
* Added a button to sell trash if autosell is an option player doesn't like.
## Verison 2.0.6
* Fixed issue with vendors duplicating.
* Added a button to remove <2.0 vendors
* Added buttons to enable/disable a throne room vendor
## Version 2.0.5
* Fixed settings being reset on updating to new versions
* Added a button to clear your trash list
* Added ability to keep a certain number of trash items
* Updated the wording in some of the menus to be easier to understand
## Version 2.0.4
* Fixed issue with companions despawning
## Version 2.0.3
* Fixed show trash items toggle button throwing an expection.
## Version 2.0.2
* Long load times have been fixed
## Version 2.0.1
* Moved Entire code base to Harmony 2.0
* Moved KingmakerModMaker to Harmony 2.0
* Moved Cotw/EA helpers to Harmony 2.0
* Added the merchant guild. The guild contains 14 new vendors, they have the vendor tables of the harder to get to vendors.
These vendor tables include, Rushlight, Skeleton(All possible tables), Varnhold DLC tables including the Goblin Merchant in main campaign, 
Issili, and a vendor that has most of the items that are unobtainable.   
* Changed the way throne room vendors are handled, all vendors are held in the same dictionary
* Fixed some throne room vendors not being interactable
* Throne room vendors now have their own BlueprintUnit
* Throne room vendors have only basic dialog now for quick interaction
* Throne room vendors will now stay in their locations across play throughs, and when upgrading to the city throne room 
* Removed enabling/disabling individual throne room vendors, unnecessary feature
* Moved arcane vendor progression from arsinoe to zarci
* No longer need to hit the search button for vendor inject, list will update as you type after the 3rd character is typed
* Vendor inject will now confirm that you added the item to the vendor
* New vendor POI flags will always be shown on the map.

## TODO:
* Fix visual issue of trash items not updating their color in vendor screens
* Add sell trash button that is only enabled in certain areas as an option from using auto sell
* Add support for DLC autosell locations 

## Notes:
* Uninstalling during a save will probably break it.
