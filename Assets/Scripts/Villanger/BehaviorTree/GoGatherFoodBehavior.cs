using ItemResources;
using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class GoGatherFoodBehavior : BehaviorTask
    {
        
         private Sequence sequence;
         
            public GoGatherFoodBehavior(VillagerBehaviour villagerBehaviour, FoodGatherable gatherableObject, FlagStockpileBehaviour stockpile)
            {
                sequence = new Sequence();
                
                sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(),gatherableObject.GetPosition()));
                sequence.AddTask(new GatherFoodTask(villagerBehaviour.GetVillagerInventory(),gatherableObject));
                sequence.AddTask(new MoveToTask(villagerBehaviour.GetAgent(), stockpile.GetPosition()));
                sequence.AddTask(new DepositItemsTask(villagerBehaviour.GetVillagerInventory(),stockpile.stockpileInventory));
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

            public override void End()
            {
                base.End();
                
            }
    }
}