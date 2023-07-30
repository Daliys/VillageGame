using UnityEngine;
using UnityEngine.AI;

namespace Villanger
{
    public class VillagerAnimation
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsTakingItem = Animator.StringToHash("IsTakingItem");
        private static readonly int IsSleeping = Animator.StringToHash("IsSleeping");
        private static readonly int IsPuttingItem = Animator.StringToHash("IsPuttingItem");

        private readonly Animator animator;
        private readonly NavMeshAgent agent;
        
        public VillagerAnimation (Animator animator, NavMeshAgent agent)
        {
            this.animator = animator;
            this.agent = agent;
        }
        
        // Update is called once per frame
        public void Update()
        {
            animator.SetBool(IsWalking, agent.velocity.magnitude > 0.1f);
        }
        
        public void SetTakingItemAnimation(bool isTakingItem)
        {
            animator.SetBool(IsTakingItem, isTakingItem);
        }
        
        public void SetSleepingAnimation(bool isSleeping)
        {
            animator.SetBool(IsSleeping, isSleeping);
        }
        
        public void SetPuttingItemAnimation(bool isPuttingItem)
        {
            animator.SetBool(IsPuttingItem, isPuttingItem);
        }

    }
}