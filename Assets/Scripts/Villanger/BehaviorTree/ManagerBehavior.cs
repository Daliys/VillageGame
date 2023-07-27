using System;
using ItemResources;
using TMPro;
using UnityEngine;
using Villanger.BehaviorTree.Settings;
using Villanger.BehaviorTree.Tasks;

namespace Villanger.BehaviorTree
{
    public class ManagerBehavior : MonoBehaviour
    {
        [SerializeField] private VillagerBehaviour villagerBehaviour;
        [SerializeField] private BehaviourSettings settings;

        [SerializeField] private FoodGatherable test_foodGatherging;
        [SerializeField] private GameObject test_sleepingPlace;
        [SerializeField] private FlagStockpileBehaviour test_stockpile;
        
        [SerializeField] private TextMeshProUGUI debugText;

        [Serializable]
        public enum TaskType
        {
            GoEat,
            GoSleep,
            GatherFood,
            
            NULL
        }


        private BehaviorTask currentTask;


        public ManagerBehavior(VillagerBehaviour villagerBehaviour)
        {
            this.villagerBehaviour = villagerBehaviour;
        }





        public void Update()
        {
            if (currentTask == null)
            {
                ChooseTask();
            }
            else
            {
                if (currentTask.IsRunning())
                {
                    currentTask.Update();
                }
                else
                {
                    currentTask = null;
                }
            }

            // --- DEBUG ---
            string str = "";
            foreach (BehaviourSettingsTask task in settings.tasks)
            {
                float conditionValue = task.conditions[0].GetValue(villagerBehaviour);
                str += task.taskType + " " + conditionValue + "\n";
            }
            str += "current task: " + currentTask + " " + currentTask?.IsRunning();
            debugText.text = str;
            
            // --- END DEBUG ---

        }


        private void ChooseTask()
        {
            TaskType bestTask = TaskType.NULL;
            float bestValue = 0;

            foreach (BehaviourSettingsTask task in settings.tasks)
            {
                float conditionValue = task.conditions[0].GetValue(villagerBehaviour);
                if (conditionValue > bestValue)
                {
                    bestValue = conditionValue;
                    bestTask = task.taskType;
                }
            }

            if (bestTask == TaskType.NULL)
            {
                return;
            }

            StartTask(bestTask);
        }


        private void StartTask(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.GoEat:
                    currentTask = new GoEatBehavior(villagerBehaviour, test_foodGatherging);
                    currentTask.Start();
                    break;
                case TaskType.GoSleep:
                    currentTask = new GoSleepBehavior(villagerBehaviour, test_sleepingPlace.transform.position);
                    currentTask.Start();
                    break;
                case TaskType.GatherFood:
                    currentTask = new GoGatherFoodBehavior(villagerBehaviour, test_foodGatherging, test_stockpile);
                    currentTask.Start();
                    break;
                
            }
        }



    }
}