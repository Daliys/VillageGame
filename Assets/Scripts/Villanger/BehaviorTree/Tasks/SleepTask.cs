using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class SleepTask : BehaviorTask
    {
        readonly VillagerBehaviour villagerBehaviour;
        private float startTime;
        private readonly float sleepTime;
        private bool isAnimationSet = false;
        
        
        public SleepTask(VillagerBehaviour villagerBehaviour)
        {
            this.villagerBehaviour = villagerBehaviour;
            sleepTime = villagerBehaviour.GetVillagerNeeds().GetSleepTime();
        }
        
        public override void Start()
        {
            base.Start();
            startTime = Time.time;
            villagerBehaviour.GetVillagerAnimation().SetSleepingAnimation(true);
        }

        public override void Update()
        {
            base.Update();
            if (startTime + sleepTime < Time.time)
            {
                // TODO change this to a proper value
                villagerBehaviour.GetVillagerNeeds().RestoreEnergy(100);
                End();
            }
            
            // TODO move constant to a variable
            if(!isAnimationSet && startTime + sleepTime - 2.7 < Time.time)
            {
                isAnimationSet = true;
                villagerBehaviour.GetVillagerAnimation().SetSleepingAnimation(false);
            }
        }

        public override void End()
        {
            base.End();
          
        }
    }
}