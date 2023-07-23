using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class GoEatBehavior : BehaviorTask
    {

        private readonly Sequence sequence;

        
        public GoEatBehavior(VillagerBehaviour villagerBehaviour, IGatherable gatherableObject)
        {
            sequence = new Sequence();
            
            sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(),gatherableObject.GetPosition()));
            sequence.AddTask(new GatherFoodTask(gatherableObject));
            sequence.AddTask(new EatFoodTask());
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