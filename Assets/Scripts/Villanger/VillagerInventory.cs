using UnityEngine;
using System.Collections.Generic;


namespace Villanger
{
    public class VillagerInventory
    {

        public readonly int numberOfSlots = 10;
        public int slotsTaken;
        public List<string> inventory;

        public VillagerInventory(int numberOfSlots)
        {
            this.numberOfSlots = numberOfSlots;

        }
        

        /// <summary>
        /// Small function to add an item to inventory safely.
        /// </summary>
        /// <param name="space">The amount of space the item takes up</param>
        /// <param name="name">The name of the item</param>
        public void AddItemToInventory(int space, string name)
        {
            if (slotsTaken + space <= numberOfSlots)
            {
                inventory.Add(name);
                slotsTaken += space;
            }
        }
    }
}