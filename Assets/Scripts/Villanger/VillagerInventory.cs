using System.Collections.Generic;
using ItemResources;


namespace Villanger
{
    public class VillagerInventory
    {

        public readonly int numberOfSlots = 10;
        public int slotsTaken;

        private readonly Dictionary<Item, int> inventory = new Dictionary<Item, int>();
        
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
            if (slotsTaken + amount <= numberOfSlots)
            {
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
        
        
        
    }
}