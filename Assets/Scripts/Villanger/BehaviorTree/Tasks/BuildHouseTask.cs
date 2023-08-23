using UnityEngine;
using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary> <br>
    /// This task will get the villager to build their house with wood and stone they
    /// have in their inventory, maybe going to recollect the materials when their inventory
    /// goes empty.</br><br>
    /// Location is to be passed into the task call, or taken from a variable in
    /// VillagerBehaviour. (subject to change)
    /// </br>
    /// </summary>
    public class BuildHouseTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        private bool isAnimationSet = false;
        private StockpileInventory stockpile;

        public BuildHouseTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
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