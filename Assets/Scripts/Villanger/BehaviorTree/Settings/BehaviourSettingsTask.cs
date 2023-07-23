using System;

namespace Villanger.BehaviorTree.Settings
{
    [Serializable]
    public class BehaviourSettingsTask
    {
        public ManagerBehavior.TaskType taskType;
        public Condition[] conditions;
        
        public float CalculateTaskValue(VillagerBehaviour villagerBehaviour)
        {
            float value = 0;
            foreach (Condition condition in conditions)
            {
                value += condition.GetValue(villagerBehaviour);
            }

            return value;
        }

    }
}