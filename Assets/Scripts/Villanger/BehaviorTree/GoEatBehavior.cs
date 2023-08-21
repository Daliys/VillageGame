using System.Collections.Generic;
using ItemResources;
using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class GoEatBehavior : BehaviorTask
    {

        private readonly Sequence sequence;
        private VillagerBehaviour villagerBehaviour;


        public GoEatBehavior(VillagerBehaviour villagerBehaviour, FoodGatherable gatherableObject, FlagStockpileBehaviour stockpile)
        {
            this.villagerBehaviour = villagerBehaviour;
            sequence = new Sequence();

            sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(), stockpile.GetPosition()));
            sequence.AddTask(new EatFoodTask(villagerBehaviour, stockpile.stockpileInventory));

        }


        public override void Start()
        {
            base.Start();
            sequence.Start();
        }

        public override void Update()
        {
            base.Update();
            if (!sequence.IsRunning())
            {
                End();
            }

            sequence.Update();
        }

        public override void End()
        {
            base.End();

            //  commented out because it caused issues and its not the right place
            //  for it

            //VillagerInventory inventory = villagerBehaviour.GetVillagerInventory();
            //VillagerNeeds needs = villagerBehaviour.GetVillagerNeeds();

            //// Get the amount of food that the villager needs to restore
            //float amountToRestore = needs.GetAmountOfFoodNeeded();

            //// Get a dictionary of all food items and their quantities in the inventory
            //Dictionary<FoodItem, int> foodItems = inventory.GetAllFoodItems();
            //foreach (var foodItem in foodItems)
            //{
            //    // If the required amount of food has been restored, exit the loop
            //    if (amountToRestore <= 0) break;

            //    // Get the quantity of this specific food item in the inventory
            //    int amountOfFood = foodItem.Value;

            //    // Calculate the needed amount of this food item to satisfy the villager's hunger
            //    int neededAmount = (int)(amountToRestore / foodItem.Key.foodValue);

            //    // Calculate the amount of food that can be eaten from this food item
            //    int amountToEat = amountOfFood >= neededAmount ? neededAmount : amountOfFood;

            //    // Try to remove the calculated amount of food from the inventory
            //    if (inventory.RemoveItemFromInventory(foodItem.Key, amountToEat))
            //    {
            //        // If the food is successfully removed from the inventory, update the needs
            //        needs.ConsumeFood(foodItem.Key, amountToEat);
            //    }
            }
        }
        
        
    
}