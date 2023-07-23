using UnityEngine;

namespace Villanger.BehaviorTree.Settings
{
    [CreateAssetMenu(fileName = "BehaviourSettings", menuName = "Villanger/BehaviourSettings", order = 0)]
    public class BehaviourSettings : ScriptableObject
    {
        
        public BehaviourSettingsTask[] tasks;
    }
}