using ItemResources;
using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class DepositItemsTask : BehaviorTask
    {
        private VillagerInventory villagerInventory;
        private FlagStockpileBehaviour stockpile;
        private float startTime;

        public DepositItemsTask(VillagerInventory villagerInventory, FlagStockpileBehaviour stockpile)
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
            if (true)
            {
                foreach(var item in villagerInventory.inventory.Keys)
                {
                    stockpile.AddItemToInventory(item, villagerInventory.inventory[item]);
                    villagerInventory.RemoveItemFromInventory(item, villagerInventory.inventory[item]);
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