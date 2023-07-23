namespace Villanger.BehaviorTree.Tasks
{
    public abstract class BehaviorTask
    {
        protected bool isRunning = false;

        public virtual void Start() { isRunning = true; }
        public virtual void Update() { }
        public virtual void End() { isRunning = false; }
        
        public bool IsRunning() { return isRunning; }
    }
}