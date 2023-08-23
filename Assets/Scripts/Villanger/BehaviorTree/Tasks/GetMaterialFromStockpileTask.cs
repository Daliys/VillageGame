using UnityEngine;
using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary> 
    /// This task will get the villager to pick up materials for their house or any other thing from the stockpile.
    /// </summary>
    public class GetMaterialFromStockpileTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        private bool isAnimationSet = false;
        private StockpileInventory stockpile;

        public GetMaterialFromStockpileTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
        {
            this.villagerBehaviour = villagerBehaviour;
            this.stockpile = stockpile;
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void End()
        {
            base.End();


        }



    }
}