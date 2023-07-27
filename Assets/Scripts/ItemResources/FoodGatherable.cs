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
    }
}