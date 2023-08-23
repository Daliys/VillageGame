using UnityEngine;
using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary> 
    /// This task will get the villager to use pebble items in their inventory to
    /// build roads. Not sure how exactly the roads would be laid out though, maybe
    /// from the stockpile to forests, clay collection pits, stone quarries, and then the
    /// houses placed along the way would get connected too.
    /// </summary>
    public class BuildRoadTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        private bool isAnimationSet = false;
        private StockpileInventory stockpile;

        public BuildRoadTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
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