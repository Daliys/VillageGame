using System.Collections.Generic;

namespace Villanger.BehaviorTree.Tasks
{

    public class Sequence : BehaviorTask
    {
        private List<BehaviorTask> tasks = new List<BehaviorTask>();
        private int currentTaskIndex = 0;

        public void AddTask(BehaviorTask task)
        {
            tasks.Add(task);
        }

        public override void Start()
        {
            base.Start();
            currentTaskIndex = 0;
            tasks[currentTaskIndex].Start();
        }

        public override void Update()
        {
            if (!isRunning) return;

            if (currentTaskIndex >= tasks.Count)
            {
                End();
                return;
            }

            tasks[currentTaskIndex].Update();

            if (!tasks[currentTaskIndex].IsRunning())
            {
                currentTaskIndex++;
                if (currentTaskIndex < tasks.Count)
                {
                    tasks[currentTaskIndex].Start();
                }
            }
        }

        public override void End()
        {
            base.End();
            currentTaskIndex = 0;
        }
    }

}