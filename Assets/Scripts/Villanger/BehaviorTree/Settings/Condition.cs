using System;

namespace Villanger.BehaviorTree.Settings
{
    [Serializable]
    public class Condition
    {
        [Serializable]
        public enum VillagerStats
        {
            Hunger,
            Health,
            Energy,
            Social
        }

        public VillagerStats stat;
        public bool invert;
        public float coefficient;


        public float GetValue(VillagerBehaviour villagerBehaviour)
        {

            switch (stat)
            {
                case VillagerStats.Hunger:
                    float hangerValue = villagerBehaviour.GetVillagerNeeds().GetFoodValue();
                    hangerValue = invert ? villagerBehaviour.GetVillagerNeeds().GetMaxValueOfNeeds() - hangerValue : hangerValue;
                    return hangerValue * coefficient;

                case VillagerStats.Energy:
                    float sleepValue = villagerBehaviour.GetVillagerNeeds().GetEnergyValue();
                    sleepValue = invert ? villagerBehaviour.GetVillagerNeeds().GetMaxValueOfNeeds() - sleepValue : sleepValue;
                    return sleepValue * coefficient;


            }

            return 0;
        }
    }
}