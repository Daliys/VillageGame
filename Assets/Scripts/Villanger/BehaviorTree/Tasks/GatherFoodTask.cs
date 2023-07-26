using System.Threading;
using ItemResources;
using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class GatherFoodTask : BehaviorTask
    {
        private VillagerInventory inventory;
        private FoodGatherable foodGatherable;
        private float startTime;

        public GatherFoodTask(VillagerInventory inventory, FoodGatherable foodGatherable)
        {
            this.inventory = inventory;
            this.foodGatherable = foodGatherable;
        }
        
        public override void Start()
        {
            base.Start();
            startTime = Time.time;
        }
        
        public override void Update()
        {
            base.Update();
            if (Time.time - startTime > 1)
            {
                inventory.AddItemToInventory(foodGatherable.GetFoodItem(), foodGatherable.GetFoodAmount(), foodGatherable.GetFoodItemSpace());
                End();
            }
        }
        
        public override void End()
        {
            base.End();
            
        }
        
    }
}