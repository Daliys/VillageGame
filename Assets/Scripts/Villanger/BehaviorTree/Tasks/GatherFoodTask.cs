using ItemResources;
using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class GatherFoodTask : BehaviorTask
    {
        private VillagerBehaviour villagerBehaviour;
        private FoodGatherable foodGatherable;
        private float startTime;

        public GatherFoodTask(VillagerBehaviour villagerBehaviour, FoodGatherable foodGatherable)
        {
            this.villagerBehaviour = villagerBehaviour;
            this.foodGatherable = foodGatherable;
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
            if (startTime + foodGatherable.GetTimeToGather() < Time.time)
            {
                if (!villagerBehaviour.GetVillagerInventory().AddItemToInventory(foodGatherable.GetFoodItem(), foodGatherable.GetFoodAmount()))
                {
                    throw  new System.Exception("Inventory is full");
                }
                End();
            }
        }
        
        public override void End()
        {
            base.End();
            villagerBehaviour.GetVillagerAnimation().SetTakingItemAnimation(false);
        }
        
    }
}