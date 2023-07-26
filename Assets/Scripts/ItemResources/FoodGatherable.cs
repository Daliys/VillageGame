using UnityEngine;

namespace ItemResources
{
    public class FoodGatherable : MonoBehaviour, IGatherable
    {
        [SerializeField] private FoodItem foodItem;
        
        
        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public float GetTimeToGather()
        {
            return 5f;
        }
        
        public FoodItem GetFoodItem()
        {
            return foodItem;
        }
        
        public int GetFoodAmount()
        {
            return 3;
        }

        /// <summary>
        /// To be reworked later to allow different foods to take up different inventory spaces.
        /// The amount of space a food item takes up.
        /// </summary>
        /// <returns>1</returns>
        public int GetFoodItemSpace()
        {
            return 1;
        }
    }
}