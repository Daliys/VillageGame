using System;
using System.Collections.Generic;
using ItemResources;
using UnityEngine;

public class Inventory
{
    protected int numberOfSlots = 10;
    protected int slotsTaken;

    /// <summary>
    /// All items of the inventory. Public to access from outer scripts.
    /// </summary>
    public readonly Dictionary<Item, int> inventory = new();

    /// <summary>
    ///  Add an item to the inventory. If the item is already in the inventory, add the amount to the existing amount.
    /// </summary>
    /// <param name="item">the item to be added to the inventory  </param>
    /// <param name="amount">amount of the item to be added to the inventory</param>
    public bool AddItemToInventory(Item item, int amount)
    {
        if (item == null)
        {
            throw new NullReferenceException("Item is null");
        }

        Debug.Log("Detected item addition attempt");
        if (slotsTaken + amount * item.spaceTaken <= numberOfSlots)
        {
            Debug.Log("Adding item with name " + item.itemName);
            if (inventory.ContainsKey(item))
            {
                inventory[item] += amount;
            }
            else
            {
                inventory.Add(item, amount);
            }

            slotsTaken += amount;
            return true;
        }

        return false;
    }


    public bool RemoveItemFromInventory(Item item, int amount)
    {
        if (!inventory.ContainsKey(item)) return false;
        if (inventory[item] < amount) return false;

        inventory[item] -= amount;
        slotsTaken -= amount;

        if (inventory[item] <= 0)
        {
            inventory.Remove(item);
        }

        return true;
    }

    public Dictionary<Item, int> RemoveAllItems()
    {
        Dictionary<Item, int> items = new Dictionary<Item, int>();
        foreach (var item in inventory)
        {
            items.Add(item.Key, item.Value);
        }

        inventory.Clear();
        slotsTaken = 0;
        return items;
    }

    public int GetAmountOfItem(Item item)
    {
        if (inventory.TryGetValue(item, out var ofItem))
        {
            return ofItem;
        }

        return 0;
    }
  

}