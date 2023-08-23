using UnityEngine;
using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{
    /// <summary> <br>
    /// This task will get the villager to evaluate the land around them in order
    /// to find the best suitable location for a building.
    /// The land would be scanned for locations in the range of 100 meters (subject to change)
    /// from the villager, and the potential plots - the ones which don't create overlaps with other buildings and roads -
    /// will further be evaluated to find the best one.
    /// </br><br>
    /// The land will be checked in increments of 0.5 meter (subj to change), and the best location
    /// would be selected by those factors:</br>
    /// <br>
    /// 1. Distance from the stockpile (the closer - the more arbitrary points to the location) </br> <br>
    /// 2. Distance from the nearest road to the house (the closer to a road - the better) </br> <br>
    /// 3. The amount of work needed to smoothen out the terrain and remove trees and rocks and such (the less work - the better) </br> <br>
    /// 4. Least important, only compared if a draw between plots is created and not sorted out by previous factors -
    /// the distance the villager would need to walk from his/her current position to the plot. Obviously, would have
    /// very minor influence on the points.</br>
    /// </summary>
    public class EvaluateLocationTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        // the villager will probably do a thinking animation of some sort
        private bool isAnimationSet = false;
        private StockpileInventory stockpile;
        private List<Transform> possibleLocations;
        
        public EvaluateLocationTask(VillagerBehaviour villagerBehaviour, StockpileInventory stockpile)
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

            possibleLocations = ScanLand();

            if (possibleLocations.Count == 0)
            {
                // Make the villager move to a different location and try again.
            }

            // Evaluate the remaining locations based on the factors listed at lines 16 to 19.
            // Points would be given as float values to make it exponentially harder to end up with a draw.

            // The best location is to be moved.. somewhere? maybe to a variable in the villager behaviour, not sure yet.
            
        }

        private List<Transform> ScanLand ()
        {
            List<Transform> theoreticalLocations = new List<Transform>();

            // Iterate through the villager's surrounding coordinates, starting from
            // -50 x -50 z to +50 x + 50 z, adding 0.5 (subject to change) at a time after scanning a whole line.
            // Append all theoretically possible locations to the list.

            // Now, move a transparent cube to each location and check its collisions. If it collides with a house or
            // an immovable object (ie a lake or a road), remove this location from the list.

            return theoreticalLocations;
        }


    }
}