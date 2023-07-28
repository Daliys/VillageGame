using System;
using System.Collections.Generic;
using ItemResources;
using UnityEngine;

namespace Villanger
{
    public class VillagerInventory
    {

        public readonly int numberOfSlots = 10;
        public int slotsTaken;

        /// <summary>
        /// All items of the inventory. Public to access from outer scripts.
        /// </summary>
        public readonly Dictionary<Item, int> inventory = new();
        
        public VillagerInventory(int numberOfSlots)
        {
            this.numberOfSlots = numberOfSlots;
        }
        

        /// <summary>
        ///  Add an item to the inventory. If the item is already in the inventory, add the amount to the existing amount.
        /// </summary>
        /// <param name="item">the item to be added to the inventory  </param>
        /// <param name="amount">amount of the item to be added to the inventory</param>
        public void AddItemToInventory(Item item, int amount)
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
            }
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
        
        public int GetAmountOfItem(Item item)
        {
            if (inventory.TryGetValue(item, out var ofItem))
            {
                return ofItem;
            }
            return 0;
        }
        
        
        public Dictionary<FoodItem, int> GetAllFoodItems() 
        {
            Dictionary<FoodItem, int> foodItems = new Dictionary<FoodItem, int>();
            foreach (var item in inventory)
            {
                if (item.Key is FoodItem)
                {
                    foodItems.Add((FoodItem)item.Key, item.Value);
                }
            }
            return foodItems;
        }
      
        
        
    }
}