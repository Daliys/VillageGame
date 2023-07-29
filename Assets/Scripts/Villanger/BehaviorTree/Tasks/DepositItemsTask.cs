using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class DepositItemsTask : BehaviorTask
    {
        private VillagerInventory villagerInventory;
        private StockpileInventory stockpile;
        private float startTime;

        public DepositItemsTask(VillagerInventory villagerInventory, StockpileInventory stockpile)
        {
            this.villagerInventory = villagerInventory;
            this.stockpile = stockpile;
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
            // i forgot what condition i wanted to put here
            // TODO here should be timer 
            if (true)
            {
                foreach(var item in villagerInventory.inventory.Keys)
                {
                    // if item was added to stockpile
                    if (stockpile.AddItemToInventory(item, villagerInventory.inventory[item]))
                    {
                        villagerInventory.RemoveItemFromInventory(item, villagerInventory.inventory[item]);
                    }
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