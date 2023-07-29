using UnityEngine;
using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class GoSleepBehavior : BehaviorTask
    {
        
        private readonly Sequence sequence;

        
        public GoSleepBehavior(VillagerBehaviour villagerBehaviour, Vector3 position)
        {
            sequence = new Sequence();
            
            sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(),position));
            sequence.AddTask(new SleepTask(villagerBehaviour));
        }
     
        
        public override void Start()
        {
            base.Start();
            sequence.Start();
        }
        
        public override void Update()
        {
            base.Update();
            if (!sequence.IsRunning())
            {
                End();
            }

            sequence.Update();
        }
        
    }
}