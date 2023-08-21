using UnityEngine;
using UnityEngine.Serialization;

namespace ItemResources
{
    [CreateAssetMenu(fileName = "FoodItem", menuName = "Item/FoodItem")]
    public class FoodItem : Item
    {
         public float foodValue = 20;
    }
}