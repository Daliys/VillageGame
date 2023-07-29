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
            if (!isRunning) return;
            
            base.Update();
            if (startTime + foodGatherable.GetTimeToGather() < Time.time)
            {
                if (!inventory.AddItemToInventory(foodGatherable.GetFoodItem(), foodGatherable.GetFoodAmount()))
                {
                    throw  new System.Exception("Inventory is full");
                }
                End();
            }
        }
        
        public override void End()
        {
            base.End();
            
        }
        
    }
}