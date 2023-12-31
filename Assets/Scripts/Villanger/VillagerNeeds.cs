using System.Collections;
using ItemResources;
using ScriptableObjects;
using UnityEngine;

namespace Villanger
{
    /// <summary>
    ///  This class is responsible for managing the needs of the villager.
    /// </summary>
    public class VillagerNeeds
    {
        private VillagerBehaviour villagerBehaviour;

        VillagerNeedsSettings villagerNeedsSettings;
        
        private const float maxValueOfNeeds = 100f;
        
        private float healthValue;
        private float foodValue;
        private float energyValue;
        private float moodValue;
        private float socialValue;
        
        public delegate void NeedsChanged(VillagerNeeds villagerNeeds);
        public event NeedsChanged OnNeedsChanged;
        
        public VillagerNeeds(VillagerBehaviour villagerBehaviour, VillagerNeedsSettings villagerNeedsSettings)
        {
            this.villagerBehaviour = villagerBehaviour;
            this.villagerNeedsSettings = villagerNeedsSettings;
            
            healthValue = 100f;
            foodValue = 100f;
            energyValue = 00f;
            moodValue = 100f;
            socialValue = 100f;
        }

        
        public void Initialize()
        {
            villagerBehaviour.StartCoroutine(UpdateNeeds());
        }
        
        IEnumerator UpdateNeeds()
        {
            while (villagerBehaviour.GetIsActive())
            {
                yield return new WaitForSeconds(0.3f);
                
                foodValue -= villagerNeedsSettings.foodDecreaseRate;
                energyValue -= villagerNeedsSettings.energyDecreaseRate;
                moodValue -= villagerNeedsSettings.moodDecreaseRate;
                socialValue -= villagerNeedsSettings.socialDecreaseRate;
                OnNeedsChanged?.Invoke(this);
            }
        }
        
        public void ConsumeFood(FoodItem foodItem, int amount)
        {
            foodValue += foodItem.foodValue * amount;
            Debug.Log("Food value:" + foodValue + "food that needs to be added: " + foodItem.foodValue);
            if (foodValue > maxValueOfNeeds)
            {
                foodValue = maxValueOfNeeds;
            }
            OnNeedsChanged?.Invoke(this);
        }
        
        public void RestoreEnergy (float amount)
        {
            energyValue += amount;
            if (energyValue > maxValueOfNeeds)
            {
                energyValue = maxValueOfNeeds;
            }
            OnNeedsChanged?.Invoke(this);
        }

        public float GetSleepTime()
        {
            //TODO : Change this to a better formula or settings
            return 10f;
        }
        
        public float GetHealthValue() => healthValue;
        public float GetFoodValue() => foodValue;
        public float GetEnergyValue() => energyValue;
        public float GetMoodValue() => moodValue;
        public float GetSocialValue() => socialValue;
        public float GetMaxValueOfNeeds() => maxValueOfNeeds;
        
        public float GetAmountOfFoodNeeded() => maxValueOfNeeds - foodValue;
    }
}