using System.Collections.Generic;
using ItemResources;

namespace Villanger
{
    public class VillagerInventory : Inventory
    {
        
        public VillagerInventory(int numberOfSlots)
        {
            this.numberOfSlots = numberOfSlots;
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