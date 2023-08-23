using UnityEngine;
using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary> <br>
    /// This task will get the villager to locate and cut down a tree, then chop it up and carry the wood
    /// to the stockpile. </br>
    /// <br>
    /// The tree will fall (maybe a change of the hitbox to make it unstable or animation) and the villager
    /// will chop it, getting wood from it for every few chops. Every tree would have a preset
    /// amount of wood in it at the moment of being cut down, and when that ends the tree will get its hitbox removed
    /// to fall below ground, and then get deleted (subject to change)</br>
    /// </summary>
    public class GatherWoodTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        private bool isAnimationSet = false;
        private StockpileInventory stockpile;

        public GatherWoodTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
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