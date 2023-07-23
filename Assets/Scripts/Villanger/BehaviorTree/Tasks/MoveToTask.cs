using UnityEngine;
using UnityEngine.AI;

namespace Villanger.BehaviorTree.Tasks
{
    public class MoveToTask : BehaviorTask
    {
        private readonly Vector3 targetPosition;
        private NavMeshAgent navMeshAgent;

        public MoveToTask (NavMeshAgent navMeshAgent, Vector3 targetPosition)
        {
            this.navMeshAgent = navMeshAgent;
            this.targetPosition = targetPosition;
        }
        
        public override void Start()
        {
            base.Start();
            navMeshAgent.SetDestination(targetPosition);
            
        }

        public override void Update()
        {
            base.Update();
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                End();
            }
        }

        public override void End()
        {
            base.End();
        }
        
    }
}