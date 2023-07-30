using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class DepositItemsTask : BehaviorTask
    {
        private readonly VillagerBehaviour villagerBehaviour;
        private readonly StockpileInventory stockpile;
        private float startTime;

        public DepositItemsTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
        {
            this.villagerBehaviour = villagerBehaviour;
            this.stockpile = stockpile;
        }

        public override void Start()
        {
            base.Start();
            startTime = Time.time;
            villagerBehaviour.GetVillagerAnimation().SetPuttingItemAnimation(true);
        }

        public override void Update()
        {
            if (!isRunning) return;

            base.Update();
            
            //TODO move constant to a variable 
            if (startTime + 5 < Time.time)
            {
                End();
            }
        }

        public override void End()
        {
            base.End();
            villagerBehaviour.GetVillagerAnimation().SetPuttingItemAnimation(false);
            
            foreach(var item in villagerBehaviour.GetVillagerInventory().inventory.Keys)
            {
                // if item was added to stockpile
                if (stockpile.AddItemToInventory(item, villagerBehaviour.GetVillagerInventory().inventory[item]))
                {
                    villagerBehaviour.GetVillagerInventory().RemoveItemFromInventory(item, villagerBehaviour.GetVillagerInventory().inventory[item]);
                }
            }
        }

    }
}