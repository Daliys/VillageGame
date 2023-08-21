using UnityEngine;
using ItemResources;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary>
    /// Pick food up from the given stockpile and consume (no middle link in the form
    /// of villager inventory, immediately eaten)
    /// </summary>
    public class EatFoodTask : BehaviorTask
    {
        
        private readonly VillagerBehaviour villagerBehaviour;
        private readonly StockpileInventory stockpile;
        private float startTime;

        public EatFoodTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
        {
            this.villagerBehaviour = villagerBehaviour;
            this.stockpile = stockpile;
        }
        
        public override void Start()
        {
            base.Start();
            startTime = Time.time;
            villagerBehaviour.GetVillagerAnimation().SetTakingItemAnimation(true);
        }

        public override void Update()
        {
            if (!isRunning) return;

            base.Update();

            
            if (startTime + 5 < Time.time)
            {
                End();
            }
        }

        public override void End()
        {
            base.End();
            
            FoodItem foodItem = new FoodItem();

            villagerBehaviour.GetVillagerAnimation().SetTakingItemAnimation(false);

            if (villagerBehaviour.GetVillagerNeeds().GetFoodValue() + foodItem.foodValue <= 100)
            {

                float foodToEat = 100 - villagerBehaviour.GetVillagerNeeds().GetFoodValue();
                int itemsToEat = Mathf.RoundToInt(foodToEat / foodItem.foodValue);
                // TODO include the case in which the stockpile does not have the food
                stockpile.RemoveItemFromInventory(foodItem, itemsToEat);
                Debug.Log("item removed");
                villagerBehaviour.GetVillagerNeeds().ConsumeFood(foodItem, itemsToEat);
                Debug.Log("item consumed");
            }
        }
    }
}