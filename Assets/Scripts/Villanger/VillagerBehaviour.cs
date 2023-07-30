using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UI;

namespace Villanger
{
    /// <summary>
    ///     Villager AI.
    ///
    ///
    ///
    ///     To be assigned to villagers.
    ///
    ///     TODO: a lot
    /// </summary>
    public class VillagerBehaviour : MonoBehaviour
    {
        [SerializeField] private VillagerNeedsSettings villagerNeedsSettings;
    
        [SerializeField] private UIController uiController;
        [SerializeField] private Animator animator;

        [SerializeField] private Transform target;
        [SerializeField] private NavMeshAgent agent;

        
        private bool isActive = true;
        private VillagerNeeds villagerNeeds;
        private VillagerInventory villagerInventory;

        private string name;
        private int age;
        
        public Gender gender = Gender.female;
        
     VillagerAnimation villagerAnimation;

        public enum Gender
        {
            female,
            male
        }

        private void Awake()
        {
            villagerNeeds = new VillagerNeeds( this, villagerNeedsSettings );
            villagerNeeds.Initialize();
            villagerInventory = new VillagerInventory(10);
            villagerAnimation = new VillagerAnimation (animator, agent);
        }

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            name = " Prove me wrong!";
            age = Random.Range(18, 50);

            // TODO:
            // make a detection of gender based on gameObject name or model
            // !!! now that i think about it, it is probably going to be name based detection
            // (for villagers created from the editor),
            // since gender is going to be assigned during villager procreation
            // to the fresh insantiated villager object.


        }

        private void Update()
        {
            villagerAnimation.Update();   
        }

        private void OnMouseDown()
        {
            uiController.ShowVillagerInformationPanel(this);
        }


        // ============================================== //
        // ====== VILLAGER PRIORITY-CALLED ACTIONS ====== //
        // ============================================== //

        /// <summary>
        /// This function is going to describe how the villager should behave and what
        /// they should do in order to get food for their group/village
        /// !!!!!! :construction: nothing here yet!!!!!!
        /// </summary>
        private void WorkOnGettingGroupFood()
        {

        }


        /// <summary>
        /// This function is going to describe how the villager should behave and what
        /// they should do in order to get shelter
        /// !!!!!! :construction: nothing here yet!!!!!!
        /// </summary>
        private void WorkOnGettingShelter ()
        {

        }


        /// <summary>
        /// This function is going to describe how the villager should behave and what
        /// they should do in order to get food for themselves
        /// !!!!!! :construction: nothing here yet!!!!!!
        /// </summary>
        private void WorkOnGettingPrivateFood()
        {

        }


        /// <summary>
        /// This function is going to describe how the villager should behave and what
        /// they should do in order to mate and procreate.
        /// !!!!!! :construction: nothing here yet!!!!!!
        /// </summary>
        private void WorkOnGettingMate()
        {

        }


        /// <summary>
        /// This function is going to describe how the villager should behave and what
        /// they should do in order to expllore the world and learn new technology for their village.
        /// !!!!!! :construction: nothing here yet!!!!!!
        /// </summary>
        private void WorkOnGettingExploration()
        {

        }

        public VillagerNeeds GetVillagerNeeds() => villagerNeeds;
        public VillagerInventory GetVillagerInventory() => villagerInventory;
         public VillagerAnimation GetVillagerAnimation() => villagerAnimation;
        public bool GetIsActive() => isActive;
        public string GetName() => name;
        public int GetAge() => age;

        public Gender GetGender() => gender;
        
        public NavMeshAgent GetAgent() => agent;
    }
}
