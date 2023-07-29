using UnityEngine;

namespace Villanger.BehaviorTree.Tasks
{
    public class SleepTask : BehaviorTask
    {
        VillagerBehaviour villagerBehaviour;
        private float startTime;
        private readonly float sleepTime;
        public SleepTask(VillagerBehaviour villagerBehaviour)
        {
            this.villagerBehaviour = villagerBehaviour;
            sleepTime = villagerBehaviour.GetVillagerNeeds().GetSleepTime();
        }
        
        public override void Start()
        {
            base.Start();
            startTime = Time.time;
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
        }

        public override void End()
        {
            base.End();
        }
    }
}