using UnityEngine;
using UnityEngine.AI;

namespace Villanger.BehaviorTree.Tasks
{
    public class MoveToTask : BehaviorTask
    {
        private Vector3 targetPosition;
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
        
        
        public Vector3 findClosestGoal(string tag, GameObject gameObject)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(tag);
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = gameObject.transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float currentDistance = diff.sqrMagnitude;
                if (currentDistance < distance)
                {
                    closest = go;
                    distance = currentDistance;
                }
            }
            return closest.transform.position;
        }

    }
}