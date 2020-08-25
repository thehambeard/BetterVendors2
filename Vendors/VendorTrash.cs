using Kingmaker;
using Kingmaker.Blueprints.Root.Strings.GameLog;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.UI.Log;
using Kingmaker.UI.ServiceWindow;
using Kingmaker.UI.Vendor;
using ModMaker;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static BetterVendors.Main;
using static BetterVendors.Utilities.SettingsWrapper;

namespace BetterVendors.Vendors
{
    internal class VendorTrashController : IModEventHandler, ISlotsController, IAreaLoadingStagesHandler
    {
        public int Priority => 600;

        public void HandleModDisable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            EventBus.Unsubscribe(this);
        }

        public void HandleModEnable()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());

            EventBus.Subscribe(this);
        }

        public void HandleSlotClick(Kingmaker.UI.ServiceWindow.ItemSlot slot)
        {
            Mod.Debug(MethodBase.GetCurrentMethod());

            bool control = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            
            if (control && ToggleVendorTrash && Mod.Enabled)
            {
                if (!slot.Item.IsNonRemovable && VendorTrashItems.Contains(slot.Item.Blueprint.AssetGuid) && slot.Index != -1)
                {
                    VendorTrashItems.Remove(slot.Item.Blueprint.AssetGuid);
                    Mod.Debug(string.Format("{0} removed from trash list.", slot.Item.Blueprint.Name));

                    foreach (ItemTypicalSlot itp in slot.ParentGroup.Slots)
                    {
                        ItemSlotHelper.HighlightSlots(itp);
                    }
                }
                else
                {
                    if (!slot.Item.IsNonRemovable && !VendorInject.invalidItems.Contains(slot.Item.Blueprint.AssetGuid) && slot.Index != -1)
                    {
                        VendorTrashItems.Add(slot.Item.Blueprint.AssetGuid);
                        Mod.Debug(string.Format("{0} added to trash list.", slot.Item.Blueprint.Name));
                        foreach (ItemTypicalSlot itp in slot.ParentGroup.Slots)
                        {
                            ItemSlotHelper.HighlightSlots(itp);
                        }
                    }
                }
            }
        }

        public void HandleSlotDoubleClick(Kingmaker.UI.ServiceWindow.ItemSlot slot) { }

        public void HandleSlotDragEnd(Kingmaker.UI.ServiceWindow.ItemSlot from, Kingmaker.UI.ServiceWindow.ItemSlot to) { }

        public void HandleSlotDragStart(Kingmaker.UI.ServiceWindow.ItemSlot slot) { }

        public void HandleSlotDrop(Kingmaker.UI.ServiceWindow.ItemSlot slot) { }

        public void HandleSlotHoverEnd(Kingmaker.UI.ServiceWindow.ItemSlot slot) { }

        public void HandleSlotHoverStart(Kingmaker.UI.ServiceWindow.ItemSlot slot) { }

        public void HandleSlotSplit(Kingmaker.UI.ServiceWindow.ItemSlot from, Kingmaker.UI.ServiceWindow.ItemSlot to, int count = 0) { }

        public void HandleSlotsSorted(SlotsGroup slotsGroup) { }

        public void OnAreaLoadingComplete()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());

            if ((Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("173c1547502bb7243ad94ef8eec980d0") ||
                Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("c39ed0e2ceb98404b811b13cb5325092") ||
                Game.Instance.CurrentlyLoadedArea.AssetGuid.Equals("ead426a6c23d39548a670ee515d77df4"))
                && ToggleAutoSell && ToggleVendorTrash && Mod.Enabled)
            {
                foreach (ItemEntity item in ItemSlotHelper.ItemsToRemove(true))
                {
                    if (TrashItemsKeep.ContainsKey(item.Blueprint.AssetGuid))
                        Game.Instance.Player.Inventory.Remove(item, item.Count - TrashItemsKeep[item.Blueprint.AssetGuid]);
                    else
                        Game.Instance.Player.Inventory.Remove(item, 1);
                }
            }
        }

        public void OnAreaScenesLoaded() { }
    }

    public static class ItemSlotHelper
    {
        public static void HighlightSlots(Kingmaker.UI.ServiceWindow.ItemSlot itemSlot)
        {
            if (itemSlot.Index != -1 && itemSlot.HasItem && VendorTrashItems.Contains(itemSlot.Item.Blueprint.AssetGuid) && ToggleVendorTrash && Mod.Enabled)
            {
                itemSlot.ItemImage.color = TrashColor;
            }
            else if (itemSlot.Index != -1 && itemSlot.HasItem && itemSlot.IsScroll && ToggleHighlightScrolls && Mod.Enabled)
            {
                itemSlot.ItemImage.color = ScrollColor;
            }
            else
            {
                if (itemSlot.HasItem)
                    itemSlot.ItemImage.color = Color.white;
                else
                    itemSlot.ItemImage.color = Color.clear;
            }
        }

        public static List<ItemEntity> ItemsToRemove(bool PayPlayer = false)
        {
            Dictionary<string, int> keepCount = new Dictionary<string, int>();
            List<ItemEntity> listSell = new List<ItemEntity>();
            long gold = 0;
            foreach (ItemEntity item in Game.Instance.Player.Inventory)
            {
                if (VendorTrashItems.Contains(item.Blueprint.AssetGuid) && item.IsInStash)
                {
                    if (keepCount.ContainsKey(item.Blueprint.AssetGuid))
                    {
                        if (keepCount[item.Blueprint.AssetGuid] >= TrashItemsKeep[item.Blueprint.AssetGuid])
                            continue;
                    }
                    if (PayPlayer)
                    {
                        gold += (item.Blueprint.SellPrice * (long)item.Count);
                    }
                    listSell.Add(item);
                    if (TrashItemsKeep.ContainsKey(item.Blueprint.AssetGuid))
                    {
                        if (keepCount.ContainsKey(item.Blueprint.AssetGuid))
                            keepCount[item.Blueprint.AssetGuid]++;
                        else
                            keepCount.Add(item.Blueprint.AssetGuid, 1);
                    }
                }
            }
            if(PayPlayer)
            {
                Game.Instance.Player.GainMoney(gold);
                LogItemData data = new LogItemData($"{gold} gold made from autoselling trash loot!", GameLogStrings.Instance.DefaultColor, null, PrefixIcon.None, new List<LogChannel>
                {
                    LogChannel.None
                });
                Game.Instance.UI.BattleLogManager.LogView.AddLogEntry(data, false);
            }
            return listSell;
        }
    }


    [HarmonyLib.HarmonyPatch(typeof(VendorMassSale))]
    [HarmonyLib.HarmonyPatch("PushSale")]
    internal static class VenderMassSale_PushSale_Patch
    {
        public static bool Prefix()
        {
            Mod.Debug(MethodBase.GetCurrentMethod());
            if (!ToggleVendorTrash && !Main.Mod.Enabled)
                return true;
            foreach (ItemEntity i in ItemSlotHelper.ItemsToRemove())
            {
                Game.Instance.Vendor.AddForSell(i, i.Count);
            }
            return true;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Kingmaker.UI.ServiceWindow.ItemSlot))]
    [HarmonyLib.HarmonyPatch("CopyItem")]
    internal static class ItemSlot_CopyItem_Patch
    {
        public static void Postfix(ItemSlot __instance)
        {
            ItemSlotHelper.HighlightSlots(__instance);
            __instance.UpdateCount();
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Kingmaker.UI.ServiceWindow.ItemSlot))]
    [HarmonyLib.HarmonyPatch("SetupEquipPossibility")]
    internal static class ItemSlot_SetupEquipPossibility_Patch
    {
        public static void Postfix(Kingmaker.UI.ServiceWindow.ItemSlot __instance)
        {
            ItemSlotHelper.HighlightSlots(__instance);
            __instance.UpdateCount();
        }
    }
}
