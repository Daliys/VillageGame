using ItemResources;
using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class GoEatBehavior : BehaviorTask
    {

        private readonly Sequence sequence;

        
        public GoEatBehavior(VillagerBehaviour villagerBehaviour, FoodGatherable gatherableObject)
        {
            sequence = new Sequence();
            
            sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(),gatherableObject.GetPosition()));
            sequence.AddTask(new GatherFoodTask(villagerBehaviour.GetVillagerInventory(),gatherableObject));
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